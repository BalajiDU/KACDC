using KACDC.Class.JobScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.TestForms
{
    public partial class TestForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
            }
            Console.WriteLine("<br /><br />");
            HangFireJobScheduler HF = new HangFireJobScheduler();
            HF.RunNow();
            HF.RunOnSchedule();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType== DataControlRowType.DataRow)
            {
                if(e.Row.Cells[5].Text== "DEFAULTER")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(e.Row.Cells[7].Text, @"\d"))
                {
                    if (Convert.ToInt32(e.Row.Cells[7].Text) > 3)
                    {
                        e.Row.ForeColor = System.Drawing.Color.DarkSeaGreen;
                    }
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(e.Row.Cells[7].Text, @"\d"))
                {
                    if (Convert.ToInt32(e.Row.Cells[7].Text) <=2)
                    {
                        e.Row.ForeColor = System.Drawing.Color.DeepSkyBlue;
                    }
                }
            }
        }
    }
}