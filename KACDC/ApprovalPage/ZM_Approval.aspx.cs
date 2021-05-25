using KACDC.Class.DataProcessing.ApplicationProcess;
using KACDC.Class.DataProcessing.ApplicationProcess.BankDetails;
using KACDC.Class.Declaration.ApprovalProcess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.ApprovalPage
{
    public partial class ZM_Approval : System.Web.UI.Page
    {
        GetDataToProcess GDTP = new GetDataToProcess();
        GetBankDetails GBD = new GetBankDetails();
        UpdateBankDetails UBD = new UpdateBankDetails();
        SBankDetails BD = new SBankDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "ZONALMANAGER")
            {
                Response.Redirect("~/Login.aspx");
                //UserName = Session["UserName"].ToString();
            }
            if (!IsPostBack)
            {
                this.fillDistrict();
                this.FillGrid();
            }
        }
        private void fillDistrict()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select DistrictName from MstDistrict where ZoneName=@District"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@District", Session["Zone"].ToString());
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpZoneSelDistrict.DataSource = cmd.ExecuteReader();
                    drpZoneSelDistrict.DataTextField = "DistrictName";
                    drpZoneSelDistrict.DataValueField = "DistrictName";
                    drpZoneSelDistrict.DataBind();
                    drpZoneSelDistrict.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
        }
        private void FillGrid()
        {
            if (drpZoneSelDistrict.SelectedItem.Text != "--SELECT--")
            {
                this.FillGridSelfEmployment();
                if (drpArivuSelectYear.SelectedItem.Text != "--SELECT--")
                {
                    this.FillGridArivu();
                }
            }
        }
        private void FillGridArivu()
        {
            if (drpZoneSelDistrict.SelectedItem.Text != "--SELECT--")
            {
                if (drpArivuSelectYear.SelectedItem.Text != "--SELECT--")
                {
                    gvZMARApproveProcess.DataSource = GDTP.GetData(drpArivuSelectYear.SelectedValue+"_ZM", drpZoneSelDistrict.SelectedValue);
                    gvZMARApproveProcess.DataBind();

                    gvZMARReleaseProcess.DataSource = GDTP.GetData(drpArivuSelectYear.SelectedValue + "_ZMRELEASE", drpZoneSelDistrict.SelectedValue);
                    gvZMARReleaseProcess.DataBind();
                }
            }
        }
        private void FillGridSelfEmployment()
        {
            if (drpZoneSelDistrict.SelectedItem.Text != "--SELECT--")
            {
                gvZMSEApproveProcess.DataSource = GDTP.GetData("SESELECTZM", drpZoneSelDistrict.SelectedValue);
                gvZMSEApproveProcess.DataBind();

                gvZMSEReleaseProcess.DataSource = GDTP.GetData("SESELECTRELEASE", drpZoneSelDistrict.SelectedValue);
                gvZMSEReleaseProcess.DataBind();
            }
        }
        protected void drpZoneSelDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillGrid();
        }
        protected void drpArivuSelectYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpZoneSelDistrict.SelectedItem.Text != "--SELECT--")
            {
                this.FillGrid();
            }
            else
            {
                DisplayAlert("Select District", this);
            }
        }
        protected void btnZMARDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblZMARBDApplicationNumber.Text = BD.ApplicationNumber;
            lblZMARBAccountHolderName.Text = BD.ApplicantName;
            lblZMARBAccountNumber.Text = BD.AccountNumber;
            lblZMARBBankName.Text = BD.BankName;
            lblZMARBBranch.Text = BD.Branch;
            lblZMARBIFSCCode.Text = BD.IFSCCode;
            lblZMARBBankAddress.Text = BD.BankAddress;
            ZMARBankDetailsPopup.Show();
        }
        protected void btnZMARDisplayBankDetailsUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblZMARBDUpdateApplicationNumber.Text = BD.ApplicationNumber;
            lblZMARBDUpdateAccountHolderName.Text = BD.ApplicantName;
            txtZMARBDUpdateAccountNumber.Text = BD.AccountNumber;
            txtZMARBDUpdateBankName.Text = BD.BankName;
            txtZMARBDUpdateBranchName.Text = BD.Branch;
            txtZMARBDUpdateIFSCCode.Text = BD.IFSCCode;
            txtZMARBDUpdateBankAddress.Text = BD.BankAddress;
            ZMARBankDetailsUpdatePopup.Show();
        }
        protected void btnZMSEDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblZMSEBDApplicationNumber.Text = BD.ApplicationNumber;
            lblZMSEBAccountHolderName.Text = BD.ApplicantName;
            lblZMSEBAccountNumber.Text = BD.AccountNumber;
            lblZMSEBBankName.Text = BD.BankName;
            lblZMSEBBranch.Text = BD.Branch;
            lblZMSEBIFSCCode.Text = BD.IFSCCode;
            lblZMSEBBankAddress.Text = BD.BankAddress;
            ZMSEBankDetailsPopup.Show();
        }
        protected void btnZMSEDisplayBankDetailsUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblZMSEBDUpdateApplicationNumber.Text = BD.ApplicationNumber;
            lblZMSEBDUpdateAccountHolderName.Text = BD.ApplicantName;
            txtZMSEBDUpdateAccountNumber.Text = BD.AccountNumber;
            txtZMSEBDUpdateBankName.Text = BD.BankName;
            txtZMSEBDUpdateBranchName.Text = BD.Branch;
            txtZMSEBDUpdateIFSCCode.Text = BD.IFSCCode;
            txtZMSEBDUpdateBankAddress.Text = BD.BankAddress;
            ZMSEBankDetailsUpdatePopup.Show();
        }
        protected void btnZMSEReleaseBankDetailsUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblZMSEBDUpdateReleaseApplicationNumber.Text = BD.ApplicationNumber;
            lblZMSEBDUpdateReleaseAccountHolderName.Text = BD.ApplicantName;
            txtZMSEBDUpdateReleaseAccountNumber.Text = BD.AccountNumber;
            txtZMSEBDUpdateReleaseBankName.Text = BD.BankName;
            txtZMSEBDUpdateReleaseBranchName.Text = BD.Branch;
            txtZMSEBDUpdateReleaseIFSCCode.Text = BD.IFSCCode;
            txtZMSEBDUpdateReleaseBankAddress.Text = BD.BankAddress;
            ZMSEBankDetailsUpdateReleasePopup.Show();
        }
        protected void btnZMARReleaseBankDetailsUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblZMARBDUpdateReleaseApplicationNumber.Text = BD.ApplicationNumber;
            lblZMARBDUpdateReleaseAccountHolderName.Text = BD.ApplicantName;
            txtZMARBDUpdateReleaseAccountNumber.Text = BD.AccountNumber;
            txtZMARBDUpdateReleaseBankName.Text = BD.BankName;
            txtZMARBDUpdateReleaseBranchName.Text = BD.Branch;
            txtZMARBDUpdateReleaseIFSCCode.Text = BD.IFSCCode;
            txtZMARBDUpdateReleaseBankAddress.Text = BD.BankAddress;
            ZMARBankDetailsUpdateReleasePopup.Show();
        }
        protected void drpZoneSESanction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnCWLogout_Click(object sender, EventArgs e)
        {

        }
        protected void btnOldProcess_Click(object sender, EventArgs e)
        {

        }
        protected void lnkbtnArivuCEODoc_Click(object sender, EventArgs e)
        {

        }
        
        protected void btnZMARDisplayCollegeDetails_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARApprove_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARHold_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARReturn_Click(object sender, EventArgs e)
        {

        }
        protected void btnARZMGenerateReport_Click(object sender, EventArgs e)
        {

        }
        protected void btnARZMSubmit_Click(object sender, EventArgs e)
        {

        }
        protected void btnARZMExportExcel_Click(object sender, EventArgs e)
        {

        }
        protected void btnARZMPrintReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARConfirmRejectApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARConfirmHoldApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARConfirmReturnApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARConfirmApproveApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnPnlCollegeDetailsClose_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARBDUpdate_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMArivuReleased_Click(object sender, EventArgs e)
        {

        }
        protected void rbZMARConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void rbZMSEConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void btnZMARConfirmReleaseApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARBDUpdateRelease_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMARGetApplicationStatus_Click(object sender, EventArgs e)
        {

        }
        protected void lnkbtnSECEODoc_Click(object sender, EventArgs e)
        {

        }
        
        protected void btnZMSEApprove_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMSEHold_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMASEReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnSEZMGenerateReport_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMASEReturn_Click(object sender, EventArgs e)
        {

        }
        protected void btnSEZMSubmit_Click(object sender, EventArgs e)
        {

        }
        protected void btnSEZMExportExcel_Click(object sender, EventArgs e)
        {

        }
        protected void btnSEZMPrintReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMSEConfirmHoldApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMSEConfirmReturnApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMSEConfirmApproveApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMSEConfirmRejectApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMSEBDUpdate_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMSEReleased_Click(object sender, EventArgs e)
        {

        }
        
        protected void btnSEZMReleaseGenerateReport_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMSEConfirmReleaseApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMSEBDUpdateRelease_Click(object sender, EventArgs e)
        {

        }
        protected void btnZMSEGetApplicationStatus_Click(object sender, EventArgs e)
        {

        }
        
        
        protected void btnARZMReleaseGenerateReport_Click(object sender, EventArgs e)
        {

        }
        protected void gvZMSEApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void gvZMARApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        public static void DisplayAlert(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            //page.ClientScript.RegisterStartupScript(owner.GetType(),"ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    message));
            ScriptManager.RegisterClientScriptBlock(owner, owner.GetType(), "alertMessage", "alert('" + message.ToUpper() + "')", true);
        }
    }
}