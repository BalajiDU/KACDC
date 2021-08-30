using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess.BankDetails
{
    public class UpdateBankDetails
    {
        public void UpdateBankDetailsToDB(string ApplicationNumber,string AccountNumber,string BankName,string IFSCCode,string Branch,string BankAddress,string Reason,string ApplicantName, string Scheme)
        {
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateBankDetails", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UpdatingTable", Scheme);
                        cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                        cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                        cmd.Parameters.AddWithValue("@BankName", BankName);
                        cmd.Parameters.AddWithValue("@IFSCCode", IFSCCode);
                        cmd.Parameters.AddWithValue("@Branch", Branch);
                        cmd.Parameters.AddWithValue("@BankAddress", BankAddress);
                        cmd.Parameters.AddWithValue("@Reason", Reason);
                        cmd.Parameters.AddWithValue("@ApplicantName", ApplicantName);
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        cmd.ExecuteNonQuery();
                        kvdConn.Close();
                    }
                }
            }
            catch
            {
            }
        }
    }
}