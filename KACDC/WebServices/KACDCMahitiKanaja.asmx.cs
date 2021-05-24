using KACDC.Class.Declaration.WebServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace KACDC.WebServices
{
    /// <summary>
    /// Summary description for KACDCMahitiKanaja
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KACDCMahitiKanaja : System.Web.Services.WebService
    {

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public List<WSMahitiKhanaja> Arivu()
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
                        cmd.Parameters.AddWithValue("@MethodName", "AR");
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
                    return ARApplication;
                }
            }
            catch
            {
                return ARApplication;
            }
        }
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public List<WSMahitiKhanaja> SelfEmployment()
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
                        cmd.Parameters.AddWithValue("@MethodName", "SE");
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
                    return ARApplication;
                }
            }
            catch
            {
                return ARApplication;
            }
        }
    }
}
