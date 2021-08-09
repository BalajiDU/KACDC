using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace KACDC.Class.DataProcessing.MasterPage
{
    public class MasterSettings
    {
        public string[] GetData(string MethodName,string Key,string Value1="",string Value2="")
        {
            string[] str = new string[5];
            try
            {
                //List<CaseWorker> CWList = new List<CaseWorker>();
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetMasterSettings", kvdConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Key", Key);
                        cmd.Parameters.AddWithValue("@MethodName", MethodName);

                        kvdConn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            str[0] = sdr["Value"].ToString();
                            str[1] = sdr["Value1"].ToString();
                            kvdConn.Close();
                            
                            //return cmd.Parameters["@RetValue"].Value.ToString() != "" ? cmd.Parameters["@RetValue"].Value.ToString() : "NA";
                        }
                        //int count = (int)cmd.ExecuteScalar();
                        //return count.ToString();

                        //return 0;
                        //return Ok();
                        return str;
                    }
                }


            }
            catch
            {

                return str;
            }
        }
    }
}