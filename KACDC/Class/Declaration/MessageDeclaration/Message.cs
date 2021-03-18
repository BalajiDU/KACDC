using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.MessageDeclaration
{
    public class Message
    {
        public string SMSMessageSendingKey
        {
            set { HttpContext.Current.Session["SMSMessageSendingKey"] = value; }
            get { return HttpContext.Current.Session["SMSMessageSendingKey"] as string; }
        }
        public string SMSNotifyURL
        {
            set { HttpContext.Current.Session["SMSNotifyURL"] = value; }
            get { return HttpContext.Current.Session["SMSNotifyURL"] as string; }
        }
        public string SMSSendUrl
        {
            set { HttpContext.Current.Session["SMSSendUrl"] = value; }
            get { return HttpContext.Current.Session["SMSSendUrl"] as string; }
        }
        public string SenderID
        {
            set { HttpContext.Current.Session["SenderID"] = value; }
            get { return HttpContext.Current.Session["SenderID"] as string; }
        }

    }
}