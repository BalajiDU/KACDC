using KACDC.Class.DataProcessing.EmailService;
using KACDC.Class.DataProcessing.EncryptionProcess;
using KACDC.Class.DataProcessing.OnlineApplication.AryaVysyaPortalStore;
using KACDC.Class.DataProcessing.OTPService;
using KACDC.Class.DataProcessing.SMSService;
using KACDC.Class.Declaration.OnlineApplication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.Schemes.AryaVysyaPortal
{
    public partial class AryaVysyaPortal : System.Web.UI.Page
    {
        AVPortal AVP = new AVPortal();
        SendSMS SM = new SendSMS();
        Encryption Enc = new Encryption();
        OTP otp = new OTP();
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblNotificationHeading.Text = "";
            //lblNotificationContent.Text = "";
            if (!IsPostBack)
            {
                this.FillDistrict();
                calDOB.EndDate = DateTime.Now;
            }
        }
        protected void btnVerifyMobileNumber_Click(object sender, EventArgs e)
        {
            
            //lblOTPError.Text = "";
            if (txtMobileNumber.Text != "")
            {
                if (txtMobileNumber.Text.Trim().Length == 10)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(txtMobileNumber.Text.Trim(), @"^\d+$"))
                    {
                        AryaVysyaPortalSave AVPS = new AryaVysyaPortalSave();
                        if (AVPS.CheckMobileNumExist(txtMobileNumber.Text.Trim()))
                        {
                            txtOTP.Text = "";
                            //txtOTP.Focus();

                            AVP.EncryptedOTP = Enc.Encrypt(otp.NewOTP());
                            string Message = Enc.Decrypt(AVP.EncryptedOTP) + " is your OTP to verify your mobile number for Arya Vysya Portal. do not share with others. From: KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION LTD";
                            SM.sendSMS(txtMobileNumber.Text.Trim(), Message, 2, "MOBVER");
                            AVPMobileNumVerifyPopup.Show();
                        }
                        else 
                        {
                            //lblNotificationHeading.Text = "Exist";
                            //lblNotificationContent.Text = "/*Mobile Number already exist, Change Mobile Number*/";
                            txtMobileNumber.ReadOnly = false;
                            btnVerifyMobileNumber.Visible = true;
                            DisplayAlert("Mobile Number already exist, Change Mobile Number", this);
                            //NotifyOtherDetailsPopup.Show();
                        }
                    }
                    else
                    {
                        //lblNotificationHeading.Text = "Error";
                        //lblNotificationContent.Text = "";
                        txtMobileNumber.Focus();
                        DisplayAlert("Enter Valid Mobile Number", this);
                        //NotifyOtherDetailsPopup.Show();
                    }
                }
                else
                {
                    lblNotificationHeading.Text = "Error";
                    lblNotificationContent.Text = "";
                    //NotifyOtherDetailsPopup.Show();
                    DisplayAlert("Enter Valid Mobile Number", this);
                    txtMobileNumber.Focus();
                }
            }
            else
            {
                lblNotificationHeading.Text = "Error";
                lblNotificationContent.Text = "";
                txtMobileNumber.Focus();
                DisplayAlert("Enter Mobile Number", this);
                //NotifyOtherDetailsPopup.Show();
            }
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
            {
                AVP.Name = txtName.Text.Trim();
                lblNameError.Text = "";
                if (txtFatherName.Text.Trim() != "")
                {
                    AVP.FatherName = txtFatherName.Text.Trim();
                    lblFatherNameError.Text = "";
                    if (rbMale.Checked == true || rbFemale.Checked == true)
                    {
                        AVP.Gender = rbMale.Checked ? "MALE" : "FEMALE";
                        if (rbPhysicallyChallengedYes.Checked == true || rbPhysicallyChallengedNo.Checked == true)
                        {
                            AVP.PhysicallyChallenged = rbPhysicallyChallengedYes.Checked ? "YES" : "NO";
                            if (txtAddress.Text.Trim() != "")
                            {
                                AVP.Address = txtAddress.Text.Trim();

                                if (txtPincode.Text.Trim() != "")
                                {
                                    AVP.Pincode = txtPincode.Text.Trim();
                                    if (drpDistrict.SelectedValue != "0" && drpDistrict.SelectedItem.Text.ToUpper() != "--SELECT--")
                                    {
                                        AVP.District = drpDistrict.SelectedValue;
                                        if (drpDistrict.SelectedValue != "0" && drpDistrict.SelectedItem.Text.ToUpper() != "--SELECT--")
                                        {
                                            AVP.District = drpDistrict.SelectedItem.Text;
                                            if (drpTaluk.SelectedValue != "0" && drpTaluk.SelectedItem.Text.ToUpper() != "--SELECT--")
                                            {
                                                AVP.Taluk = drpTaluk.SelectedValue;
                                                if (txt_DOB.Text.Trim() != "")
                                                {
                                                    AVP.DOB = txt_DOB.Text.Trim();
                                                    if (txtMobileNumber.Text.Trim() != "" && System.Text.RegularExpressions.Regex.IsMatch(txtMobileNumber.Text.Trim(), @"^\d+$"))
                                                    {
                                                        if (AVP.IsMobileVerified == "TRUE")
                                                        {
                                                            AVP.MobileNumber = txtMobileNumber.Text.Trim();
                                                            if (txtWhatsAppNumber.Text.Trim() != "" && System.Text.RegularExpressions.Regex.IsMatch(txtWhatsAppNumber.Text.Trim(), @"^\d+$"))
                                                            {
                                                                AVP.WhatsappNumber = txtWhatsAppNumber.Text.Trim();
                                                                if (txtEmailID.Text != "")
                                                                {
                                                                    VerifyEmailID VEID = new VerifyEmailID();
                                                                    if (VEID.IsValidEmail(txtEmailID.Text.Trim()))
                                                                    {
                                                                        AVP.EmailID = txtEmailID.Text.Trim();
                                                                        if (txtEducationQualification.Text.Trim() != "")
                                                                        {
                                                                            AVP.EducationQualification = txtEducationQualification.Text.Trim();
                                                                            if (drpOccupation.SelectedValue != "0")
                                                                            {
                                                                                AVP.Occupation = drpOccupation.SelectedValue;
                                                                                if (txtOccupationDetails.Text.Trim() != "")
                                                                                {
                                                                                    AVP.OccupationDetails = txtOccupationDetails.Text.Trim();
                                                                                    AVP.Declaration = ChkSelfDeclaration.Checked ? "Yes" : "No";
                                                                                    AryaVysyaPortalSave AVPS = new AryaVysyaPortalSave();
                                                                                    string number = AVPS.StoreAV(AVP.Name, AVP.FatherName, AVP.Gender, AVP.Address, AVP.District, AVP.Taluk, AVP.Pincode,
                                                                                        AVP.DOB, AVP.MobileNumber, AVP.WhatsappNumber, AVP.EmailID, AVP.Occupation, AVP.OccupationDetails, AVP.Declaration, AVP.PhysicallyChallenged, AVP.EducationQualification);
                                                                                    if (number != "")
                                                                                    {
                                                                                        if (number != "UNIQUE KEY CONSTRAINT")
                                                                                        {
                                                                                            lblSuccessHead.Text = "Success";
                                                                                            lblSuccessMessage.Text = "";
                                                                                            divsuccess.Visible = true;
                                                                                            
                                                                                            //SuccessPopup.Show();
                                                                                            DisplayAlert("Dear "+ AVP.Name + ", Your Details Stored Successfully, Kindly Share with your arya vysya friends and family", this);
                                                                                            Session.Clear();
                                                                                            //Response.Redirect("~/Login.aspx");
                                                                                        }
                                                                                        else if (number == "UNIQUE KEY CONSTRAINT")
                                                                                        {
                                                                                            lblNotificationHeading.Text = "Exist";
                                                                                            lblNotificationContent.Text = "";
                                                                                            txtMobileNumber.ReadOnly = false;
                                                                                            btnVerifyMobileNumber.Visible = true;
                                                                                            //NotifyOtherDetailsPopup.Show();
                                                                                            DisplayAlert("Mobile Number already exist, Change Mobile Number", this);
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    lblNotificationHeading.Text = "Error";
                                                                                    lblNotificationContent.Text = "";
                                                                                    txtOccupationDetails.Focus();
                                                                                    //NotifyOtherDetailsPopup.Show();
                                                                                    DisplayAlert("Enter your Occupation Details", this);
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                lblNotificationHeading.Text = "Error";
                                                                                lblNotificationContent.Text = "";
                                                                                drpOccupation.Focus();
                                                                                DisplayAlert("Select your Occupation", this);
                                                                                //NotifyOtherDetailsPopup.Show();
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            lblNotificationHeading.Text = "Error";
                                                                            lblNotificationContent.Text = "";
                                                                            txtEducationQualification.Focus();
                                                                            DisplayAlert("Enter your Education Qualification", this);
                                                                            //NotifyOtherDetailsPopup.Show();
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        lblNotificationHeading.Text = "Error";
                                                                        lblNotificationContent.Text = "";
                                                                        txtWhatsAppNumber.Focus();
                                                                        DisplayAlert("Enter Valid EmailID", this);
                                                                        //NotifyOtherDetailsPopup.Show();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    lblNotificationHeading.Text = "Error";
                                                                    lblNotificationContent.Text = "";
                                                                    txtWhatsAppNumber.Focus();
                                                                    DisplayAlert("Enter your EmailID", this);
                                                                    //NotifyOtherDetailsPopup.Show();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                lblNotificationHeading.Text = "Error";
                                                                lblNotificationContent.Text = "";
                                                                txtWhatsAppNumber.Focus();
                                                                //NotifyOtherDetailsPopup.Show();
                                                                DisplayAlert("Enter your WhatsApp Mobile Number", this);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            lblNotificationHeading.Text = "Error";
                                                            lblNotificationContent.Text = "";
                                                            txtMobileNumber.Focus();
                                                            //NotifyOtherDetailsPopup.Show();
                                                            DisplayAlert("Verify your Mobile Number", this);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        lblNotificationHeading.Text = "Error";
                                                        lblNotificationContent.Text = "";
                                                        txtMobileNumber.Focus();
                                                        //NotifyOtherDetailsPopup.Show();
                                                        DisplayAlert("Enter your Mobile Number", this);
                                                    }
                                                }
                                                else
                                                {
                                                    lblNotificationHeading.Text = "Error";
                                                    lblNotificationContent.Text = "";
                                                    txt_DOB.Focus();
                                                    //NotifyOtherDetailsPopup.Show();
                                                    DisplayAlert("Select Your Date of Birth", this);
                                                }
                                            }
                                            else
                                            {
                                                lblNotificationHeading.Text = "Error";
                                                lblNotificationContent.Text = "";
                                                drpTaluk.Focus();
                                                //NotifyOtherDetailsPopup.Show();
                                                DisplayAlert("Select Taluk", this);

                                            }
                                        }
                                        else
                                        {
                                            lblNotificationHeading.Text = "Error";
                                            lblNotificationContent.Text = "";
                                            drpDistrict.Focus();
                                            //NotifyOtherDetailsPopup.Show();
                                            DisplayAlert("Select District", this);
                                        }
                                    }
                                    else
                                    {
                                        lblNotificationHeading.Text = "Error";
                                        lblNotificationContent.Text = "";
                                        drpDistrict.Focus();
                                        //NotifyOtherDetailsPopup.Show();
                                        DisplayAlert("Select District", this);
                                    }
                                }
                                else
                                {
                                    lblNotificationHeading.Text = "Error";
                                    lblNotificationContent.Text = "";
                                    txtPincode.Focus();
                                    //NotifyOtherDetailsPopup.Show();
                                    DisplayAlert("Enter Pincode", this);
                                }
                            }
                            else
                            {
                                lblNotificationHeading.Text = "Error";
                                lblNotificationContent.Text = "";
                                txtAddress.Focus();
                                //NotifyOtherDetailsPopup.Show();
                                DisplayAlert("Enter Your Address", this);
                            }
                        }
                        else
                        {
                            lblNotificationHeading.Text = "Error";
                            lblNotificationContent.Text = "";
                            rbPhysicallyChallengedYes.Focus();
                            //NotifyOtherDetailsPopup.Show();
                            DisplayAlert("Select Person With Disabilitie", this);
                        }
                    }
                    else
                    {
                        lblNotificationHeading.Text = "Error";
                        lblNotificationContent.Text = "";
                        rbMale.Focus();
                        //NotifyOtherDetailsPopup.Show();
                        DisplayAlert("Select Your Gender", this);
                    }
                }
                else
                {
                    lblNotificationHeading.Text = "Error";
                    lblNotificationContent.Text = "Enter Valid Father Name";
                    txtFatherName.Focus();
                    //NotifyOtherDetailsPopup.Show();
                    DisplayAlert("Enter Valid Father Name", this);
                }
            }
            else
            {
                lblNotificationHeadingNew.Text = "Error";
                lblNotificationContentNew.Text = "Enter Valid Name";
                txtName.Focus();
                //NotifyOtherDetailsPopup.Show();
                DisplayAlert("Enter Valid Name", this);
            }
        }
        protected void btnAVPVerifyOTP_Click(object sender, EventArgs e)
        {
            string OTPString = txtOTP.Text.Trim();
            if (OTPString.Contains(','))
                OTPString=OTPString.Remove(0,1);
            lblOTPError.Text = "";
            int len = txtOTP.Text.Trim().Length;
            if (OTPString.Trim().Length == 8)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(OTPString.Trim(), @"^\d+$"))
                {
                    if (OTPString.Trim() == Enc.Decrypt(AVP.EncryptedOTP))
                    {
                        AVP.EncryptedOTP = "";
                        AVP.IsMobileVerified = "TRUE";
                        txtMobileNumber.ReadOnly = true;
                        btnVerifyMobileNumber.Visible = false;
                    }
                    else
                    {
                        lblOTPError.Text = "Enter Valid OTP";
                        AVPMobileNumVerifyPopup.Show();
                    }
                }
                else
                {
                    lblOTPError.Text = "Enter Valid OTP";
                    AVPMobileNumVerifyPopup.Show();
                }
            }
            else
            {
                lblOTPError.Text = "Enter Valid 8 digit OTP";
                AVPMobileNumVerifyPopup.Show();
            }
        }
        protected void btnAVPOTPResend_Click(object sender, EventArgs e)
        {
            string Message =  Enc.Decrypt(AVP.EncryptedOTP)+ " is your OTP to verify, your application number of avp. do not share with others. From:KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION";
            SM.sendSMS(txtMobileNumber.Text.Trim(), Message, 2, "LGNOTP");
            AVPMobileNumVerifyPopup.Show();
        }
        protected void drpDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.FillTaluk();
        }
        protected void drpOccupation_SelectedIndexChange(object sender, EventArgs e)
        {
            txtOccupationDetails.Text = "";
            if (drpOccupation.SelectedValue == "student")
            {
                lblOccupationDetails.Text = "Education Qualification";
                txtOccupationDetails.Text = "STUDENT";
                //divOccupationDetails.Visible = true;
            }
            else if (drpOccupation.SelectedValue == "business")
            {
                lblOccupationDetails.Text = "Nature of Business";
                divOccupationDetails.Visible = true;
            }
            else if (drpOccupation.SelectedValue == "employee")
            {
                lblOccupationDetails.Text = "Company/Department Name";
                divOccupationDetails.Visible = true;
            }
            else if (drpOccupation.SelectedValue == "homemaker")
            {
                lblOccupationDetails.Text = "Company/Department Name";
                txtOccupationDetails.Text = "Home Maker";

                //divOccupationDetails.Visible = true;
            }
            else
            {
                divOccupationDetails.Visible = false;
            }
        }
        private void FillDistrict()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select DistrictCd,DistrictName from MstDistrict"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpDistrict.DataSource = cmd.ExecuteReader();
                    drpDistrict.DataTextField = "DistrictName";
                    drpDistrict.DataValueField = "DistrictCd";
                    drpDistrict.DataBind();
                    drpDistrict.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
        }
        protected void txt_DOB_TextChanged(object sender, EventArgs e)
        {
            CalculateYourAge(Convert.ToDateTime(txt_DOB.Text.Trim()));
            //DisplayAlert(CalculateYourAge(Convert.ToDateTime(txt_DOB.Text.Trim())), this);
            if (Int32.Parse(CalculateYourAge(Convert.ToDateTime(txt_DOB.Text.Trim()))) < 13)
            {
                DisplayAlert("You are not eligible as you are below 13 years", this);
            }
        }
        private void FillTaluk()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select distinct TalukNm from MstTaluk where DistrictCd=@District"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@District", drpDistrict.SelectedValue);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpTaluk.DataSource = cmd.ExecuteReader();
                    drpTaluk.DataTextField = "TalukNm";
                    drpTaluk.DataValueField = "TalukNm";
                    drpTaluk.DataBind();
                    drpTaluk.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
        }
        static string CalculateYourAge(DateTime Dob)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return Years.ToString();
            //return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)", Years, Months, Days, Hours, Seconds);
        }
        public static void DisplayAlert(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            //page.ClientScript.RegisterStartupScript(owner.GetType(),"ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    message));
            ScriptManager.RegisterClientScriptBlock(owner, owner.GetType(), "alertMessage", "alert('" + message.ToUpper() + "')", true);
        }
        
        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (lblNotificationHeading.Text == "Success")
            {
                Session.Clear();
                Response.Redirect(@"~\Schemes\AryaVysyaPortal\AryaVysyaPortal.aspx");
            }
        }
    }
}