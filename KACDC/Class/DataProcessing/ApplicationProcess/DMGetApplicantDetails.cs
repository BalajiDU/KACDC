using KACDC.Class.Declaration.ApprovalProcess.ArivuRenewal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess
{
    public class DMGetApplicantDetails
    {
        public void GetApplicantDetailsAR(string ApplicationNumber, string status)
        {
            RenewalApplicantDetails ARRP = new RenewalApplicantDetails();
            if (ApplicationNumber != "")
            {
                
                    //string LoanName = Scheme == "AR" ? "ArivuEduLoan" : "SelfEmpLoan";
                    using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                    {
                        if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                        SqlDataAdapter DAcmd = new SqlDataAdapter(status, kvdConn);
                        DAcmd.SelectCommand.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                        DataTable dt = new DataTable();
                        DAcmd.Fill(dt);

                        ARRP.ApplicationNumber = dt.Rows[0]["ApplicationNumber"].ToString();
                        ARRP.ApplicantName = dt.Rows[0]["ApplicantName"].ToString();
                        ARRP.AlternateNumber = dt.Rows[0]["AlternateNumber"].ToString();
                        ARRP.LoanNumber = dt.Rows[0]["ApprovedApplicationNum"].ToString();
                        ARRP.Email = dt.Rows[0]["EmailID"].ToString();
                        ARRP.LoanAmount = dt.Rows[0]["LoanAmount"].ToString();
                        ARRP.MobileNumber = dt.Rows[0]["MobileNumber"].ToString();
                        ARRP.Quota = dt.Rows[0]["Quota"].ToString();
                        ARRP.RDNumber = dt.Rows[0]["RDNumber"].ToString();
                        ARRP.TotalAmount = dt.Rows[0]["TOTALLOAN"].ToString();
                        ARRP.ApplicationNumber = ApplicationNumber;
                        kvdConn.Close();
                    }
            }
        }
    }
}