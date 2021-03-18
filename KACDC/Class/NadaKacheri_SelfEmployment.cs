using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class
{
    public class NadaKacheri_SelfEmployment
    {
        public string SMSSendUrl
        {
            set { HttpContext.Current.Session["SMSSendUrl"] = value; }
            get { return HttpContext.Current.Session["SMSSendUrl"] as string; }
        }
        public string SMSNotifyURL
        {
            set { HttpContext.Current.Session["SMSNotifyURL"] = value; }
            get { return HttpContext.Current.Session["SMSNotifyURL"] as string; }
        }
        public string SMSMessageSendingKey
        {
            set { HttpContext.Current.Session["SMSMessageSendingKey"] = value; }
            get { return HttpContext.Current.Session["SMSMessageSendingKey"] as string; }
        }
        public string OTP
        {
            set { HttpContext.Current.Session["OTP"] = value; }
            get { return HttpContext.Current.Session["OTP"] as string; }
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
    }
}