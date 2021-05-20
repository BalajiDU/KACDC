using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string T1="", C1 = "blue", T2 = "", C2 = "", T3 = "", C3 = "", T4 = "", C4 = "";
            GetScrollText();
            //Scroll1.Text = "This is test";
            //string text = "Literal1 with Encode property example";
            //Scroll1.Text = "<font color="+C1+">"+text.ToUpper()+"</font>";
        }

        protected void GetScrollText()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                kvdConn.Open();
                
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KACDCSettings where id=1"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        Scroll1.Text = "<font color=" + sdr["Value1"].ToString() + ">" + sdr["Value"].ToString().ToUpper() + "</font>";
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KACDCSettings where id=2"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        Scroll2.Text = "<font color=" + sdr["Value1"].ToString() + ">" + sdr["Value"].ToString().ToUpper() + "</font>";
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KACDCSettings where id=3"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        Scroll3.Text = "<font color=" + sdr["Value1"].ToString() + ">" + sdr["Value"].ToString().ToUpper() + "</font>";
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM KACDCSettings where id=4"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        Scroll4.Text = "<font color=" + sdr["Value1"].ToString() + ">" + sdr["Value"].ToString().ToUpper() + "</font>";
                    }
                }
                kvdConn.Close();

            }
        }
    }
}