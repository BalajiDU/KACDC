using KACDC.Class.DataProcessing.MasterPage;
using KACDC.Class.DataProcessing.SMSService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using KACDC.Class.Declaration.MessageDeclaration;
using System.Web;

namespace KACDC.Class.MessageSending
{
    public class SendMessage
    {
        SendSMS SSMS = new SendSMS();
        Message MSGDEC = new Message();
        MasterSettings MS = new MasterSettings();
        public void MessageRequest(string Mesage, string MobileNumber,string User,int Language, string Path)
        {
        
        }
        public void OTPMessageRequest(string message,string mobilenumber, string MsgCategory)
        {
            GetMessageCategory(MsgCategory);
            CreateSMSLog LOG = new CreateSMSLog();
            LOG.CreateLog(MsgCategory, mobilenumber, 
                SSMS.sendSingleSMS(MSGDEC.SenderUserName, MSGDEC.SenderPassword, MSGDEC.SMSUser, mobilenumber, message, MSGDEC.SenderAPIkey, MSGDEC.TemplateID), message);
        }
        public void NewMessageRequest(string message,string mobilenumber, string MsgCategory)
        {
            GetMessageCategory(MsgCategory);
            CreateSMSLog LOG = new CreateSMSLog();
            LOG.CreateLog(MsgCategory, mobilenumber, 
                SSMS.sendOTPMSG(MSGDEC.SenderUserName, MSGDEC.SenderPassword, MSGDEC.SMSUser, mobilenumber, message, MSGDEC.SenderAPIkey, MSGDEC.TemplateID), message);
        }
        private void GetMessageCategory(string MsgCategory)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from SMSTemplate where Category=@Category"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Category", MsgCategory);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        MSGDEC.TemplateID = sdr["TemplateID"].ToString();
                        MSGDEC.TemplateName = sdr["TemplateName"].ToString();
                        MSGDEC.Category = sdr["Category"].ToString();
                        MSGDEC.SMSLanguage = sdr["SMSLanguage"].ToString();
                        MSGDEC.SMSUser = sdr["SMSUser"].ToString();
                        MSGDEC.TemplateMessage = sdr["TemplateMessage"].ToString();
                        kvdConn.Close();

                        //return cmd.Parameters["@RetValue"].Value.ToString() != "" ? cmd.Parameters["@RetValue"].Value.ToString() : "NA";

                    }
                }
            }
            MSGDEC.SenderUserName = MSGDEC.SMSUser == "KAVDES" ? "Mobile_1-KAVDES" : "Mobile_1-GKACDC";
            string[] str = new string[5];
            str = MS.GetData("GET", MSGDEC.SenderUserName);
            MSGDEC.SenderPassword = str[0];
            MSGDEC.SenderAPIkey = str[1];
        }
    }
}