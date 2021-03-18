using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.CollegeData
{
    public class Applicant_College_Data
    {
        public string PdfCETAdmissionTicket
        {
            set { HttpContext.Current.Session["PdfCETAdmissionTicket"] = value; }
            get { return HttpContext.Current.Session["PdfCETAdmissionTicket"] as string; }
        }
        public string CollegeName
        {
            set { HttpContext.Current.Session["CollegeName"] = value; }
            get { return HttpContext.Current.Session["CollegeName"] as string; }
        }
        public string CollegeAddress
        {
            set { HttpContext.Current.Session["CollegeAddress"] = value; }
            get { return HttpContext.Current.Session["CollegeAddress"] as string; }
        }
        

    }
}