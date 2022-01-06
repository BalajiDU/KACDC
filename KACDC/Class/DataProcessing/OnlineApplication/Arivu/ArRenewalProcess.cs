using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.OnlineApplication.Arivu
{
    public class ArRenewalProcess
    {
        public string CheckApplicatDetails(string ApplicationNumber, string status = "")
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spArivuRenewalProcess", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.Parameters.Add("@RetValue", SqlDbType.VarChar, -1);
                    cmd.Parameters["@RetValue"].Direction = ParameterDirection.Output;
                    kvdConn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        kvdConn.Close();
                        return cmd.Parameters["@RetValue"].Value.ToString();
                    }
                    //int count = (int)cmd.ExecuteScalar();
                    //return count.ToString();
                    //return "NA";
                }
            }
        }
        public string UpdateRenewalRequest(string ApplicationNumber, string ApplicationStatus , string status)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spArivuRenewalProcess", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    cmd.Parameters.Add("@RetValue", SqlDbType.VarChar, -1);
                    cmd.Parameters["@RetValue"].Direction = ParameterDirection.Output;
                    kvdConn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        kvdConn.Close();
                        return cmd.Parameters["@RetValue"].Value.ToString();
                    }
                    //int count = (int)cmd.ExecuteScalar();
                    //return count.ToString();
                    return "NA";
                }
            }
        }
    }
}