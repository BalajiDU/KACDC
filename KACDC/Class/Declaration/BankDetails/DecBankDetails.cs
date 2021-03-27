using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.BankDetails
{
    public class DecBankDetails
    {
        public string RTGS
        {
            set { HttpContext.Current.Session["RTGS"] = value; }
            get { return HttpContext.Current.Session["RTGS"] as string; }
        }
        public string AccountNumber
        {
            set { HttpContext.Current.Session["AccountNumber"] = value; }
            get { return HttpContext.Current.Session["AccountNumber"] as string; }
        }
        public string NEFT
        {
            set { HttpContext.Current.Session["NEFT"] = value; }
            get { return HttpContext.Current.Session["NEFT"] as string; }
        }
        public string IMPS
        {
            set { HttpContext.Current.Session["IMPS"] = value; }
            get { return HttpContext.Current.Session["IMPS"] as string; }
        }
        public string UPI
        {
            set { HttpContext.Current.Session["UPI"] = value; }
            get { return HttpContext.Current.Session["UPI"] as string; }
        }
        public string CENTRE
        {
            set { HttpContext.Current.Session["CENTRE"] = value; }
            get { return HttpContext.Current.Session["CENTRE"] as string; }
        }
        public string DISTRICT
        {
            set { HttpContext.Current.Session["DISTRICT"] = value; }
            get { return HttpContext.Current.Session["DISTRICT"] as string; }
        }
        public string MICR
        {
            set { HttpContext.Current.Session["MICR"] = value; }
            get { return HttpContext.Current.Session["MICR"] as string; }
        }
        public string BRANCH
        {
            set { HttpContext.Current.Session["BRANCH"] = value; }
            get { return HttpContext.Current.Session["BRANCH"] as string; }
        }
        public string CITY
        {
            set { HttpContext.Current.Session["CITY"] = value; }
            get { return HttpContext.Current.Session["CITY"] as string; }
        }
        public string STATE
        {
            set { HttpContext.Current.Session["STATE"] = value; }
            get { return HttpContext.Current.Session["STATE"] as string; }
        }
        public string ADDRESS
        {
            set { HttpContext.Current.Session["ADDRESS"] = value; }
            get { return HttpContext.Current.Session["ADDRESS"] as string; }
        }
        public string SWIFT
        {
            set { HttpContext.Current.Session["SWIFT"] = value; }
            get { return HttpContext.Current.Session["SWIFT"] as string; }
        }
        public string CONTACT
        {
            set { HttpContext.Current.Session["CONTACT"] = value; }
            get { return HttpContext.Current.Session["CONTACT"] as string; }
        }
        public string BANK
        {
            set { HttpContext.Current.Session["BANK"] = value; }
            get { return HttpContext.Current.Session["BANK"] as string; }
        }
        public string BANKCODE
        {
            set { HttpContext.Current.Session["BANKCODE"] = value; }
            get { return HttpContext.Current.Session["BANKCODE"] as string; }
        }
        public string IFSC
        {
            set { HttpContext.Current.Session["IFSC"] = value; }
            get { return HttpContext.Current.Session["IFSC"] as string; }
        }
        public string FULLADDRESS
        {
            set { HttpContext.Current.Session["FULLADDRESS"] = value; }
            get { return HttpContext.Current.Session["FULLADDRESS"] as string; }
        }

    }
}