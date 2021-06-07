using KACDC.Class.DataProcessing.EncryptionProcess;
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
                        txtOTP.Text = "";
                        txtOTP.Focus();
                        
                        AVP.EncryptedOTP = Enc.Encrypt(otp.NewOTP());
                        string Message = Enc.Decrypt(AVP.EncryptedOTP) + " is your OTP to verify, your application number avp. do not share with others. From:KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION";
                        SM.sendSMS(txtMobileNumber.Text.Trim(), Message, 2, "LGNOTP");
                        AVPMobileNumVerifyPopup.Show();
                    }
                }
            }
            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
            {
                lblNameError.Text = "";
                if (txtFatherName.Text.Trim() != "")
                {
                    lblFatherNameError.Text = "";
                    if (rbMale.Checked == true || rbFemale.Checked == true)
                    {

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