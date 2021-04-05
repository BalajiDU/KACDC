using KACDC.Class.DataProcessing.Nadakacheri;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.TestForms
{
    public partial class TestForm1 : System.Web.UI.Page
    {
        NadakacheriProcess NKAR = new NadakacheriProcess();
        protected void Page_Load(object sender, EventArgs e)
        {

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
            HttpResponse res = GetHttpResponse();
            res.Clear();
            res.AppendHeader("content-disposition", "attachment; filename=" + filePath);
            res.ContentType = "application/octet-stream";
            res.WriteFile(filePath);
            res.Flush();
            res.End();
        }
        public static HttpResponse GetHttpResponse()
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
    }
}