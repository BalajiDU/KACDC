using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class
{
    public class GetFinancialYear
    {
        public void GetFY()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select Value from KACDCSettings where KeyVal='FinancialYear'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        HttpContext.Current.Session["FinancilaYear"] = sdr["Value"].ToString();

                    }
                    kvdConn.Close();
                }
            }
        }
    }
}