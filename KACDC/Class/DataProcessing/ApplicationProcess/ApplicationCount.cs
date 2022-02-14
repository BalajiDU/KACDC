using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess
{
    public class ApplicationCount
    {
        public string Count(string StotedProcedureName, string MethodName, string ApplicationStatus = "", string District = "", string Gender = "", string Zone = "")
        {

            try
            {
                //List<CaseWorker> CWList = new List<CaseWorker>();
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
                            cmd.Parameters.AddWithValue("@Gender", Gender);
                            cmd.Parameters.Add("@RetValue", SqlDbType.VarChar, -1);
                            cmd.Parameters["@RetValue"].Direction = ParameterDirection.Output;
                            kvdConn.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                da.Fill(ds);
                                kvdConn.Close();

                                string Count = cmd.Parameters["@RetValue"].Value.ToString() != "" ? cmd.Parameters["@RetValue"].Value.ToString() : "NA";
                                return Count;
                            }
                            //int count = (int)cmd.ExecuteScalar();
                            //return count.ToString();
                        }
                        //return 0;
                        //return Ok();
                        return "NA";
                    }
                }


            }
            catch
            {

                return "NA";
            }
        }
    }
}