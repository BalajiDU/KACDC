using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.Service
{
    public partial class UserTracker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "TRACKER")
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                gvSavedTaks.DataSource = SqlDataSource1;
                gvSavedTaks.DataBind();
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            SaveTask(Session["Name"].ToString(), txtWok.Text.Trim(), txtStart.Text.Trim(), txtEnd.Text.Trim(), drpStatus.SelectedValue, txtDisciption.Text.Trim());
            gvSavedTaks.DataSource = SqlDataSource1;
            gvSavedTaks.DataBind();
            //DisplayAlert(txtStart.Text, this);
        }
        public static void DisplayAlert(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            //page.ClientScript.RegisterStartupScript(owner.GetType(),"ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    message));
            ScriptManager.RegisterClientScriptBlock(owner, owner.GetType(), "alertMessage", "alert('" + message.ToUpper() + "')", true);
        }
        public void SaveTask(string User, string Work, string StartTime, string EndTime, string Status, string Discription)
        {
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spCreateTracker", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@User", User);
                        cmd.Parameters.AddWithValue("@Work", Work);
                        cmd.Parameters.AddWithValue("@StartTime", StartTime);
                        cmd.Parameters.AddWithValue("@EndTime", EndTime);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        cmd.Parameters.AddWithValue("@Discription", Discription);
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
    }
}