using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.ApprovalProcess
{
    public class SBankDetails
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
        public string BankName
        {
            set { HttpContext.Current.Session["BankName"] = value; }
            get { return HttpContext.Current.Session["BankName"] as string; }
        }
        public string Branch
        {
            set { HttpContext.Current.Session["Branch"] = value; }
            get { return HttpContext.Current.Session["Branch"] as string; }
        }
        public string AccountNumber
        {
            set { HttpContext.Current.Session["AccountNumber"] = value; }
            get { return HttpContext.Current.Session["AccountNumber"] as string; }
        }
        public string IFSCCode
        {
            set { HttpContext.Current.Session["IFSCCode"] = value; }
            get { return HttpContext.Current.Session["IFSCCode"] as string; }
        }
        public string BankAddress
        {
            set { HttpContext.Current.Session["BankAddress"] = value; }
            get { return HttpContext.Current.Session["BankAddress"] as string; }
        }

    }
}