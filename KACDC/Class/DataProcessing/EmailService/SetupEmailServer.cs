using KACDC.Class.Declaration.EmailDeclaration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.EmailService
{
    public class SetupEmailServer
    {
        EmailVarDec EM = new EmailVarDec();
        public void SetupEmailService()
        {
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[KACDCInfo]"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            EM.FinancialYear = sdr["FinancialYear"].ToString();
                            EM.SenderPassword = sdr["SenderPassword"].ToString();
                            EM.SenderMailID = sdr["SenderMailID"].ToString();
                            EM.ToMail = sdr["ToMail"].ToString();
                            EM.CCMail = sdr["CCMail"].ToString();
                            EM.PortNum = sdr["SmtpServerPortNum"].ToString();
                            EM.SMTP_Server = sdr["SMTP_Server"].ToString();
                            
                        }
                        kvdConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}