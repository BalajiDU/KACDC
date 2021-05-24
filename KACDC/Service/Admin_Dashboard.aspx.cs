using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.Service
{
    public partial class Admin_Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "DASHBOARD")
            {
                Response.Redirect("~/Login.aspx");
                //UserName = Session["UserName"].ToString();
            }
        }
    }
}