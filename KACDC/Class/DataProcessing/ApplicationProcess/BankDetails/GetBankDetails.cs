using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KACDC.Class.Declaration.ApprovalProcess;

namespace KACDC.Class.DataProcessing.ApplicationProcess.BankDetails
{
    public class GetBankDetails
    {
        
        public void GetApplicantBankDetails(string ApplicationNumber,string Scheme)
        {
            SBankDetails BD = new SBankDetails();
            if (ApplicationNumber != "")
            {
                if (Scheme != "")
                {
                    string LoanName = Scheme == "AR" ? "ArivuEduLoan" : "SelfEmpLoan";
                    using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                    {
                        if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                        SqlDataAdapter DAcmd = new SqlDataAdapter("SELECT ApplicantName,BankName,Branch,AccountNumber,IFSCCode,BankAddress FROM "+ LoanName + " WHERE ApplicationNumber= @AppnNumber", kvdConn);
                        DAcmd.SelectCommand.Parameters.AddWithValue("@AppnNumber", ApplicationNumber);
                        DataTable dt = new DataTable();
                        DAcmd.Fill(dt);

                        BD.ApplicantName = dt.Rows[0]["ApplicantName"].ToString();
                        BD.AccountNumber = dt.Rows[0]["AccountNumber"].ToString();
                        BD.BankName = dt.Rows[0]["BankName"].ToString();
                        BD.IFSCCode = dt.Rows[0]["IFSCCode"].ToString();
                        BD.BankAddress = dt.Rows[0]["BankAddress"].ToString();
                        BD.Branch = dt.Rows[0]["Branch"].ToString();
                        BD.ApplicationNumber = ApplicationNumber;
                        kvdConn.Close();
                    }
                }
            }
        }
    }
}