using KACDC.Class.DataProcessing.Nadakacheri;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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