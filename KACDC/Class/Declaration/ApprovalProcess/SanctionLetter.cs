using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.ApprovalProcess
{
    public class SanctionLetter
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
        public string LoanAmount
        {
            set { HttpContext.Current.Session["LoanAmount"] = value; }
            get { return HttpContext.Current.Session["LoanAmount"] as string; }
        }
        public string EmailID
        {
            set { HttpContext.Current.Session["EmailID"] = value; }
            get { return HttpContext.Current.Session["EmailID"] as string; }
        }
        public string INSTALMENT
        {
            set { HttpContext.Current.Session["INSTALMENT"] = value; }
            get { return HttpContext.Current.Session["INSTALMENT"] as string; }
        }
        public string LOANNUMBER
        {
            set { HttpContext.Current.Session["LOANNUMBER"] = value; }
            get { return HttpContext.Current.Session["LOANNUMBER"] as string; }
        }
        public string Principle
        {
            set { HttpContext.Current.Session["Principle"] = value; }
            get { return HttpContext.Current.Session["Principle"] as string; }
        }
        public string Intrest
        {
            set { HttpContext.Current.Session["Intrest"] = value; }
            get { return HttpContext.Current.Session["Intrest"] as string; }
        }
        public string TotalPrinciple
        {
            set { HttpContext.Current.Session["TotalPrinciple"] = value; }
            get { return HttpContext.Current.Session["TotalPrinciple"] as string; }
        }
        public string ReleaseDate
        {
            set { HttpContext.Current.Session["ReleaseDate"] = value; }
            get { return HttpContext.Current.Session["ReleaseDate"] as string; }
        }

    }
}