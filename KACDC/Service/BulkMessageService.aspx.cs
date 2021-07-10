using KACDC.Class.DataProcessing.SMSService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.Service
{
    public partial class BulkMessageService : System.Web.UI.Page
    {
        SendSMS SSMS = new SendSMS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSendSingleMessage_Click(object sender, EventArgs e)
        {
            if(txtMobileNumber.Text.Trim() != "")
            {
                if (txtMobileNumber.Text.Trim().Length == 10)
                {
                    if (Regex.IsMatch(txtMobileNumber.Text.Trim(), @"^\d+$"))
                    {
                        string status = "";
                        if (txtMessage.Text.Trim() != "")
                        {
                            status = SSMS.sendSMS(txtMobileNumber.Text.Trim(), txtMessage.Text.Trim(), 2, "SINGLE");
                            if (status.StartsWith("402")||status== "Message Sent")
                            {
                                DisplayAlert("Message Sent", this);
                            }
                            else
                            {
                                DisplayAlert(status, this);
                            }
                        }
                        else
                        {
                            DisplayAlert("Enter Valid Message Number", this);
                        }
                    }
                    else
                    {
                        DisplayAlert("Enter Valid Mobile Number", this);
                    }
                }
                else
                {
                    DisplayAlert("Enter Valid Mobile Number", this);
                }
            }
            else
            {
                DisplayAlert("Enter Mobile Number", this);
            }
        }
        protected void btnSendSingleUnicodeMessage_Click(object sender, EventArgs e)
        {
            if (txtMobileNumber.Text.Trim() != "")
            {
                string status = "";
                if (txtMessage.Text.Trim() != "")
                {
                    status = SSMS.sendSMS(txtMobileNumber.Text.Trim(), txtMessage.Text.Trim(), 1, "COVIDMSG");
                    if (status.StartsWith("402"))
                    {
                        DisplayAlert("Message Sent", this);
                    }
                    else
                    {
                        DisplayAlert(status, this);
                    }
                }
            }
        }
        protected void btnSendServerBulkMessage_Click(object sender, EventArgs e)
        {
            if (txtMobileNumber.Text.Trim() != "")
            {
                string status = "";
                if (txtMessage.Text.Trim() != "")
                {
                    status = SSMS.sendSMS(txtMobileNumber.Text.Trim(), txtMessage.Text.Trim(), 2, "BULK");
                    if (status.StartsWith("402"))
                    {
                        DisplayAlert("Message Sent", this);
                    }
                    else
                    {
                        DisplayAlert(status, this);
                    }
                }
            }
        }
        protected void btnMessageLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
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