using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.Class.DataProcessing.Aadhaar;
using KACDC.Class.DataProcessing.ApplicationProcess;
using KACDC.Class.DataProcessing.BankData;
using KACDC.Class.DataProcessing.EmailService;
using KACDC.Class.DataProcessing.FileProcessing;
using KACDC.Class.DataProcessing.FileProcessing.CreatePDF.ApplicationProcess;
using KACDC.Class.DataProcessing.FileProcessing.CreatePDF.PDFModuleProcess.ZMBankPDF;
using KACDC.Class.DataProcessing.Nadakacheri;
using KACDC.Class.DataProcessing.OnlineApplication;
using KACDC.Class.Declaration.Aadhaar;
using KACDC.Class.Declaration.BankDetails;
using KACDC.Class.Declaration.Nadakacheri;
using KACDC.Class.Declaration.OnlineApplication;
using KACDC.Class.FileSaving;
using KACDC.Class.GetCountStatistics;
using KACDC.CreateTextSharpPDF.Process;
using KACDC.CreateTextSharpPDF.Schemes.SelfEmployment;
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
using System.Text.RegularExpressions;
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
        AadhaarService ADAR = new AadhaarService();
        AadhaarServiceData ADSER = new AadhaarServiceData();
        NadaKacheri NDAR = new NadaKacheri();
        OtherDataSelfEmployment ODSE = new OtherDataSelfEmployment();
        NadaKacheri NKSER = new NadaKacheri();
        GetBankDetailsIFSC GETBD = new GetBankDetailsIFSC();
        DecBankDetails BD = new DecBankDetails();
        ApplicantPDFTable APPLITAB = new ApplicantPDFTable();
        BankTable BT = new BankTable();
        AgreementTable AT = new AgreementTable();
        SignatureTable ST = new SignatureTable();
        HeadingTable HT = new HeadingTable();
        VerifyEmailID VEID = new VerifyEmailID();
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
            ExcelFileOperations FO = new ExcelFileOperations();
            GetDataToProcess GDTP = new GetDataToProcess();

            DataTable employees = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add((GDTP.GetData("spGetDataToApprovalProcess","SESELECTCW", "Bengaluru Dakshina","asdf")));
            ds.Tables.Add(GDTP.GetData("spGetDataToApprovalProcess","SESELECTCW", "Bengaluru Dakshina"));
