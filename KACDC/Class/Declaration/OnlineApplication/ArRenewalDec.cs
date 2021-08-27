using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.OnlineApplication
{
    public class ArRenewalDec
    {
        public byte[] byteStudyCertificate
        {
            set { HttpContext.Current.Session["byteStudyCertificate"] = value; }
            get { return HttpContext.Current.Session["byteStudyCertificate"] as byte[]; }
        }
        public byte[] bytePrevMarksCard
        {
            set { HttpContext.Current.Session["bytePrevMarksCard"] = value; }
            get { return HttpContext.Current.Session["bytePrevMarksCard"] as byte[]; }
        }
        public byte[] byteFeesStructure
        {
            set { HttpContext.Current.Session["byteFeesStructure"] = value; }
            get { return HttpContext.Current.Session["byteFeesStructure"] as byte[]; }
        }
        public byte[] byteCollegeHostel
        {
            set { HttpContext.Current.Session["byteCollegeHostel"] = value; }
            get { return HttpContext.Current.Session["byteCollegeHostel"] as byte[]; }
        }
        public string ApplicationNumber
        {
            set { HttpContext.Current.Session["ApplicationNumber"] = value; }
            get { return HttpContext.Current.Session["ApplicationNumber"] as string; }
        }
        public string Installment
        {
            set { HttpContext.Current.Session["Installment"] = value; }
            get { return HttpContext.Current.Session["Installment"] as string; }
        }
        public string StudyCertificate
        {
            set { HttpContext.Current.Session["StudyCertificate"] = value; }
            get { return HttpContext.Current.Session["StudyCertificate"] as string; }
        }
        public string PrevMarksCard
        {
            set { HttpContext.Current.Session["PrevMarksCard"] = value; }
            get { return HttpContext.Current.Session["PrevMarksCard"] as string; }
        }
        public string DBInstallment
        {
            set { HttpContext.Current.Session["DBInstallment"] = value; }
            get { return HttpContext.Current.Session["DBInstallment"] as string; }
        }
        public string FILENAME
        {
            set { HttpContext.Current.Session["FILENAME"] = value; }
            get { return HttpContext.Current.Session["FILENAME"] as string; }
        }
        public string MOBILENUMBER
        {
            set { HttpContext.Current.Session["MOBILENUMBER"] = value; }
            get { return HttpContext.Current.Session["MOBILENUMBER"] as string; }
        }
        public string APPLICANTNAME
        {
            set { HttpContext.Current.Session["APPLICANTNAME"] = value; }
            get { return HttpContext.Current.Session["APPLICANTNAME"] as string; }
        }
        public string GETEMAILID
        {
            set { HttpContext.Current.Session["GETEMAILID"] = value; }
            get { return HttpContext.Current.Session["GETEMAILID"] as string; }
        }
    }
}