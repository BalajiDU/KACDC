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
            if (!IsPostBack)
            {
                this.FillDistrict();
                calDOB.EndDate = DateTime.Now;
            }
        }
        protected void btnVerifyMobileNumber_Click(object sender, EventArgs e)
        {
            lblOTPError.Text = "";
            if (txtMobileNumber.Text != "")
            {
                if(txtMobileNumber.Text.Trim().Length == 10)
                {
                    if(System.Text.RegularExpressions.Regex.IsMatch(txtMobileNumber.Text.Trim(), @"^\d+$"))
                    {
                        AryaVysyaPortalSave AVPS = new AryaVysyaPortalSave();
                        if (AVPS.CheckMobileNumExist(txtMobileNumber.Text.Trim()))
                        {
                            txtOTP.Text = "";
                            txtOTP.Focus();

                            AVP.EncryptedOTP = Enc.Encrypt(otp.NewOTP());
                            string Message = Enc.Decrypt(AVP.EncryptedOTP) + " is your OTP to verify, your application number avp. do not share with others. From:KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION";
                            SM.sendSMS(txtMobileNumber.Text.Trim(), Message, 2, "LGNOTP");
                            AVPMobileNumVerifyPopup.Show();
                        }
                        else 
                        {
                            lblNotificationHeading.Text = "Exist";
                            lblNotificationContent.Text = "Mobile Number already exist <br/ >Change Your Mobile Number";
                            txtMobileNumber.ReadOnly = false;
                            btnVerifyMobileNumber.Visible = true;
                            OtherDetailsPopup.Show();
                        }
                    }
                    else
                    {
                        lblNotificationHeading.Text = "Error";
                        lblNotificationContent.Text = "Enter Valid Mobile Number";
                        txtMobileNumber.Focus();
                        OtherDetailsPopup.Show();
                    }
                }
                else
                {
                    lblNotificationHeading.Text = "Error";
                    lblNotificationContent.Text = "Enter Valid Mobile Number";
                    OtherDetailsPopup.Show();
                    txtMobileNumber.Focus();
                }
            }
            else
            {
                lblNotificationHeading.Text = "Error";
                lblNotificationContent.Text = "Enter Mobile Number";
                txtMobileNumber.Focus();
                OtherDetailsPopup.Show();
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
                                            if (txt_DOB.Text.Trim() != "" )
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
                                                                    if (drpOccupation.SelectedValue != "0")
                                                                    {
                                                                        AVP.Occupation = drpOccupation.SelectedValue;
                                                                        if (txtOccupationDetails.Text.Trim() != "")
                                                                        {
                                                                            AVP.OccupationDetails = txtOccupationDetails.Text.Trim();
                                                                            AVP.Declaration = ChkSelfDeclaration.Checked ? "Yes" : "No";
                                                                            AryaVysyaPortalSave AVPS = new AryaVysyaPortalSave();
                                                                            string number = AVPS.StoreAV(AVP.Name, AVP.FatherName, AVP.Gender, AVP.Address, AVP.District, AVP.Taluk, AVP.Pincode,
                                                                                AVP.DOB, AVP.MobileNumber, AVP.WhatsappNumber, AVP.EmailID, AVP.Occupation, AVP.OccupationDetails, AVP.Declaration);
                                                                            if(number != "")
                                                                            {
                                                                                if (number != "UNIQUE KEY CONSTRAINT")
                                                                                {
                                                                                    lblNotificationHeading.Text = "Success";
                                                                                    lblNotificationContent.Text = "Your Details Stored Successfully : " + number;
                                                                                    Session.Clear();
                                                                                    OtherDetailsPopup.Show();
                                                                                    //Response.Redirect("~/Login.aspx");
                                                                                }
                                                                                else if (number == "UNIQUE KEY CONSTRAINT")
                                                                                {
                                                                                    lblNotificationHeading.Text = "Exist";
                                                                                    lblNotificationContent.Text = "Mobile Number already exist <br/ >Change Your Mobile Number";
                                                                                    txtMobileNumber.ReadOnly = false;
                                                                                    btnVerifyMobileNumber.Visible = true;
                                                                                    OtherDetailsPopup.Show();
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            lblNotificationHeading.Text = "Error";
                                                                            lblNotificationContent.Text = "Enter your Occupation Details";
                                                                            txtOccupationDetails.Focus();
                                                                            OtherDetailsPopup.Show();
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        lblNotificationHeading.Text = "Error";
                                                                        lblNotificationContent.Text = "Select your Occupation";
                                                                        drpOccupation.Focus();
                                                                        OtherDetailsPopup.Show();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    lblNotificationHeading.Text = "Error";
                                                                    lblNotificationContent.Text = "Enter Valid EmailID";
                                                                    txtWhatsAppNumber.Focus();
                                                                    OtherDetailsPopup.Show();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                lblNotificationHeading.Text = "Error";
                                                                lblNotificationContent.Text = "Enter your EmailID";
                                                                txtWhatsAppNumber.Focus();
                                                                OtherDetailsPopup.Show();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            lblNotificationHeading.Text = "Error";
                                                            lblNotificationContent.Text = "Enter your WhatsApp Mobile Number";
                                                            txtWhatsAppNumber.Focus();
                                                            OtherDetailsPopup.Show();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        lblNotificationHeading.Text = "Error";
                                                        lblNotificationContent.Text = "Verify your Mobile Number";
                                                        txtMobileNumber.Focus();
                                                        OtherDetailsPopup.Show();
                                                    }
                                                }
                                                else
                                                {
                                                    lblNotificationHeading.Text = "Error";
                                                    lblNotificationContent.Text = "Enter your Mobile Number";
                                                    txtMobileNumber.Focus();
                                                    OtherDetailsPopup.Show();
                                                }
                                            }
                                            else
                                            {
                                                lblNotificationHeading.Text = "Error";
                                                lblNotificationContent.Text = "Select Your Date of Birth";
                                                txt_DOB.Focus();
                                                OtherDetailsPopup.Show();
                                            }
                                        }
                                        else
                                        {
                                            lblNotificationHeading.Text = "Error";
                                            lblNotificationContent.Text = "Select Taluk";
                                            drpTaluk.Focus();
                                            OtherDetailsPopup.Show();
                                        }
                                    }
                                    else
                                    {
                                        lblNotificationHeading.Text = "Error";
                                        lblNotificationContent.Text = "Select District";
                                        drpDistrict.Focus();
                                        OtherDetailsPopup.Show();
                                    }
                                }
                                else
                                {
                                    lblNotificationHeading.Text = "Error";
                                    lblNotificationContent.Text = "Select District";
                                    drpDistrict.Focus();
                                    OtherDetailsPopup.Show();
                                }
                            }
                            else
                            {
                                lblNotificationHeading.Text = "Error";
                                lblNotificationContent.Text = "Enter Pincode";
                                txtPincode.Focus();
                                OtherDetailsPopup.Show();
                            }
                        }
                    
                        else
                        {
                            lblNotificationHeading.Text = "Error";
                            lblNotificationContent.Text = "Enter Your Address";
                            txtAddress.Focus();
                            OtherDetailsPopup.Show();
                        }
                    }
                    else
                    {
                        lblNotificationHeading.Text = "Error";
                        lblNotificationContent.Text = "Select Your Gender";
                        txtFatherName.Focus();
                        OtherDetailsPopup.Show();
                    }
                }
                else
                {
                    lblNotificationHeading.Text = "Error";
                    lblNotificationContent.Text = "Enter Valid Father Name";
                    txtFatherName.Focus();
                    OtherDetailsPopup.Show();
                }
            }
            else
            {
                lblNotificationHeading.Text = "Error";
                lblNotificationContent.Text = "Enter Valid Name";
                txtName.Focus();
                OtherDetailsPopup.Show();
            }
        }
        protected void btnAVPVerifyOTP_Click(object sender, EventArgs e)
        {
            lblOTPError.Text = "";
            if (txtOTP.Text.Trim().Length == 8)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtOTP.Text.Trim(), @"^\d+$"))
                {
                    if (txtOTP.Text.Trim() == Enc.Decrypt(AVP.EncryptedOTP))
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
                lblOccupationDetails.Text = "Edication Qualification";
                divOccupationDetails.Visible = true;
            }
            else if (drpOccupation.SelectedValue == "business")
            {
                lblOccupationDetails.Text = "Nature of Business";
                divOccupationDetails.Visible = true;
            }
            else if (drpOccupation.SelectedValue == "employee")
            {
                lblOccupationDetails.Text = "Employer Name";
                divOccupationDetails.Visible = true;
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
    }
}