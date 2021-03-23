using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.Class;
using KACDC.NadaKacheriServiceReference;
using Newtonsoft.Json.Linq;
using System.Drawing.Text;
using System.Data.SqlClient;
using System.Data;
using iTextSharp.text.html.simpleparser;
using System.Net.Mail;

using krdh.connector;
using krdh.parameters;
using KRDHConnector;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace KACDC
{
    public partial class CheckRD : System.Web.UI.Page
    {
        NadaKacheri_SelfEmployment NCSE = new NadaKacheri_SelfEmployment();
        BankDetails_SelfEmployment BD = new BankDetails_SelfEmployment();
        OtherData_SelfEmployment ODSE = new OtherData_SelfEmployment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "CHECKRD")
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnVerifyRDNumber_Click(object sender, EventArgs e)
        {
            NCSE.NCAnnualIncome = "";
            NCSE.NCApplicantName = "";
            NCSE.NCApplicantFatherName = "";
            NCSE.NCApplicantCAddress1 = "";
            NCSE.NCApplicantCAddress2 = "";
            NCSE.NCApplicantCAddress3 = "";
            NCSE.NCGSCNumber = "";
            NCSE.NCTalukName = "";
            NCSE.NCDistrictName = "";


            lblNCAnnualIncome.Text = "";
            lblNCApplicantName.Text = "";
            lblNCApplicantFatherName.Text = "";
            lblNCFullAddress.Text = "";
            lblNCGSCNumber.Text = "";
            lblNCTaluk.Text = "";
            lblNCDistrict.Text = "";


            GetCasteAndIncomeCertificate(txtRDNumber.Text.Trim());

            if (Int32.Parse(NCSE.NCStatusCode) == 1)
            {
                if (Int32.Parse(NCSE.NCFacilityCode) == 42)
                {
                    if (Int32.Parse(NCSE.NCAnnualIncome) < 300000)
                    {
                        if (Convert.ToDateTime(NCSE.NCDateOfIssue) > Convert.ToDateTime("24/12/2019"))
                        {
                            //txtRDNumber.Enabled = false;
                            lblNCAnnualIncome.Text = NCSE.NCAnnualIncome;
                            lblNCApplicantName.Text = NCSE.NCApplicantName;
                            lblNCApplicantFatherName.Text = NCSE.NCApplicantFatherName;
                            lblNCFullAddress.Text = NCSE.NCApplicantCAddress1 + ", " + NCSE.NCApplicantCAddress2 + ", " + NCSE.NCApplicantCAddress3;
                            lblNCGSCNumber.Text = NCSE.NCGSCNumber;
                            lblNCTaluk.Text = NCSE.NCTalukName;
                            lblNCDistrict.Text = NCSE.NCDistrictName;
                            lblEligibility.Text = "Eligible";
                            lblEligibility.Style.Add("color", "GREEN");
                        }
                        else
                        {
                            divRDNumChkError.InnerText = "Old Certificate : " + NCSE.NCDateOfIssue;
                            lblEligibility.Text = "NOT Eligible : " + NCSE.NCDateOfIssue;
                            lblEligibility.Style.Add("color", "RED");
                        }
                    }
                    else
                    {
                        divRDNumChkError.InnerText = "Income Must be less than 300000";
                        lblEligibility.Text = "NOT Eligible";
                        lblEligibility.Style.Add("color", "RED");
                    }
                }
                else
                {
                    divRDNumChkError.InnerText = "RD Number not belongs to Arya Vysya";
                    lblEligibility.Text = "Must be Arya Vysya";
                    lblEligibility.Style.Add("color", "RED");
                }
            }
            else
            {
                if (NCSE.NCStatusCode == "0")
                    //lblEligibility.Text = "NOT Eligible";
                    divRDNumChkError.InnerText = "Invalid RD Number";

                lblEligibility.Style.Add("color", "RED");
            }

        }

        private void GetCasteAndIncomeCertificate(string RDNumber)
        {
            XElement xElement=null;
            try
            {
               
                XmlDocument xmlDocument = new XmlDocument();
                XmlDocument xmlApplicantDetails = new XmlDocument();
                WebServiceSoapClient NCWebService = new WebServiceSoapClient("WebServiceSoap");
                xElement = NCWebService.GetXmlDataWoDSCV(RDNumber);
                //xElement = NCWebService.GetXmlDataWoDSCV("RD0038750142124");
                xmlDocument.LoadXml(xElement.ToString());
                if (true)
                {
                    NCSE.NCStatusCode = xElement.Element("Status").Value.ToString();
                    NCSE.NCStatusMsg = xElement.Element("StatusMsg").Value.ToString();
                    NCSE.NCFacilityCode = xElement.Element("FacilityCode").Value.ToString();
                    NCSE.NCFacilityName = xElement.Element("FacilityName").Value.ToString();
                    NCSE.NCLanguage = xElement.Element("Language").Value.ToString();

                    string xml = HttpUtility.HtmlDecode(xElement.Element("xmlData").ToString()).Replace("\r", "").Replace("\n", "").Replace("{Text = \"", "").Replace("\"", "")
                .Replace("{", "").Replace("}", "").Replace("\"", "");
                    xmlApplicantDetails.LoadXml(xml);

                    XmlNodeList nodeList = xmlApplicantDetails.GetElementsByTagName("ApplicantDetails");
                    foreach (XmlNode nodeRes in nodeList)
                    {
                        NCSE.NCGSCNumber = nodeRes["GSCNo"].InnerText;
                        NCSE.NCAnnualIncome = nodeRes["AnnualIncome"].InnerText;
                        NCSE.NCDateOfIssue = nodeRes["DateOfIssue"].InnerText;
                        NCSE.NCApplicantName = nodeRes["ApplicantName"].InnerText;
                        NCSE.NCApplicantFatherName = nodeRes["ApplicantFatherName"].InnerText;
                        NCSE.NCDistrictName = nodeRes["DistrictName"].InnerText;
                        NCSE.NCTalukName = nodeRes["TalukName"].InnerText;
                        if (nodeRes["ApplicantCAddressPin"] != null) { NCSE.NCApplicantCAddressPin = nodeRes["ApplicantCAddressPin"].InnerText; } else { NCSE.NCApplicantCAddressPin = ""; }
                        if (nodeRes["ApplicantCAddress1"] != null) { NCSE.NCApplicantCAddress1 = nodeRes["ApplicantCAddress1"].InnerText; } else { NCSE.NCApplicantCAddress1 = ""; }
                        if (nodeRes["ApplicantCAddress2"] != null) { NCSE.NCApplicantCAddress2 = nodeRes["ApplicantCAddress2"].InnerText; } else { NCSE.NCApplicantCAddress2 = ""; }
                        if (nodeRes["ApplicantCAddress3"] != null) { NCSE.NCApplicantCAddress3 = nodeRes["ApplicantCAddress3"].InnerText; } else { NCSE.NCApplicantCAddress2 = ""; }
                        NCSE.NCFullAddress = NCSE.NCApplicantCAddress1 + ", " + NCSE.NCApplicantCAddress2 + ", " + NCSE.NCApplicantCAddress3 + ", " + NCSE.NCTalukName + ", " + NCSE.NCDistrictName;
                        if (nodeRes["App_Title"].InnerText == "ಶ್ರೀ." || nodeRes["App_Title"].InnerText == "ಕುಮಾರ." || nodeRes["App_Title"].InnerText == "Sri." || nodeRes["App_Title"].InnerText == "Kumar.")
                        {
                            NCSE.NCGender = "MALE";
                            ODSE.Widow = "NA";
                            ODSE.Divorced = "NA";
                        }
                        else
                        {
                            NCSE.NCGender = "FEMALE";
                        }

                        NCSE.NCVerification = "Success";

                    }
                    //Label11.Text = NCSE.NCLanguage;
                    
                }
            }
            catch (Exception ex)
            {
                if (xElement.Element("Status").Value.ToString() == "0") 
                {
                    lblEligibility.Text = xElement.Element("StatusMsg").Value.ToString();
                    lblEligibility.Style.Add("color", "RED");
                    DisplayAlert(xElement.Element("StatusMsg").Value.ToString(), this);
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
        public static void DisplayAlert(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            //page.ClientScript.RegisterStartupScript(owner.GetType(),"ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    message));
            ScriptManager.RegisterClientScriptBlock(owner, owner.GetType(), "alertMessage", "alert('" + message.ToUpper() + "')", true);
        }
    }
}