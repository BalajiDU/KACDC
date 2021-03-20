using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.Aadhaar
{
    public class Aadhaarlog
    {
        public void AadhaarHistoryLog(string Type, string status, string TransactionID, string TimeStamp)
        {
            try
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }


                SqlCommand cmd = new SqlCommand("INSERT INTO AadhaarTransactionHistory ([Type],[Status],[TransactionID],[TimeStamp]) VALUES('" + Type + "','" + status + "','" + TransactionID + "','" + TimeStamp + "')", kvdConn);

                cmd.ExecuteNonQuery();

                kvdConn.Close();
            }
            catch (Exception ex)
            {
                //DisplayAlert(ex.Message, this);
            }
        }
    }
}