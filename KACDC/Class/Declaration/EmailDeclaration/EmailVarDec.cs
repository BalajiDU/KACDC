using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.EmailDeclaration
{
    public class EmailVarDec
    {
        public string SenderPassword
        {
            set { HttpContext.Current.Session["SenderPassword"] = value; }
            get { return HttpContext.Current.Session["SenderPassword"] as string; }
        }
        public string SenderMailID
        {
            set { HttpContext.Current.Session["SenderMailID"] = value; }
            get { return HttpContext.Current.Session["SenderMailID"] as string; }
        }
        public string ToMail
        {
            set { HttpContext.Current.Session["ToMail"] = value; }
            get { return HttpContext.Current.Session["ToMail"] as string; }
        }
        public string CCMail
        {
            set { HttpContext.Current.Session["CCMail"] = value; }
            get { return HttpContext.Current.Session["CCMail"] as string; }
        }
        public string PortNum
        {
            set { HttpContext.Current.Session["PortNum"] = value; }
            get { return HttpContext.Current.Session["PortNum"] as string; }
        }
        public string SMTP_Server
        {
            set { HttpContext.Current.Session["SMTP_Server"] = value; }
            get { return HttpContext.Current.Session["SMTP_Server"] as string; }
        }

        public string UserName
        {
            set { HttpContext.Current.Session["UserName"] = value; }
            get { return HttpContext.Current.Session["UserName"] as string; }
        }
        public string FinancialYear
        {
            set { HttpContext.Current.Session["FinancialYear"] = value; }
            get { return HttpContext.Current.Session["FinancialYear"] as string; }
        }
    }
}