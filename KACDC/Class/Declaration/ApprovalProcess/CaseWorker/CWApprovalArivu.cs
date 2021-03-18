using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.ApprovalProcess.CaseWorker
{
    public class CWApprovalArivu
    {
        public string CWARTotalApplicationCount
        {
            set { HttpContext.Current.Session["CWARTotalApplicationCount"] = value; }
            get { return HttpContext.Current.Session["CWARTotalApplicationCount"] as string; }
        }
        public string CWARApprovedApplicationCount
        {
            set { HttpContext.Current.Session["CWARApprovedApplicationCount"] = value; }
            get { return HttpContext.Current.Session["CWARApprovedApplicationCount"] as string; }
        }
        public string CWARPendingApplicationCount
        {
            set { HttpContext.Current.Session["CWARPendingApplicationCount"] = value; }
            get { return HttpContext.Current.Session["CWARPendingApplicationCount"] as string; }
        }
        public string CWARRejectedApplicationCount
        {
            set { HttpContext.Current.Session["CWARRejectedApplicationCount"] = value; }
            get { return HttpContext.Current.Session["CWARRejectedApplicationCount"] as string; }
        }
        public string CWARHoldApplicationCount
        {
            set { HttpContext.Current.Session["CWARHoldApplicationCount"] = value; }
            get { return HttpContext.Current.Session["CWARHoldApplicationCount"] as string; }
        }
    }
}