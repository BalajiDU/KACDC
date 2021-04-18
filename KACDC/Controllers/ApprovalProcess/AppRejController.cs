using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KACDC.Controllers
{
    public class AppRejController : ApiController
    {
        public IHttpActionResult GetSE(string Status,string ApplicationStatus,string ApplicationNumber,string RejectReason="")
        {
            try
            {
                //List<CaseWorker> CWList = new List<CaseWorker>();
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spApprovalProcess", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@status", Status); //"SESELECTCW"
                        cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);//"Bengaluru Dakshina"
                        cmd.Parameters.AddWithValue("@RejectReason", RejectReason);//"Bengaluru Dakshina"
                        cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);//"Bengaluru Dakshina"
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        cmd.ExecuteNonQuery();
                        kvdConn.Close();
                    }
                }
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
