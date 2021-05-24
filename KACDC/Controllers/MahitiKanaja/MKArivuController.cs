using KACDC.Class.Declaration.WebServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KACDC.Controllers.MahitiKanaja
{
    public class MKArivuController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Arivu(string Scheme,string District="",string Taluk="")
        {
            WSMahitiKhanaja AR = new WSMahitiKhanaja();
            List<WSMahitiKhanaja> ARApplication = new List<WSMahitiKhanaja>();
            try
            {
                
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spMahitiKanajaData", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (Scheme.ToUpper() == "AR")
                        {
                            cmd.Parameters.AddWithValue("@scheme", "AR");
                        }
                        else if (Scheme.ToUpper() == "SE")
                        {
                            cmd.Parameters.AddWithValue("@scheme", "SE");
                        }
                        if(District!="")
                        cmd.Parameters.AddWithValue("@District", District);
                        if (Taluk != "")
                            cmd.Parameters.AddWithValue("@Taluk", Taluk);

                        kvdConn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {

                            AR.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                            AR.ApplicantName = rdr["ApplicantName"].ToString();
                            AR.LoanNumber = rdr["ApprovedApplicationNum"].ToString();
                            AR.District = rdr["ParDistrict"].ToString();
                            AR.Taluk = rdr["ParTaluk"].ToString();
                            AR.Constituency = rdr["ParConstituency"].ToString();
                            AR.FinancialYear = rdr["FinancialYear"].ToString();
                            ARApplication.Add(AR);

                        }
                    }
                    return Ok(ARApplication);
                }
            }
            catch
            {
                return Ok(ARApplication);
            }
        }
    }
}
