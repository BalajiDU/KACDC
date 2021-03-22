using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.SMSService
{
    public class CreateSMSLog
    {
        public void CreateLog(string Category, string MobileNumber, string MessageStatus, string Message)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spMessageLog", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Category", Category);
                    cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                    cmd.Parameters.AddWithValue("@Status", MessageStatus);
                    cmd.Parameters.AddWithValue("@Message", Message);
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
        }
    }
}