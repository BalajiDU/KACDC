using KACDC.Models;
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
    public class CaseWorkerController : ApiController
    {
        [HttpPost]
        public bool AddEmpDetails()
        {
            return true;
            //write insert logic  

        }
        
        public IHttpActionResult GetSE(string District,string Status)
        {
            List<CaseWorker> CWList = new List<CaseWorker>();
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
                            CaseWorker CW = new CaseWorker();
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
        [HttpDelete]
        public string DeleteEmpDetails(string id)
        {
            return "Employee details deleted having Id " + id;

        }
        [HttpPut]
        public string UpdateEmpDetails(string Name, String Id)
        {
            return "Employee details Updated with Name " + Name + " and Id " + Id;

        }
    }
}
