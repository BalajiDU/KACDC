using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.ApprovalProcess.DistrictManager
{
    public class DistrictManagerProcess
    {
        public string Instalment
        {
            set { HttpContext.Current.Session["Instalment"] = value; }
            get { return HttpContext.Current.Session["Instalment"] as string; }
        }
    }
}