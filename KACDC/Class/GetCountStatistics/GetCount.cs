using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.GetCountStatistics
{
    public class GetCount
    {
        public string GetTotalCount(string StotedProcedureName, string MethodName, string ApplicationStatus = "", string District = "", string Zone = "")
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StotedProcedureName, kvdConn))
                {
                    if (StotedProcedureName != "")
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ZoneName", Zone);
                        cmd.Parameters.AddWithValue("@MethodName", MethodName);
                        cmd.Parameters.AddWithValue("@ApplicationStatusType", ApplicationStatus);
                        cmd.Parameters.AddWithValue("@District", District);
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
                    }
                    return "NA";
                }
            }
        }
    }
}