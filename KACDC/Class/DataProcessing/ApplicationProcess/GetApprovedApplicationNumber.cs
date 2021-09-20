using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess
{
    public class GetApprovedApplicationNumber
    {
        public string GetLoanNumber(string ApplicationNumber, string Scheme)
        {
            try
            {
                if (ApplicationNumber != "")
                {
                    if (Scheme != "")
                    {
                        //string LoanName = Scheme == "AR" ? "ArivuEduLoan" : "SelfEmpLoan";
                        using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                        {
                            if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                            SqlDataAdapter DAcmd = new SqlDataAdapter("SELECT ApprovedApplicationNum FROM " + Scheme + " WHERE ApplicationNumber= @AppnNumber", kvdConn);
                            DAcmd.SelectCommand.Parameters.AddWithValue("@AppnNumber", ApplicationNumber);
                            DataTable dt = new DataTable();
                            DAcmd.Fill(dt);

                            return dt.Rows[0]["ApprovedApplicationNum"].ToString();
                        }
                    }
                }
                return "NA";
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return "NA";
            }
        }
    }
}