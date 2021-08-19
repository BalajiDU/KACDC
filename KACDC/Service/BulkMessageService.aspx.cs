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
            if (Session["USERTYPE"] != "MESSAGESERVICE")
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                txtMobileNumber.Enabled = false;
                MSGDEC.TemplateID = "";
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
                rbSingle.Enabled = true;
                rbBulk.Enabled = true;
                MSGDEC.SelectedLacguage = "Kannada";
                MSGDEC.MessageType = "";
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
        protected void Type_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSingle.Checked == true)
            {
                MSGDEC.MessageType = "Single";
            }
            else if (rbBulk.Checked == true)
            {
                MSGDEC.MessageType = "Bulk";
            }
        }
        protected void MobEnable_CheckedChanged(object sender, EventArgs e)
        {
            MobileTextbox();
        }
        private void MobileTextbox()
        {
            if (rbEnable.Checked == true)
            {
                txtMobileNumber.Enabled = true;
            }
            else if (rbDisable.Checked == true)
            {
                txtMobileNumber.Enabled = false;
            }
        }
        protected void Recipient_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBeneficiary.Checked == true || rbApplicants.Checked == true)
            {
                rbEnable.Checked = false;
                rbDisable.Checked = true;
                txtMobileNumber.Enabled = false;
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetSEMobileNumber"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MethodName", rbBeneficiary.Checked==true ? "Beneficiary" : "Applicants");
                        cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar, -1);
                        cmd.Parameters["@MobileNumber"].Direction = ParameterDirection.Output;
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            kvdConn.Close();
                            txtMobileNumber.Text= cmd.Parameters["@MobileNumber"].Value.ToString();
                            //string aassdfgasdfaddff = cmd.Parameters["@M"].Value.ToString();
                        }
                        kvdConn.Close();
                    }
                }
            }
            else if (rbCustom.Checked == true)
            {
                rbEnable.Checked = true;
                MobileTextbox();
                //MSGDEC.MessageType = "Bulk";
            }
        }
        private void DropDownBinding()
        {
            if (rbEnglish.Checked == true || rbKannada.Checked == true)
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select TemplateName,TemplateID from SMSTemplate where SMSLanguage=@SMSLanguage"))
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
        }
        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
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
            int numberlen = (txtMobileNumber.Text.Trim().Length) % 11;
            if (rbEnglish.Checked == true || rbKannada.Checked == true)
            {
                if (rbSingle.Checked == true || rbBulk.Checked == true)
                {
                    if (MSGDEC.TemplateID != "")
                    {
                        if (txtMobileNumber.Text.Trim() != "")
                        {
                            if (txtMessage.Text.Trim() != "")
                            {
                                if (MSGDEC.MessageType == "Single" && txtMobileNumber.Text.Trim().Length == 10)
                                {
                                    DisplayAlert(
                SSMS.BulkMessaging(MSGDEC.SenderUserName, MSGDEC.SenderPassword, MSGDEC.SMSUser, txtMobileNumber.Text.Trim(), txtMessage.Text.Trim(), MSGDEC.SenderAPIkey, MSGDEC.TemplateID, MSGDEC.SMSLanguage, MSGDEC.MessageType, MSGDEC.Category)
                , this);
                                }
                                else if (MSGDEC.MessageType == "Bulk" && (txtMobileNumber.Text.Trim().Length) % 11 == 10)
                                {
                                    DisplayAlert(
                SSMS.BulkMessaging(MSGDEC.SenderUserName, MSGDEC.SenderPassword, MSGDEC.SMSUser, txtMobileNumber.Text.Trim(), txtMessage.Text.Trim(), MSGDEC.SenderAPIkey, MSGDEC.TemplateID, MSGDEC.SMSLanguage, MSGDEC.MessageType, MSGDEC.Category)
                , this);
                                }
                                else
                                {
                                    DisplayAlert("enter valid mobile number", this);
                                }
                            }
                            else
                            {
                                DisplayAlert("enter message", this);
                            }
                        }
                        else
                        {
                            DisplayAlert("enter mobile number", this);
                        }
                    }
                    else
                    {
                        DisplayAlert("Please Select Message Category", this);
                    }
                }
                else
                {
                    DisplayAlert("Please Select message type", this);
                }
            }
            else
            {
                DisplayAlert("Please Select language", this);
            }
            ////if (txtMobileNumber.Text.Trim() != "")
            ////{
            ////    if (MSGDEC.MessageType == "Single" && txtMobileNumber.Text.Trim().Length == 10)
            ////    {

            ////    }
            ////    else if (MSGDEC.MessageType == "Bulk" && (txtMobileNumber.Text.Trim().Length) % 11 == 10)
            ////    {

            ////    }
            ////    //string status = "";
            ////    //if (txtMessage.Text.Trim() != "")
            ////    //{
            ////    //    status = SSMS.sendSMS(txtMobileNumber.Text.Trim(), txtMessage.Text.Trim(), 2, "BULK");
            ////    //    if (status.StartsWith("402"))
            ////    //    {
            ////    //        DisplayAlert("Message Sent", this);
            ////    //    }
            ////    //    else
            ////    //    {
            ////    //        DisplayAlert(status, this);
            ////    //    }
            ////    //}
            ////}
            //sendSingleSMS(String username, String password, String senderid, string mobileNo, String message, String secureKey, String templateid)
            //sendBulkSMS(String username, String password, String senderid, string mobileNos, String message, String secureKey, String templateid)
            //sendUnicodeSMS(String username, String password, String senderid, String mobileNos, String Unicodemessage, String secureKey, String templateid)
            
        }
        protected void btnRegisterMessageTemplate_Click(object sender, EventArgs e)
        {
            ClearTemplateRegistration();
            RegTempPopup.Show();
        }
        protected void btnRegtemplate_Click(object sender, EventArgs e)
        {
            if(rbRegEnglish.Checked == true || rbRegKannada.Checked == true)
            {
                if (rbRegGKACDC.Checked == true || rbRegKAVDES.Checked == true)
                {
                    if(txtRegTemplateID.Text.Trim() != "")
                    {
                        if (txtRegTemplateName.Text.Trim() != "")
                        {
                            if (txtRegCategory.Text.Trim() != "")
                            {
                                if (txtRegCategory.Text.Trim().Length == 6)
                                {
                                    if (txtRegMessage.Text.Trim() != "")
                                    {
                                        InsertTemplate();
                                        DropDownBinding();
                                        ClearTemplateRegistration();
                                        DisplayAlert("template registered", this);
                                    }
                                    else
                                    {
                                        DisplayAlert("Enter Template message", this);
                                        RegTempPopup.Show();
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Enter Category must be 6 characters", this);
                                    RegTempPopup.Show();
                                }
                            }
                            else
                            {
                                DisplayAlert("Enter template Category", this);
                                RegTempPopup.Show();
                            }
                        }
                        else
                        {
                            DisplayAlert("Enter template name", this);
                            RegTempPopup.Show();
                        }
                    }
                    else
                    {
                        DisplayAlert("Enter template id", this);
                        RegTempPopup.Show();
                    }
                }
                else
                {
                    DisplayAlert("select user", this);
                    RegTempPopup.Show();
                }
            }
            else
            {
                DisplayAlert("select language", this);
                RegTempPopup.Show();
            }
            
        }
        protected void btnRegClear_Click(object sender, EventArgs e)
        {
            ClearTemplateRegistration();
            RegTempPopup.Show();
        }
        private void ClearTemplateRegistration()
        {
            rbRegEnglish.Checked = false;
            rbRegKannada.Checked = false;
            rbRegGKACDC.Checked = false;
            rbRegKAVDES.Checked = false;
            txtRegCategory.Text = "";
            txtRegMessage.Text = "";
            txtRegTemplateID.Text = "";
            txtRegTemplateName.Text = "";
        }
        private void InsertTemplate()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[SMSTemplate]([TemplateID],[TemplateName],[Category],[SMSLanguage],[SMSUser],[TemplateMessage])VALUES(@TemplateID , @TemplateName, @Category, @SMSLanguage, @SMSUser, @TemplateMessage)", kvdConn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TemplateID", txtRegTemplateID.Text.Trim());
                    cmd.Parameters.AddWithValue("@TemplateName", txtRegTemplateName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Category", txtRegCategory.Text.Trim());
                    cmd.Parameters.AddWithValue("@SMSLanguage", rbRegEnglish.Checked==true ? "English" : "Kannada");
                    cmd.Parameters.AddWithValue("@SMSUser", rbRegGKACDC.Checked == true ? "GKACDC" : "KAVDES");
                    cmd.Parameters.AddWithValue("@TemplateMessage", txtRegMessage.Text.Trim());
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
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