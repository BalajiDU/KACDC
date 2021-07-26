using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.OnlineApplication
{
    public class OtherDataSelfEmployment
    {
        public string EncryptionKey
        {
            set { HttpContext.Current.Session["EncryptionKey"] = value; }
            get { return HttpContext.Current.Session["EncryptionKey"] as string; }
        }
        public string OtherDetailsStatus
        {
            set { HttpContext.Current.Session["OtherDetailsStatus"] = value; }
            get { return HttpContext.Current.Session["OtherDetailsStatus"] as string; }
        }
        public string EmailID
        {
            set { HttpContext.Current.Session["EmailID"] = value; }
            get { return HttpContext.Current.Session["EmailID"] as string; }
        }
        public string AlternateMobileNumber
        {
            set { HttpContext.Current.Session["AlternateMobileNumber"] = value; }
            get { return HttpContext.Current.Session["AlternateMobileNumber"] as string; }
        }
        public string MobileNumber
        {
            set { HttpContext.Current.Session["MobileNumber"] = value; }
            get { return HttpContext.Current.Session["MobileNumber"] as string; }
        }
        public string PurposeOfLoan
        {
            set { HttpContext.Current.Session["PurposeOfLoan"] = value; }
            get { return HttpContext.Current.Session["PurposeOfLoan"] as string; }
        }
        public string LoanDESCRIPTION
        {
            set { HttpContext.Current.Session["LoanDESCRIPTION"] = value; }
            get { return HttpContext.Current.Session["LoanDESCRIPTION"] as string; }
        }
        public string PersonWithDisabilities
        {
            set { HttpContext.Current.Session["PersonWithDisabilities"] = value; }
            get { return HttpContext.Current.Session["PersonWithDisabilities"] as string; }
        }
        public string PersonWith
        {
            set { HttpContext.Current.Session["PersonWithDisabilities"] = value; }
            get { return HttpContext.Current.Session["PersonWithDisabilities"] as string; }
        }
        public string ContactDistrictName
        {
            set { HttpContext.Current.Session["NCDistrictName"] = value; }
            get { return HttpContext.Current.Session["NCDistrictName"] as string; }
        }
        public string ContactTalukName
        {
            set { HttpContext.Current.Session["NCTalukName"] = value; }
            get { return HttpContext.Current.Session["NCTalukName"] as string; }
        }
        public string ContactFullAddress
        {
            set { HttpContext.Current.Session["NCFullAddress"] = value; }
            get { return HttpContext.Current.Session["NCFullAddress"] as string; }
        }
        public string ContactPinCode
        {
            set { HttpContext.Current.Session["ContactPinCode"] = value; }
            get { return HttpContext.Current.Session["ContactPinCode"] as string; }
        }
        public string Widow
        {
            set { HttpContext.Current.Session["Widow"] = value; }
            get { return HttpContext.Current.Session["Widow"] as string; }
        }
        public string Divorced
        {
            set { HttpContext.Current.Session["Divorced"] = value; }
            get { return HttpContext.Current.Session["Divorced"] as string; }
        }
        public string GeneratedApplicationNumber
        {
            set { HttpContext.Current.Session["GeneratedApplicationNumber"] = value; }
            get { return HttpContext.Current.Session["GeneratedApplicationNumber"] as string; }
        }
        public string ApplicationDateTime
        {
            set { HttpContext.Current.Session["ApplicationDateTime"] = value; }
            get { return HttpContext.Current.Session["ApplicationDateTime"] as string; }
        }

        public string FinancialYear
        {
            set { HttpContext.Current.Session["FinancialYear"] = value; }
            get { return HttpContext.Current.Session["FinancialYear"] as string; }
        }
        public string SenderPassword
        {
            set { HttpContext.Current.Session["SenderPassword"] = value; }
            get { return HttpContext.Current.Session["SenderPassword"] as string; }
        }
        public string SenderMailID
        {
            set { HttpContext.Current.Session["SenderMailID"] = value; }
            get { return HttpContext.Current.Session["SenderMailID"] as string; }
        }
        public string ToMail
        {
            set { HttpContext.Current.Session["ToMail"] = value; }
            get { return HttpContext.Current.Session["ToMail"] as string; }
        }
        public string PortNum
        {
            set { HttpContext.Current.Session["PortNum"] = value; }
            get { return HttpContext.Current.Session["PortNum"] as string; }
        }
        public string SMTP_Server
        {
            set { HttpContext.Current.Session["SMTP_Server"] = value; }
            get { return HttpContext.Current.Session["SMTP_Server"] as string; }
        }
        public string SelfDeclaration
        {
            set { HttpContext.Current.Session["SelfDeclaration"] = value; }
            get { return HttpContext.Current.Session["SelfDeclaration"] as string; }
        }
        public string AadharDeclaration
        {
            set { HttpContext.Current.Session["AadharDeclaration"] = value; }
            get { return HttpContext.Current.Session["AadharDeclaration"] as string; }
        }
        public string ShareData
        {
            set { HttpContext.Current.Session["ShareData"] = value; }
            get { return HttpContext.Current.Session["ShareData"] as string; }
        }
    }
}