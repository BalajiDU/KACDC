using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.ApprovalProcess.CaseWorker
{
    public class CWApprovalSelfEmploymentcs
    {
        public string CWSETotalApplicationCount
        {
            set { HttpContext.Current.Session["CWSETotalApplicationCount"] = value; }
            get { return HttpContext.Current.Session["CWSETotalApplicationCount"] as string; }
        }
        public string CWSEApprovedApplicationCount
        {
            set { HttpContext.Current.Session["CWSEApprovedApplicationCount"] = value; }
            get { return HttpContext.Current.Session["CWSEApprovedApplicationCount"] as string; }
        }
        public string CWSEPendingApplicationCount
        {
            set { HttpContext.Current.Session["CWSEPendingApplicationCount"] = value; }
            get { return HttpContext.Current.Session["CWSEPendingApplicationCount"] as string; }
        }
        public string CWSERejectedApplicationCount
        {
            set { HttpContext.Current.Session["CWSERejectedApplicationCount"] = value; }
            get { return HttpContext.Current.Session["CWSERejectedApplicationCount"] as string; }
        }
        public string CWSEHoldApplicationCount
        {
            set { HttpContext.Current.Session["CWSEHoldApplicationCount"] = value; }
            get { return HttpContext.Current.Session["CWSEHoldApplicationCount"] as string; }
        }
    }
}