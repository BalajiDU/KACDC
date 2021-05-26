using KACDC.Class.Declaration.WebServices;
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
    /// Summary description for Get_SE_Applications
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Get_SE_Applications : System.Web.Services.WebService
    {
        
        [WebMethod]
        public void GetSelfEmployment()
        {
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    List<WSSEWebService> SEApplication = new List<WSSEWebService>();
                    using (SqlCommand cmd = new SqlCommand("spGetSEApplications", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        kvdConn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            WSSEWebService SE = new WSSEWebService();
                            SE.ImgPath = rdr["ImgPath"].ToString();
                            SE.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                            SE.ApplicantName = rdr["ApplicantName"].ToString();
                            SE.ApplicantNameNC = rdr["ApplicantNameNC"].ToString();
                            SE.FatherName = rdr["FatherName"].ToString();
                            SE.Gender = rdr["Gender"].ToString();
                            SE.District = rdr["ParDistrict"].ToString();
                            SE.RDNumber = rdr["RDNumber"].ToString();
                            SE.MobileNumber = rdr["MobileNumber"].ToString();
                            SE.AlternateNumber = rdr["AlternateNumber"].ToString();
                            SE.EmailID = rdr["EmailID"].ToString();
                            SE.Quota = rdr["Quota"].ToString();
                            SE.ApprovedAmount = rdr["ApprovedAmount"].ToString();
                            SE.CaseWorker = rdr["CaseWorker"].ToString();
                            SE.CWStatus = rdr["CWStatus"].ToString();
                            SE.DistrictManager = rdr["DistrictManager"].ToString();
                            SE.DMStatus = rdr["DMStatus"].ToString();
                            SE.CEO = rdr["CEO"].ToString();
                            SE.CEOStatus = rdr["CEOStatus"].ToString();
                            SE.Documentation = rdr["Documentation"].ToString();
                            SE.DOCStatus = rdr["DOCStatus"].ToString();
                            SE.ZonalManager = rdr["ZonalManager"].ToString();
                            SE.ZMStatus = rdr["ZMStatus"].ToString();
                            SE.ApprovedApplicationNum = rdr["ApprovedApplicationNum"].ToString();
                            SE.DOB = rdr["DOB"].ToString();
                            SE.Age = rdr["Age"].ToString();
                            SE.PWD = rdr["PhysicallyChallenged"].ToString();
                            SE.Widowed = rdr["Widowed"].ToString();
                            SE.Divorced = rdr["Divorced"].ToString();
                            SE.AnualIncome = rdr["AnualIncome"].ToString();
                            SE.Address = rdr["ParmanentAddress"].ToString();
                            SE.Constituency = rdr["ParConstituency"].ToString();
                            SE.Pincode = rdr["ParPincode"].ToString();
                            SE.AccountNumber = rdr["AccountNumber"].ToString();
                            SE.BankName = rdr["BankName"].ToString();
                            SE.Branch = rdr["Branch"].ToString();
                            SE.IFSCCode = rdr["IFSCCode"].ToString();
                            SE.BankAddress = rdr["BankAddress"].ToString();
                            SE.BankDetails = "";
                            SE.LoanPurpose = rdr["LoanPurpose"].ToString();
                            SE.ApplicationAppliedDate = rdr["ApplicationAppliedDate"].ToString();
                            SE.BankUpdate = rdr["BankUpdate"].ToString();
                            SE.AadhaarNumber = "";
                            SE.Zone = rdr["ZoneName"].ToString();
                            SEApplication.Add(SE);
                        }
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    js.MaxJsonLength = (Int32.MaxValue);//2147483647
                    Context.Response.Write(js.Serialize(SEApplication));
                    //Context.Response.Write(new System.Web.Configuration.ScriptingJsonSerializationSection().MaxJsonLength);

                }
            }
            catch (Exception ex)
            {
                WSError ER = new WSError();
                ER.ErrorMessage = ex.ToString();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(ER));
            }
        }
    }
}
