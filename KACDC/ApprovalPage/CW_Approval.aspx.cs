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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FetchCount();
            }

        }
        protected void FetchCount()
        {
            SE.CWSETotalApplicationCount = CwGetCount.GetTotalCount("spGetApplicationCount", "CWSECount");
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
    }
}