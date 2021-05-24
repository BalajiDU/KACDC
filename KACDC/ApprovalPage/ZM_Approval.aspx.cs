using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.ApprovalPage
{
    public partial class ZM_Approval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "ZONALMANAGER")
            {
                Response.Redirect("~/Login.aspx");
                //UserName = Session["UserName"].ToString();
            }
        }
    }
}