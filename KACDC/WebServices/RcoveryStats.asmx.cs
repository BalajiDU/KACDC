using KACDC.Class.Declaration.WebServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace KACDC.WebServices
{
    /// <summary>
    /// Summary description for RcoveryStats
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RcoveryStats : System.Web.Services.WebService
    {

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public List<WSPaymentStatistics> GetPayments()
        {
            List<WSPaymentStatistics> SEApplication = new List<WSPaymentStatistics>();
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetRcoveryStats", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@District", District);
                        kvdConn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            WSPaymentStatistics SE = new WSPaymentStatistics();
                            SE.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                            SE.ApplicantName = rdr["ApplicantName"].ToString();
                            SE.LoanAmount = rdr["LoanAmount"].ToString();
                            SE.ReleaseDate = rdr["ReleaseDate"].ToString();
                            SE.ZMApprove = rdr["ZMApprove"].ToString();
                            SE.ZONE = rdr["ZONE"].ToString();
                            SE.DISTRICT = rdr["DISTRICT"].ToString();
                            SE.LOANNUMBER = rdr["LOANNUMBER"].ToString();
                            SE.TOTALPAID = rdr["TOTALPAID"].ToString();
                            SE.LASTPAID = rdr["LASTPAID"].ToString();
                            SE.SINSCNOTPAID = rdr["SINSCNOTPAID"].ToString();
                            SE.INSTALMENT = rdr["INSTALMENT"].ToString();
                            SE.PAYABLEINSTALMENTS = rdr["PAYABLEINSTALMENTS"].ToString();
                            SE.PAYABLEAMOUNT = rdr["PAYABLEAMOUNT"].ToString();
                            SE.REMAININGAMOUNT = rdr["REMAININGAMOUNT"].ToString();
                            SEApplication.Add(SE);
                        }
                    }
                    return SEApplication;
                    //Context.Response.Write(new System.Web.Configuration.ScriptingJsonSerializationSection().MaxJsonLength);

                }
            }
            catch (Exception ex)
            {
                WSPaymentStatistics SE = new WSPaymentStatistics();
                SE.Error = ex.ToString();
                SEApplication.Add(SE);
                return SEApplication;
            }
        }
    }
}
