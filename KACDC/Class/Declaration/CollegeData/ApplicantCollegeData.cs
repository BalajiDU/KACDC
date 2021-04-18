using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.CollegeData
{
    public class ApplicantCollegeData
    {
        public string CETAdmissionTicketNumber
        {
            set { HttpContext.Current.Session["CETAdmissionTicketNumber"] = value; }
            get { return HttpContext.Current.Session["CETAdmissionTicketNumber"] as string; }
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
        public string CETApplicationNumber
        {
            set { HttpContext.Current.Session["CETApplicationNumber"] = value; }
            get { return HttpContext.Current.Session["CETApplicationNumber"] as string; }
        }
        public string Year
        {
            set { HttpContext.Current.Session["Year"] = value; }
            get { return HttpContext.Current.Session["Year"] as string; }
        }
        public string Course
        {
            set { HttpContext.Current.Session["Course"] = value; }
            get { return HttpContext.Current.Session["Course"] as string; }
        }
        public string PreviousYearMarks
        {
            set { HttpContext.Current.Session["PreviousYearMarks"] = value; }
            get { return HttpContext.Current.Session["PreviousYearMarks"] as string; }
        }
        public string RequiredLoanAmount
        {
            set { HttpContext.Current.Session["RequiredLoanAmount"] = value; }
            get { return HttpContext.Current.Session["RequiredLoanAmount"] as string; }
        }
        public string CollegeHostel
        {
            set { HttpContext.Current.Session["CollegeHostel"] = value; }
            get { return HttpContext.Current.Session["CollegeHostel"] as string; }
        }
        public string PdfCETAdmissionTicket
        {
            set { HttpContext.Current.Session["PdfCETAdmissionTicket"] = value; }
            get { return HttpContext.Current.Session["PdfCETAdmissionTicket"] as string; }
        }
        

    }
}