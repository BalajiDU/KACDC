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
        public string TemplateID
        {
            set { HttpContext.Current.Session["TemplateID"] = value; }
            get { return HttpContext.Current.Session["TemplateID"] as string; }
        }
        public string TemplateName
        {
            set { HttpContext.Current.Session["TemplateName"] = value; }
            get { return HttpContext.Current.Session["TemplateName"] as string; }
        }
        public string Category
        {
            set { HttpContext.Current.Session["Category"] = value; }
            get { return HttpContext.Current.Session["Category"] as string; }
        }
        public string SMSLanguage
        {
            set { HttpContext.Current.Session["SMSLanguage"] = value; }
            get { return HttpContext.Current.Session["SMSLanguage"] as string; }
        }
        public string SMSUser
        {
            set { HttpContext.Current.Session["SMSUser"] = value; }
            get { return HttpContext.Current.Session["SMSUser"] as string; }
        }
        public string TemplateMessage
        {
            set { HttpContext.Current.Session["TemplateMessage"] = value; }
            get { return HttpContext.Current.Session["TemplateMessage"] as string; }
        }
        public string SelectedLacguage
        {
            set { HttpContext.Current.Session["SelectedLacguage"] = value; }
            get { return HttpContext.Current.Session["SelectedLacguage"] as string; }
        }
        public string SenderUserName
        {
            set { HttpContext.Current.Session["SenderUserName"] = value; }
            get { return HttpContext.Current.Session["SenderUserName"] as string; }
        }
        public string SenderPassword
        {
            set { HttpContext.Current.Session["SenderPassword"] = value; }
            get { return HttpContext.Current.Session["SenderPassword"] as string; }
        }
        public string SenderAPIkey
        {
            set { HttpContext.Current.Session["SenderAPIkey"] = value; }
            get { return HttpContext.Current.Session["SenderAPIkey"] as string; }
        }

    }
}