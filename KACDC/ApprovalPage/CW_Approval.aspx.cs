using KACDC.Class.Declaration.ApprovalProcess.CaseWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KACDC.Class.GetCountStatistics;
using KACDC.Class.DataProcessing;
using KACDC.Class.DataProcessing.ApplicationProcess;
using KACDC.Class.DataProcessing.ApplicationProcess.BankDetails;
using KACDC.Class.Declaration.ApprovalProcess;

namespace KACDC.ApprovalPage
{
    public partial class CW_Approval : System.Web.UI.Page
    {
        CWApprovalArivu AR = new CWApprovalArivu();
        CWApprovalSelfEmploymentcs SE = new CWApprovalSelfEmploymentcs();
        GetCount CwGetCount = new GetCount();
        CWProcess CWP = new CWProcess();
        ApprovalProcess AP = new ApprovalProcess();
        GetDataToProcess GDTP = new GetDataToProcess();
        GetBankDetails GBD = new GetBankDetails();
        SBankDetails BD = new SBankDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "CASEWORKER")
            {
                Response.Redirect("~/Login.aspx");
                //UserName = Session["UserName"].ToString();
            }
            CWP.CWDistrict = Session["District"].ToString();
            if (!IsPostBack)
            {
                this.FetchCount();
                this.FillGrid();
            }

        }
        protected void FetchCount()
        {
            SE.CWSETotalApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSECount","",CWP.CWDistrict);
            SE.CWSEApprovedApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSECount", "APPROVED");
            SE.CWSEPendingApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSECount", "PENDING");
            SE.CWSERejectedApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSECount", "REJECTED");
            SE.CWSEHoldApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSECount", "HOLD");

            AR.CWARTotalApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWARCount");
            AR.CWARApprovedApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWARCount", "APPROVED");
            AR.CWARPendingApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWARCount", "PENDING");
            AR.CWARRejectedApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWARCount", "REJECTED");
            AR.CWARHoldApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWARCount", "HOLD");
            lblArivuStatistics.Text = "<strong>T-" + AR.CWARTotalApplicationCount + "</strong> (P-" + AR.CWARPendingApplicationCount + " , A-" + AR.CWARApprovedApplicationCount + " , R-" + AR.CWARRejectedApplicationCount + " , H-" + AR.CWARHoldApplicationCount + ")";
            lblSEStatistics.Text = "<strong>T-" + SE.CWSETotalApplicationCount + "</strong> (P-" + SE.CWSEPendingApplicationCount + " , A-" + SE.CWSEApprovedApplicationCount + " , R-" + SE.CWSERejectedApplicationCount + " , H-" + SE.CWSEHoldApplicationCount + ")";
            //DisplayAlert(SE.CWSETotalApplicationCount, this);
            lblCWARWelMaleCountReceived.Text= CwGetCount.GetTotalCount("spGetApplicationCount", "CWARGenderCountTotal", "",CWP.CWDistrict,"MALE");
            lblCWARWelMaleCountApproved.Text= CwGetCount.GetTotalCount("spGetApplicationCount", "CWARGenderCountApproved", "",CWP.CWDistrict,"MALE");

            lblCWSEWelMaleCountReceived.Text= CwGetCount.GetTotalCount("spGetApplicationCount", "CWSEGenderCountTotal", "",CWP.CWDistrict,"MALE");
            lblCWSEWelMaleCountApproved.Text= CwGetCount.GetTotalCount("spGetApplicationCount", "CWSEGenderCountApproved", "",CWP.CWDistrict,"MALE");

            lblCWARWelFemaleCountReceived.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWARGenderCountTotal", "", CWP.CWDistrict, "FEMALE");
            lblCWARWelFemaleCountApproved.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWARGenderCountApproved", "", CWP.CWDistrict, "FEMALE");

            lblCWSEWelFemaleCountReceived.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSEGenderCountTotal", "", CWP.CWDistrict, "FEMALE");
            lblCWSEWelFemaleCountApproved.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSEGenderCountApproved", "", CWP.CWDistrict, "FEMALE");

            lblCWARWelPWDCountReceived.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWARPWDCountTotal", "", CWP.CWDistrict);
            lblCWARWelPWDCountApproved.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWARPWDCountApproved", "", CWP.CWDistrict);

            lblCWSEWelPWDCountReceived.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSEPWDCountTotal", "", CWP.CWDistrict);
            lblCWSEWelPWDCountApproved.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSEPWDCountApproved", "", CWP.CWDistrict);

            lblCWSEWelWidowCountReceived.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSEWidowCountTotal", "", CWP.CWDistrict);
            lblCWSEWelWidowCountApproved.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSEWidowCountApproved", "", CWP.CWDistrict);

            lblCWSEWelDivorcedCountReceived.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSEDivorcedCountTotal", "", CWP.CWDistrict);
            lblCWSEWelDivorcedCountApproved.Text = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSEDivorcedCountApproved", "", CWP.CWDistrict);

        }
        private void FillGrid()
        {
            this.FillGridSelfEmployment();

            this.FillGridArivu();
        }
        private void FillGridArivu()
        {

            gvCWARApproveProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess", "ARSELECTCW", Session["District"].ToString());
            gvCWARApproveProcess.DataBind();
            
        }
        private void FillGridSelfEmployment()
        {

            gvCWSEApproveProcess.DataSource = GDTP.GetData("spGetDataToApprovalProcess", "SESELECTCW", Session["District"].ToString());
            gvCWSEApproveProcess.DataBind();

        }
        public static void DisplayAlert(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            //page.ClientScript.RegisterStartupScript(owner.GetType(),"ShowMessage", string.Format("<script type=text/javascript>alert({0})</script>",
            //    message));
            message = message.ToUpper();
            ScriptManager.RegisterClientScriptBlock(owner, owner.GetType(), "alertMessage", "alert(" + message + ")", true);
        }
        //9870346347
        protected void btnCWLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
        protected void btnCWARDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvCWARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "AR");
            lblCWARBDApplicationNumber.Text = BD.ApplicationNumber;
            lblCWARBDAccountHolderName.Text = BD.ApplicantName;
            lblCWARBDAccountNumber.Text = BD.AccountNumber;
            lblCWARBDBankName.Text = BD.BankName;
            lblCWARBDBranchName.Text = BD.Branch;
            lblCWARBDIFSCCode.Text = BD.IFSCCode;
            lblCWARBDBankAddress.Text = BD.BankAddress;
            CWARBankDetailsPopup.Show();
        }
        protected void btnCWARDisplayCollegeDetails_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWARApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCWARConfirmApproveAppNumber.Text = gvCWARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCWARConfirmApproveAppName.Text = gvCWARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CWARConfirmApprovePopup.Show();
        }
        protected void btnCWARHold_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCWARConfirmHoldAppNumber.Text = gvCWARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCWARConfirmHoldAppName.Text = gvCWARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CWARConfirmHoldPopup.Show();
        }
        protected void btnCWARReject_Click(object sender, EventArgs e)
        {
            rbCWARConfirmRejectReasonOther.Checked = false;
            rbCWARConfirmRejectReasonName.Checked = false;
            rbCWARConfirmRejectReasonCET.Checked = false;
            divCWARRejectReason.Visible = false;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCWARConfirmRejectAppNumber.Text = gvCWARApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCWARConfirmRejectAppName.Text = gvCWARApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CWARConfirmRejectPopup.Show();
        }
        protected void btnCWARConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            if (txtCWARConfirmRejectAppReason.Text.Trim() != "")
            {
                if (txtCWARConfirmRejectAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("ARCWPROCESS", "REJECTED", lblCWARConfirmRejectAppNumber.Text, txtCWARConfirmRejectAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    DisplayAlert("Reason must be above 10 characters", this);
                    CWARConfirmRejectPopup.Show();
                }
            }
            else
            {
                DisplayAlert("Enter Reason", this);
                CWARConfirmRejectPopup.Show();
            }
        }
        protected void btnCWARConfirmHoldApplication_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWARConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate("ARCWPROCESS", "APPROVED", lblCWARConfirmApproveAppNumber.Text);
            this.FillGridArivu();
        }
        protected void btnPnlCollegeDetailsClose_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWARGetApplicationStatus_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWSEDisplayBankDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            GBD.GetApplicantBankDetails(gvCWSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString(), "SE");
            lblCWSEBDApplicationNumber.Text = BD.ApplicationNumber;
            lblCWSEBDAccountHolderName.Text = BD.ApplicantName;
            lblCWSEBDAccountNumber.Text = BD.AccountNumber;
            lblCWSEBDBankName.Text = BD.BankName;
            lblCWSEBDBranchName.Text = BD.Branch;
            lblCWSEBDIFSCCode.Text = BD.IFSCCode;
            lblCWSEBDBankAddress.Text = BD.BankAddress;
            CWSEBankDetailsPopup.Show();
        }
        protected void btnCWSEApprove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCWSEConfirmApproveAppNumber.Text = gvCWSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCWSEConfirmApproveAppName.Text = gvCWSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CWSEConfirmApprovePopup.Show();
        }
        protected void btnCWSEHold_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCWSEConfirmHoldAppNumber.Text = gvCWSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCWSEConfirmHoldAppName.Text = gvCWSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CWSEConfirmHoldPopup.Show();
        }
        protected void btnCWSEReject_Click(object sender, EventArgs e)
        {
            rbCWSEConfirmRejectReasonName.Checked = false;
            rbCWSEConfirmRejectReasonOther.Checked = false;
            divCWSERejectReason.Visible = false;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblCWSEConfirmRejectAppNumber.Text = gvCWSEApproveProcess.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblCWSEConfirmRejectAppName.Text = gvCWSEApproveProcess.DataKeys[rowindex].Values["ApplicantName"].ToString();
            CWSEConfirmRejectPopup.Show();
        }
        protected void btnCWSEConfirmHoldApplication_Click(object sender, EventArgs e)
        {
            if (txtCWSEConfirmHoldAppReason.Text.Trim() != "")
            {
                if (txtCWSEConfirmHoldAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("SECWPROCESS", "HOLD", lblCWSEConfirmHoldAppNumber.Text, txtCWSEConfirmHoldAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    DisplayAlert("Reason must be above 10 characters", this);
                    CWSEConfirmHoldPopup.Show();
                }
            }
            else
            {
                DisplayAlert("Enter Reason", this);
                CWSEConfirmHoldPopup.Show();
            }
        }
        protected void btnCWSEConfirmApproveApplication_Click(object sender, EventArgs e)
        {
            AP.ApplicationStatusUpdate("SECWPROCESS", "APPROVED", lblCWSEConfirmApproveAppNumber.Text);
            this.FillGridSelfEmployment();
        }
        protected void btnCWSEConfirmRejectApplication_Click(object sender, EventArgs e)
        {
            if (txtCWSEConfirmRejectAppReason.Text.Trim() != "")
            {
                if (txtCWSEConfirmRejectAppReason.Text.Trim().Length >= 10)
                {
                    AP.ApplicationStatusUpdate("SECWPROCESS", "REJECTED", lblCWSEConfirmRejectAppNumber.Text, txtCWSEConfirmRejectAppReason.Text.Trim());
                    this.FillGridSelfEmployment();
                }
                else
                {
                    DisplayAlert("Reason must be above 10 characters", this);
                    CWSEConfirmRejectPopup.Show();
                }
            }
            else
            {
                DisplayAlert("Enter Reason", this);
                CWSEConfirmRejectPopup.Show();
            }
        }
        protected void btnCWSEGetApplicationStatus_Click(object sender, EventArgs e)
        {
           
        }
        protected void gvCWARApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
        protected void gvCWSEApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
        protected void rbCWARConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCWARConfirmRejectReasonName.Checked)
            {
                txtCWARConfirmRejectAppReason.Text = "Applicant Name Mismatch";
                divCWARRejectReason.Visible = true;
                CWARConfirmRejectPopup.Show();
            }
            if (rbCWARConfirmRejectReasonCET.Checked)
            {
                txtCWARConfirmRejectAppReason.Text = "Invalid CET Certificate";
                divCWARRejectReason.Visible = true;
                CWARConfirmRejectPopup.Show();
            }
            if (rbCWARConfirmRejectReasonOther.Checked)
            {
                txtCWARConfirmRejectAppReason.Text = "";
                divCWARRejectReason.Visible = true;
                CWARConfirmRejectPopup.Show();
            }
        }
        protected void rbCWSEConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCWSEConfirmRejectReasonName.Checked)
            {
                divCWSERejectReason.Visible = true;
                txtCWSEConfirmRejectAppReason.Text = "Applicant Name Mismatch";
                CWSEConfirmRejectPopup.Show();
            }
            if (rbCWSEConfirmRejectReasonOther.Checked)
            {
                divCWSERejectReason.Visible = true;
                txtCWSEConfirmRejectAppReason.Text = "";
                CWSEConfirmRejectPopup.Show();
            }
        }
        
        
    }
}