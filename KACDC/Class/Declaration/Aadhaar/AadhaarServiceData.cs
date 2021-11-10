using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.Aadhaar
{
    public class AadhaarServiceData
    {
        public string AadhaarNumber
        {
            set { HttpContext.Current.Session["AadhaarNumber"] = value; }
            get { return HttpContext.Current.Session["AadhaarNumber"] as string; }
        }
        public string AadhaarOTPResponseTransactionID
        {
            set { HttpContext.Current.Session["AadhaarOTPResponseTransactionID"] = value; }
            get { return HttpContext.Current.Session["AadhaarOTPResponseTransactionID"] as string; }
        }
        public string SendOTPErrorMessage
        {
            set { HttpContext.Current.Session["SendOTPErrorMessage"] = value; }
            get { return HttpContext.Current.Session["SendOTPErrorMessage"] as string; }
        }
        public string SendOTPErrorCode
        {
            set { HttpContext.Current.Session["SendOTPErrorCode"] = value; }
            get { return HttpContext.Current.Session["SendOTPErrorCode"] as string; }
        }
        public string AadhaarApplicantOTP
        {
            set { HttpContext.Current.Session["AadhaarApplicantOTP"] = value; }
            get { return HttpContext.Current.Session["AadhaarApplicantOTP"] as string; }
        }
        public string AadhaarVaultToken
        {
            set { HttpContext.Current.Session["AadhaarVaultToken"] = value; }
            get { return HttpContext.Current.Session["AadhaarVaultToken"] as string; }
        }
        public string OTPErrorCode
        {
            set { HttpContext.Current.Session["OTPErrorCode"] = value; }
            get { return HttpContext.Current.Session["OTPErrorCode"] as string; }
        }
        public string OTPErrorMessage
        {
            set { HttpContext.Current.Session["OTPErrorMessage"] = value; }
            get { return HttpContext.Current.Session["OTPErrorMessage"] as string; }
        }
        public string DOB
        {
            set { HttpContext.Current.Session["DOB"] = value; }
            get { return HttpContext.Current.Session["DOB"] as string; }
        }
        public string Gender
        {
            set { HttpContext.Current.Session["Gender"] = value; }
            get { return HttpContext.Current.Session["Gender"] as string; }
        }
        public string Name
        {
            set { HttpContext.Current.Session["Name"] = value; }
            get { return HttpContext.Current.Session["Name"] as string; }
        }
        public string State
        {
            set { HttpContext.Current.Session["State"] = value; }
            get { return HttpContext.Current.Session["State"] as string; }
        }
        public string District
        {
            set { HttpContext.Current.Session["District"] = value; }
            get { return HttpContext.Current.Session["District"] as string; }
        }
        public byte[] Photo
        {
            set { HttpContext.Current.Session["Photo"] = value; }
            get { return HttpContext.Current.Session["Photo"] as byte[]; }
        }
        public string Pincode
        {
            set { HttpContext.Current.Session["Pincode"] = value; }
            get { return HttpContext.Current.Session["Pincode"] as string; }
        }
        public string KannadaName
        {
            set { HttpContext.Current.Session["KannadaName"] = value; }
            get { return HttpContext.Current.Session["KannadaName"] as string; }
        }

    }
}