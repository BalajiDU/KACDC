using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.ApprovalProcess.CaseWorker
{
    public class CWProcess
    {
        public string CWDistrict
        {
            set { HttpContext.Current.Session["CWDistrict"] = value; }
            get { return HttpContext.Current.Session["CWDistrict"] as string; }
        }
    }
}