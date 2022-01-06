using KACDC.Class.DataProcessing.Nadakacheri;
using KACDC.Class.Declaration.ApprovalProcess;
using KACDC.Class.Declaration.Nadakacheri;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess
{
    public class DownloadApplication
    {
        DownloadApplicationDec DAD = new DownloadApplicationDec();

        public void GetApplicantDetails()
        {
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    string Loan = "";
                    if (DAD.LoanType == "AR")
                        Loan = "spCheckARExist";
                    else
                        Loan = "spCheckSEExist";

                    using (SqlCommand cmd = new SqlCommand(Loan, kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ApplicationNum", DAD.ApplicationNumber);

                        cmd.Parameters.Add("@MobileNum", SqlDbType.NVarChar, 20);
                        cmd.Parameters["@MobileNum"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@AppliName", SqlDbType.NVarChar, 20);
                        cmd.Parameters["@AppliName"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@AppNum", SqlDbType.NVarChar, 20);
                        cmd.Parameters["@AppNum"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@FinancialYear", SqlDbType.NVarChar, 20);
                        cmd.Parameters["@FinancialYear"].Direction = ParameterDirection.Output;

                        kvdConn.Open();
                        cmd.ExecuteScalar();
                        kvdConn.Close();
                        DAD.MobileNum = cmd.Parameters["@MobileNum"].Value.ToString();
                        DAD.AppliName = cmd.Parameters["@AppliName"].Value.ToString();
                        DAD.FinancialYear = cmd.Parameters["@FinancialYear"].Value.ToString();

                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        cmd.ExecuteNonQuery();
                        kvdConn.Close();
                    }
                }
            }
            catch
            {
            }
        }
        public string GetIncomeCertificate(string RDNumber)
        {
            NadakacheriProcess NKAR = new NadakacheriProcess();
            NadaKacheri NKSER = new NadaKacheri();
            NKAR.GetCasteAndIncomeCertificate(RDNumber);
            return NKSER.NCLanguage;
        }
    }
}