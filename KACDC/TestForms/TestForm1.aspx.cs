using KACDC.Class.DataProcessing.Nadakacheri;
using KACDC.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.TestForms
{
    public partial class TestForm1 : System.Web.UI.Page
    {
        NadakacheriProcess NKAR = new NadakacheriProcess();
        protected void Page_Load(object sender, EventArgs e)
        {
            MainTestNew();
            HostingEnvironment env;
            
            Label2.Text= HttpContext.Current.Request.Url.Host;

            //if()
        }
        public void test5()
        {
            IEnumerable<CaseWorker> CW = null;
            HttpClient HC = new HttpClient();
            //HC.BaseAddress = new Uri("http://localhost:50369/api/CaseWorker?District=Bengaluru%20Dakshina&Status=SESELECTCW");
            HC.BaseAddress = new Uri("http://localhost:50369/api/CaseWorker");
            var ConsumeAPI = HC.GetAsync("CaseWorker");
            var request = new RestRequest(Method.GET);
            request.AddParameter("application/json",
                "{\"District\":\"" + "Bengaluru Dakshina" +
                "\",\"Status\":\"" + "SESELECTCW" +
                "\"}",
                RestSharp.ParameterType.RequestBody);
            ConsumeAPI.Wait();
            var readdata = ConsumeAPI.Result;


            HC.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                //if (response.IsSuccessStatusCode)
                //{
                //    // decide if request succeed or not.
                //}
            }
            catch (Exception ex)
            {

            }
            lblStatuscode.Text = readdata.IsSuccessStatusCode.ToString();
        }
        public void MainTest()
        {


            IEnumerable<CaseWorker> CW = null;
            HttpClient HC = new HttpClient();
            string district = "Bengaluru Dakshina";
            string method = "SESELECTCW";

            //var values = new List<KeyValuePair<string, string>>();
            //values.Add(new KeyValuePair<string, string>("id", param.Id.Value));
            //values.Add(new KeyValuePair<string, string>("type", param.Type.Value));
            //var content = new FormUrlEncodedContent(values);

            if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
            {
                HC.BaseAddress = new Uri("http://localhost:50369/api/");
            }
            else
            {
                HC.BaseAddress = new Uri("https://aryavysya.karnataka.gov.in/api/");
            }            //var ConsAPI = HC.GetAsync("CaseWorker");
            var ConsAPI = HC.GetAsync(string.Format("CaseWorker/Status="+method+"&District="+district));
            
            ConsAPI.Wait();
            var readData = ConsAPI.Result;
            if (readData.IsSuccessStatusCode)
            {
                lblStatuscode.Text = "OK <br />" + ConsAPI.Result.ToString();
            }
            else
            {
                lblStatuscode.Text = "Not OK <br />"+ ConsAPI.Result.ToString();

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
        public void MainTestNew()
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
            builder.Query = "Status="+ method + "&District="+ district ;

            if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
            {
                HC.BaseAddress = new Uri("http://localhost:50369/api/");
            }
            else
            {
                HC.BaseAddress = new Uri("https://aryavysya.karnataka.gov.in/api/");
            }
            //var ConsAPI = HC.GetAsync("CaseWorker");
            var ConsAPI = HC.GetAsync(builder.Uri);
            
            ConsAPI.Wait();
            var readData = ConsAPI.Result;
            if (readData.IsSuccessStatusCode)
            {
                lblStatuscode.Text = "OK <br />" + ConsAPI.Result.ToString();
                var disprecord = readData.Content.ReadAsAsync<IList<CaseWorker>>();
                disprecord.Wait();
                CW = disprecord.Result;
                GridView1.DataSource = CW;
                GridView1.DataBind();
            }
            else
            {
                lblStatuscode.Text = "Not OK <br />"+ ConsAPI.Result.ToString();

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
        public async void Test4()
        {
            using (var client = new HttpClient())
            {
                var postedData = "{ JSON Data for post }";
                client.BaseAddress = new Uri("http://localhost:50369/api/CaseWorker");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/values/", postedData);
                    if (response.IsSuccessStatusCode)
                    {
                        // decide if request succeed or not.
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        public void Test1()
        {
            //using (var client = new HttpClient())
            //{
            //    var postedData = "{ JSON Data for post }";
            //    client.BaseAddress = new Uri("url");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    try
            //    {
            //        HttpResponseMessage response = await client.PostAsJsonAsync("api/values/", postedData);
            //        if (response.IsSuccessStatusCode)
            //        {
            //            // decide if request succeed or not.
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}
        }
        public void Test2()
        {

        }
        public void Test3()
        {
            IEnumerable<CaseWorker> CW = null;
            HttpClient HC = new HttpClient();
            string district = "Bengaluru Dakshina";
            var client = new RestClient("http://localhost:50369/api/CaseWorker?District=" + district + "&Status=SESELECTCW");
            //var ConsumeAPI = HC.GetAsync("CaseWorker");
            var request = new RestRequest(Method.GET);
            //request.AddParameter("application/json",
            //    "{\"District\":\"" + "Bengaluru Dakshina" +
            //    "\",\"Status\":\"" + "SESELECTCW"
            //    + "\"}",
            //    RestSharp.ParameterType.GetOrPost);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            //Response.Write("___response Data" + response.Content);
            string responseData = response.Content;
            lblStatuscode.Text = response.StatusCode.ToString();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jObject = JObject.Parse(response.Content);
                //string token1 = jObject.GetValue("token").ToString();
                lblStatuscode.Text = jObject.GetValue("ApplicantName").ToString();


                //var dispREcord= response.Content.re
                //Response.Write("___response token is:" + token1);
            }
        }

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
                return "Error : "+e.Message;
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
            builderfun("Method", "ApplicationStatus", "ApplicationNumber", TextBox1.Text.Trim());
        }
        private void builderfun(string Method, string ApplicationStatus, string ApplicationNumber, string Reason)
        {

            UriBuilder builder = new UriBuilder("http://localhost:50369/api/CaseWorker");
            //builder.Query = "Status=" + method + "&District=" + district;

            if (Reason == "")
            {
                builder.Query = "Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber;
            }
            else
            {
                builder.Query = "Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber + "&RejectReason=" + Reason;
            }
            Label1.Text = builder.Query.ToString();
        }
    }
}