using KACDC.Class.DataProcessing.SMSService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using KACDC.Class.Declaration.MessageDeclaration;
using KACDC.Class.DataProcessing.MasterPage;

namespace KACDC.WebServices
{
    /// <summary>
    /// Summary description for KACDC_Send_Message
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KACDC_Send_Message : System.Web.Services.WebService
    {

        [WebMethod]
        public string SendMessage(string Message,string MobileNumber,string MessageType,string Key)
        {
            //return MessageType;
            Message MSGDEC = new Message();
            MasterSettings MS = new MasterSettings();
            SendSMS SM = new SendSMS();
            //try
            //{
                if (Key == "KABA94ASBHSU14DBA3U")
                {
                    if (Message.Length > 1)
                    {
                        //return Message + "__" + MobileNumber + "__" + MessageType + "__" + Key;
                        //return MessageType;
                        //MSGDEC.MessageType = "";
                        //MSGDEC.MessageType = MobileNumber.Trim().Length == 10 ? "Single" : "Bulk";

                        //return SM.sendSMS(MobileNumber, Message, 2, MessageType);




                        using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand("select * from SMSTemplate where Category=@Category"))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@Category", MessageType);
                                cmd.Connection = kvdConn;
                                kvdConn.Open();
                                using (SqlDataReader sdr = cmd.ExecuteReader())
                                {
                                    sdr.Read();
                                    string TemplateID = sdr["TemplateID"].ToString();
                                string TemplateName = sdr["TemplateName"].ToString();
                                string Category = sdr["Category"].ToString();
                                string SMSLanguage = sdr["SMSLanguage"].ToString();
                                string SMSUser = sdr["SMSUser"].ToString();
                                string TemplateMessage = sdr["TemplateMessage"].ToString();
                                    kvdConn.Close();



                                string SenderUserName = SMSUser == "KAVDES" ? "Mobile_1-KAVDES" : "Mobile_1-GKACDC";
                                    string[] str = new string[5];
                                    str = MS.GetData("GET", SenderUserName);
                                string SenderPassword = str[0];
                                string SenderAPIkey = str[1];

                                if (MessageType != "FGTPWD")
                                {
                                    if (MobileNumber.Trim().Length == 10)

                                        MessageType = "Single";
                                    else
                                        MessageType = "Bulk";
                                }
                                    return SM.BulkMessaging(SenderUserName, SenderPassword, SMSUser, MobileNumber, Message, SenderAPIkey, TemplateID, SMSLanguage, MessageType, Category);

                                    //return cmd.Parameters["@RetValue"].Value.ToString() != "" ? cmd.Parameters["@RetValue"].Value.ToString() : "NA";

                                }
                            }
                        }


                    }
                    else { return "Invalid Message"; }
                }
                else { return "Invalid Key"; }
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
        }
    }
}
