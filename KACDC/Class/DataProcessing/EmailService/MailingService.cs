using KACDC.Class.Declaration.EmailDeclaration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace KACDC.Class.DataProcessing.EmailService
{
    public class MailingService
    {
        EmailVarDec EM = new EmailVarDec();
        SetupEmailServer ESERVER = new SetupEmailServer();
        public void SendMail(string Subject,string EmailBody,string ToMail="",string CCMail="",byte[] Attachment=null ,string AttachmentName="")
        {
            ESERVER.SetupEmailService();
               ToMail = ToMail != "" ? ToMail : EM.ToMail;
            CCMail = CCMail != "" ? CCMail : EM.CCMail;

            SmtpClient SmtpServer = new SmtpClient(EM.SMTP_Server);
            SmtpServer.Port = Int32.Parse(EM.PortNum);
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(EM.SenderMailID, EM.SenderPassword);
            SmtpServer.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.To.Add(ToMail);
            mail.CC.Add(CCMail);
            mail.From = new MailAddress(EM.SenderMailID);
            mail.Subject = Subject;
            mail.IsBodyHtml = true;
            mail.Body = EmailBody;
            if (Attachment != null)
            {
                mail.Attachments.Add(new Attachment(new MemoryStream(Attachment), AttachmentName));
            }
            SmtpServer.Send(mail);
        }
    }
}