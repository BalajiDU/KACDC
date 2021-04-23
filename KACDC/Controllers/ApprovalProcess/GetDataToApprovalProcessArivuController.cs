using KACDC.Class.Declaration.Schemes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KACDC.Controllers.ApprovalProcess
{
    public class GetDataToApprovalProcessArivuController : ApiController
    {
        public IHttpActionResult GetApplication(string District, string Status)
        {
            List<Arivu> CWList = new List<Arivu>();
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetDataToApprovalProcess", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", Status); //"SESELECTCW"
                    cmd.Parameters.AddWithValue("@District", District);//"Bengaluru Dakshina"
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Arivu CW = new Arivu();
                            CW.ApplicationNumber = sdr["ApplicationNumber"].ToString();
                            CW.ApplicantName = sdr["ApplicantName"].ToString();
                            CW.FinancialYear = sdr["Gender"].ToString();
                            CWList.Add(CW);
                        }
                    }
                    kvdConn.Close();
                }
            }
            return Ok(CWList);
        }
    }
}
