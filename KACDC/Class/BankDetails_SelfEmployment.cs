using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class
{
    public class BankDetails_SelfEmployment
    {
        public string BankDetailsVerification
        {
            set { HttpContext.Current.Session["BankDetailsVerification"] = value; }
            get { return HttpContext.Current.Session["BankDetailsVerification"] as string; }
        }
        public string BankAccountNumber
        {
            set { HttpContext.Current.Session["BankAccountNumber"] = value; }
            get { return HttpContext.Current.Session["BankAccountNumber"] as string; }
        }
        public string BankName
        {
            set { HttpContext.Current.Session["BankName"] = value; }
            get { return HttpContext.Current.Session["BankName"] as string; }
        }
        public string BankIFSCCode
        {
            set { HttpContext.Current.Session["BankIFSCCode"] = value; }
            get { return HttpContext.Current.Session["BankIFSCCode"] as string; }
        }
        public string BankBranch
        {
            set { HttpContext.Current.Session["BankBranch"] = value; }
            get { return HttpContext.Current.Session["BankBranch"] as string; }
        }
        public string BankAddress
        {
            set { HttpContext.Current.Session["BankAddress"] = value; }
            get { return HttpContext.Current.Session["BankAddress"] as string; }
        }
    }
}