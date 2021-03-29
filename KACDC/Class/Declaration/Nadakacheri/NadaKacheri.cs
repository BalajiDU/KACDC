using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.Nadakacheri
{
    public class NadaKacheri
    {
        public string OTP
        {
            set { HttpContext.Current.Session["OTP"] = value; }
            get { return HttpContext.Current.Session["OTP"] as string; }
        }
        public string SMSSendUrl
        {
            set { HttpContext.Current.Session["SMSSendUrl"] = value; }
            get { return HttpContext.Current.Session["SMSSendUrl"] as string; }
        }
        public string SMSMessageSendingKey
        {
            set { HttpContext.Current.Session["SMSMessageSendingKey"] = value; }
            get { return HttpContext.Current.Session["SMSMessageSendingKey"] as string; }
        }
        public string SMSNotifyURL
        {
            set { HttpContext.Current.Session["SMSNotifyURL"] = value; }
            get { return HttpContext.Current.Session["SMSNotifyURL"] as string; }
        }

        public string NCConstituency
        {
            set { HttpContext.Current.Session["NCConstituency"] = value; }
            get { return HttpContext.Current.Session["NCConstituency"] as string; }
        }




        
        public string NCLanguage
        {
            set { HttpContext.Current.Session["NCLanguage"] = value; }
            get { return HttpContext.Current.Session["NCLanguage"] as string; }
        }
        public string NCDateOfIssue
        {
            set { HttpContext.Current.Session["NCDateOfIssue"] = value; }
            get { return HttpContext.Current.Session["NCDateOfIssue"] as string; }
        }
        public string NCAnnualIncome
        {
            set { HttpContext.Current.Session["NCAnnualIncome"] = value; }
            get { return HttpContext.Current.Session["NCAnnualIncome"] as string; }
        }
        public string NCApplicantName
        {
            set { HttpContext.Current.Session["NCApplicantName"] = value; }
            get { return HttpContext.Current.Session["NCApplicantName"] as string; }
        }
        public string NCApplicantFatherName
        {
            set { HttpContext.Current.Session["NCApplicantFatherName"] = value; }
            get { return HttpContext.Current.Session["NCApplicantFatherName"] as string; }
        }
        public string NCApplicantCAddressPin
        {
            set { HttpContext.Current.Session["NCApplicantCAddressPin"] = value; }
            get { return HttpContext.Current.Session["NCApplicantCAddressPin"] as string; }
        }
        public string NCDistrictName
        {
            set { HttpContext.Current.Session["NCDistrictName"] = value; }
            get { return HttpContext.Current.Session["NCDistrictName"] as string; }
        }
        public string NCApplicantCAddress1
        {
            set { HttpContext.Current.Session["NCApplicantCAddress1"] = value; }
            get { return HttpContext.Current.Session["NCApplicantCAddress1"] as string; }
        }
        public string NCApplicantCAddress2
        {
            set { HttpContext.Current.Session["NCApplicantCAddress2"] = value; }
            get { return HttpContext.Current.Session["NCApplicantCAddress2"] as string; }
        }
        public string NCApplicantCAddress3
        {
            set { HttpContext.Current.Session["NCApplicantCAddress3"] = value; }
            get { return HttpContext.Current.Session["NCApplicantCAddress3"] as string; }
        }
        public string NCTalukName
        {
            set { HttpContext.Current.Session["NCTalukName"] = value; }
            get { return HttpContext.Current.Session["NCTalukName"] as string; }
        }
        public string NCVerification
        {
            set { HttpContext.Current.Session["NCVerification"] = value; }
            get { return HttpContext.Current.Session["NCVerification"] as string; }
        }
        public string NCStatusCode
        {
            set { HttpContext.Current.Session["NCStatusCode"] = value; }
            get { return HttpContext.Current.Session["NCStatusCode"] as string; }
        }
        public string NCStatusMsg
        {
            set { HttpContext.Current.Session["NCStatusMsg"] = value; }
            get { return HttpContext.Current.Session["NCStatusMsg"] as string; }
        }
        public string NCFacilityCode
        {
            set { HttpContext.Current.Session["NCFacilityCode"] = value; }
            get { return HttpContext.Current.Session["NCFacilityCode"] as string; }
        }
        public string NCFacilityName
        {
            set { HttpContext.Current.Session["NCFacilityName"] = value; }
            get { return HttpContext.Current.Session["NCFacilityName"] as string; }
        }
        public string NCFullAddress
        {
            set { HttpContext.Current.Session["NCFullAddress"] = value; }
            get { return HttpContext.Current.Session["NCFullAddress"] as string; }
        }
        public string NCContactAddress
        {
            set { HttpContext.Current.Session["NCContactAddress"] = value; }
            get { return HttpContext.Current.Session["NCContactAddress"] as string; }
        }
        public string NCGSCNumber
        {
            set { HttpContext.Current.Session["NCGSCNumber"] = value; }
            get { return HttpContext.Current.Session["NCGSCNumber"] as string; }
        }
        public string NCGender
        {
            set { HttpContext.Current.Session["NCGender"] = value; }
            get { return HttpContext.Current.Session["NCGender"] as string; }
        }
        public string App_Title
        {
            set { HttpContext.Current.Session["App_Title"] = value; }
            get { return HttpContext.Current.Session["App_Title"] as string; }
        }
        public string TLIFileNo
        {
            set { HttpContext.Current.Session["TLIFileNo"] = value; }
            get { return HttpContext.Current.Session["TLIFileNo"] as string; }
        }
        public string HobliName
        {
            set { HttpContext.Current.Session["HobliName"] = value; }
            get { return HttpContext.Current.Session["HobliName"] as string; }
        }
        public string VillageName
        {
            set { HttpContext.Current.Session["VillageName"] = value; }
            get { return HttpContext.Current.Session["VillageName"] as string; }
        }
        public string HabitationName
        {
            set { HttpContext.Current.Session["HabitationName"] = value; }
            get { return HttpContext.Current.Session["HabitationName"] as string; }
        }
        public string ApplicantBincom
        {
            set { HttpContext.Current.Session["ApplicantBincom"] = value; }
            get { return HttpContext.Current.Session["ApplicantBincom"] as string; }
        }
        public string Fat_Title
        {
            set { HttpContext.Current.Session["Fat_Title"] = value; }
            get { return HttpContext.Current.Session["Fat_Title"] as string; }
        }
        public string ApplicantMotherName
        {
            set { HttpContext.Current.Session["ApplicantMotherName"] = value; }
            get { return HttpContext.Current.Session["ApplicantMotherName"] as string; }
        }
        public string ReservationCategory
        {
            set { HttpContext.Current.Session["ReservationCategory"] = value; }
            get { return HttpContext.Current.Session["ReservationCategory"] as string; }
        }
        public string Caste
        {
            set { HttpContext.Current.Session["Caste"] = value; }
            get { return HttpContext.Current.Session["Caste"] as string; }
        }
        public string AnnualIncomeInWords
        {
            set { HttpContext.Current.Session["AnnualIncomeInWords"] = value; }
            get { return HttpContext.Current.Session["AnnualIncomeInWords"] as string; }
        }
        public string Purpose
        {
            set { HttpContext.Current.Session["Purpose"] = value; }
            get { return HttpContext.Current.Session["Purpose"] as string; }
        }
        public string ValidPeriod
        {
            set { HttpContext.Current.Session["ValidPeriod"] = value; }
            get { return HttpContext.Current.Session["ValidPeriod"] as string; }
        }
        public string SpecialTaluk
        {
            set { HttpContext.Current.Session["SpecialTaluk"] = value; }
            get { return HttpContext.Current.Session["SpecialTaluk"] as string; }
        }
        public string DocumentsSubmitted
        {
            set { HttpContext.Current.Session["DocumentsSubmitted"] = value; }
            get { return HttpContext.Current.Session["DocumentsSubmitted"] as string; }
        }
        public string DisplayDocumentsSubmitted
        {
            set { HttpContext.Current.Session["DisplayDocumentsSubmitted"] = value; }
            get { return HttpContext.Current.Session["DisplayDocumentsSubmitted"] as string; }
        }
       
    }
}