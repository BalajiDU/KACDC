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
using iTextSharp.text;
using iTextSharp.text.pdf;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;
using iTextSharp.text.html.simpleparser;

namespace KACDC
{
    public partial class AdminApprove : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "ADMINAPPROVE")
            {
                Response.Redirect("~/Login.aspx");

            }
            if (!this.IsPostBack)
            {
                this.FillAdminApproveGrid();
            }
        }

        private void FillAdminApproveGrid()
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "ARSELECTADMIN");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArivugvZMApprove.DataSource = ds;
                    ArivugvZMApprove.DataBind();

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    ArivugvZMApprove.DataSource = ds;
                    ArivugvZMApprove.DataBind();
                    int columncount = ArivugvZMApprove.Rows[0].Cells.Count;
                    ArivugvZMApprove.Rows[0].Cells.Clear();
                    ArivugvZMApprove.Rows[0].Cells.Add(new TableCell());
                    ArivugvZMApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                    ArivugvZMApprove.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }

        protected void btnAdminEditLoan_Click(object sender, EventArgs e)
        {
            lblInstalmentError1.Text = "";
            lblInstalmentError2.Text = "";
            lblInstalmentError3.Text = "";
            lblInstalmentError4.Text = "";
            lblInstalmentError5.Text = "";

            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblAdminEditApplicationNumber.Text = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblAdminEditApplicantName.Text = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicantName"].ToString();
            txtInstalment1.Text = ArivugvZMApprove.DataKeys[rowindex].Values["Year1Loan"].ToString();
            txtInstalment2.Text = ArivugvZMApprove.DataKeys[rowindex].Values["Year2Loan"].ToString();
            txtInstalment3.Text = ArivugvZMApprove.DataKeys[rowindex].Values["Year3Loan"].ToString();
            txtInstalment4.Text = ArivugvZMApprove.DataKeys[rowindex].Values["Year4Loan"].ToString();
            txtInstalment5.Text = ArivugvZMApprove.DataKeys[rowindex].Values["Year5Loan"].ToString();
            AdminEditPopup.Show();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
        protected void btnAdminReject_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblAdminRejApplicationNumber.Text = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblAdminRejApplicationName.Text = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicantName"].ToString();

            AdminRejectPopup.Show();
        }
        protected void AdminStatusUpdate(string status, string ApplicationNumber, string Reason = "")
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "ARREJECTADMIN")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.Parameters.AddWithValue("@ZMRejectReason", Reason);
                }
                else if (status == "ARAPPROVEADMIN")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }

                cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                ArivugvZMApprove.EditIndex = -1;
                //ArivuDMApproveBindGrid();
            }
        }
        protected void btnAdminApprove_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            AdminStatusUpdate("ARAPPROVEADMIN", ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString());
            this.FillAdminApproveGrid();
        }
        private void UpdateLoanAmount(string ApplicationNumber, string LA1 = "0", string LA2 = "0", string LA3 = "0", string LA4 = "0", string LA5 = "0")
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "ARADMINUPDATEAMOUNT");
                cmd.Parameters.AddWithValue("@1YearLoan", LA1);
                cmd.Parameters.AddWithValue("@2YearLoan", LA2);
                cmd.Parameters.AddWithValue("@3YearLoan", LA3);
                cmd.Parameters.AddWithValue("@4YearLoan", LA4);
                cmd.Parameters.AddWithValue("@5YearLoan", LA5);
                cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                cmd.ExecuteNonQuery();
            }
        }
    
        protected void txtInstalment1_TextChanged(object sender, EventArgs e)
        {
            AdminEditPopup.Show();

            if (Int32.TryParse(txtInstalment1.Text.Trim(), out int result))
                if (!CheckLoanAmount(result))
                {
                    lblInstalmentError1.Text = "Amount must be less than 100000";
                    AdminEditPopup.Show();
                }
        }
        private bool CheckLoanAmount(int Amount)
        {
            if (Amount < 100000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void txtInstalment2_TextChanged(object sender, EventArgs e)
        {
            AdminEditPopup.Show();
            //int result;
            if (Int32.TryParse(txtInstalment2.Text.Trim(), out int result))
                if (!CheckLoanAmount(result))
                {
                    lblInstalmentError2.Text = "Amount must be less than 100000";
                    AdminEditPopup.Show();
                }
        }

        protected void txtInstalment3_TextChanged(object sender, EventArgs e)
        {
            AdminEditPopup.Show();
            if (Int32.TryParse(txtInstalment3.Text.Trim(), out int result))
                if (!CheckLoanAmount(result))
                {
                    lblInstalmentError3.Text = "Amount must be less than 100000";
                    AdminEditPopup.Show();
                }
        }

        protected void txtInstalment4_TextChanged(object sender, EventArgs e)
        {
            AdminEditPopup.Show();
            if (Int32.TryParse(txtInstalment4.Text.Trim(), out int result))
                if (!CheckLoanAmount(result))
                {
                    lblInstalmentError4.Text = "Amount must be less than 100000";
                    AdminEditPopup.Show();
                }
        }

        protected void txtInstalment5_TextChanged(object sender, EventArgs e)
        {
            AdminEditPopup.Show();
            if (Int32.TryParse(txtInstalment5.Text.Trim(), out int result))
                if (!CheckLoanAmount(result))
                {
                    lblInstalmentError5.Text = "Amount must be less than 100000";
                    AdminEditPopup.Show();
                }
        }

        protected void btnAdminRejectUpdate_Click(object sender, EventArgs e)
        {
            AdminStatusUpdate("ARREJECTADMIN", lblAdminRejApplicationNumber.Text, txtAdminRejectReason.Text.Trim());
            this.FillAdminApproveGrid();
        }

        protected void btnUpdateLoanAmount_Click(object sender, EventArgs e)
        {
            lblInstalmentError1.Text = "";
            string loan1="0", loan2 = "0", loan3 = "0", loan4 = "0", loan5 = "0";
            if (txtInstalment1.Text.Trim() != null && txtInstalment1.Text.Trim() != "")
            {
                if (Int32.TryParse(txtInstalment1.Text.Trim(), out int num1) && txtInstalment1.Text.Trim() != null || txtInstalment1.Text.Trim() != "") { loan1 = txtInstalment1.Text.Trim(); }
                if (Int32.TryParse(txtInstalment2.Text.Trim(), out int num2) && txtInstalment2.Text.Trim() != null || txtInstalment2.Text.Trim() != "") { loan2 = txtInstalment2.Text.Trim(); }
                if (Int32.TryParse(txtInstalment3.Text.Trim(), out int num3) && txtInstalment3.Text.Trim() != null || txtInstalment3.Text.Trim() != "") { loan3 = txtInstalment3.Text.Trim(); }
                if (Int32.TryParse(txtInstalment4.Text.Trim(), out int num4) && txtInstalment4.Text.Trim() != null || txtInstalment4.Text.Trim() != "") { loan4 = txtInstalment4.Text.Trim(); }
                if (Int32.TryParse(txtInstalment5.Text.Trim(), out int num5) && txtInstalment5.Text.Trim() != null || txtInstalment5.Text.Trim() != "") { loan5 = txtInstalment5.Text.Trim(); }

                UpdateLoanAmount(lblAdminEditApplicationNumber.Text, loan1, loan2, loan3, loan4, loan5);
                this.FillAdminApproveGrid();
            }
            else
            {
                lblInstalmentError1.Text = "1st Instalment is Compulsory";
                AdminEditPopup.Show();
            }
            
        }
        private string getLoanAmount(string Amount)
        {
            return Amount;
        }
    }
}