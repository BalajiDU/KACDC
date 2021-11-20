using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.OnlineApplication
{
    public class IsAadhaarExist
    {
        public string CheckAadhaar(string Aadhaar)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spAadhaarExist", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Aadhar", Aadhaar);
                    cmd.Parameters.AddWithValue("@MethodName", "SE");
                    cmd.Parameters.Add("@RetValue", SqlDbType.VarChar, -1);
                    cmd.Parameters["@RetValue"].Direction = ParameterDirection.Output;
                    kvdConn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        kvdConn.Close();
                        string Temp = cmd.Parameters["@RetValue"].Value.ToString();
                        if (Temp == "NA")
                        {
                            return CheckAadhaarExistAR(Aadhaar);
                        }
                        else
                        {
                            return Temp;
                        }
                    }
                }
            }
        }
        private string CheckAadhaarExistAR(string Aadhaar)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spAadhaarExist", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Aadhar", Aadhaar);
                    cmd.Parameters.AddWithValue("@MethodName", "AR");
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
                }
            }
        }
    }
}