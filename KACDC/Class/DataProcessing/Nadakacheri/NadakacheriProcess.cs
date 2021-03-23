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
        StoreNadakacheriData StoreNC = new StoreNadakacheriData();
        public bool GetCasteAndIncomeCertificate(string RDNumber)
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
                        if (nodeRes["ApplicantCAddress3"] != null) { NKSER.NCApplicantCAddress3 = nodeRes["ApplicantCAddress3"].InnerText; } else { NKSER.NCApplicantCAddress3 = ""; }
                        NKSER.NCFullAddress = NKSER.NCApplicantCAddress1 + ", " + NKSER.NCApplicantCAddress2 + ", " + NKSER.NCApplicantCAddress3 + ", " + NKSER.NCTalukName + ", " + NKSER.NCDistrictName;


                        if (nodeRes["TLIFileNo"] != null) { NKSER.TLIFileNo = nodeRes["TLIFileNo"].InnerText; } else { NKSER.TLIFileNo = ""; }
                        if (nodeRes["HobliName"] != null) { NKSER.HobliName = nodeRes["HobliName"].InnerText; } else { NKSER.HobliName = ""; }
                        if (nodeRes["VillageName"] != null) { NKSER.VillageName = nodeRes["VillageName"].InnerText; } else { NKSER.VillageName = ""; }
                        if (nodeRes["HabitationName"] != null) { NKSER.HabitationName = nodeRes["HabitationName"].InnerText; } else { NKSER.HabitationName = ""; }
                        if (nodeRes["ApplicantBincom"] != null) { NKSER.ApplicantBincom = nodeRes["ApplicantBincom"].InnerText; } else { NKSER.ApplicantBincom = ""; }
                        if (nodeRes["Fat_Title"] != null) { NKSER.Fat_Title = nodeRes["Fat_Title"].InnerText; } else { NKSER.Fat_Title = ""; }
                        if (nodeRes["ApplicantMotherName"] != null) { NKSER.ApplicantMotherName = nodeRes["ApplicantMotherName"].InnerText; } else { NKSER.ApplicantMotherName = ""; }
                        if (nodeRes["ReservationCategory"] != null) { NKSER.ReservationCategory = nodeRes["ReservationCategory"].InnerText; } else { NKSER.ReservationCategory = ""; }
                        if (nodeRes["AnnualIncomeInWords"] != null) { NKSER.AnnualIncomeInWords = nodeRes["AnnualIncomeInWords"].InnerText; } else { NKSER.AnnualIncomeInWords = ""; }
                        if (nodeRes["Purpose"] != null) { NKSER.Purpose = nodeRes["Purpose"].InnerText; } else { NKSER.Purpose = ""; }
                        if (nodeRes["ValidPeriod"] != null) { NKSER.ValidPeriod = nodeRes["ValidPeriod"].InnerText; } else { NKSER.ValidPeriod = ""; }
                        if (nodeRes["SpecialTaluk"] != null) { NKSER.SpecialTaluk = nodeRes["SpecialTaluk"].InnerText; } else { NKSER.SpecialTaluk = ""; }
                        if (nodeRes["DocumentsSubmitted"] != null) { NKSER.DocumentsSubmitted = nodeRes["DocumentsSubmitted"].InnerText; } else { NKSER.DocumentsSubmitted = ""; }
                        if (nodeRes["DisplayDocumentsSubmitted"] != null) { NKSER.DisplayDocumentsSubmitted = nodeRes["DisplayDocumentsSubmitted"].InnerText; } else { NKSER.DisplayDocumentsSubmitted = ""; }




                        NKSER.App_Title = nodeRes["App_Title"].InnerText;
                        if (NKSER.App_Title == "ಶ್ರೀ." || NKSER.App_Title == "ಕುಮಾರ." || NKSER.App_Title == "Sri." || NKSER.App_Title == "Kumar." || NKSER.App_Title == "ಕುಮಾರ.")
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
                    StoreNC.StoreCasteIncomeCert(NKSER.NCGSCNumber,NKSER.NCStatusCode, NKSER.NCStatusMsg, NKSER.NCFacilityCode, NKSER.NCFacilityName, NKSER.NCLanguage, NKSER.NCAnnualIncome, NKSER.NCDateOfIssue, NKSER.NCApplicantName,
                        NKSER.NCTalukName, NKSER.NCApplicantCAddressPin, NKSER.NCApplicantCAddress1, NKSER.NCApplicantCAddress2, NKSER.NCApplicantCAddress3, NKSER.App_Title, NKSER.NCGender, NKSER.NCVerification,
                        NKSER.TLIFileNo, NKSER.HobliName, NKSER.VillageName,NKSER.HabitationName, NKSER.ApplicantBincom, NKSER.Fat_Title, NKSER.ApplicantMotherName, NKSER.ReservationCategory, NKSER.AnnualIncomeInWords, NKSER.Purpose,
                        NKSER.ValidPeriod, NKSER.SpecialTaluk, NKSER.DocumentsSubmitted, NKSER.DisplayDocumentsSubmitted);
                }
                return true;
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
                return false;
            }
        }
    }
}