//D:\Project\KACDCProject\KACDC\KACDC\DownloadFiles\
            FO.ExportToExcel(ds, Server.MapPath("~/DownloadFiles/") +"ABC.xlsx","", "Bengaluru Dakshina");

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
        protected void btnExportPDFZMApproved_Click(object sender, EventArgs e)
        {
            ExcelFileOperations FO = new ExcelFileOperations();
            GetDataToProcess GDTP = new GetDataToProcess();

            DataTable employees = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add((GDTP.GetData("spGetDataToApprovalProcess","SESELECTCW", "Bengaluru Dakshina", "asdf")));
            //ds.Tables.Add(GDTP.GetData("spGetDataToApprovalProcess","SESELECTCW", "Bengaluru Dakshina"));
            //D:\Project\KACDCProject\KACDC\KACDC\DownloadFiles\
            ExportToPDF(ds);
        }
        private void ExportToPDF(DataSet ds)
        {
            BankTable BT = new BankTable();
            PDFFileOperation PDFop = new PDFFileOperation();
            GetDataToProcess GDTP = new GetDataToProcess();

            //PdfPTable Table = null;
            //Table = new PdfPTable(4);
            Document pdfDoc = new Document(PageSize.A4, 0, 0, 35, 0);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                //pdfDoc.Add(Table);
                //PdfPTable BankTable = null;
                //BankTable = new PdfPTable(4);

                string FinancialYear = "2020";
                string District = "Bangalore";
                string Zone = "BLR";

                string FilePath = Server.MapPath("~/ApplicationProcessFiles/" + FinancialYear + "/ZM/") + "SE" + Zone + District + "_" + FinancialYear + DateTime.Now + ".pdf";
                //BankTable = PDFop.ExportToPDF( ds,  FilePath,  District);
                //pdfDoc.Add(BankTable);







                int Center = PdfPCell.ALIGN_CENTER;
                int VCenter = PdfPCell.ALIGN_MIDDLE;
                int Left = PdfPCell.ALIGN_LEFT;
                PDFCellPrint PCell = new PDFCellPrint();
                PdfPCell EmptyCell = new PdfPCell();
                EmptyCell = PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter);
                PDFParagraph PDFP = new PDFParagraph();

                string BankName = "SBI";
                string BankBranch = "SBI branch";
                string city = "Bangalore";
                string AccountNumber = "1111111";
                pdfDoc.Add(PDFP.SingleLineParagraph("\n\n\n\n\n\n\n", "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, Left, VCenter));
                pdfDoc.Add(PDFP.SingleLineParagraph("Date: "+DateTime.Now.ToString("dd MMMM yyyy"), "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, PdfPCell.ALIGN_RIGHT, VCenter));
                pdfDoc.Add(PDFP.ToAddressBlock(BankName, BankBranch, city, "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, Left, VCenter));
                pdfDoc.Add(PDFP.SingleLineParagraph("\n", "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, Left, VCenter));
                pdfDoc.Add(PDFP.SingleLineParagraph("Sir/Madam,", "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, Left, VCenter));
                pdfDoc.Add(PDFP.SingleLineParagraph("\n", "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, Left, VCenter));
                pdfDoc.Add(PDFP.SingleLineParagraph("Sub :- Transfer of amount to the beneficiaries", "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, PdfPCell.ALIGN_CENTER, VCenter));
                pdfDoc.Add(PDFP.SingleLineParagraph(" SB Accounts through RTGF/NEFT-reg", "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, PdfPCell.ALIGN_CENTER, VCenter));
                pdfDoc.Add(PDFP.SingleLineParagraph("***************", "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, PdfPCell.ALIGN_CENTER, VCenter));
                pdfDoc.Add(PDFP.SingleLineParagraph("\n", "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, Left, VCenter));
                pdfDoc.Add(PDFP.MainBlock(BankName, BankBranch, "1", AccountNumber, "Arial", 16, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, Left, VCenter));
                pdfDoc.Add(PDFP.SingleLineParagraph("     Thank You,", "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, PdfPCell.ALIGN_LEFT, VCenter));
                pdfDoc.Add(PDFP.SingleLineParagraph("Your Faithfully     " , "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, PdfPCell.ALIGN_RIGHT, VCenter));



                pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                pdfDoc.SetMargins( 0, 0, 10, 0);
                pdfDoc.NewPage();
                
                ReportTableHeading HT = new ReportTableHeading();
                PdfPTable HeadingTable = null;
                HeadingTable = new PdfPTable(4);
                //pdfDoc.Add(PDFP.SingleLineParagraph("***************", "Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, PdfPCell.ALIGN_CENTER, VCenter));
                HeadingTable = HT.GenerateHeading(HeadingTable, "Self Employment Loan", FinancialYear,District,Zone);
                pdfDoc.Add(HeadingTable);
                pdfDoc.Add(PDFop.ZMBankTable(GDTP.GetData("spPrintExcel", "SEZMAPPROVEDPRINT", "Bengaluru Dakshina", "Approved List"),"3523"));//print 


                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();

                SaveFile SV = new SaveFile();
                //Arivu_Kalaburgi_Bidar_2020-21_30-03-2021
                SV.SavingFileOnServer(Server.MapPath("~/ApplicationProcessFiles/" + FinancialYear + "/ZM/"), "SE" + Zone + District + "_" + FinancialYear + string.Format("{0:dd-MM-yyyy}", DateTime.Now) + ".pdf", bytes);
                if (File.Exists(FilePath))
                {
                    //SendSMSEmail();
                }
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "ZM" + "_" + "ZM" + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }

        protected void btnVerifyRDNumber_Click(object sender, EventArgs e)
        {
            
            if (txtRDNumber.Text.Trim().Length == 15)
            {
                if (txtRDNumber.Text.Trim().ToUpper().Substring(0, 2) == "RD")
                {
                    if (Regex.IsMatch(txtRDNumber.Text.Trim().Substring(2, 13), @"^\d+$"))
                    {
                        string IsRDExist = NKAR.CheckRDNumberExist(txtRDNumber.Text.Trim());
                        if (IsRDExist == "NA")
                        {
                            if (NKAR.GetCasteAndIncomeCertificate(txtRDNumber.Text.Trim()))
                            {
                                if (Int32.Parse(NKSER.NCStatusCode) == 1)
                                {
                                    if (Int32.Parse(NKSER.NCFacilityCode) == 42)
                                    {
                                        if (Int32.Parse(NKSER.NCAnnualIncome) < 300000)
                                        {
                                            if (Convert.ToDateTime(NKSER.NCDateOfIssue) > Convert.ToDateTime("24/12/2019"))
                                            {
                                                if (NDAR.NCGender == "MALE")
                                                {
                                                    ODSE.Widow = "NA";
                                                    ODSE.Divorced = "NA";
                                                }
                                                else
                                                {
                                                }
                                                lbl2.Text = NKSER.NCError;
                                                NKAR.UpdateDistrict();
                                                lblNCGSCNumber.Text = NKSER.NCGSCNumber;
                                                lblNCAnnualIncome.Text = NKSER.NCAnnualIncome;
                                                //NKSER.NCDateOfIssue;
                                                lblNCApplicantName.Text = NKSER.NCApplicantName;
                                                lblNCApplicantFatherName.Text = NKSER.NCApplicantFatherName;
                                                lblNCDistrict.Text = NKSER.NCDistrictName;
                                                lblNCTaluk.Text = NKSER.NCTalukName;
                                                lblNCFullAddress.Text = NKSER.NCFullAddress;

                                                //CasteCertificatePopup.Show();
                                            }
                                            else
                                            {
                                                DisplayAlert("new Caste and Income certificate must be taken, which is issued after 24/12/2019", this);
                                            }
                                        }
                                        else
                                        {
                                            DisplayAlert("Income must be less then 1,00,000", this);
                                        }
                                    }
                                    else
                                    {
                                        DisplayAlert("Only Arya vysya Community is eligible", this);
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Invalid RD Number", this);
                                }

                            }
                            else
                            {
                                DisplayAlert("Invalid RD Number", this);
                            }
                        }
                        else
                        {
                            DisplayAlert("You have already avail the loan in " + IsRDExist + " financial year", this);
                        }
                    }
                    else
                    {
                        DisplayAlert("Invalid RD Number", this);
                    }
                }
                else
                {
                    DisplayAlert("Invalid RD Number", this);
                }
            }
            else
            {
                DisplayAlert("Invalid RD Number", this);
            }
        }

        protected void btnAadhaarGetOTP_Click(object sender, EventArgs e)
        {
            if (txtAadhaarNumber.Text.Trim().Length == 12)
            {
                if (Regex.IsMatch(txtAadhaarNumber.Text.Trim(), @"^\d+$"))
                {
                    ADSER.AadhaarNumber = txtAadhaarNumber.Text.Trim();
                    if (ADAR.SendOTP(txtAadhaarNumber.Text.Trim()))
                    {
                        DisplayAlert("otp sent to registered mobile number", this);
                        divMobileOTP.Visible = true;
                    }
                    else
                    {
                        AadhaarError AE = new AadhaarError();
                        DisplayAlert(AE.GetAadhaarErrorMessage(ADSER.SendOTPErrorCode), this);
                    }
                }
                else
                {
                    DisplayAlert("Invalid Aadhaar Number", this);
                }
            }
            else
            {
                DisplayAlert("Invalid Aadhaar Number", this);
            }
        }
        protected void btnVerifyAadhaarOTP_Click(object sender, EventArgs e)
        {
            ADSER.AadhaarApplicantOTP = txtOTP.Text.Trim();
            string ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
            { ipaddress = Request.ServerVariables["REMOTE_ADDR"]; }
            string errorLogFilename = "ErrorLog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

            if (ADAR.VerifyAadhaarOTP(ipaddress, Path.GetFileName(Request.Path), Server.MapPath("~/LogFiles/AadhaarErrorLog/" + errorLogFilename)))
            {
                lblAadhaarPopupDOB.Text = ADSER.DOB;
                lblAadhaarPopupGender.Text = ADSER.Gender;
                lblAadhaarPopupName.Text = ADSER.Name;

                lblAadhaarPopupState.Text = ADSER.State;

                ImgAadhaarPopupPhoto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ADSER.Photo, 0, (ADSER.Photo).Length);
                lblAadhaarPopupPincode.Text = ADSER.Pincode;

                lblAadhaarPopupDistrict.Text = ADSER.District;
                //AadhaarPopup.Show();
            }
            else
            {
                lblAadhaarPopupName.Text = ADSER.OTPErrorMessage;
                lblAadhaarPopupState.Text = ADSER.OTPErrorCode;
                AadhaarError AE = new AadhaarError();
                DisplayAlert(AE.GetAadhaarErrorMessage(ADSER.OTPErrorCode), this);
            }
        }
        public static void DisplayAlert(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            //page.ClientScript.RegisterStartupScript(owner.GetType(),"ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    message));
            ScriptManager.RegisterClientScriptBlock(owner, owner.GetType(), "alertMessage", "alert('" + message.ToUpper() + "')", true);
        }
        protected void btnsepdfgeneratetest_click(object sender, EventArgs e)
        {
            GenerateApplicantPDF();
        }
        private bool GenerateApplicantPDF()
        {
            string ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            try
            {
                ODSE.GeneratedApplicationNumber = "TestApp"; ADSER.Name = "MyName";
                NKSER.NCLanguage = "2";
                string SelfEnglish = "I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Self Employment Loan. If any discrepancies are found later, I agree to take legal action against me.";
                string SelfKannada = "\n ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು  ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು  ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣೀಕರಿಸುತ್ತೇನೆ.  ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ  ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು \n ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿಯ ಕ್ರಮ ಜರುಗಿಸಲು ಒಪ್ಪಿರುತ್ತೇನೆ.";
                string AadhaarEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
                string AadhaarKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";
                string ShareEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
                string ShareKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";

                PdfPTable HeadingTable = null;
                HeadingTable = new PdfPTable(4);
                HeadingTable = HT.GenerateHeading(HeadingTable, "Self Employment Loan", (Convert.ToDateTime(DateTime.Now.ToString())).ToString("MM/dd/yyyy hh:mm:sss tt"));
                PdfPTable Table = null;
                Table = new PdfPTable(4);
                Table = APPLITAB.SEApplicantMainTable(Table, "GeneratedApplicationNumber", "Name", "NCApplicantFatherName","Gender", "Widow", "ODSE.Divorced", "ODSE.PersonWithDisabilities", "NDAR.NCAnnualIncome"," NDAR.NCGSCNumber"," ODSE.EmailID"," ODSE.MobileNumber"," ODSE.AlternateMobileNumber",
            "ADSER.DOB", "ODSE.PurposeOfLoan", "ADSER.AadhaarVaultToken:", "", "ODSE.ContactFullAddress", "ODSE.ContactDistrictName", "ODSE.ContactPinCode", "NDAR.NCFullAddress", "NDAR.NCDistrictName", "NKSER.NCConstituency", "NDAR.NCApplicantCAddressPin",
             (Convert.ToDateTime(DateTime.Now.ToString())).ToString("MM/dd/yyyy hh:mm:sss tt"), (Convert.ToDateTime(DateTime.Now.ToString())).ToString("MM/dd/yyyy hh:mm:sss tt"), "NDAR.NCTalukName", "ODSE.ContactTalukName", "ODSE.LoanDESCRIPTION", "NDAR.NCApplicantName", NKSER.NCLanguage);
                PdfPTable BankTable = null;
                BankTable = new PdfPTable(4);
                BankTable = BT.GenerateBankTable(BankTable, "ADSER.Name", "BD.AccountNumber", "BD.BANK", "BD.BRANCH", "BD.IFSC", "BD.ADDRESS");
                PdfPTable AgreeTable = null;
                AgreeTable = new PdfPTable(4);
                AgreeTable = AT.GenerateAgreementTable(AgreeTable, "SelfEnglish", "SelfKannada", "AadhaarEnglish", "AadhaarKannada"," ShareEnglish", "ShareKannada");
                PdfPTable SignatureTable = null;
                SignatureTable = new PdfPTable(4);
                SignatureTable = ST.GenerateSignatureTable(SignatureTable);

                Document pdfDoc = new Document(PageSize.A4, 0, 0, 35, 0);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    pdfDoc.Open();
                    pdfDoc.Add(HeadingTable);
                    pdfDoc.Add(Table);
                    pdfDoc.Add(BankTable);
                    pdfDoc.Add(AgreeTable);
                    pdfDoc.Add(SignatureTable);

                    pdfDoc.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    //Response.Clear();

                    SaveFile SV = new SaveFile();
                    SV.SavingFileOnServer(Server.MapPath("~/Files_SelfEmployment/Application/" + "2020" + "/"), ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf", bytes);
                    if (File.Exists(Server.MapPath("~/Files_SelfEmployment/Application/" + "2020" + "/") + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf"))
                    {
                        SendSMSEmail();
                    }
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Response.Write("File Creation: " + ex.ToString()+ "<br / ><br / ><br / >"+ex.Message+"<br / ><br / ><br / ><br / >");
                return false;
            }
        }
        private bool SendSMSEmail()
        {
            try
            {
                ODSE.GeneratedApplicationNumber = "TestApp"; ADSER.Name = "MyName";

                SubmitApplicationSMS SMS = new SubmitApplicationSMS();
                ApplicationSubmitEmail EMAIL = new ApplicationSubmitEmail();
                SMS.ApplicantSMSConfirmation("9740560748", ODSE.GeneratedApplicationNumber, "Self Employment", ADSER.Name);
                EMAIL.ApplicantEmailConfirmation("balaji.duk@gmail.com", ODSE.GeneratedApplicationNumber, "Self Employment", ADSER.Name,
                    File.ReadAllBytes(Server.MapPath("~/Files_SelfEmployment/Application/" + "2020" + "/") + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf"),
                    ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf");
                return true;
            }
            catch (Exception ex)
            {
                Response.Write("Send mail: " + ex.ToString());
                return false;
            }
        }
    }
}