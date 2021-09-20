using KACDC.Class.DataProcessing;
using KACDC.Class.DataProcessing.ApplicationProcess;
using KACDC.Class.DataProcessing.ApplicationProcess.BankDetails;
using KACDC.Class.DataProcessing.FileProcessing.CreatePDF.ApplicationProcess;
using KACDC.Class.Declaration.ApprovalProcess;
using KACDC.Class.GetCountStatistics;
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
        ApprovalProcess AP = new ApprovalProcess();
        GetCount GC = new GetCount();
        GetApprovedApplicationNumber GAAN = new GetApprovedApplicationNumber();
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
                    gvZMARApproveProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess",drpArivuSelectYear.SelectedValue+"_ZM", drpZoneSelDistrict.SelectedValue);
                    gvZMARApproveProcess.DataBind();

                    gvZMARReleaseProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess",drpArivuSelectYear.SelectedValue + "_ZMRELEASE", drpZoneSelDistrict.SelectedValue);
                    gvZMARReleaseProcess.DataBind();
                }
            }
        }
        private void FillGridSelfEmployment()
        {
            if (drpZoneSelDistrict.SelectedItem.Text != "--SELECT--")
            {
                gvZMSEApproveProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess","SESELECTZM", drpZoneSelDistrict.SelectedValue);
                gvZMSEApproveProcess.DataBind();

                gvZMSEReleaseProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess","SESELECTRELEASE", drpZoneSelDistrict.SelectedValue);
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
            GBD.GetApplicantBankDetails(gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
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
            GBD.GetApplicantBankDetails(gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
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
            GBD.GetApplicantBankDetails(gvZMSEReleaseProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
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
            GBD.GetApplicantBankDetails(gvZMARReleaseProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
            lblZMARBDUpdateReleaseApplicationNumber.Text = BD.ApplicationNumber;
            lblZMARBDUpdateReleaseAccountHolderName.Text = BD.ApplicantName;
            txtZMARBDUpdateReleaseAccountNumber.Text = BD.AccountNumber;
            txtZMARBDUpdateReleaseBankName.Text = BD.BankName;
            txtZMARBDUpdateReleaseBranchName.Text = BD.Branch;
            txtZMARBDUpdateReleaseIFSCCode.Text = BD.IFSCCode;
            txtZMARBDUpdateReleaseBankAddress.Text = BD.BankAddress;
            ZMARBankDetailsUpdateReleasePopup.Show();
        }
        protected void btnZMARApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblZMARConfirmApproveAppNumber.Text = gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblZMARConfirmApproveAppName.Text = gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ZMARConfirmApprovePopup.Show();
        }
        protected void btnZMARConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate(drpArivuSelectYear.SelectedValue,"APPROVED", lblZMARConfirmApproveAppNumber.Text);
            
            lblARNotificationHeading.Text = "Approved Application Number of <br />"+ lblZMARConfirmApproveAppName.Text +" <br />";
            this.FillGridArivu();
            lblARNotificationContent.Text= GAAN.GetLoanNumber(lblZMARConfirmApproveAppNumber.Text, "ArivuEduLoan");
            AROtherDetailsPopup.Show();
        }
        protected void btnZMSEApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblZMSEConfirmApproveAppNumber.Text = gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblZMSEConfirmApproveAppName.Text = gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ZMSEConfirmApprovePopup.Show();
        }
        protected void btnZMSEConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate("SEZMPROCESS", "APPROVED", lblZMSEConfirmApproveAppNumber.Text);

            lblSENotificationHeading.Text = "Approved Application Number of <br />" + lblZMSEConfirmApproveAppName.Text + " <br />";
            this.FillGridSelfEmployment();
            lblSENotificationContent.Text = GAAN.GetLoanNumber(lblZMSEConfirmApproveAppNumber.Text, "SelfEmpLoan");
            SEOtherDetailsPopup.Show();
        }
        protected void btnZMARHold_Click(object sender, EventArgs e)
        {
            if (drpArivuSelectYear.SelectedValue == "1ST_INSTALMENT")
            {
                txtZMARConfirmHoldAppReason.Text = "";
                lblZMARConfirmHoldAppReasonError.Text = "";
                Button btn = (Button)sender;
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                int rowindex = gvr.RowIndex;
                lblZMARConfirmHoldAppNumber.Text = gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
                lblZMARConfirmHoldAppName.Text = gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
                ZMARConfirmHoldPopup.Show();
            }
            else
            {
                DisplayAlert("Only 1ST INSTALMENT application can be hold", this);
            }
        }
        protected void btnZMSEHold_Click(object sender, EventArgs e)
        {

            txtZMSEConfirmHoldAppReason.Text = "";
            lblZMSEConfirmHoldAppReasonError.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblZMSEConfirmHoldAppNumber.Text = gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblZMSEConfirmHoldAppName.Text = gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ZMSEConfirmHoldPopup.Show();

        }
        protected void btnZMARConfirmHoldApplication_Click(object sender, EventArgs e)
        {
            lblZMARConfirmHoldAppReasonError.Text = "";
            if (txtZMARConfirmHoldAppReason.Text.Trim() != "")
            {
                if (txtZMARConfirmHoldAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate(drpArivuSelectYear.SelectedValue + "HOLD", "HOLD", lblZMARConfirmHoldAppNumber.Text.Trim(), txtZMARConfirmHoldAppReason.Text.Trim());
                    this.FillGridArivu();
                }
                else
                {
                    lblZMARConfirmHoldAppReasonError.Text = "ENTER VALID REASON FOR HOLD (MINIMUM OF 10 CHARACTERS)";
                    ZMARConfirmHoldPopup.Show();
                }
            }
            else
            {
                lblZMARConfirmHoldAppReasonError.Text = "ENTER REASON FOR HOLD";
                ZMARConfirmHoldPopup.Show();
            }
        }
        protected void btnZMSEConfirmHoldApplication_Click(object sender, EventArgs e)
        {
            lblZMSEConfirmHoldAppReasonError.Text = "";
            if (txtZMSEConfirmHoldAppReason.Text.Trim() != "")
            {
                if (txtZMSEConfirmHoldAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("SEZMPROCESS", "HOLD", lblZMSEConfirmHoldAppNumber.Text.Trim(), txtZMSEConfirmHoldAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    lblZMSEConfirmHoldAppReasonError.Text = "ENTER VALID REASON FOR HOLD (MINIMUM OF 10 CHARACTERS)";
                    ZMSEConfirmHoldPopup.Show();
                }
            }
            else
            {
                lblZMSEConfirmHoldAppReasonError.Text = "ENTER REASON FOR HOLD";
                ZMSEConfirmHoldPopup.Show();
            }
        }
        protected void rbZMARConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {
            lblZMARConfirmRejectAppReasonSelectionError.Text = "";
            lblZMARConfirmRejectAppReasonError.Text = "";
            if (rbZMARConfirmRejectReasonName.Checked)
            {
                txtZMARConfirmRejectAppReason.Text = "Aadhaar and Caste & Income Certificate Name Mismatch";
                divZMARRejectReason.Visible = true;
                ZMARConfirmRejectPopup.Show();
            }
            else if (rbZMARConfirmRejectReasonCET.Checked)
            {
                txtZMARConfirmRejectAppReason.Text = "Invalid CET Certificate is submitted";
                divZMARRejectReason.Visible = true;
                ZMARConfirmRejectPopup.Show();
            }
            else if (rbZMARConfirmRejectReasonOther.Checked)
            {
                txtZMARConfirmRejectAppReason.Text = "";
                divZMARRejectReason.Visible = true;
                ZMARConfirmRejectPopup.Show();
            }
        }
        protected void rbZMSEConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {
            lblZMSEConfirmRejectAppReasonSelectionError.Text = "";
            lblZMSEConfirmRejectAppReasonError.Text = "";
            if (rbZMSEConfirmRejectReasonName.Checked)
            {
                txtZMSEConfirmRejectAppReason.Text = "Aadhaar and Caste & Income Certificate Name Mismatch";
                divZMSERejectReason.Visible = true;
                ZMSEConfirmRejectPopup.Show();
            }
            else if (rbZMSEConfirmRejectReasonOther.Checked)
            {
                txtZMSEConfirmRejectAppReason.Text = "";
                divZMSERejectReason.Visible = true;
                ZMSEConfirmRejectPopup.Show();
            }
        }
        protected void btnZMARReject_Click(object sender, EventArgs e)
        {
            rbZMARConfirmRejectReasonName.Checked = false;
            rbZMARConfirmRejectReasonCET.Checked = false;
            rbZMARConfirmRejectReasonOther.Checked = false;
            divZMARRejectReason.Visible = false;
            lblZMARConfirmRejectAppReasonError.Text = "";
            lblZMARConfirmRejectAppReasonSelectionError.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblZMARConfirmRejectAppNumber.Text = gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblZMARConfirmRejectAppName.Text = gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ZMARConfirmRejectPopup.Show();
        }
        protected void btnZMSEReject_Click(object sender, EventArgs e)
        {
            rbZMSEConfirmRejectReasonName.Checked = false;
            rbZMSEConfirmRejectReasonOther.Checked = false;
            divZMSERejectReason.Visible = false;
            lblZMSEConfirmRejectAppReasonError.Text = "";
            lblZMSEConfirmRejectAppReasonSelectionError.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblZMSEConfirmRejectAppNumber.Text = gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblZMSEConfirmRejectAppName.Text = gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ZMSEConfirmRejectPopup.Show();
        }
        protected void btnZMARConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            lblZMARConfirmRejectAppReasonSelectionError.Text = "";
            lblZMARConfirmRejectAppReasonError.Text = "";
            if (rbZMARConfirmRejectReasonName.Checked || rbZMARConfirmRejectReasonCET.Checked || rbZMARConfirmRejectReasonOther.Checked)
            {
                lblZMARConfirmRejectAppReasonSelectionError.Text = "";
                if (lblZMARConfirmRejectAppReasonSelectionError.Text.Trim().Length > 10)
                {
                    lblZMARConfirmRejectAppReasonError.Text = "";
                    AP.ApplicationStatusUpdate(drpArivuSelectYear.SelectedValue + "REJECTED", "REJECTED", lblZMARConfirmRejectAppNumber.Text.Trim(), txtZMARConfirmRejectAppReason.Text.Trim());
                    this.FillGridArivu();
                }
                else
                {
                    lblZMARConfirmRejectAppReasonError.Text = "Enter Valid Reason to reject application(minium 10 characters)";
                    ZMARConfirmRejectPopup.Show();
                }
            }
            else
            {
                lblZMARConfirmRejectAppReasonSelectionError.Text = "Select any reason to REJECT application";
                ZMARConfirmRejectPopup.Show();
            }
        }
        protected void btnZMSEConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            lblZMSEConfirmRejectAppReasonSelectionError.Text = "";
            lblZMSEConfirmRejectAppReasonError.Text = "";
            if (rbZMSEConfirmRejectReasonName.Checked ||  rbZMSEConfirmRejectReasonOther.Checked)
            {
                lblZMSEConfirmRejectAppReasonSelectionError.Text = "";
                if (txtZMSEConfirmRejectAppReason.Text.Trim().Length > 10)
                {
                    lblZMSEConfirmRejectAppReasonError.Text = "";
                    AP.ApplicationStatusUpdate("SEZMPROCESS", "REJECTED", lblZMSEConfirmRejectAppNumber.Text.Trim(), txtZMSEConfirmRejectAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    lblZMSEConfirmRejectAppReasonError.Text = "Enter Valid Reason to reject application(minium 10 characters)";
                    ZMSEConfirmRejectPopup.Show();
                }
            }
            else
            {
                lblZMSEConfirmRejectAppReasonSelectionError.Text = "Select any reason to REJECT application";
                ZMSEConfirmRejectPopup.Show();
            }
        }
        protected void btnZMARReturn_Click(object sender, EventArgs e)
        {
            if (drpArivuSelectYear.SelectedValue == "1ST_INSTALMENT")
            {
                txtZMARConfirmReturnAppReason.Text = "";
                lblZMARConfirmReturnAppReasonError.Text = "";
                Button btn = (Button)sender;
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                int rowindex = gvr.RowIndex;
                lblZMARConfirmReturnAppNumber.Text = gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
                lblZMARConfirmReturnAppName.Text = gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
                ZMARConfirmReturnPopup.Show();
            }
            else
            {
                DisplayAlert("Only 1ST INSTALMENT application can be return",this);
            }
        }
        protected void btnZMSEReturn_Click(object sender, EventArgs e)
        {
            txtZMSEConfirmReturnAppReason.Text = "";
            lblZMSEConfirmReturnAppReasonError.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblZMSEConfirmReturnAppNumber.Text = gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblZMSEConfirmReturnAppName.Text = gvZMSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ZMSEConfirmReturnPopup.Show();
        }
        protected void btnZMARConfirmReturnApplication_Click(object sender, EventArgs e)
        {
            lblZMARConfirmReturnAppReasonError.Text = "";
            if (txtZMARConfirmReturnAppReason.Text.Trim().Length > 10)
            {
                AP.ApplicationStatusUpdate("ARDOCPROCESS", "RETURNED", lblZMARConfirmReturnAppNumber.Text.Trim(), txtZMARConfirmReturnAppReason.Text.Trim());
                this.FillGridArivu();
            }
            else
            {
                lblZMARConfirmReturnAppReasonError.Text = "Enter valid reason to return application to DM";
                ZMARConfirmReturnPopup.Show();
            }

        }
        protected void btnZMSEConfirmReturnApplication_Click(object sender, EventArgs e)
        {
            lblZMSEConfirmReturnAppReasonError.Text = "";
            if (txtZMSEConfirmReturnAppReason.Text.Trim().Length > 10)
            {
                AP.ApplicationStatusUpdate("SEDOCPROCESS", "RETURNED", lblZMSEConfirmReturnAppNumber.Text.Trim(), txtZMSEConfirmReturnAppReason.Text.Trim());
                this.FillGridSelfEmployment();
            }
            else
            {
                lblZMSEConfirmReturnAppReasonError.Text = "Enter valid reason to return application to DM";
                ZMSEConfirmReturnPopup.Show();
            }

        }
        protected void btnZMArivuReleased_Click(object sender, EventArgs e)
        {
            if (txtZMARReleaseChequeNumber.Text.Trim() != "")
            {
                if (txtZMARReleaseChequeDate.Text.Trim() != "")
                {
                    Button btn = (Button)sender;
                    GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                    int rowindex = gvr.RowIndex;
                    lblZMARConfirmReleaseAppNumber.Text = gvZMARReleaseProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
                    lblZMARConfirmReleaseAppName.Text = gvZMARReleaseProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
                    lblZMARConfirmReleaseLoanNumber.Text = gvZMARReleaseProcess.DataKeys[rowindex].Values["ApprovedApplicationNum"].ToString();
                    lblZMARConfirmReleaseChequeNumber.Text = txtZMARReleaseChequeNumber.Text.Trim();
                    lblZMARConfirmReleaseChequeDate.Text = txtZMARReleaseChequeDate.Text.Trim();
                    ZMARConfirmReleasePopup.Show();
                    ZMSEConfirmReleasePopup.Show();
                }
                else
                {
                    DisplayAlert("Select Cheque Date", this);
                }
            }
            else
            {
                DisplayAlert("Enter Cheque number", this);
            }

        }
        protected void btnZMSEReleased_Click(object sender, EventArgs e)
        {
            if (txtZMSEReleaseChequeNumber.Text.Trim() != "")
            {
                if (txtZMSEReleaseChequeDate.Text.Trim() != "")
                {
                    Button btn = (Button)sender;
                    GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                    int rowindex = gvr.RowIndex;
                    lblZMSEConfirmReleaseAppNumber.Text = gvZMSEReleaseProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
                    lblZMSEConfirmReleaseAppName.Text = gvZMSEReleaseProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
                    lblZMSEConfirmReleaseLoanNumber.Text = gvZMSEReleaseProcess.DataKeys[rowindex].Values["ApprovedApplicationNum"].ToString();
                    lblZMSEConfirmReleaseChequeNumber.Text = txtZMSEReleaseChequeNumber.Text.Trim();
                    lblZMSEConfirmReleaseChequeDate.Text = txtZMSEReleaseChequeDate.Text.Trim();
                    ZMSEConfirmReleasePopup.Show();
                }
                else
                {
                    DisplayAlert("Select Cheque Date", this);
                }
            }
            else
            {
                DisplayAlert("Enter Cheque number", this);
            }
            
        }
        protected void btnZMARDisplayCollegeDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;

            ApplicantPDFMerge PMerge = new ApplicantPDFMerge();
            
            string FileName = gvZMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString() + "_" + gvZMARApproveProcess.DataKeys[rowindex].Values["AadharNum"].ToString() + ".pdf";
            Server.MapPath("~/Files_Arivu/App/AdmisionTicket/" + FileName);
            Server.MapPath("~/Files_Arivu/App/CollegeHostel/" + FileName);
            Server.MapPath("~/Files_Arivu/App/FeesStructure/" + FileName);
            Server.MapPath("~/Files_Arivu/App/PreviousMarksCard/" + FileName);
            Server.MapPath("~/Files_Arivu/App/StudyCertificate/" + FileName);
            string[] ApplicantFiles = {
                Server.MapPath("~/Files_Arivu/App/AdmisionTicket/" + FileName),
                Server.MapPath("~/Files_Arivu/App/CollegeHostel/" + FileName),
                Server.MapPath("~/Files_Arivu/App/FeesStructure/" + FileName),
                Server.MapPath("~/Files_Arivu/App/PreviousMarksCard/" + FileName),
                Server.MapPath("~/Files_Arivu/App/StudyCertificate/" + FileName),
            };
            PMerge.PDFMerge(ApplicantFiles, FileName, Server.MapPath("~/Files_Arivu/App/TempCollegeFile/"));


            
            Server.MapPath("~/Files_Arivu/App/TempCollegeFile/" + FileName);






            string destinationFileName = @"Merged.pdf";

            // Merge 1 with (2, 3) and form destination  
            //PDFFile pdfFile = new PDFFile(sourceFileName1);
            //pdfFile.MergeWith(new string[] { sourceFileName2, sourceFileName3 }, destinationFileName);

            
        }
        protected void btnZMSEConfirmReleaseApplication_Click(object sender, EventArgs e)
        {
            if (txtZMSEReleaseChequeNumber.Text.Trim() != "")
            {
                if (txtZMSEReleaseChequeDate.Text.Trim() != "")
                {
                    if (lblZMSEConfirmReleaseAppNumber.Text != "")
                    {
                        AP.ApplicationStatusUpdate("SESERELEASE", "APPROVED", lblZMSEConfirmReleaseAppNumber.Text.Trim());
                        AP.ApplicationStatusUpdate("SECHEQUENUMDATE", txtZMSEReleaseChequeNumber.Text.Trim(), lblZMSEConfirmReleaseAppNumber.Text.Trim(), txtZMSEReleaseChequeDate.Text.Trim());
                        this.FillGridSelfEmployment();
                    }
                }
                else
                {
                    DisplayAlert("Select Cheque Date", this);
                }
            }
            else
            {
                DisplayAlert("Enter Cheque number", this);
            }
        }
        //Last
        protected void drpZoneSESanction_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void btnCWLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
        protected void btnOldProcess_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ZM_Form.aspx");
        }
        protected void lnkbtnArivuCEODoc_Click(object sender, EventArgs e)
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
        
        protected void btnPnlCollegeDetailsClose_Click(object sender, EventArgs e)
        {

        }

        protected void btnZMARBDUpdate_Click(object sender, EventArgs e)
        {
            if (lblZMARBDUpdateApplicationNumber.Text != "")
            {
                if (txtZMARBDUpdateAccountNumber.Text.Trim() != "")
                {
                    if (txtZMARBDUpdateBankName.Text.Trim() != "")
                    {
                        if (txtZMARBDUpdateBranchName.Text.Trim() != "")
                        {
                            if (txtZMARBDUpdateIFSCCode.Text.Trim() != "")
                            {
                                if (txtZMARBDUpdateBankAddress.Text.Trim() != "")
                                {
                                    if (drpZMARBankModifyReason.SelectedValue != "0")
                                    {
                                        UBD.UpdateBankDetailsToDB(lblZMARBDUpdateApplicationNumber.Text, txtZMARBDUpdateAccountNumber.Text.Trim(), txtZMARBDUpdateBankName.Text.Trim(), txtZMARBDUpdateIFSCCode.Text.Trim(), txtZMARBDUpdateBranchName.Text.Trim(), txtZMARBDUpdateBankAddress.Text.Trim()
                                            , drpZMARBankModifyReason.SelectedValue, lblZMARBDUpdateAccountHolderName.Text, "Arivu");
                                        this.FillGridArivu();
                                    }
                                    else
                                    {
                                        DisplayAlert("sELECT REASON", this);
                                        ZMARBankDetailsUpdatePopup.Show();
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Enter bank address", this);
                                    ZMARBankDetailsUpdatePopup.Show();
                                }
                            }
                            else
                            {
                                DisplayAlert("Enter IFSC Code", this);
                                ZMARBankDetailsUpdatePopup.Show();
                            }
                        }
                        else
                        {
                            DisplayAlert("Enter Branch Name", this);
                            ZMARBankDetailsUpdatePopup.Show();
                        }
                    }
                    else
                    {
                        DisplayAlert("Enter Bank Name", this);
                        ZMARBankDetailsUpdatePopup.Show();
                    }
                }
                else
                {
                    DisplayAlert("Enter Application Number", this);
                    ZMARBankDetailsUpdatePopup.Show();
                }
            }
           // UBD.UpdateBankDetailsToDB();
        }



        protected void btnZMARConfirmReleaseApplication_Click(object sender, EventArgs e)
        {
            if (txtZMARReleaseChequeNumber.Text.Trim() != "")
            {
                if (txtZMARReleaseChequeDate.Text.Trim() != "")
                {
                    if (lblZMARConfirmReleaseAppNumber.Text != "")
                    {
                        AP.ApplicationStatusUpdate(drpArivuSelectYear.SelectedValue+"RELEASED", "RELEASED", lblZMARConfirmReleaseAppNumber.Text);
                        AP.ApplicationStatusUpdate(drpArivuSelectYear.SelectedValue+"CHEQUENUMDATE", txtZMARReleaseChequeNumber.Text.Trim(), lblZMARConfirmReleaseAppNumber.Text.Trim(), txtZMARReleaseChequeDate.Text.Trim());

                        this.FillGridArivu();
                    }
                }
                else
                {
                    DisplayAlert("Select Cheque Date", this);
                }
            }
            else
            {
                DisplayAlert("Enter Cheque number", this);
            }

            
        }
        protected void btnZMARBDUpdateRelease_Click(object sender, EventArgs e)
        {
            if (lblZMARBDUpdateReleaseApplicationNumber.Text != "")
            {
                if (txtZMARBDUpdateReleaseAccountNumber.Text.Trim() != "")
                {
                    if (txtZMARBDUpdateReleaseBankName.Text.Trim() != "")
                    {
                        if (txtZMARBDUpdateReleaseBranchName.Text.Trim() != "")
                        {
                            if (txtZMARBDUpdateReleaseIFSCCode.Text.Trim() != "")
                            {
                                if (txtZMARBDUpdateReleaseBankAddress.Text.Trim() != "")
                                {
                                    if (drpZMARBankModifyReleaseReason.SelectedValue != "0")
                                    {
                                        UBD.UpdateBankDetailsToDB(lblZMARBDUpdateReleaseApplicationNumber.Text, txtZMARBDUpdateReleaseAccountNumber.Text.Trim(), txtZMARBDUpdateReleaseBankName.Text.Trim(), txtZMARBDUpdateReleaseIFSCCode.Text.Trim(), txtZMARBDUpdateReleaseBranchName.Text.Trim(), txtZMARBDUpdateReleaseBankAddress.Text.Trim()
                                            , drpZMARBankModifyReleaseReason.SelectedValue, lblZMARBDUpdateReleaseAccountHolderName.Text, "Arivu");
                                        this.FillGridArivu();
                                    }
                                    else
                                    {
                                        DisplayAlert("sELECT REASON", this);
                                        ZMARBankDetailsUpdateReleasePopup.Show();
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Enter bank address", this);
                                    ZMARBankDetailsUpdateReleasePopup.Show();
                                }
                            }
                            else
                            {
                                DisplayAlert("Enter IFSC Code", this);
                                ZMARBankDetailsUpdateReleasePopup.Show();
                            }
                        }
                        else
                        {
                            DisplayAlert("Enter Branch Name", this);
                            ZMARBankDetailsUpdateReleasePopup.Show();
                        }
                    }
                    else
                    {
                        DisplayAlert("Enter Bank Name", this);
                        ZMARBankDetailsUpdateReleasePopup.Show();
                    }
                }
                else
                {
                    DisplayAlert("Enter Application Number", this);
                    ZMARBankDetailsUpdateReleasePopup.Show();
                }
            }
        }
        protected void btnZMARGetApplicationStatus_Click(object sender, EventArgs e)
        {

        }
        protected void lnkbtnSECEODoc_Click(object sender, EventArgs e)
        {

        }
        
        
        
        
        protected void btnSEZMGenerateReport_Click(object sender, EventArgs e)
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
        
        
        
        
        protected void btnZMSEBDUpdate_Click(object sender, EventArgs e)
        {
            if (lblZMSEBDUpdateApplicationNumber.Text != "")
            {
                if (txtZMSEBDUpdateAccountNumber.Text.Trim()!="")
                {
                    if (txtZMSEBDUpdateBankName.Text.Trim() != "")
                    {
                        if (txtZMSEBDUpdateBranchName.Text.Trim() != "")
                        {
                            if (txtZMSEBDUpdateIFSCCode.Text.Trim() != "")
                            {
                                if (txtZMSEBDUpdateBankAddress.Text.Trim() != "")
                                {
                                    if (drpZMSEBankModifyReason.SelectedValue != "0")
                                    {
                                        UBD.UpdateBankDetailsToDB(lblZMSEBDUpdateApplicationNumber.Text, txtZMSEBDUpdateAccountNumber.Text.Trim(), txtZMSEBDUpdateBankName.Text.Trim(), txtZMSEBDUpdateIFSCCode.Text.Trim(), txtZMSEBDUpdateBranchName.Text.Trim(), txtZMSEBDUpdateBankAddress.Text.Trim()
                                            , drpZMSEBankModifyReason.SelectedValue, lblZMSEBDUpdateAccountHolderName.Text, "SE");
                                    }
                                    else
                                    {
                                        DisplayAlert("sELECT REASON", this);
                                        ZMSEBankDetailsUpdatePopup.Show();
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Enter bank address", this);
                                    ZMSEBankDetailsUpdatePopup.Show();
                                }
                            }
                            else
                            {
                                DisplayAlert("Enter IFSC Code", this);
                                ZMSEBankDetailsUpdatePopup.Show();
                            }
                        }
                        else
                        {
                            DisplayAlert("Enter Branch Name", this);
                            ZMSEBankDetailsUpdatePopup.Show();
                        }
                    }
                    else
                    {
                        DisplayAlert("Enter Bank Name", this);
                        ZMSEBankDetailsUpdatePopup.Show();
                    }
                }
                else
                {
                    DisplayAlert("Enter Application Number", this);
                    ZMSEBankDetailsUpdatePopup.Show();
                }
            }
            //UBD.UpdateBankDetailsToDB();
            this.FillGridSelfEmployment();
        }
        
        
        protected void btnSEZMReleaseGenerateReport_Click(object sender, EventArgs e)
        {

        }
        
        protected void btnZMSEBDUpdateRelease_Click(object sender, EventArgs e)
        {
            if (lblZMSEBDUpdateReleaseApplicationNumber.Text != "")
            {
                if (txtZMSEBDUpdateReleaseAccountNumber.Text.Trim() != "")
                {
                    if (txtZMSEBDUpdateReleaseBankName.Text.Trim() != "")
                    {
                        if (txtZMSEBDUpdateReleaseBranchName.Text.Trim() != "")
                        {
                            if (txtZMSEBDUpdateReleaseIFSCCode.Text.Trim() != "")
                            {
                                if (txtZMSEBDUpdateReleaseBankAddress.Text.Trim() != "")
                                {
                                    if (drpZMSEBankModifyReleaseReason.SelectedValue != "0")
                                    {
                                        UBD.UpdateBankDetailsToDB(lblZMSEBDUpdateReleaseApplicationNumber.Text, txtZMSEBDUpdateReleaseAccountNumber.Text.Trim(), txtZMSEBDUpdateReleaseBankName.Text.Trim(), txtZMSEBDUpdateReleaseIFSCCode.Text.Trim(), txtZMSEBDUpdateReleaseBranchName.Text.Trim(), txtZMSEBDUpdateReleaseBankAddress.Text.Trim()
                                            , drpZMSEBankModifyReleaseReason.SelectedValue, lblZMSEBDUpdateReleaseAccountHolderName.Text, "SE");
                                        this.FillGridArivu();
                                    }
                                    else
                                    {
                                        DisplayAlert("sELECT REASON", this);
                                        ZMSEBankDetailsUpdateReleasePopup.Show();
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Enter bank address", this);
                                    ZMSEBankDetailsUpdateReleasePopup.Show();
                                }
                            }
                            else
                            {
                                DisplayAlert("Enter IFSC Code", this);
                                ZMSEBankDetailsUpdateReleasePopup.Show();
                            }
                        }
                        else
                        {
                            DisplayAlert("Enter Branch Name", this);
                            ZMSEBankDetailsUpdateReleasePopup.Show();
                        }
                    }
                    else
                    {
                        DisplayAlert("Enter Bank Name", this);
                        ZMSEBankDetailsUpdateReleasePopup.Show();
                    }
                }
                else
                {
                    DisplayAlert("Enter Application Number", this);
                    ZMSEBankDetailsUpdateReleasePopup.Show();
                }
            }
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