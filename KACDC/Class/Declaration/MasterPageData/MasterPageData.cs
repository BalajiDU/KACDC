using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.MasterPageData
{
    public class MasterPageData
    {
        public string CMName
        {
            set { HttpContext.Current.Session["CMName"] = value; }
            get { return HttpContext.Current.Session["CMName"] as string; }
        }
        public string MinisterName
        {
            set { HttpContext.Current.Session["MinisterName"] = value; }
            get { return HttpContext.Current.Session["MinisterName"] as string; }
        }
        public string ChairmanName
        {
            set { HttpContext.Current.Session["ChairmanName"] = value; }
            get { return HttpContext.Current.Session["ChairmanName"] as string; }
        }
        public string CMPhoto
        {
            set { HttpContext.Current.Session["CMPhoto"] = value; }
            get { return HttpContext.Current.Session["CMPhoto"] as string; }
        }
        public string MinisterPhoto
        {
            set { HttpContext.Current.Session["MinisterPhoto"] = value; }
            get { return HttpContext.Current.Session["MinisterPhoto"] as string; }
        }
        public string ChairmanPhoto
        {
            set { HttpContext.Current.Session["ChairmanPhoto"] = value; }
            get { return HttpContext.Current.Session["ChairmanPhoto"] as string; }
        }
        public string GOKLogo
        {
            set { HttpContext.Current.Session["GOKLogo"] = value; }
            get { return HttpContext.Current.Session["GOKLogo"] as string; }
        }
        public string KACDCLogo
        {
            set { HttpContext.Current.Session["KACDCLogo"] = value; }
            get { return HttpContext.Current.Session["KACDCLogo"] as string; }
        }
        public string FinancialYear
        {
            set { HttpContext.Current.Session["FinancialYear"] = value; }
            get { return HttpContext.Current.Session["FinancialYear"] as string; }
        }

    }
}