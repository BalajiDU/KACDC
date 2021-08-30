using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.ApprovalProcess.ArivuRenewal
{
    public class RenewalApplicantDetails
    {
        public string ApplicationNumber
        {
            set { HttpContext.Current.Session["ApplicationNumber"] = value; }
            get { return HttpContext.Current.Session["ApplicationNumber"] as string; }
        }
        public string ApplicantName
        {
            set { HttpContext.Current.Session["ApplicantName"] = value; }
            get { return HttpContext.Current.Session["ApplicantName"] as string; }
        }
        public string LoanNumber
        {
            set { HttpContext.Current.Session["LoanNumber"] = value; }
            get { return HttpContext.Current.Session["LoanNumber"] as string; }
        }
        public string RDNumber
        {
            set { HttpContext.Current.Session["RDNumber"] = value; }
            get { return HttpContext.Current.Session["RDNumber"] as string; }
        }
        public string Email
        {
            set { HttpContext.Current.Session["Email"] = value; }
            get { return HttpContext.Current.Session["Email"] as string; }
        }
        public string MobileNumber
        {
            set { HttpContext.Current.Session["MobileNumber"] = value; }
            get { return HttpContext.Current.Session["MobileNumber"] as string; }
        }
        public string AlternateNumber
        {
            set { HttpContext.Current.Session["AlternateNumber"] = value; }
            get { return HttpContext.Current.Session["AlternateNumber"] as string; }
        }
        public string Quota
        {
            set { HttpContext.Current.Session["Quota"] = value; }
            get { return HttpContext.Current.Session["Quota"] as string; }
        }
        public string TotalAmount
        {
            set { HttpContext.Current.Session["TotalAmount"] = value; }
            get { return HttpContext.Current.Session["TotalAmount"] as string; }
        }
        public string LoanAmount
        {
            set { HttpContext.Current.Session["LoanAmount"] = value; }
            get { return HttpContext.Current.Session["LoanAmount"] as string; }
        }

    }
}