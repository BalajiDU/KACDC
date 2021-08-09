using KACDC.Class.DataProcessing.MasterPage;
using KACDC.Class.DataProcessing.SMSService;
using KACDC.Class.Declaration.MessageDeclaration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        Message MSGDEC = new Message();
        MasterSettings MS = new MasterSettings();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
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


        protected void Language_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKannada.Checked == true)
            {
                rbSingle.Enabled = false;
                rbBulk.Enabled = false;
                MSGDEC.SelectedLacguage = "Kannada";
                DropDownBinding();
            }
            else if (rbEnglish.Checked == true)
            {
                rbSingle.Enabled = true;
                rbBulk.Enabled = true;
                MSGDEC.SelectedLacguage = "English";
                DropDownBinding();
            }
        }
        private void DropDownBinding()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select TemplateName from SMSTemplate where SMSLanguage=@SMSLanguage"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@SMSLanguage", MSGDEC.SelectedLacguage);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpCategory.DataSource = cmd.ExecuteReader();
                    drpCategory.DataTextField = "TemplateName";
                    drpCategory.DataValueField = "TemplateID";
                    drpCategory.DataBind();
                    drpCategory.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
        }
        protected void drpContDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from SMSTemplate where TemplateID=@TemplateID"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TemplateID", drpCategory.SelectedValue);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        MSGDEC.TemplateID = sdr["TemplateID"].ToString();
                        MSGDEC.TemplateName = sdr["TemplateName"].ToString();
                        MSGDEC.Category = sdr["Category"].ToString();
                        MSGDEC.SMSLanguage = sdr["SMSLanguage"].ToString();
                        MSGDEC.SMSUser = sdr["SMSUser"].ToString();
                        MSGDEC.TemplateMessage = sdr["TemplateMessage"].ToString();
                        kvdConn.Close();

                        //return cmd.Parameters["@RetValue"].Value.ToString() != "" ? cmd.Parameters["@RetValue"].Value.ToString() : "NA";
                        
                    }
                }
            }
            MSGDEC.SenderUserName = MSGDEC.SMSUser == "KAVDES" ? "Mobile_1-KAVDES" : "Mobile_1-GKACDC";
            string[] str = new string[5];
            str = MS.GetData("GET", MSGDEC.SenderUserName);
            MSGDEC.SenderPassword = str[0];
            MSGDEC.SenderAPIkey = str[1];

            txtMessage.Text = MSGDEC.TemplateMessage;
        }
        protected void btnSendMessage_Click(object sender, EventArgs e)
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