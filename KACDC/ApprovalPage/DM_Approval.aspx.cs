using KACDC.Class;
using KACDC.Class.DataProcessing;
using KACDC.Class.DataProcessing.ApplicationProcess;
using KACDC.Class.DataProcessing.ApplicationProcess;
using KACDC.Class.DataProcessing.ApplicationProcess.BankDetails;
using KACDC.Class.DataProcessing.BankData;
using KACDC.Class.DataProcessing.FileProcessing;
using KACDC.Class.DataProcessing.FileProcessing.CreatePDF.ApplicationProcess;
using KACDC.Class.DataProcessing.OnlineApplication.Arivu;
using KACDC.Class.Declaration.ApprovalProcess;
using KACDC.Class.Declaration.ApprovalProcess.ArivuRenewal;
using KACDC.Class.Declaration.ApprovalProcess.DistrictManager;
using KACDC.Class.FileSaving;
using KACDC.Class.GetCountStatistics;
using KACDC.Class.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.ApprovalPage
{
    public partial class DM_Approval : System.Web.UI.Page
    {
        GetDataToProcess GDTP = new GetDataToProcess();
        GetBankDetails GBD = new GetBankDetails();
        UpdateBankDetails UBD = new UpdateBankDetails();
        SBankDetails BD = new SBankDetails();
        ApprovalProcess AP = new ApprovalProcess();
        GetCount GC = new GetCount();
        DistrictManagerProcess DMP = new DistrictManagerProcess();
        UpdateBankDetailsToDB UBDDB = new UpdateBankDetailsToDB();
        ArRenewalProcess ARP = new ArRenewalProcess();
        GetFinancialYear FY = new GetFinancialYear();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "DISTRICTMANAGER")
            {
                Response.Redirect("~/Login.aspx");
                FY.GetFY();
                gvRepaymentStats.DataSource = SqlDataSourcegvRepaymentStats;
                gvRepaymentStats.DataBind();
                //UserName = Session["UserName"].ToString();
            }
            if (!IsPostBack)
            {
                this.FillGrid();
            }
            
        }
        private void FillGrid()
        {
            this.FillGridSelfEmployment();

            this.FillGridArivu();
        }
        private void FillGridArivu()
        {

            gvDMARApproveProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess", "ARSELECTDM", Session["District"].ToString());
            gvDMARApproveProcess.DataBind();

            gvCEOARApproveProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess", "ARSELECTCEO", Session["District"].ToString());
            gvCEOARApproveProcess.DataBind();

            gvDOCARApproveProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess", "ARSELECTDOC", Session["District"].ToString());
            gvDOCARApproveProcess.DataBind();

            if (DMP.Instalment != "" && DMP.Instalment != null)
            {
                gvARRenewalProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess", DMP.Instalment, Session["District"].ToString());
                gvARRenewalProcess.DataBind();
            }
        }
        private void FillGridSelfEmployment()
        {

            gvDMSEApproveProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess", "SESELECTDM", Session["District"].ToString());
            gvDMSEApproveProcess.DataBind();

            gvCEOSEApproveProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess", "SESELECTCEO", Session["District"].ToString());
            gvCEOSEApproveProcess.DataBind();

            gvDOCSEApproveProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess", "SESELECTDOC", Session["District"].ToString());
            gvDOCSEApproveProcess.DataBind();
        }

        protected void btnDMLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
        protected void btnOldProcess_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMARDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvDMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
            lblDMARBDApplicationNumber.Text = BD.ApplicationNumber;
            lblDMARBDAccountHolderName.Text = BD.ApplicantName;
            lblDMARBDAccountNumber.Text = BD.AccountNumber;
            lblDMARBDBankName.Text = BD.BankName;
            lblDMARBDBranchName.Text = BD.Branch;
            lblDMARBDIFSCCode.Text = BD.IFSCCode;
            lblDMARBDBankAddress.Text = BD.BankAddress;
            DMARBankDetailsPopup.Show();
        }
        protected void btnDMARDisplayCollegeDetails_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMARApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDMARConfirmApproveAppNumber.Text = gvDMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDMARConfirmApproveAppName.Text = gvDMARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMARConfirmApprovePopup.Show();
        }
        protected void btnDMARHold_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDMARConfirmHoldAppNumber.Text = gvDMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDMARConfirmHoldAppName.Text = gvDMARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMARConfirmHoldPopup.Show();
        }
        protected void btnDMARReject_Click(object sender, EventArgs e)
        {
            rbDMARConfirmRejectReasonOther.Checked = false;
            rbDMARConfirmRejectReasonName.Checked = false;
            rbDMARConfirmRejectReasonCET.Checked = false;
            divDMARRejectReason.Visible = false;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDMARConfirmRejectAppNumber.Text = gvDMARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDMARConfirmRejectAppName.Text = gvDMARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMARConfirmRejectPopup.Show();
        }
        protected void btnDMARDownloadExcelForCEO_Click(object sender, EventArgs e)
        {
          
        }
        protected void btnDMARConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            if (txtDMARConfirmRejectAppReason.Text.Trim() != "")
            {
                if (txtDMARConfirmRejectAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("ARCWPROCESS", "REJECTED", lblDMARConfirmRejectAppNumber.Text, txtDMARConfirmRejectAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    DisplayAlert("Reason must be above 10 characters", this);
                    DMARConfirmRejectPopup.Show();
                }
            }
            else
            {
                DisplayAlert("Enter Reason", this);
                DMARConfirmRejectPopup.Show();
            }
        }
        protected void btnDMARConfirmHoldApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate("ARDMPROCESS", "HOLD", lblDMARConfirmApproveAppNumber.Text);
            this.FillGridArivu();
        }
        protected void btnDMARConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate("ARDMPROCESS", "APPROVED", lblDMARConfirmApproveAppNumber.Text);
            this.FillGridArivu();
        }
        protected void btnDMPnlCollegeDetailsClose_Click(object sender, EventArgs e)
        {

        }
        protected void btnArivuUploadCeoDoc_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOARDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvCEOARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
            lblCEOARBDApplicationNumber.Text = BD.ApplicationNumber;
            lblCEOARBDAccountHolderName.Text = BD.ApplicantName;
            lblCEOARBDAccountNumber.Text = BD.AccountNumber;
            lblCEOARBDBankName.Text = BD.BankName;
            lblCEOARBDBranchName.Text = BD.Branch;
            lblCEOARBDIFSCCode.Text = BD.IFSCCode;
            lblCEOARBDBankAddress.Text = BD.BankAddress;
            CEOARBankDetailsPopup.Show();
        }
        protected void btnCEOARDisplayCollegeDetails_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOARApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCEOARConfirmApproveAppNumber.Text = gvCEOARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCEOARConfirmApproveAppName.Text = gvCEOARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CEOARConfirmApprovePopup.Show();
        }
        protected void btnCEOARWaiting_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCEOARConfirmWaitingAppNumber.Text = gvCEOARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCEOARConfirmWaitingAppName.Text = gvCEOARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CEOARConfirmWaitingPopup.Show();
        }
        protected void btnCEOARHold_Click(object sender, EventArgs e)
        {
            txtCEOARConfirmHoldAppReason.Text = "";
               Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCEOARConfirmHoldAppNumber.Text = gvCEOARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCEOARConfirmHoldAppName.Text = gvCEOARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CEOARConfirmHoldPopup.Show();
        }
        protected void btnCEOARReject_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCEOARConfirmRejectAppNumber.Text = gvCEOARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCEOARConfirmRejectAppName.Text = gvCEOARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CEOARConfirmRejectPopup.Show();
        }
        protected void btDMARCEODownloadApproved_Click(object sender, EventArgs e)
        {

        }
        protected void btDMARCEODownloadWaiting_Click(object sender, EventArgs e)
        {

        }
        protected void btDMARCEODownloadHold_Click(object sender, EventArgs e)
        {

        }
        protected void btDMARCEODownloadReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOARConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            lblCEOARConfirmRejectAppReasonSelectionError.Text = "";
            if (rbCEOARConfirmRejectReasonNotSelected.Checked == true || rbCEOARConfirmRejectReasonOther.Checked == true)
            {
                if (txtCEOARConfirmRejectAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("ARCEOPROCESS", "REJECTED", lblCEOARConfirmRejectAppNumber.Text,txtCEOARConfirmRejectAppReason.Text.Trim());
                    this.FillGridArivu();
                }
                else
                {
                    lblCEOARConfirmRejectAppReasonSelectionError.Text = "Describe the Reason";
                    CEOARConfirmRejectPopup.Show();
                }
            }
            else
            {
                lblCEOARConfirmRejectAppReasonSelectionError.Text = "Select Reason";
                CEOARConfirmRejectPopup.Show();
            }
        }
        protected void btnCEOARConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            if (drpCEOARQuota.SelectedValue != "0")
            {

            }
            else
            {

            }
            AP.ApplicationStatusUpdate("ARCEOPROCESS", "APPROVED", lblCEOARConfirmApproveAppNumber.Text);
            AP.ApplicationAmountUpdate("ARCEOPROCESS", lblCEOARConfirmApproveAppNumber.Text, drpCEOARQuota.SelectedValue, txtInstalment1.Text.Trim());
            this.FillGridArivu();
        }
        protected void btnCEOARConfirmWaitingApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate("ARCEOPROCESS", "WAITING", lblCEOARConfirmWaitingAppNumber.Text);
            this.FillGridArivu();
        }
        protected void btnCEOPnlCollegeDetailsClose_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCARDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvDOCARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
            lblDOCARBDApplicationNumber.Text = BD.ApplicationNumber;
            lblDOCARBDAccountHolderName.Text = BD.ApplicantName;
            lblDOCARBDAccountNumber.Text = BD.AccountNumber;
            lblDOCARBDBankName.Text = BD.BankName;
            lblDOCARBDBranchName.Text = BD.Branch;
            lblDOCARBDIFSCCode.Text = BD.IFSCCode;
            lblDOCARBDBankAddress.Text = BD.BankAddress;
            DOCARBankDetailsPopup.Show();
        }
        protected void btnDOCARDisplayBankDetailsUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvDOCARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
            lblDOCARBDUpdateApplicationNumber.Text = BD.ApplicationNumber;
            lblDOCARBDUpdateAccountHolderName.Text = BD.ApplicantName;
            txtDOCARBDUpdateAccountNumber.Text = BD.AccountNumber;
            txtDOCARBDUpdateBankName.Text = BD.BankName;
            txtDOCARBDUpdateBranchName.Text = BD.Branch;
            txtDOCARBDUpdateIFSCCode.Text = BD.IFSCCode;
            txtDOCARBDUpdateBankAddress.Text = BD.BankAddress;
            DOCARBankDetailsUpdatePopup.Show();
        }
        protected void btnDOCARApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDOCARConfirmApproveAppNumber.Text = gvDOCARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDOCARConfirmApproveAppName.Text = gvDOCARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DOCARConfirmApprovePopup.Show();
        }
        protected void btnDOCARHold_Click(object sender, EventArgs e)
        {
            txtDOCARConfirmHoldAppReason.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDOCARConfirmHoldAppNumber.Text = gvDOCARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDOCARConfirmHoldAppName.Text = gvDOCARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DOCARConfirmHoldPopup.Show();
        }
        protected void btnDOCARReject_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDOCARConfirmRejectAppNumber.Text = gvDOCARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDOCARConfirmRejectAppName.Text = gvDOCARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DOCARConfirmRejectPopup.Show();
        }
        protected void btnDMARSubmitToZM_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCARConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            lblDOCARConfirmRejectAppReasonError.Text = "";
            if (txtDOCARConfirmRejectAppReason.Text.Trim() != "")
            {
                if (txtDOCARConfirmRejectAppReason.Text.Trim().Length>=10)
                {
                    AP.ApplicationStatusUpdate("ARDOCPROCESS", "REJECT", lblDOCARConfirmRejectAppNumber.Text, txtDOCARConfirmRejectAppReason.Text.Trim());
                    this.FillGridArivu();
                }
                else
                {
                    lblDOCARConfirmRejectAppReasonError.Text = "Describe the reason";
                    DOCARConfirmRejectPopup.Show();
                }
            }
            else
            {
                lblDOCARConfirmRejectAppReasonError.Text = "Enter the reason";
                DOCARConfirmRejectPopup.Show();
            }

        }
        protected void btnDOCARConfirmHoldApplication_Click(object sender, EventArgs e)
        {
            lblDOCARConfirmHoldAppReasonError.Text = "";
            if (txtDOCARConfirmHoldAppReason.Text.Trim() != "")
            {
                if (txtDOCARConfirmHoldAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("ARDOCPROCESS", "HOLD", lblDOCARConfirmHoldAppNumber.Text, txtDOCARConfirmHoldAppReason.Text.Trim());
                    this.FillGridArivu();
                }
                else
                {
                    lblDOCARConfirmHoldAppReasonError.Text = "Describe the reason";
                    DOCARConfirmHoldPopup.Show();
                }
            }
            else
            {
                lblDOCARConfirmHoldAppReasonError.Text = "Enter the reason";
                DOCARConfirmHoldPopup.Show();
            }
            
        }
        protected void btnDOCARConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate("ARDOCPROCESS", "APPROVED", lblDOCARConfirmApproveAppNumber.Text);
            this.FillGridArivu();
        }
        protected void btnPnlCollegeDetailsClose_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCARBDUpdate_Click(object sender, EventArgs e)
        {
            if (lblDOCARBDUpdateApplicationNumber.Text != "")
            {
                if (txtDOCARBDUpdateAccountNumber.Text.Trim() != "")
                {
                    if (txtDOCARBDUpdateBankName.Text.Trim() != "")
                    {
                        if (txtDOCARBDUpdateBranchName.Text.Trim() != "")
                        {
                            if (txtDOCARBDUpdateIFSCCode.Text.Trim() != "")
                            {
                                if (txtDOCARBDUpdateBankAddress.Text.Trim() != "")
                                {
                                    if (drpDOCARBankModifyReason.SelectedValue != "0")
                                    {
                                        UBD.UpdateBankDetailsToDB(lblDOCARBDUpdateApplicationNumber.Text, txtDOCARBDUpdateAccountNumber.Text.Trim(), txtDOCARBDUpdateBankName.Text.Trim(), txtDOCARBDUpdateIFSCCode.Text.Trim(), txtDOCARBDUpdateBranchName.Text.Trim(), txtDOCARBDUpdateBankAddress.Text.Trim()
                                            , drpDOCARBankModifyReason.SelectedValue, lblDOCARBDUpdateAccountHolderName.Text, "SE");
                                    }
                                    else
                                    {
                                        DisplayAlert("sELECT REASON", this);
                                        DOCARBankDetailsUpdatePopup.Show();
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Enter bank address", this);
                                    DOCARBankDetailsUpdatePopup.Show();
                                }
                            }
                            else
                            {
                                DisplayAlert("Enter IFSC Code", this);
                                DOCARBankDetailsUpdatePopup.Show();
                            }
                        }
                        else
                        {
                            DisplayAlert("Enter Branch Name", this);
                            DOCARBankDetailsUpdatePopup.Show();
                        }
                    }
                    else
                    {
                        DisplayAlert("Enter Bank Name", this);
                        DOCARBankDetailsUpdatePopup.Show();
                    }
                }
                else
                {
                    DisplayAlert("Enter Application Number", this);
                    DOCARBankDetailsUpdatePopup.Show();
                }
            }
            //UBD.UpdateBankDetailsToDB();
            this.FillGridArivu();
        }
        protected void btnARRenewalViewDetails_Click(object sender, EventArgs e)
        {
            RenewalApplicantDetails ARRP = new RenewalApplicantDetails();
            DMGetApplicantDetails ARRAD = new DMGetApplicantDetails();
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            ARRAD.GetApplicantDetailsAR(gvARRenewalProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), DMP.Instalment + "_VIEW");

            lblARRenewalViewApplicationNumber.Text = ARRP.ApplicationNumber;
            lblARRenewalViewApplicantName.Text = ARRP.ApplicantName;
            lblARRenewalViewLoanNumber.Text = ARRP.LoanNumber;
            lblARRenewalViewRDNumber.Text = ARRP.RDNumber;
            lblARRenewalEmail.Text = ARRP.Email;
            lblARRenewalViewMobileNumber.Text = ARRP.MobileNumber;
            lblARRenewalViewAlternateNumber.Text = ARRP.AlternateNumber;
            lblARRenewalViewQuota.Text = ARRP.Quota;
            lblARRenewalViewTotalAmount.Text = ARRP.TotalAmount;
            lblARRenewalViewLoanAmount.Text = ARRP.LoanAmount;

            ARRenewalViewDetailsPopup.Show();
        }
        protected void btnARRenewalDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvARRenewalProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
            lblARRenewalBDApplicationNumber.Text = BD.ApplicationNumber;
            lblARRenewalBDAccountHolderName.Text = BD.ApplicantName;
            lblARRenewalBDAccountNumber.Text = BD.AccountNumber;
            lblARRenewalBDBankName.Text = BD.BankName;
            lblARRenewalBDBranchName.Text = BD.Branch;
            lblARRenewalBDIFSCCode.Text = BD.IFSCCode;
            lblARRenewalBDBankAddress.Text = BD.BankAddress;
            ARRenewalBankDetailsPopup.Show();
        }
        protected void btnARRenewalDisplayBankDetailsUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvARRenewalProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
            lblARRenewalBDUpdateApplicationNumber.Text = BD.ApplicationNumber;
            lblARRenewalBDUpdateAccountHolderName.Text = BD.ApplicantName;
            txtARRenewalBDUpdateAccountNumber.Text = BD.AccountNumber;
            txtARRenewalBDUpdateBankName.Text = BD.BankName;
            txtARRenewalBDUpdateBranchName.Text = BD.Branch;
            txtARRenewalBDUpdateIFSCCode.Text = BD.IFSCCode;
            txtARRenewalBDUpdateBankAddress.Text = BD.BankAddress;
            ARRenewalBankDetailsUpdatePopup.Show();
        }
        protected void btnARRenewalDisplayCollegeDetails_Click(object sender, EventArgs e)
        {

        }
        protected void btnARRenewalApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblARRenewalConfirmApproveAppNumber.Text = gvARRenewalProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblARRenewalConfirmApproveAppName.Text = gvARRenewalProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ARRenewalConfirmApprovePopup.Show();
        }
        protected void btnARRenewalHold_Click(object sender, EventArgs e)
        {
            ArRenewalProcess ARP = new ArRenewalProcess();
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblARRenewalConfirmHoldAppNumber.Text = gvARRenewalProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblARRenewalConfirmHoldAppName.Text = gvARRenewalProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ARRenewalConfirmHoldPopup.Show();
        }
        protected void btnARRenewalReject_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblARRenewalConfirmRejectAppNumber.Text = gvARRenewalProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblARRenewalConfirmRejectAppName.Text = gvARRenewalProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ARRenewalConfirmRejectPopup.Show();
        }
        protected void btnARRenewalSubmitToZM_Click(object sender, EventArgs e)
        {

        }
        protected void btnARRenewalBDUpdate_Click(object sender, EventArgs e)
        {
            if (txtARRenewalBDUpdateIFSCCode.Text.Trim() != "")
            {
                GetBankDetailsIFSC GBDI = new GetBankDetailsIFSC();
                if (GBDI.GetBankDetails(txtARRenewalBDUpdateIFSCCode.Text.Trim()))
                {
                    if (txtARRenewalBDUpdateAccountNumber.Text.Trim() != "")
                    {
                        if (txtARRenewalBDUpdateBankName.Text.Trim() != "")
                        {
                            if (txtARRenewalBDUpdateBranchName.Text.Trim() != "")
                            {
                                if (txtARRenewalBDUpdateBankAddress.Text.Trim() != "")
                                {
                                    if (drpARRenewalBankModifyReason.SelectedValue != "0")
                                    {
                                        UBD.UpdateBankDetailsToDB(lblARRenewalBDUpdateApplicationNumber.Text, txtARRenewalBDUpdateAccountNumber.Text.Trim(), txtARRenewalBDUpdateBankName.Text.Trim(), txtARRenewalBDUpdateIFSCCode.Text.Trim(), txtARRenewalBDUpdateBranchName.Text.Trim(),
                  txtARRenewalBDUpdateBankAddress.Text.Trim(), drpARRenewalBankModifyReason.SelectedValue, lblARRenewalBDUpdateAccountHolderName.Text, "Arivu");
                                        this.FillGridArivu();
                                    }
                                    else
                                    {
                                        DisplayAlert("select reason to modification", this);
                                        ARRenewalBankDetailsUpdatePopup.Show();
                                        txtARRenewalBDUpdateBankAddress.Focus();
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Enter Valid bank address", this);
                                    ARRenewalBankDetailsUpdatePopup.Show();
                                    txtARRenewalBDUpdateBankAddress.Focus();
                                }
                            }
                            else
                            {
                                DisplayAlert("Enter Valid branch name", this);
                                ARRenewalBankDetailsUpdatePopup.Show();
                                txtARRenewalBDUpdateBranchName.Focus();
                            }
                        }
                        else
                        {
                            DisplayAlert("Enter Valid bank name", this);
                            ARRenewalBankDetailsUpdatePopup.Show();
                            txtARRenewalBDUpdateBankName.Focus();
                        }
                    }
                    else
                    {
                        DisplayAlert("Enter Valid account number", this);
                        ARRenewalBankDetailsUpdatePopup.Show();
                        txtARRenewalBDUpdateAccountNumber.Focus();
                    }
                }
                else
                {
                    DisplayAlert("Enter Valid ifsc code", this);
                    ARRenewalBankDetailsUpdatePopup.Show();
                    txtARRenewalBDUpdateIFSCCode.Focus();
                }
            }
            else
            {
                DisplayAlert("Enter Valid ifsc code", this);
                ARRenewalBankDetailsUpdatePopup.Show();
                txtARRenewalBDUpdateIFSCCode.Focus();
            }
           


        }
        protected void txtARRenewalBDUpdateIFSCCode_TextChanged(object sender, EventArgs e)
        {
            GetBankDetailsIFSC GBD = new GetBankDetailsIFSC();
            if (txtARRenewalBDUpdateIFSCCode.Text.Trim().Length > 8)
            {
                if (GBD.GetBankDetails(txtARRenewalBDUpdateIFSCCode.Text.Trim()))
                {
                    txtARRenewalBDUpdateBankName.Text = BD.BankName;
                    txtARRenewalBDUpdateBranchName.Text = BD.Branch;
                    txtARRenewalBDUpdateBankAddress.Text = BD.BankAddress;
                    ARRenewalBankDetailsUpdatePopup.Show();
                }
                else
                {
                    DisplayAlert("Invalid IFSC Code", this);
                }
            }
        }
        protected void btnARRenewalConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            ARP.UpdateRenewalRequest(lblARRenewalConfirmApproveAppNumber.Text, "APPROVED", DMP.Instalment);
            this.FillGridArivu();
        }
        protected void btnARRenewalConfirmHoldApplication_Click(object sender, EventArgs e)
        {
            ARP.UpdateRenewalRequest(lblARRenewalConfirmApproveAppNumber.Text, "HOLD", DMP.Instalment);
            this.FillGridArivu();
        }
        protected void btnARRenewalConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            ARP.UpdateRenewalRequest(lblARRenewalConfirmApproveAppNumber.Text, "REJECT", DMP.Instalment);
            this.FillGridArivu();
        }
        protected void btnDMSEDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvDMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblDMSEBDApplicationNumber.Text = BD.ApplicationNumber;
            lblDMSEBDAccountHolderName.Text = BD.ApplicantName;
            lblDMSEBDAccountNumber.Text = BD.AccountNumber;
            lblDMSEBDBankName.Text = BD.BankName;
            lblDMSEBDBranchName.Text = BD.Branch;
            lblDMSEBDIFSCCode.Text = BD.IFSCCode;
            lblDMSEBDBankAddress.Text = BD.BankAddress;
            DMSEBankDetailsPopup.Show();
        }
        protected void btnDMARGetApplicationStatus_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMSEApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDMSEConfirmApproveAppNumber.Text = gvDMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDMSEConfirmApproveAppName.Text = gvDMSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMSEConfirmApprovePopup.Show();
        }
        protected void btnDMSEHold_Click(object sender, EventArgs e)
        {
            txtDMSEConfirmHoldAppReason.Text = "";
               Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDMSEConfirmHoldAppNumber.Text = gvDMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDMSEConfirmHoldAppName.Text = gvDMSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMSEConfirmHoldPopup.Show();
        }
        protected void btnDMSEReject_Click(object sender, EventArgs e)
        {
            rbDMSEConfirmRejectReasonName.Checked = false;
            rbDMSEConfirmRejectReasonOther.Checked = false;
            divDMSERejectReason.Visible = false;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDMSEConfirmRejectAppNumber.Text = gvDMSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDMSEConfirmRejectAppName.Text = gvDMSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMSEConfirmRejectPopup.Show();
        }
        protected void btnDMSEDownloadExcelForCEO_Click(object sender, EventArgs e)
        {
            DataLogging DL = new DataLogging();
            try
            {
                SaveFile SF = new SaveFile();
                ExcelFileOperations FO = new ExcelFileOperations();
                GetDataToProcess GDTP = new GetDataToProcess();
                string FilePath = Server.MapPath("~/DownloadFiles/DMSelectedToCEOExcel/" + Session["FinancialYear"].ToString() + "/" + Session["District"].ToString() + "/");
                string Name = Session["District"].ToString()+"_DMApproved.xlsx";//Session["District"].ToString() +
                DataTable employees = new DataTable();
                DataSet ds = new DataSet();
                //SF.CheckDirExist(FilePath);
                SF.IfFileExistDelete(Server.MapPath("~/DownloadFiles/") , Name);
                DL.WriteErrorLog("File Verification", "Comp", FilePath + Name, "asdf", Server.MapPath("~/DownloadFiles/"));
                ds.Tables.Add((GDTP.GetData("spPrintExcel", "SEPRINTMALE", Session["District"].ToString(), "MALE")));
                ds.Tables.Add((GDTP.GetData("spPrintExcel", "SEPRINTFEMALE", Session["District"].ToString(), "FEMALE")));
                ds.Tables.Add((GDTP.GetData("spPrintExcel", "SEPRINTPWD", Session["District"].ToString(), "PWD")));
                DL.WriteErrorLog("Data Received", "Comp", FilePath + Name, "asdf", Server.MapPath("~/DownloadFiles/"));

                FO.ExportToExcel(ds, FilePath, Name, "", Session["District"].ToString(), Server.MapPath("~/DownloadFiles/"));
                DL.WriteErrorLog("Excel Created", "Comp", FilePath + Name, "asdf", Server.MapPath("~/DownloadFiles/"));

                if (System.IO.File.Exists(FilePath + Name))
                {
                    //Response.ContentType = "application/vnd.ms-excel";
                    //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path + Name);
                    //Response.End();
                    //Response.Close();

                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.AddHeader("Content-Disposition", "attachment; filename=" +Server.MapPath("~/DownloadFiles/") + Name);
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(File.ReadAllBytes(Server.MapPath("~/DownloadFiles/") + Name));
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception Ex)
            {
                DL.WriteErrorLog("Error", Ex.ToString(), Ex.Message, "Er", Server.MapPath("~/DownloadFiles/"));

                DisplayAlert(Ex.ToString(), this);
            }
        }
        protected void btnDMSEConfirmHoldApplication_Click(object sender, EventArgs e)
        {
            if (txtDMSEConfirmHoldAppReason.Text.Trim() != "")
            {
                if (txtDMSEConfirmHoldAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("SEDMPROCESS", "HOLD", lblDMSEConfirmHoldAppNumber.Text);
                    this.FillGridSelfEmployment();
                }
                else
                {
                    DisplayAlert("describe reason to hold (minium 10 characters)", this);
                    DMSEConfirmHoldPopup.Show();
                }
            }
            else
            {
                DisplayAlert("Enter reason to hold", this);
                DMSEConfirmHoldPopup.Show();
            }
            
        }
        protected void btnDMSEConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate("SEDMPROCESS", "APPROVED", lblDMSEConfirmApproveAppNumber.Text);
            this.FillGridSelfEmployment();
        }
        protected void btnDMSEConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            if (txtDMSEConfirmRejectAppReason.Text.Trim() != "")
            {
                if (txtDMSEConfirmRejectAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("SEDMPROCESS", "REJECTED", lblDMSEConfirmRejectAppNumber.Text, txtDMSEConfirmRejectAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    DisplayAlert("Reason must be above 10 characters", this);
                    DMSEConfirmRejectPopup.Show();
                }
            }
            else
            {
                DisplayAlert("Enter Reason", this);
                DMSEConfirmRejectPopup.Show();
            }
        }
        protected void btnSEUploadCeoDoc_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOSEDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvCEOSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblCEOSEBDApplicationNumber.Text = BD.ApplicationNumber;
            lblCEOSEBDAccountHolderName.Text = BD.ApplicantName;
            lblCEOSEBDAccountNumber.Text = BD.AccountNumber;
            lblCEOSEBDBankName.Text = BD.BankName;
            lblCEOSEBDBranchName.Text = BD.Branch;
            lblCEOSEBDIFSCCode.Text = BD.IFSCCode;
            lblCEOSEBDBankAddress.Text = BD.BankAddress;
            CEOSEBankDetailsPopup.Show();
        }
        protected void btnCEOSEApprove_Click(object sender, EventArgs e)
        {
            drpCEOSEQuota.ClearSelection();
            txtCEOLoanAmount.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCEOSEConfirmApproveAppNumber.Text = gvCEOSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCEOSEConfirmApproveAppName.Text = gvCEOSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CEOSEConfirmApprovePopup.Show();
        }
        protected void btnCEOSEWaiting_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCEOSEConfirmWaitingAppNumber.Text = gvCEOSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCEOSEConfirmWaitingAppName.Text = gvCEOSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CEOSEConfirmWaitingPopup.Show();
        }
        protected void btnCEOSEHold_Click(object sender, EventArgs e)
        {
            txtCEOSEConfirmHoldAppReason.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCEOSEConfirmHoldAppNumber.Text = gvCEOSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCEOSEConfirmHoldAppName.Text = gvCEOSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CEOSEConfirmHoldPopup.Show();
        }
        protected void btnCEOSEReject_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCEOSEConfirmRejectAppNumber.Text = gvCEOSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCEOSEConfirmRejectAppName.Text = gvCEOSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CEOSEConfirmRejectPopup.Show();
        }
        protected void btnDMSECEOGenerateReport_Click(object sender, EventArgs e)
        {

        }
        protected void btDMSECEODownloadApproved_Click(object sender, EventArgs e)
        {

        }
        protected void btDMSECEODownloadWaiting_Click(object sender, EventArgs e)
        {

        }
        protected void btDMSECEODownloadHold_Click(object sender, EventArgs e)
        {

        }
        protected void btDMSECEODownloadReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOSEConfirmHoldApplication_Click(object sender, EventArgs e)
        {
            lblCEOSEConfirmHoldAppReasonError.Text = "";
            if (txtCEOSEConfirmHoldAppReason.Text.Trim() != "")
            {
                if (txtCEOSEConfirmHoldAppReason.Text.Trim().Length > 10)
                {
                    AP.ApplicationStatusUpdate("SECEOPROCESS", "HOLD", lblCEOSEConfirmHoldAppNumber.Text, txtCEOSEConfirmHoldAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    DisplayAlert("Describe the Reason for HOLD", this);
                    CEOSEConfirmHoldPopup.Show();
                }
            }
            else
            {
                DisplayAlert("Enter the Reason for HOLD",this);
                CEOSEConfirmHoldPopup.Show();
            }
            
        }
        protected void gvRepaymentStats_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text == "DEFAULTER")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(e.Row.Cells[7].Text, @"\d"))
                {
                    if (Convert.ToInt32(e.Row.Cells[7].Text) > 3)
                    {
                        e.Row.ForeColor = System.Drawing.Color.DarkRed;
                    }
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(e.Row.Cells[7].Text, @"\d"))
                {
                    if (Convert.ToInt32(e.Row.Cells[7].Text) <= 2)
                    {
                        e.Row.ForeColor = System.Drawing.Color.Green;
                    }
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(e.Row.Cells[7].Text, @"\d"))
                {
                    if (Convert.ToInt32(e.Row.Cells[7].Text) == 0)
                    {
                        e.Row.ForeColor = System.Drawing.Color.DeepSkyBlue;
                    }
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(e.Row.Cells[7].Text, @"\d"))
                {
                    if (Convert.ToInt32(e.Row.Cells[11].Text) >2511)
                    {
                        e.Row.Cells[1].Font.Bold=true;
                    }
                }
            }
        }
        protected void btnCEOSEConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            if (drpCEOSEQuota.SelectedValue != "0")
            {
                if (txtCEOLoanAmount.Text.Trim() != "")
                {
                    if (txtCEOLoanAmount.Text.Trim().Length > 4)
                    {
                        int number;
                        Int32.TryParse(txtCEOLoanAmount.Text.Trim(), out number);
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtCEOLoanAmount.Text.Trim(), @"\d"))
                        {
                            AP.ApplicationStatusUpdate("SECEOPROCESS", "APPROVED", lblCEOSEConfirmApproveAppNumber.Text);
                            AP.ApplicationAmountUpdate("SEUPDATEAMOUNT", lblCEOSEConfirmApproveAppNumber.Text, drpCEOSEQuota.SelectedValue, txtCEOLoanAmount.Text.Trim() );
                            this.FillGridSelfEmployment();
                        }
                        else
                        {
                            DisplayAlert("Enter valid amount", this);
                            CEOSEConfirmApprovePopup.Show();
                        }
                        //if (txtCEOLoanAmount.Text.Trim() < 5)
                        //{

                        //}
                        //else
                        //{
                        //    DisplayAlert("Enter valid amount", this);
                        //    CEOSEConfirmApprovePopup.Show();
                        //}
                    }
                    else
                    {
                        DisplayAlert("Enter valid amount", this);
                        CEOSEConfirmApprovePopup.Show();
                    }
                }
                else
                {
                    DisplayAlert("Enter amount", this);
                    CEOSEConfirmApprovePopup.Show();
                }
            }
            else
            {
                DisplayAlert("Select Quota", this);
                CEOSEConfirmApprovePopup.Show();
            }
            
        }
        protected void btnCEOSEConfirmWaitingApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate("SECEOPROCESS", "WAITING", lblCEOSEConfirmWaitingAppNumber.Text);
            this.FillGridSelfEmployment();
        }
        protected void btnCEOSEConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            lblCEOSEConfirmRejectAppReasonSelectionError.Text = "";
            if (rbCEOSEConfirmRejectReasonNotSelected.Checked == true || rbCEOSEConfirmRejectReasonOther.Checked == true)
            {
                if (txtCEOSEConfirmRejectAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("SECEOPROCESS", "REJECTED", lblCEOSEConfirmRejectAppNumber.Text, txtCEOSEConfirmRejectAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    lblCEOSEConfirmRejectAppReasonSelectionError.Text = "Describe the Reason";
                    CEOSEConfirmRejectPopup.Show();
                }
            }
            else
            {
                lblCEOSEConfirmRejectAppReasonSelectionError.Text = "Select Reason";
                CEOSEConfirmRejectPopup.Show();
            }
            
        }
        protected void btnDOCSEDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvDOCSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblDOCSEBDApplicationNumber.Text = BD.ApplicationNumber;
            lblDOCSEBDAccountHolderName.Text = BD.ApplicantName;
            lblDOCSEBDAccountNumber.Text = BD.AccountNumber;
            lblDOCSEBDBankName.Text = BD.BankName;
            lblDOCSEBDBranchName.Text = BD.Branch;
            lblDOCSEBDIFSCCode.Text = BD.IFSCCode;
            lblDOCSEBDBankAddress.Text = BD.BankAddress;
            DOCSEBankDetailsPopup.Show();
        }
        protected void btnDOCSEDisplayBankDetailsUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvDOCSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblDOCSEBDUpdateApplicationNumber.Text = BD.ApplicationNumber;
            lblDOCSEBDUpdateAccountHolderName.Text = BD.ApplicantName;
            txtDOCSEBDUpdateAccountNumber.Text = BD.AccountNumber;
            txtDOCSEBDUpdateBankName.Text = BD.BankName;
            txtDOCSEBDUpdateBranchName.Text = BD.Branch;
            txtDOCSEBDUpdateIFSCCode.Text = BD.IFSCCode;
            txtDOCSEBDUpdateBankAddress.Text = BD.BankAddress;
            DOCSEBankDetailsUpdatePopup.Show();
        }
        protected void btnDOCSEApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDOCSEConfirmApproveAppNumber.Text = gvDOCSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString() ;
            lblDOCSEConfirmApproveAppName.Text = gvDOCSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DOCSEConfirmApprovePopup.Show();
        }
        protected void btnDOCSEHold_Click(object sender, EventArgs e)
        {
            txtDOCSEConfirmHoldAppReason.Text = "";
               Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDOCSEConfirmHoldAppNumber.Text = gvDOCSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDOCSEConfirmHoldAppName.Text = gvDOCSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DOCSEConfirmHoldPopup.Show();
        }
        protected void btnDOCSEReject_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblDOCSEConfirmRejectAppNumber.Text = gvDOCSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblDOCSEConfirmRejectAppName.Text = gvDOCSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DOCSEConfirmRejectPopup.Show();
        }
        protected void btnDMSESubmitToZM_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCSEConfirmHoldApplication_Click(object sender, EventArgs e)
        {
            lblDOCSEConfirmHoldAppReasonError.Text = "";
            if (txtDOCSEConfirmHoldAppReason.Text.Trim()!="")
            {
                if (txtDOCSEConfirmHoldAppReason.Text.Trim().Length>=10)
                {
                    AP.ApplicationStatusUpdate("SEDOCPROCESS", "HOLD", lblDOCSEConfirmHoldAppNumber.Text, txtDOCSEConfirmHoldAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    lblDOCSEConfirmHoldAppReasonError.Text = "Enter reason for hold";
                    DOCSEConfirmHoldPopup.Show();
                }
            }
            else
            {
                lblDOCSEConfirmHoldAppReasonError.Text = "Enter reason for hold";
                DOCSEConfirmHoldPopup.Show();
            }
            
        }
        protected void btnDOCSEConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate("SEDOCPROCESS", "APPROVED", lblDOCSEConfirmApproveAppNumber.Text);
            this.FillGridSelfEmployment();
        }
        protected void btnDOCSEConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            lblDOCSEConfirmRejectAppReasonSelectionError.Text = "";
            if (rbDOCSEConfirmRejectReasonNotInterested.Checked || rbDOCSEConfirmRejectReasonFamilyMember.Checked || rbDOCSEConfirmRejectReasonVoluntarilyrejected.Checked || rbDOCSEConfirmRejectReasonDeath.Checked || rbDOCSEConfirmRejectReasonOther.Checked)
            {
                if (txtDOCSEConfirmRejectAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("SEDOCPROCESS", "REJECTED", lblDOCSEConfirmRejectAppNumber.Text, txtDOCSEConfirmRejectAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    lblDOCSEConfirmRejectAppReasonSelectionError.Text = "Describe the reason";
                    DOCSEConfirmRejectPopup.Show();
                }
            }
            else
            {
                lblDOCSEConfirmRejectAppReasonSelectionError.Text = "Select reason";
                DOCSEConfirmRejectPopup.Show();
            }

        }
        protected void btnDOCSEBDUpdate_Click(object sender, EventArgs e)
        {
            if (lblDOCSEBDUpdateApplicationNumber.Text != "")
            {
                if (txtDOCSEBDUpdateAccountNumber.Text.Trim() != "")
                {
                    if (txtDOCSEBDUpdateBankName.Text.Trim() != "")
                    {
                        if (txtDOCSEBDUpdateBranchName.Text.Trim() != "")
                        {
                            if (txtDOCSEBDUpdateIFSCCode.Text.Trim() != "")
                            {
                                if (txtDOCSEBDUpdateBankAddress.Text.Trim() != "")
                                {
                                    if (drpDOCSEBankModifyReason.SelectedValue != "0")
                                    {
                                        UBD.UpdateBankDetailsToDB(lblDOCSEBDUpdateApplicationNumber.Text, txtDOCSEBDUpdateAccountNumber.Text.Trim(), txtDOCSEBDUpdateBankName.Text.Trim(), txtDOCSEBDUpdateIFSCCode.Text.Trim(), txtDOCSEBDUpdateBranchName.Text.Trim(), txtDOCSEBDUpdateBankAddress.Text.Trim()
                                            , drpDOCSEBankModifyReason.SelectedValue, lblDOCSEBDUpdateAccountHolderName.Text, "SE");
                                    }
                                    else
                                    {
                                        DisplayAlert("sELECT REASON", this);
                                        DOCSEBankDetailsUpdatePopup.Show();
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Enter bank address", this);
                                    DOCSEBankDetailsUpdatePopup.Show();
                                }
                            }
                            else
                            {
                                DisplayAlert("Enter IFSC Code", this);
                                DOCSEBankDetailsUpdatePopup.Show();
                            }
                        }
                        else
                        {
                            DisplayAlert("Enter Branch Name", this);
                            DOCSEBankDetailsUpdatePopup.Show();
                        }
                    }
                    else
                    {
                        DisplayAlert("Enter Bank Name", this);
                        DOCSEBankDetailsUpdatePopup.Show();
                    }
                }
                else
                {
                    DisplayAlert("Enter Application Number", this);
                    DOCSEBankDetailsUpdatePopup.Show();
                }
            }
            //UBD.UpdateBankDetailsToDB();
            this.FillGridSelfEmployment();
        }
        protected void btnDMSEGetApplicationStatus_Click(object sender, EventArgs e)
        {

        }
        protected void btnSEUDGetDetails_Click(object sender, EventArgs e)
        {

        }
        protected void btnSEUDNewMobileNumber_Click(object sender, EventArgs e)
        {

        }
        protected void btnSEUDNewAlternateNumber_Click(object sender, EventArgs e)
        {

        }
        protected void btnSEUDNewEmailID_Click(object sender, EventArgs e)
        {

        }
        protected void OnCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void rbCEOARConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {
            lblCEOARConfirmRejectAppReasonSelectionError.Text = "";
            if (rbCEOARConfirmRejectReasonNotSelected.Checked)
            {
                txtCEOARConfirmRejectAppReason.Text = "Applicant is not selected in CEO Committee";
                CEOARConfirmRejectPopup.Show();
            }
            else if (rbCEOARConfirmRejectReasonOther.Checked)
            {
                txtCEOARConfirmRejectAppReason.Text = "";
                CEOARConfirmRejectPopup.Show();
            }
        }
        protected void rbDMSEConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDMSEConfirmRejectReasonName.Checked)
            {
                divDMSERejectReason.Visible = true;
                txtDMSEConfirmRejectAppReason.Text = "Applicant Name Mismatch";
                DMSEConfirmRejectPopup.Show();
            }
            if (rbDMSEConfirmRejectReasonOther.Checked)
            {
                divDMSERejectReason.Visible = true;
                txtDMSEConfirmRejectAppReason.Text = "";
                DMSEConfirmRejectPopup.Show();
            }
        }
        protected void rbCEOSEConfirmRejectReasonNotSelected_CheckedChanged(object sender, EventArgs e)
        {
            lblCEOSEConfirmRejectAppReasonSelectionError.Text = "";
            if (rbCEOSEConfirmRejectReasonNotSelected.Checked)
            {
                txtCEOSEConfirmRejectAppReason.Text = "Applicant is not selected in CEO Committee";
                CEOSEConfirmRejectPopup.Show();
            }else if (rbCEOSEConfirmRejectReasonOther.Checked)
            {
                txtCEOSEConfirmRejectAppReason.Text = "";
                CEOSEConfirmRejectPopup.Show();
            }
        }
        protected void rbDOCSEConfirmReject_CheckedChanged(object sender, EventArgs e)
        {
            lblDOCSEConfirmRejectAppReasonSelectionError.Text = "";
            if (rbDOCSEConfirmRejectReasonNotInterested.Checked)
            {
                txtDOCSEConfirmRejectAppReason.Text = "Applicant is Not Interested";
                DOCSEConfirmRejectPopup.Show();
            }
            else if (rbDOCSEConfirmRejectReasonFamilyMember.Checked)
            {
                txtDOCSEConfirmRejectAppReason.Text = "Applicant Family member already availed the loan";
                DOCSEConfirmRejectPopup.Show();
            }
            else if (rbDOCSEConfirmRejectReasonVoluntarilyrejected.Checked)
            {
                txtDOCSEConfirmRejectAppReason.Text = "Applicant Voluntarily rejected the loan";
                DOCSEConfirmRejectPopup.Show();
            }
            else if (rbDOCSEConfirmRejectReasonDeath.Checked)
            {
                txtDOCSEConfirmRejectAppReason.Text = "Applicant is died";
                DOCSEConfirmRejectPopup.Show();
            }
            else if (rbDOCSEConfirmRejectReasonOther.Checked)
            {
                txtDOCSEConfirmRejectAppReason.Text = "";
                DOCSEConfirmRejectPopup.Show();
            }
            
        }
        protected void rbDMARConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDMARConfirmRejectReasonName.Checked)
            {
                txtDMARConfirmRejectAppReason.Text = "Applicant Name Mismatch";
                divDMARRejectReason.Visible = true;
                DMARConfirmRejectPopup.Show();
            }
            if (rbDMARConfirmRejectReasonCET.Checked)
            {
                txtDMARConfirmRejectAppReason.Text = "Invalid CET Certificate";
                divDMARRejectReason.Visible = true;
                DMARConfirmRejectPopup.Show();
            }
            if (rbDMARConfirmRejectReasonOther.Checked)
            {
                txtDMARConfirmRejectAppReason.Text = "";
                divDMARRejectReason.Visible = true;
                DMARConfirmRejectPopup.Show();
            }
        }
        protected void btnDMARCEOGenerateReport_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOARConfirmHoldApplication_Click(object sender, EventArgs e)
        {
            lblCEOARConfirmHoldAppReasonError.Text = "";
            if (txtCEOARConfirmHoldAppReason.Text.Trim() != "")
            {
                if (txtCEOARConfirmHoldAppReason.Text.Trim().Length > 10)
                {
                    AP.ApplicationStatusUpdate("ARCEOPROCESS", "HOLD", lblCEOARConfirmHoldAppNumber.Text, txtCEOARConfirmHoldAppReason.Text.Trim());
                    this.FillGridArivu();
                }
                else
                {
                    DisplayAlert("Describe the Reason for HOLD", this);
                    CEOARConfirmHoldPopup.Show();
                }
            }
            else
            {
                DisplayAlert("Enter the Reason for HOLD", this);
                CEOARConfirmHoldPopup.Show();
            }

        }
        protected void btnDOCARDisplayCollegeDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvDOCARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
            lblDOCARBDUpdateApplicationNumber.Text = BD.ApplicationNumber;
            lblDOCARBDUpdateAccountHolderName.Text = BD.ApplicantName;
            txtDOCARBDUpdateAccountNumber.Text = BD.AccountNumber;
            txtDOCARBDUpdateBankName.Text = BD.BankName;
            txtDOCARBDUpdateBranchName.Text = BD.Branch;
            txtDOCARBDUpdateIFSCCode.Text = BD.IFSCCode;
            txtDOCARBDUpdateBankAddress.Text = BD.BankAddress;
            DOCARBankDetailsUpdatePopup.Show();
        }
        protected void drpARRenewalInstalment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpARRenewalInstalment.SelectedItem.Text != "--SELECT--")
            {
                DMP.Instalment = drpARRenewalInstalment.SelectedValue;
                gvARRenewalProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess", DMP.Instalment, Session["District"].ToString());
                gvARRenewalProcess.DataBind();
                divRenewalGridview.Visible = true;
            } 
        }

        protected void txtInstalment1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtInstalment2_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtInstalment3_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtInstalment4_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtInstalment5_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtInstalment6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gvDMARApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text.Contains("REJECTED"))
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[7].Text.Contains("APPROVED"))
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.DarkOliveGreen;
                }

                if (e.Row.Cells[8].Text.Contains("REJECTED"))
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[8].Text.Contains("APPROVED"))
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.DarkOliveGreen;
                }
            }
        }
        protected void gvCEOARApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[8].Text.Contains("REJECTED"))
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[8].Text.Contains("HOLD"))
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Orange;
                }
                if (e.Row.Cells[8].Text.Contains("WAITING"))
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Blue;
                }

            }
        }
        protected void gvDOCARApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[8].Text.Contains("REJECTED"))
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[8].Text.Contains("HOLD"))
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Orange;
                }
                if (e.Row.Cells[8].Text.Contains("WAITING"))
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Blue;
                }

            }
        }
        protected void gvDMSEApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text.Contains("Ineligible"))
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[7].Text.Contains("ELIGIBLE"))
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.ForestGreen;
                }

                if (e.Row.Cells[8].Text.Contains("Ineligible"))
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[8].Text.Contains("ELIGIBLE"))
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.ForestGreen;
                }
            }
        }
        protected void gvCEOSEApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text.Contains("REJECTED"))
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[7].Text.Contains("HOLD"))
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Orange;
                }
                if (e.Row.Cells[7].Text.Contains("WAITING"))
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Blue;
                }

            }
        }
        protected void gvDOCSEApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text.Contains("REJECTED"))
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[7].Text.Contains("HOLD"))
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Orange;
                }
                if (e.Row.Cells[7].Text.Contains("WAITING"))
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Blue;
                }

            }
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