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
    /// Summary description for TallyApprovedData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TallyApprovedData : System.Web.Services.WebService
    {

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public List<ApprovedDataForTally> Arivu()
        {
            ApprovedDataForTally AR = new ApprovedDataForTally();
            List<ApprovedDataForTally> ARApplication = new List<ApprovedDataForTally>();

            try
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetTallyApplications", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MethodName", "AR");
                        kvdConn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            
                            AR.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                            AR.ApplicantName = rdr["ApplicantName"].ToString();
                            AR.DistrictCD = rdr["DistrictCD"].ToString();
                            AR.LoanName = rdr["LoanName"].ToString();
                            AR.LoanAmount = rdr["LoanAmount"].ToString();
                            AR.ACCOUNTNUMBER = rdr["ACCOUNTNUMBER"].ToString();
                            ARApplication.Add(AR);
                            
                        }
                    }
                    return ARApplication;
                }
            }
            catch {
                return ARApplication;
            }
        }
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public List<ApprovedDataForTally> SelfEmployment()
        {
            ApprovedDataForTally AR = new ApprovedDataForTally();
            List<ApprovedDataForTally> ARApplication = new List<ApprovedDataForTally>();
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetTallyApplications", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MethodName","SE");
                        kvdConn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {

                            AR.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                            AR.ApplicantName = rdr["ApplicantName"].ToString();
                            AR.DistrictCD = rdr["DistrictCD"].ToString();
                            AR.LoanName = rdr["LoanName"].ToString();
                            AR.LoanAmount = rdr["LoanAmount"].ToString();
                            AR.ACCOUNTNUMBER = rdr["ACCOUNTNUMBER"].ToString();
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
