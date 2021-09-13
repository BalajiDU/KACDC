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
    /// Summary description for Get_Payments
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Get_Payments : System.Web.Services.WebService
    {

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public List<WSPayment> GetPayments()
        {
            List<WSPayment> SEApplication = new List<WSPayment>();
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetPayments", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        kvdConn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            WSPayment SE = new WSPayment();
                            SE.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                            SE.ApplicantName = rdr["ApplicantName"].ToString();
                            SE.LoanNumber = rdr["LoanNumber"].ToString();
                            SE.PaymentDate = rdr["PaymentDate"].ToString();
                            SE.PayedAmount = rdr["PayedAmount"].ToString();
                            SE.PaymentMode = rdr["PaymentMode"].ToString();
                            SE.Remarks = rdr["Remarks"].ToString();
                            SE.District = rdr["District"].ToString();
                            SE.Zone = rdr["Zone"].ToString();
                            SE.ReceiptNumber = rdr["ReceiptNumber"].ToString();
                            SE.AddedBy = rdr["AddedBy"].ToString();
                            SE.ReceiptGeneratedDate = rdr["ReceiptGeneratedDate"].ToString();
                            SE.modified_by = rdr["modified_by"].ToString();
                            SE.modified_datetime = rdr["modified_datetime"].ToString();
                            SE.pay_status = rdr["pay_status"].ToString();
                            SE.pay_otp = rdr["pay_otp"].ToString();
                            SEApplication.Add(SE);
                        }
                    }
                    return SEApplication;
                    //Context.Response.Write(new System.Web.Configuration.ScriptingJsonSerializationSection().MaxJsonLength);

                }
            }
            catch (Exception ex)
            {
                WSPayment SE = new WSPayment();
                SE.Error = ex.ToString();
                SEApplication.Add(SE);
                return SEApplication;
            }
        }
    }
}
