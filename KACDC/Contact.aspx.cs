using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace KACDC
{
    public partial class Contact : Page
    {
        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.DMKABindGrid();
                this.DMENBindGrid();
                this.ZMENBindGrid();
                this.ZMKABindGrid();
                this.HOENBindGrid();
                this.HOKABindGrid();
            }

        }
        private void HOKABindGrid()
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spGetContactHO", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "KANNADA");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvHOKAn.DataSource = ds;
                    gvHOKAn.DataBind();

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                }
            }
        }// gvHOKAn
        private void DMKABindGrid()
        {

            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT * FROM [DM Kannada]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvDMKan.DataSource = dt;
                        gvDMKan.DataBind();
                    }
                }
            }
        }
        private void DMENBindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT * FROM [DM English]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvDMENn.DataSource = dt;
                        gvDMENn.DataBind();
                    }
                }
            }
        }
        private void ZMENBindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT * FROM [ZM English]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvZMENn.DataSource = dt;
                        gvZMENn.DataBind();
                    }
                }
            }
        }
        private void ZMKABindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT * FROM [ZM Kannada]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvZMKAn.DataSource = dt;
                        gvZMKAn.DataBind();
                    }
                }
            }
        }
        private void HOENBindGrid()
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spGetContactHO", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "ENGLISH");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvHOENn.DataSource = ds;
                    gvHOENn.DataBind();

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                }
            }
        }
       


    }
}