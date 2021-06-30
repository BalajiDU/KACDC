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
            lblARNotificationContent.Text= GC.GetTotalCount("spGetApplicationCount", "ARAPPROVEDNUMBER");
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

            lblARNotificationHeading.Text = "Approved Application Number of <br />" + lblZMSEConfirmApproveAppName.Text + " <br />";
            this.FillGridSelfEmployment();
            lblARNotificationContent.Text = GC.GetTotalCount("spGetApplicationCount", "ARAPPROVEDNUMBER");
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
                txtZMARConfirmRejectAppReason.Visible = true;
                ZMARConfirmRejectPopup.Show();
            }
            else if (rbZMARConfirmRejectReasonCET.Checked)
            {
                txtZMARConfirmRejectAppReason.Text = "Invalid CET Certificate is submitted";
                txtZMARConfirmRejectAppReason.Visible = true;
                ZMARConfirmRejectPopup.Show();
            }
            else if (rbZMARConfirmRejectReasonOther.Checked)
            {
                txtZMARConfirmRejectAppReason.Text = "";
                txtZMARConfirmRejectAppReason.Visible = true;
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
                txtZMSEConfirmRejectAppReason.Visible = true;
                ZMSEConfirmRejectPopup.Show();
            }
            else if (rbZMSEConfirmRejectReasonOther.Checked)
            {
                txtZMSEConfirmRejectAppReason.Text = "";
                txtZMSEConfirmRejectAppReason.Visible = true;
                ZMSEConfirmRejectPopup.Show();
            }
        }
        protected void btnZMARReject_Click(object sender, EventArgs e)
        {
            rbZMARConfirmRejectReasonName.Checked = false;
            rbZMARConfirmRejectReasonCET.Checked = false;
            rbZMARConfirmRejectReasonOther.Checked = false;
            txtZMARConfirmRejectAppReason.Visible = false;
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
            txtZMSEConfirmRejectAppReason.Visible = false;
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
                if (lblZMSEConfirmRejectAppReasonSelectionError.Text.Trim().Length > 10)
                {
                    lblZMSEConfirmRejectAppReasonError.Text = "";
                    AP.ApplicationStatusUpdate("SEZMPROCESS", "REJECTED", lblZMSEConfirmRejectAppNumber.Text.Trim(), txtZMSEConfirmRejectAppReason.Text.Trim());
                    this.FillGridArivu();
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
                this.FillGridArivu();
            }
            else
            {
                lblZMSEConfirmReturnAppReasonError.Text = "Enter valid reason to return application to DM";
                ZMSEConfirmReturnPopup.Show();
            }

        }
        protected void btnZMArivuReleased_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblZMARConfirmReleaseAppNumber.Text = gvZMARReleaseProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblZMARConfirmReleaseAppName.Text = gvZMARReleaseProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            lblZMARConfirmReleaseLoanNumber.Text = gvZMARReleaseProcess.DataKeys[rowindex].Values["ApprovedApplicationNum"].ToString();
            ZMARConfirmReleasePopup.Show();
        }
        protected void btnZMSEReleased_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblZMSEConfirmReleaseAppNumber.Text = gvZMSEReleaseProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblZMSEConfirmReleaseAppName.Text = gvZMSEReleaseProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            lblZMSEConfirmReleaseLoanNumber.Text = gvZMSEReleaseProcess.DataKeys[rowindex].Values["ApprovedApplicationNum"].ToString();
            ZMSEConfirmReleasePopup.Show();
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
        protected void btnZMASEReturn_Click(object sender, EventArgs e)
        {


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