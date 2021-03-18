using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
namespace KACDC
{
    public partial class Site : System.Web.UI.MasterPage
    {

        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

        private string FinancialYear
        {
            set { ViewState["FinancialYear"] = value; }
            get { return ViewState["FinancialYear"] as string; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (kvdConn)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[KACDCInfo]"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            lblCM.Text = sdr["CM Name"].ToString();
                            lblMinister.Text = sdr["Minister Name"].ToString();
                            lblChairman.Text = sdr["Chairman Name"].ToString();
                            FinancialYear = sdr["FinancialYear"].ToString();

                            ImgGOK.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["GOK"]);
                            Imgkacdc.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["KACDC"]);
                            ImgCM.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["CMPhoto"]);
                            ImgChairman.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["Minister Photo"]);
                            ImaMinister.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["Chairman Photo"]);

                        }
                        kvdConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}