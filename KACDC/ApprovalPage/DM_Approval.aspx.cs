using KACDC.Class.DataProcessing;
using KACDC.Class.DataProcessing.ApplicationProcess;
using KACDC.Class.DataProcessing.ApplicationProcess;
using KACDC.Class.DataProcessing.ApplicationProcess.BankDetails;
using KACDC.Class.DataProcessing.BankData;
using KACDC.Class.DataProcessing.FileProcessing.CreatePDF.ApplicationProcess;
using KACDC.Class.DataProcessing.OnlineApplication.Arivu;
using KACDC.Class.Declaration.ApprovalProcess;
using KACDC.Class.Declaration.ApprovalProcess.ArivuRenewal;
using KACDC.Class.Declaration.ApprovalProcess.DistrictManager;
using KACDC.Class.GetCountStatistics;
using System;
using System.Collections.Generic;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "DISTRICTMANAGER")
            {
                Response.Redirect("~/Login.aspx");
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
        protected void rbCollegeHostel_CheckedChanged(object sender, EventArgs e)
        {

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

        }
        protected void btnDMARHold_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMARReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMARDownloadExcelForCEO_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMARConfirmRejectApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMARConfirmHoldApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMARConfirmApproveApplication_Click(object sender, EventArgs e)
        {

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

        }
        protected void btnCEOARWaiting_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOARHold_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOARReject_Click(object sender, EventArgs e)
        {

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

        }
        protected void btnCEOARConfirmApproveApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOARConfirmWaitingApplication_Click(object sender, EventArgs e)
        {

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

        }
        protected void btnDOCARApprove_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCARHold_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCARReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMARSubmitToZM_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCARConfirmRejectApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCARConfirmHoldApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCARConfirmApproveApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnPnlCollegeDetailsClose_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCARBDUpdate_Click(object sender, EventArgs e)
        {

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
        }
        protected void btnARRenewalDisplayBankDetailsUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvARRenewalProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
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

        }
        protected void btnDMSEHold_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMSEReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMSEDownloadExcelForCEO_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMSEConfirmHoldApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMSEConfirmApproveApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMSEConfirmRejectApplication_Click(object sender, EventArgs e)
        {

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

        }
        protected void btnCEOSEWaiting_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOSEHold_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOSEReject_Click(object sender, EventArgs e)
        {

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

        }
        protected void btnCEOSEConfirmApproveApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOSEConfirmWaitingApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOSEConfirmRejectApplication_Click(object sender, EventArgs e)
        {

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

        }
        protected void btnDOCSEApprove_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCSEHold_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCSEReject_Click(object sender, EventArgs e)
        {

        }
        protected void btnDMSESubmitToZM_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCSEConfirmHoldApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCSEConfirmApproveApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCSEConfirmRejectApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCSEBDUpdate_Click(object sender, EventArgs e)
        {

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

        }
        protected void rbDMSEConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void rbCEOSEConfirmRejectReasonNotSelected_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void rbDOCSEConfirmReject_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void rbDMARConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void btnDMARCEOGenerateReport_Click(object sender, EventArgs e)
        {

        }
        protected void btnCEOARConfirmHoldApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnDOCARDisplayCollegeDetails_Click(object sender, EventArgs e)
        {

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

        }
        protected void gvCEOARApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void gvDOCARApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void gvDMSEApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void gvCEOSEApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void gvDOCSEApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
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