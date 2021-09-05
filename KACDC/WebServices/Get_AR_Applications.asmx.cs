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
    /// Summary description for Get_AR_Applications
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Get_AR_Applications : System.Web.Services.WebService
    {
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public List<WSARWebService> GetArivu()
        {
            List<WSARWebService> ARApplication = new List<WSARWebService>();
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetARApplications", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        kvdConn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            WSARWebService AR = new WSARWebService();
                            AR.ImgPath = rdr["ImgPath"].ToString();
                            AR.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                            AR.ApplicantName = rdr["ApplicantName"].ToString();
                            AR.ApplicantNameNC = rdr["ApplicantNameNC"].ToString();
                            AR.FatherName = rdr["FatherName"].ToString();
                            AR.Gender = rdr["Gender"].ToString();
                            AR.District = rdr["ParDistrict"].ToString();
                            AR.RDNumber = rdr["RDNumber"].ToString();
                            AR.MobileNumber = rdr["MobileNumber"].ToString();
                            AR.AlternateNumber = rdr["AlternateNumber"].ToString();
                            AR.EmailID = rdr["EmailID"].ToString();
                            AR.Quota = rdr["Quota"].ToString();
                            AR.CaseWorker = rdr["CaseWorker"].ToString();
                            AR.CWStatus = rdr["CWStatus"].ToString();
                            AR.DistrictManager = rdr["DistrictManager"].ToString();
                            AR.DMStatus = rdr["DMStatus"].ToString();
                            AR.CEO = rdr["CEO"].ToString();
                            AR.CEOStatus = rdr["CEOStatus"].ToString();
                            AR.Documentation = rdr["Documentation"].ToString();
                            AR.DOCStatus = rdr["DOCStatus"].ToString();
                            AR.ZonalManager = rdr["ZonalManager"].ToString();
                            AR.ZMStatus = rdr["ZMStatus"].ToString();
                            AR.ApprovedApplicationNum = rdr["ApprovedApplicationNum"].ToString();
                            AR.DOB = rdr["DOB"].ToString();
                            AR.Age = rdr["Age"].ToString();
                            AR.PWD = rdr["PhysicallyChallenged"].ToString();
                            AR.AnualIncome = rdr["AnualIncome"].ToString();
                            AR.Address = rdr["ParmanentAddress"].ToString();
                            AR.Constituency = rdr["ParConstituency"].ToString();
                            AR.Pincode = rdr["ParPincode"].ToString();
                            AR.AccountNumber = rdr["AccountNumber"].ToString();
                            AR.BankName = rdr["BankName"].ToString();
                            AR.Branch = rdr["Branch"].ToString();
                            AR.IFSCCode = rdr["IFSCCode"].ToString();
                            AR.BankAddress = rdr["BankAddress"].ToString();
                            AR.BankDetails = "";
                            AR.ApplicationAppliedDate = rdr["ApplicationAppliedDate"].ToString();
                            AR.BankUpdate = rdr["BankUpdate"].ToString();
                            AR.AadhaarNumber = "";
                            AR.Zone = rdr["ZoneName"].ToString();
                            AR.Taluk = rdr["ParTaluk"].ToString();

                            AR.CETApplicationNum = rdr["CETApplicationNum"].ToString();
                            AR.CETAdmissionTicateNum = rdr["CETAdmissionTicateNum"].ToString();
                            AR.CollegeName = rdr["CollegeName"].ToString();
                            AR.Course = rdr["Course"].ToString();
                            AR.PrevYearMarks = rdr["PrevYearMarks"].ToString();
                            AR.ClgHostel = rdr["ClgHostel"].ToString();
                            AR.CurrentYear = rdr["CurrentYear"].ToString();
                            AR.Year1Loan = rdr["Year1Loan"].ToString();
                            AR.Year2Loan = rdr["Year2Loan"].ToString();
                            AR.Year3Loan = rdr["Year3Loan"].ToString();
                            AR.Year4Loan = rdr["Year4Loan"].ToString();
                            AR.Year5Loan = rdr["Year5Loan"].ToString();
                            AR.Year6Loan = rdr["Year6Loan"].ToString();

                            AR.Instalment1 = rdr["Instalment1"].ToString();
                            AR.Instalment2 = rdr["Instalment2"].ToString();
                            AR.Instalment3 = rdr["Instalment3"].ToString();
                            AR.Instalment4 = rdr["Instalment4"].ToString();
                            AR.Instalment5 = rdr["Instalment5"].ToString();
                            AR.Instalment6 = rdr["Instalment6"].ToString();
                            ARApplication.Add(AR);
                        }
                    }
                    return ARApplication;
                }
            }
            catch (Exception ex)
            {
                WSARWebService AR = new WSARWebService();
                AR.Error = ex.ToString();
                ARApplication.Add(AR);
                return ARApplication;
            }
        }
    }
}
