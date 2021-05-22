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
    public partial class Arivu_Renewal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    kvdConn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM KACDCSettings where KeyVal=@Key"))
                    {
                        cmd.Parameters.AddWithValue("@Key", "ArivuRenewalEnable");
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = kvdConn;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            if (bool.Parse(sdr["Value"].ToString().ToUpper()) != true)
                            {
                                Response.Redirect(@"~\Default.aspx");
                            }
                        }
                    }
                    kvdConn.Close();
                }
            }
        }
    }
}