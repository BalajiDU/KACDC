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
using KACDC.Class.DataProcessing.MasterPage;
using KACDC.Class.Declaration.MasterPageData;

namespace KACDC
{
    public partial class Site : System.Web.UI.MasterPage
    {
        MasterSettings MS = new MasterSettings();
        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
        MasterPageData MPD = new MasterPageData();
        private string FinancialYear
        {
            set { ViewState["FinancialYear"] = value; }
            get { return ViewState["FinancialYear"] as string; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["LoginLogout"] = "Login";
            }
            try
            {
                if (true)
                {
                    string[] str = new string[5];
                    str=MS.GetData("GET","CMName");
                    MPD.CMName = str[0];

                    str=MS.GetData("GET", "MinisterName");
                    MPD.MinisterName = str[0];

                    str =MS.GetData("GET", "ChairmanName");
                    MPD.ChairmanName = str[0];

                    str =MS.GetData("GET", "CMPhoto");
                    MPD.CMPhoto = str[0];
                    str =MS.GetData("GET", "MinisterPhoto");
                    MPD.MinisterPhoto = str[0];
                    str =MS.GetData("GET", "ChairmanPhoto");
                    MPD.ChairmanPhoto = str[0];
                    str =MS.GetData("GET", "GOKLogo");
                    MPD.GOKLogo = str[0];
                    str =MS.GetData("GET", "KACDCLogo");
                    MPD.KACDCLogo = str[0];
                    str =MS.GetData("GET", "FinancialYear");
                    MPD.FinancialYear = str[0];


                    lblCM.Text = MPD.CMName;
                    lblMinister.Text = MPD.MinisterName;
                    lblChairman.Text = MPD.ChairmanName;
                    FinancialYear = MPD.FinancialYear;

                    //ImgGOK.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["GOK"]);
                    ImgGOK.ImageUrl = MPD.GOKLogo;
                    Imgkacdc.ImageUrl = MPD.KACDCLogo;
                    ImgCM.ImageUrl = MPD.CMPhoto;
                    ImgChairman.ImageUrl = MPD.ChairmanPhoto;
                    ImaMinister.ImageUrl = MPD.MinisterPhoto;
                }
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
                            //lblCM.Text = MPD.CMName;
                            ////lblCM.Text = sdr["CM Name"].ToString();
                            //lblMinister.Text = sdr["Minister Name"].ToString();
                            //lblChairman.Text = sdr["Chairman Name"].ToString();
                            //FinancialYear = sdr["FinancialYear"].ToString();

                            ////ImgGOK.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["GOK"]);
                            //ImgGOK.ImageUrl = "https://aryavysya.karnataka.gov.in/image/chairman.jpeg";
                            //Imgkacdc.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["KACDC"]);
                            //ImgCM.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["CMPhoto"]);
                            //ImgChairman.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["Minister Photo"]);
                            //ImaMinister.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["Chairman Photo"]);

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
        protected void btnLoginLogout_Click(object sender, EventArgs e)
        {
            //if (btnLoginLogout.InnerText.ToUpper() == "LOGIN")
            //{
            //    Response.Redirect(@"~\Login.aspx");
            //    btnLoginLogout.InnerText = "Logout";
            //}
            //else if(btnLoginLogout.InnerText.ToUpper() == "LOGOUT")
            //{
            //    btnLoginLogout.InnerText = "Login";
            //    Session.Clear();
            //    Response.Redirect("~/Login.aspx");
            //}
        }
    }
}