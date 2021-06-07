using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.OnlineApplication
{
    public class AVPortal
    {
        public string EncryptedOTP
        {
            set { HttpContext.Current.Session["EncryptedOTP"] = value; }
            get { return HttpContext.Current.Session["EncryptedOTP"] as string; }
        }
        public string IsMobileVerified
        {
            set { HttpContext.Current.Session["IsMobileVerified"] = value; }
            get { return HttpContext.Current.Session["IsMobileVerified"] as string; }
        }
        public string EmailID
        {
            set { HttpContext.Current.Session["EmailID"] = value; }
            get { return HttpContext.Current.Session["EmailID"] as string; }
        }
        public string Name
        {
            set { HttpContext.Current.Session["Name"] = value; }
            get { return HttpContext.Current.Session["Name"] as string; }
        }
        public string Gender
        {
            set { HttpContext.Current.Session["Gender"] = value; }
            get { return HttpContext.Current.Session["Gender"] as string; }
        }

    }
}