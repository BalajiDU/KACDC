using KACDC.Class.Declaration.ApprovalProcess.CaseWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KACDC.Class.GetCountStatistics;

namespace KACDC.ApprovalPage
{
    public partial class CW_Approval : System.Web.UI.Page
    {
        CWApprovalArivu AR = new CWApprovalArivu();
        CWApprovalSelfEmploymentcs SE = new CWApprovalSelfEmploymentcs();
        GetCount CwGetCount = new GetCount();
        CWProcess CWP = new CWProcess();
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
           
        }
        protected void btnCWARDisplayCollegeDetails_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWArApprove_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWArHold_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWArReject_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCwArConfirmRejectApplication_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCwArConfirmHoldApplication_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCwArConfirmApproveApplication_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnPnlCollegeDetailsClose_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCwArGetApplicationStatus_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWSEDisplayBankDetails_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWSEApprove_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWSEHold_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCWASEReject_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCwSEConfirmHoldApplication_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCwSEConfirmApproveApplication_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCwSEConfirmRejectApplication_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnCwSEGetApplicationStatus_Click(object sender, EventArgs e)
        {
           
        }
        protected void gvCwARApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
        protected void gvCwSEApproveProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
        protected void rbCWArConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        protected void rbCWSEConfirmRejectReasonName_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        
    }
}