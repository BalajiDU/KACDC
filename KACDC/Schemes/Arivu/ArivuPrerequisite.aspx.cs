using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.Schemes.Arivu
{
    public partial class ArivuPrerequisite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnArivu_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\DownloadAppn.aspx");
        }
        protected void btnRenewal_Click(object sender, EventArgs e)
        {
            
        }
    }
}