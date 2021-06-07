using KACDC.Class.DataProcessing.Aadhaar;
using KACDC.Class.DataProcessing.Nadakacheri;
using KACDC.Class.GetCountStatistics;
using KACDC.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace KACDC.TestForms
{
    public partial class TestForm1 : System.Web.UI.Page
    {
        NadakacheriProcess NKAR = new NadakacheriProcess();
        protected void Page_Load(object sender, EventArgs e)
        {
            MainTestNew();
            HostingEnvironment env;
            try
            {
                //Label2.Text = HttpContext.Current.Request.Url.Host;
                //Label2.Text = HttpContext.Current.Request.Url.AbsoluteUri;
                Label2.Text = HttpContext.Current.Request.IsLocal.ToString();
            }
            catch (Exception ex)
            {
                Label2.Text += "<br />" + ex.Message;
            }
            //if()
        }
        //public void test5()
        //{
        //    IEnumerable<CaseWorker> CW = null;
        //    HttpClient HC = new HttpClient();
        //    //HC.BaseAddress = new Uri("http://localhost:50369/api/CaseWorker?District=Bengaluru%20Dakshina&Status=SESELECTCW");
        //    HC.BaseAddress = new Uri("http://localhost:50369/api/CaseWorker");
        //    var ConsumeAPI = HC.GetAsync("CaseWorker");
        //    var request = new RestRequest(Method.GET);
        //    request.AddParameter("application/json",
        //        "{\"District\":\"" + "Bengaluru Dakshina" +
        //        "\",\"Status\":\"" + "SESELECTCW" +
        //        "\"}",
        //        RestSharp.ParameterType.RequestBody);
        //    ConsumeAPI.Wait();
        //    var readdata = ConsumeAPI.Result;


        //    HC.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    try
        //    {
        //        //if (response.IsSuccessStatusCode)
        //        //{
        //        //    // decide if request succeed or not.
        //        //}
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    lblStatuscode.Text = readdata.IsSuccessStatusCode.ToString();
        //}
        //public void MainTest()
        //{


        //    IEnumerable<CaseWorker> CW = null;
        //    HttpClient HC = new HttpClient();
        //    string district = "Bengaluru Dakshina";
        //    string method = "SESELECTCW";

        //    //var values = new List<KeyValuePair<string, string>>();
        //    //values.Add(new KeyValuePair<string, string>("id", param.Id.Value));
        //    //values.Add(new KeyValuePair<string, string>("type", param.Type.Value));
        //    //var content = new FormUrlEncodedContent(values);

        //    if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
        //    {
        //        HC.BaseAddress = new Uri("http://localhost:50369/api/");
        //    }
        //    else
        //    {
        //        HC.BaseAddress = new Uri("https://aryavysya.karnataka.gov.in/api/");
        //    }            //var ConsAPI = HC.GetAsync("CaseWorker");
        //    var ConsAPI = HC.GetAsync(string.Format("CaseWorker/Status="+method+"&District="+district));

        //    ConsAPI.Wait();
        //    var readData = ConsAPI.Result;
        //    if (readData.IsSuccessStatusCode)
        //    {
        //        lblStatuscode.Text = "OK <br />" + ConsAPI.Result.ToString();
        //    }
        //    else
        //    {
        //        lblStatuscode.Text = "Not OK <br />"+ ConsAPI.Result.ToString();

        //    }

        //    //IRestResponse response = client.Execute(request);
        //    //Console.WriteLine(response.Content);
        //    //string responseData = response.Content;
        //    //lblStatuscode.Text = response.StatusCode.ToString();
        //    //if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    //{
        //    //    var jObject = JObject.Parse(response.Content);
        //    //    //string token1 = jObject.GetValue("token").ToString();
        //    //    lblStatuscode.Text = jObject.GetValue("ApplicantName").ToString();


        //    //    //var dispREcord= response.Content.re
        //    //    //Response.Write("___response token is:" + token1);
        //    //}
        //}
        public void MainTestNew()
        {
            try
            {
                IEnumerable<CaseWorker> CW = null;
                HttpClient HC = new HttpClient();
                string district = "Bengaluru Dakshina";
                string method = "SESELECTCW";

                //var values = new List<KeyValuePair<string, string>>();
                //values.Add(new KeyValuePair<string, string>("id", param.Id.Value));
                //values.Add(new KeyValuePair<string, string>("type", param.Type.Value));
                //var content = new FormUrlEncodedContent(values);
                UriBuilder builder = new UriBuilder();
                //builder.Query = "Status='"+ method + "'&District='"+ district + "'";


                if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
                {
                    builder = new UriBuilder("http://localhost:50369/api/CaseWorker/");
                }
                else
                {
                    builder = new UriBuilder("https://aryavysya.karnataka.gov.in/api/CaseWorker/");
                }
                //var ConsAPI = HC.GetAsync("CaseWorker");
                builder.Query = "Status=" + method + "&District=" + district;
                var ConsAPI = HC.GetAsync(builder.Uri);

                ConsAPI.Wait();
                var readData = ConsAPI.Result;
                if (readData.IsSuccessStatusCode)
                {

                    var disprecord = readData.Content.ReadAsAsync<IList<CaseWorker>>();
                    disprecord.Wait();
                    CW = disprecord.Result;
                    lblStatuscode.Text = builder.Uri.ToString() + "<br />OK <br />" + ConsAPI.Result.ToString() + "<br />" + CW;
                    int qwe = CW.Cast<CaseWorker>().Count();
                    if (CW.Cast<CaseWorker>().Count() > 0)
                    {
                        GridView1.DataSource = CW;
                        GridView1.DataBind();
                    }
                    else
                    {
                        ////GridView GridView1 = (GridView)sender;
                        //GridViewRow NewTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //NewTotalRow.Font.Bold = true;
                        //NewTotalRow.BackColor = System.Drawing.Color.Aqua;
                        //TableCell HeaderCell = new TableCell();
                        //HeaderCell.Height = 10;
                        //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        //HeaderCell.ColumnSpan = 4;
                        //NewTotalRow.Cells.Add(HeaderCell);
                        //GridView1.Controls[0].Controls.AddAt(1, NewTotalRow);
                        ////rowIndex++;

                        ////iRow = Convert.ToInt32(GridView1.Rows.Count.ToString());
                        //DataRow dr;
                        //DataTable dtable = new DataTable();
                        ////for (int i = dtable.Rows.Count; i < 10; i++)
                        //for (int i = GridView1.Rows.Count; i < 1; i++)
                        //{
                        //    dr = dtable.NewRow();
                        //    dtable.Rows.Add(dr);
                        //}
                        //dtable.AcceptChanges();








                        //int columncount = GridView1.Rows[0].Cells.Count;
                        //GridView1.Rows[0].Cells.Clear();
                        //GridView1.Rows[0].Cells.Add(new TableCell());
                        //GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                        //GridView1.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
                else
                {
                    lblStatuscode.Text = "Not OK <br />" + ConsAPI.Result.ToString();

                }

                //IRestResponse response = client.Execute(request);
                //Console.WriteLine(response.Content);
                //string responseData = response.Content;
                //lblStatuscode.Text = response.StatusCode.ToString();
                //if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //    var jObject = JObject.Parse(response.Content);
                //    //string token1 = jObject.GetValue("token").ToString();
                //    lblStatuscode.Text = jObject.GetValue("ApplicantName").ToString();


                //    //var dispREcord= response.Content.re
                //    //Response.Write("___response token is:" + token1);
                //}
            }
            catch (Exception ex)
            {
                Label2.Text += "<br />" + ex.Message;
            }
        }
        public void AddNewRow(object sender, GridViewRowEventArgs e)
        {
            //GridView GridView1 = (GridView)sender;
            //GridViewRow NewTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
            //NewTotalRow.Font.Bold = true;
            //NewTotalRow.BackColor = System.Drawing.Color.Aqua;
            //TableCell HeaderCell = new TableCell();
            //HeaderCell.Height = 10;
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //HeaderCell.ColumnSpan = 4;
            //NewTotalRow.Cells.Add(HeaderCell);
            //GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);
            //rowIndex++;
        }
        //public async void Test4()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var postedData = "{ JSON Data for post }";
        //        client.BaseAddress = new Uri("http://localhost:50369/api/CaseWorker");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //        try
        //        {
        //            HttpResponseMessage response = await client.PostAsJsonAsync("api/values/", postedData);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                // decide if request succeed or not.
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //}
        //public void Test1()
        //{
        //    //using (var client = new HttpClient())
        //    //{
        //    //    var postedData = "{ JSON Data for post }";
        //    //    client.BaseAddress = new Uri("url");
        //    //    client.DefaultRequestHeaders.Accept.Clear();
        //    //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    //    try
        //    //    {
        //    //        HttpResponseMessage response = await client.PostAsJsonAsync("api/values/", postedData);
        //    //        if (response.IsSuccessStatusCode)
        //    //        {
        //    //            // decide if request succeed or not.
        //    //        }
        //    //    }
        //    //    catch (Exception ex)
        //    //    {

        //    //    }
        //    //}
        //}
        //public void Test2()
        //{

        //}
        //public void Test3()
        //{
        //    IEnumerable<CaseWorker> CW = null;
        //    HttpClient HC = new HttpClient();
        //    string district = "Bengaluru Dakshina";
        //    var client = new RestClient("http://localhost:50369/api/CaseWorker?District=" + district + "&Status=SESELECTCW");
        //    //var ConsumeAPI = HC.GetAsync("CaseWorker");
        //    var request = new RestRequest(Method.GET);
        //    //request.AddParameter("application/json",
        //    //    "{\"District\":\"" + "Bengaluru Dakshina" +
        //    //    "\",\"Status\":\"" + "SESELECTCW"
        //    //    + "\"}",
        //    //    RestSharp.ParameterType.GetOrPost);
        //    IRestResponse response = client.Execute(request);
        //    Console.WriteLine(response.Content);
        //    //Response.Write("___response Data" + response.Content);
        //    string responseData = response.Content;
        //    lblStatuscode.Text = response.StatusCode.ToString();
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        var jObject = JObject.Parse(response.Content);
        //        //string token1 = jObject.GetValue("token").ToString();
        //        lblStatuscode.Text = jObject.GetValue("ApplicantName").ToString();


        //        //var dispREcord= response.Content.re
        //        //Response.Write("___response token is:" + token1);
        //    }
        //}

        protected void btn1_Click(object sender, EventArgs e)
        {
            //lbl1.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss:fffffff tt");
            //lbl1.Text = CheckDirExist();
            string AppDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            DateTime newdate = Convert.ToDateTime(AppDate, System.Globalization.CultureInfo.InvariantCulture);
            lbl1.Text = newdate.ToString("dd MMMM yyyy hh:mm tt");
            DownloadFile();
        }
        public void DownloadFile()
        {
            string filePath = Server.MapPath("~/Files_SelfEmployment/App/") + "Test" + ".pdf";
            //This is used to get the current response.
            System.Web.HttpResponse res = GetHttpResponse();
            res.Clear();
            res.AppendHeader("content-disposition", "attachment; filename=" + filePath);
            res.ContentType = "application/octet-stream";
            res.WriteFile(filePath);
            res.Flush();
            res.End();
        }
        public static System.Web.HttpResponse GetHttpResponse()
        {
            return HttpContext.Current.Response;
        }
        public string CheckDirExist()
        {
            string path = Server.MapPath("~/Files_SelfEmployment/App/");
            // ... Set to folder path we must ensure exists.
            try
            {
                // ... If the directory doesn't exist, create it.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    return "Created";
                }
                else
                {
                    return "Exist";
                }
            }
            catch (Exception e)
            {
                return "Error : " + e.Message;
                // Fail silently.
            }
        }
        public void RazorPay()
        {
            try
            {
                lbl1.Text = NKAR.CheckRDNumberExist(txt1.Text.Trim());
                string json = (new WebClient()).DownloadString("https://ifsc.razorpay.com/" + txt1.Text.Trim());


                var details = JObject.Parse(json);
                lbl1.Text = details["RTGS"].ToString();
                //XmlDocument doc = JsonConvert.DeserializeXmlNode("<root>"+json+"</root>");
                //XmlDocument xmlApplicantDetails = JsonConvert.DeserializeXmlNode(json);
                //xmlApplicantDetails.LoadXml(xml);
                //lblIFSCData.Text = json;
                //lblIFSCData.Text= doc.InnerText;
            }
            catch { lbl1.Text = "Invalid"; }
        }
        protected void rbContactAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (rbContactAddressYes.Checked == true)
            {
                lbl2.Text = "yes";
            }
            else if (rbContactAddressNo.Checked == true)
            {
                lbl2.Text = "no";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            builderfunNew("Method", "ApplicationStatus", "ApplicationNumber", TextBox1.Text.Trim());
        }
        private void builderfun(string Method, string ApplicationStatus, string ApplicationNumber, string Reason)
        {

            UriBuilder builder = new UriBuilder("http://localhost:50369/api/CaseWorker");
            //builder.Query = "Status=" + method + "&District=" + district;
            builder.Query = "Main=" + Method;
            if (Reason == "")
            {
                builder.Query += "&Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber;
            }
            else
            {
                //builder.Query = "Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber + "&RejectReason=" + Reason;
                builder.Query += Reason == "11" ? "&District" + Reason : "";

            }
            builder.Query += "&Status=" + Method;
            Label1.Text = builder.ToString();
        }
        private void builderfunNew(string Method, string ApplicationStatus, string ApplicationNumber, string Reason)
        {
            UriBuilder builder = new UriBuilder();
            if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
            {
                builder = new UriBuilder("http://localhost:50369/api/ApplicationCount");
            }
            else
            {
                builder = new UriBuilder("https://aryavysya.karnataka.gov.in/api/ApplicationCount");
            }
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["111111"] = "1111111111";
            if (Reason == "")
            {
                query["aaaaaaaa"] = "aaaaaaaa";
            }
            query["22222222"] = "2222222222";
            if (Reason == "11")
            {
                //builder.Query = "Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber + "&RejectReason=" + Reason;
                //builder.Query += Reason == "11" ? "&District" + Reason : "";
                query["bbbbbbbb"] = "bbbbbbbbbbb";
            }
            if (Reason == "2") query["true"] = "true";
            query["33333333"] = "33333333333";
            builder.Query = query.ToString();
            Label1.Text = builder.ToString() + "<br />" + builder.Query.ToString();

            GetCount CwGetCount = new GetCount();
            AadhaarEnceyption AE = new AadhaarEnceyption();
            Label1.Text += "<br />" + CwGetCount.GetTotalCount("spGetApplicationCount", Reason);
            Label1.Text += "<br />" + AE.GetAadhaarToken("301007056373");
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            
            
        }
        private void ExportExcel(DataSet ds)
        {
            int inHeaderLength = 2, inColumn = 0, inRow = 0;
            System.Reflection.Missing Default = System.Reflection.Missing.Value;
            //Create Excel File
            //strPath += @"\Excel" + DateTime.Now.ToString().Replace(':', '-') + ".xlsx";
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);

            foreach (DataTable dtbl in ds.Tables)
            {
                //Create Excel WorkSheet
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add(Default, excelWorkBook.Sheets[excelWorkBook.Sheets.Count], 1, Default);
                excelWorkSheet.Name = dtbl.TableName;//Name worksheet

                //Write Column Name
                for (int i = 0; i < dtbl.Columns.Count; i++)
                    excelWorkSheet.Cells[inHeaderLength + 1, i + 1] = dtbl.Columns[i].ColumnName.ToUpper();
                //Write Rows
                int ma = dtbl.Rows.Count;
                int na = dtbl.Columns.Count + 2;
                for (int m = 0; m < dtbl.Rows.Count; m++)
                {
                    for (int n = 0; n < dtbl.Columns.Count; n++)
                    {
                        inColumn = n + 1;
                        inRow = inHeaderLength + 2 + m;
                        excelWorkSheet.Cells[inRow, inColumn] = dtbl.Rows[m].ItemArray[n].ToString();
                        if (m % 2 == 0)
                            excelWorkSheet.get_Range("A" + inRow.ToString(), "E" + inRow.ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FCE4D6");

                        na = n;
                    }
                }
                //Excel Header
                Excel.Range cellRang = excelWorkSheet.get_Range("A1", "E2");
                cellRang.Merge(false);
                cellRang.Interior.Color = System.Drawing.Color.White;
                cellRang.Font.Color = System.Drawing.Color.Gray;
                cellRang.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                cellRang.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                cellRang.Font.Size = 14;
                excelWorkSheet.Cells[1, 1] = "Sales Report of " + DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
                //excelWorkSheet.Cells[60, 5] = "=SUM(E4,E59)";
                //excelWorkSheet.Cells[dtbl.Rows.Count + 2, dtbl.Columns.Count].Formula = a;

                //Style table column names
                cellRang = excelWorkSheet.get_Range("A3", "E3");
                cellRang.Font.Bold = true;
                cellRang.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                cellRang.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#ED7D31");
                excelWorkSheet.get_Range("E4").EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                //Formate price column
                //excelWorkSheet.get_Range("F5").EntireColumn.NumberFormat = "0.00";
                //Auto fit columns
                excelWorkSheet.Columns.AutoFit();
            }
        }
    }
}