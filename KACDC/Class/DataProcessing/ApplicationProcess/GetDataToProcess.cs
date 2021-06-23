using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess
{
    public class GetDataToProcess
    {
        public DataTable GetData(string StoredProcedureName,string Method, string District,string TableName="")
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedureName, kvdConn))//"spGetDataToApprovalProcess"
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", Method); //"SESELECTCW"
                    cmd.Parameters.AddWithValue("@District", District);//"Bengaluru Dakshina"
                    cmd.Connection = kvdConn;
                    //kvdConn.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (TableName != "")
                            dt.TableName = TableName;
                        return dt;
                    }
                    //kvdConn.Close();
                }
            }
        }
    }
}