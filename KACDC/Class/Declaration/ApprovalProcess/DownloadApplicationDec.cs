using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.ApprovalProcess
{
    public class DownloadApplicationDec
    {
        public string ApplicationNumber
        {
            set { HttpContext.Current.Session["ApplicationNumber"] = value; }
            get { return HttpContext.Current.Session["ApplicationNumber"] as string; }
        }
        public string LoanType
        {
            set { HttpContext.Current.Session["LoanType"] = value; }
            get { return HttpContext.Current.Session["LoanType"] as string; }
        }
        public string MobileNum
        {
            set { HttpContext.Current.Session["MobileNum"] = value; }
            get { return HttpContext.Current.Session["MobileNum"] as string; }
        }
        public string AppliName
        {
            set { HttpContext.Current.Session["AppliName"] = value; }
            get { return HttpContext.Current.Session["AppliName"] as string; }
        }
        public string EmailID
        {
            set { HttpContext.Current.Session["EmailID"] = value; }
            get { return HttpContext.Current.Session["EmailID"] as string; }
        }
        public string PhyCha
        {
            set { HttpContext.Current.Session["PhyCha"] = value; }
            get { return HttpContext.Current.Session["PhyCha"] as string; }
        }
        public string OTP
        {
            set { HttpContext.Current.Session["OTP"] = value; }
            get { return HttpContext.Current.Session["OTP"] as string; }
        }
        public string FinancialYear
        {
            set { HttpContext.Current.Session["FinancialYear"] = value; }
            get { return HttpContext.Current.Session["FinancialYear"] as string; }
        }

    }
}