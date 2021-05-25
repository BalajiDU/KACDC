using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.Schemes.Self_Employment
{
    public partial class SelfEmploymentPrerequisite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckEnableApplication();
        }
        protected void btnSE_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Schemes\Self Employment\Self_Employment_Application.aspx");
        }
        private void CheckEnableApplication()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                kvdConn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KACDCSettings where KeyVal=@Key"))
                {
                    cmd.Parameters.AddWithValue("@Key", "SEApplicationEnable");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        btnSE.Enabled = bool.Parse(sdr["Value"].ToString().ToUpper());
                    }
                }
                
                kvdConn.Close();
            }
        }
    }
}