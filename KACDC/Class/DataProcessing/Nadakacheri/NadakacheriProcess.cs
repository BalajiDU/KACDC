using KACDC.Class.Declaration.Nadakacheri;
using KACDC.NadaKacheriServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace KACDC.Class.DataProcessing.Nadakacheri
{
    public class NadakacheriProcess
    {
        NadaKacheri NKSER = new NadaKacheri();
        private void GetCasteAndIncomeCertificate(string RDNumber)
        {
            XElement xElement = null;
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
                    NKSER.NCStatusCode = xElement.Element("Status").Value.ToString();
                    NKSER.NCStatusMsg = xElement.Element("StatusMsg").Value.ToString();
                    NKSER.NCFacilityCode = xElement.Element("FacilityCode").Value.ToString();
                    NKSER.NCFacilityName = xElement.Element("FacilityName").Value.ToString();
                    NKSER.NCLanguage = xElement.Element("Language").Value.ToString();

                    string xml = HttpUtility.HtmlDecode(xElement.Element("xmlData").ToString()).Replace("\r", "").Replace("\n", "").Replace("{Text = \"", "").Replace("\"", "")
                .Replace("{", "").Replace("}", "").Replace("\"", "");
                    xmlApplicantDetails.LoadXml(xml);

                    XmlNodeList nodeList = xmlApplicantDetails.GetElementsByTagName("ApplicantDetails");
                    foreach (XmlNode nodeRes in nodeList)
                    {
                        NKSER.NCGSCNumber = nodeRes["GSCNo"].InnerText;
                        NKSER.NCAnnualIncome = nodeRes["AnnualIncome"].InnerText;
                        NKSER.NCDateOfIssue = nodeRes["DateOfIssue"].InnerText;
                        NKSER.NCApplicantName = nodeRes["ApplicantName"].InnerText;
                        NKSER.NCApplicantFatherName = nodeRes["ApplicantFatherName"].InnerText;
                        NKSER.NCDistrictName = nodeRes["DistrictName"].InnerText;
                        NKSER.NCTalukName = nodeRes["TalukName"].InnerText;
                        if (nodeRes["ApplicantCAddressPin"] != null) { NKSER.NCApplicantCAddressPin = nodeRes["ApplicantCAddressPin"].InnerText; } else { NKSER.NCApplicantCAddressPin = ""; }
                        if (nodeRes["ApplicantCAddress1"] != null) { NKSER.NCApplicantCAddress1 = nodeRes["ApplicantCAddress1"].InnerText; } else { NKSER.NCApplicantCAddress1 = ""; }
                        if (nodeRes["ApplicantCAddress2"] != null) { NKSER.NCApplicantCAddress2 = nodeRes["ApplicantCAddress2"].InnerText; } else { NKSER.NCApplicantCAddress2 = ""; }
                        if (nodeRes["ApplicantCAddress3"] != null) { NKSER.NCApplicantCAddress3 = nodeRes["ApplicantCAddress3"].InnerText; } else { NKSER.NCApplicantCAddress2 = ""; }
                        NKSER.NCFullAddress = NKSER.NCApplicantCAddress1 + ", " + NKSER.NCApplicantCAddress2 + ", " + NKSER.NCApplicantCAddress3 + ", " + NKSER.NCTalukName + ", " + NKSER.NCDistrictName;
                        if (nodeRes["App_Title"].InnerText == "ಶ್ರೀ." || nodeRes["App_Title"].InnerText == "ಕುಮಾರ." || nodeRes["App_Title"].InnerText == "Sri." || nodeRes["App_Title"].InnerText == "Kumar.")
                        {
                            NKSER.NCGender = "MALE";
                        }
                        else
                        {
                            NKSER.NCGender = "FEMALE";
                        }

                        NKSER.NCVerification = "Success";

                    }
                    //Label11.Text = NKSER.NCLanguage;

                }
            }
            catch (Exception ex)
            {
                if (xElement.Element("Status").Value.ToString() == "0")
                {
                    //todo
                    //lblEligibility.Text = xElement.Element("StatusMsg").Value.ToString();
                    //lblEligibility.Style.Add("color", "RED");
                    //DisplayAlert(xElement.Element("StatusMsg").Value.ToString(), this);
                }
            }
        }
    }
}