using KACDC.Class.Declaration.Schemes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace KACDC.WebServices
{
    /// <summary>
    /// Summary description for FetchSelfEmploymentData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FetchSelfEmploymentData : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetSelfEmployment()
        {
            string SQL = @"select ApplicationNumber,ApplicantName,Gender,RDNumber,MobileNumber,Quota,ParmanentAddress,ParDistrict,ParConstituency,ParPincode,AadharNum,AnualIncome,PhysicallyChallenged,EmailID
,CONVERT(VARCHAR(20),DoB,110) as DoB
	  ,CASE WHEN CWApprove = 'REJECTED' THEN CWApprove+' : '+RejectReason else CWApprove END CWStatus
	  ,CASE WHEN DMApprove = 'REJECTED' THEN DMApprove+' : '+DMRejectReason else DMApprove END DMStatus
	  	  ,CASE WHEN DMCEOApprove = 'REJECTED' THEN DMCEOApprove+' : '+DMCEORejectReason WHEN DMCEOApprove = 'APPROVED' THEN DMCEOApprove+' : '+LoanAmount else DMCEOApprove	END	CEOStatus   
	  ,CASE WHEN DMDocApprove = 'REJECTED' THEN DMDocApprove+' : '+DMDocRejectReason else DMDocApprove END DOCStatus
	  ,CASE WHEN ZMApprove = 'REJECTED' THEN ZMApprove+' : '+ZMRejectReason else ZMApprove END ZMStatus
        ,datediff(year,DoB,getdate()) as Age
	  from SelfEmpLoan";

            List<SelfEmployment> SEApplication = new List<SelfEmployment>();
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                cmd.CommandType = CommandType.Text;
                kvdConn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelfEmployment SE = new SelfEmployment();
                    SE.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                    SE.ApplicantName = rdr["ApplicantName"].ToString() + "<br />" + rdr["Gender"].ToString() + "<br /> PH : " + rdr["PhysicallyChallenged"].ToString();
                    SE.RDNumber = rdr["RDNumber"].ToString() + "<br />" + rdr["AadharNum"].ToString();
                    SE.MobileNumber = rdr["MobileNumber"].ToString() + "<br />" + rdr["EmailID"].ToString();
                    SE.IncomeDoB = rdr["AnualIncome"].ToString() + "<br />" + rdr["DoB"].ToString() + " (" + rdr["Age"].ToString() + ")";
                    SE.Quota = rdr["Quota"].ToString();
                    SE.CWStatus = rdr["CWStatus"].ToString();
                    SE.Status = "CW : " + rdr["CWStatus"].ToString() + "<br />DM : " + rdr["DMStatus"].ToString() + "<br />CEO : " + rdr["CEOStatus"].ToString() + "<br />DOC : " + rdr["DOCStatus"].ToString() + "<br />ZM : " + rdr["ZMStatus"].ToString();
                    SE.DMStatus = rdr["DMStatus"].ToString() + "\n" + rdr["DMStatus"].ToString();
                    SE.CEOStatus = rdr["CEOStatus"].ToString();
                    SE.DOCStatus = rdr["DOCStatus"].ToString();
                    SE.ZMStatus = rdr["ZMStatus"].ToString();
                    SE.ParmanentAddress = rdr["ParmanentAddress"].ToString() + "<br />" + rdr["ParConstituency"].ToString() + "(C)" + "<br />" + rdr["ParDistrict"].ToString() + "(D)" + "<br />" + rdr["ParPincode"].ToString();
                    //SE.NullColumn = "<input type=\"checkbox\" name=\"SelfEmploymentSelectApplication\" />";
                    SEApplication.Add(SE);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(SEApplication));
        }   
    }
}
