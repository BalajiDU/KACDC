using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Hangfire;
using KACDC.Class.DataProcessing.MasterPage;
using KACDC.Class.DataProcessing.SMSService;

namespace KACDC.Class.JobScheduler
{
    public class HangFireJobScheduler
    {
        public void RunNow()
        {
            //BackgroundJob.Enqueue<HangFireModule>(X => X.PrintToConsole());
        }
        public void RunOnSchedule()
        {
            RecurringJob.AddOrUpdate<HangFireModule>(X => X.SendMessage(), Cron.Daily(8),TimeZoneInfo.Local);
        }
    }
    public class HangFireModule
    {
        public void SendMessage()
        {
            MasterSettings MS = new MasterSettings();
            SendSMS SM = new SendSMS();
            string MobileNumber = "9740560748";
            string Message = "Dear Beneficiary, " + "Test" + " is your new Password for KACDC Application, to reset your Password navigate to PASSWORD RESET option in Menu. From: KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION LTD";
            string MessageType = "FGTPWD";
            using (SqlConnection kvdConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
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
                        //SM.BulkMessaging(SenderUserName, SenderPassword, SMSUser, MobileNumber, Message, SenderAPIkey, TemplateID, SMSLanguage, MessageType, Category);

                        //return cmd.Parameters["@RetValue"].Value.ToString() != "" ? cmd.Parameters["@RetValue"].Value.ToString() : "NA";

                    }
                }
            }
        }
    }
}