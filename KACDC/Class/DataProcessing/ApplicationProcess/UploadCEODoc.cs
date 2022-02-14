using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess
{
    public class UploadCEODoc
    {
        public int UploadDoc(string Scheme,string FinancialYear, string District, byte[] Byte)
        {
            string StoredPro = Scheme == "SE" ? "spSECEOScanDoc" : "spArivuCEOScanDoc";
            try
            {
                //List<CaseWorker> CWList = new List<CaseWorker>();
                using (SqlConnection kvdConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredPro, kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@District", District); //"SESELECTCW"
                        cmd.Parameters.AddWithValue("@FinancialYear", FinancialYear); //"SESELECTCW"
                        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString());//"Bengaluru Dakshina"
                        cmd.Parameters.AddWithValue("@CEOVerifiedDoc", Byte);//"Bengaluru Dakshina"
                        cmd.Parameters.Add("@ID", SqlDbType.Int, -1);
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        cmd.ExecuteNonQuery();
                        kvdConn.Close();
                         return Int32.Parse(cmd.Parameters["@RetValue"].Value.ToString());
                    }
                }
                return 0;
            }
            catch (Exception EX)
            {
                string MESSAGE = EX.Message;
                return 0;
            }
        }
    }
}