using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.Schemes.Arivu
{
    public partial class ArivuPrerequisite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckEnableApplication();
        }
        protected void btnArivu_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\DownloadAppn.aspx");
        }
        protected void btnRenewal_Click(object sender, EventArgs e)
        {
            
        }
        private void CheckEnableApplication()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                kvdConn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KACDCSettings where KeyVal=@Key"))
                {
                    cmd.Parameters.AddWithValue("@Key", "ArivuApplicationEnable");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        btnArivu.Enabled = bool.Parse(sdr["Value"].ToString().ToUpper()) ;
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KACDCSettings where KeyVal=@Key"))
                {
                    cmd.Parameters.AddWithValue("@Key", "ArivuRenewalEnable");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        btnRenewal.Enabled = bool.Parse(sdr["Value"].ToString().ToUpper()) ;
                    }
                }
                kvdConn.Close();
            }
        }
    }
}