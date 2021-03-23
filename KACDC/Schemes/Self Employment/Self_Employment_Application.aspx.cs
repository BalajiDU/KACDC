using KACDC.Class.DataProcessing.Aadhaar;
using KACDC.Class.DataProcessing.Nadakacheri;
using KACDC.Class.Declaration.Aadhaar;
using KACDC.Class.Declaration.Nadakacheri;
using KACDC.Class.Declaration.OnlineApplication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.Schemes.Self_Employment
{
    public partial class Self_Employment_Application : System.Web.UI.Page
    {
        AadhaarService ADAR = new AadhaarService();
        AadhaarServiceData ADSER = new AadhaarServiceData();
        NadaKacheri NDAR = new NadaKacheri();
        NadakacheriProcess NKAR = new NadakacheriProcess();
        OtherDataSelfEmployment ODSE = new OtherDataSelfEmployment();
        NadaKacheri NKSER = new NadaKacheri();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAadhaarGetOTP_Click(object sender, EventArgs e)
        {
            ADSER.AadhaarNumber = txtAadhaarNumber.Text.Trim();
            ADAR.SendOTP(txtAadhaarNumber.Text.Trim());
            divMobileOTP.Visible = true;
        }
        protected void btnVerifyAadhaarOTP_Click(object sender, EventArgs e)
        {
            ADSER.AadhaarApplicantOTP = txtOTP.Text.Trim();
            string ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
            { ipaddress = Request.ServerVariables["REMOTE_ADDR"]; }
            string errorLogFilename = "ErrorLog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

            if (ADAR.VerifyAadhaarOTP(ipaddress, Path.GetFileName(Request.Path), Server.MapPath("~/LogFiles/AadhaarErrorLog/" + errorLogFilename)))
            {
                lblAadhaarPopupDOB.Text = ADSER.DOB;
                lblAadhaarPopupGender.Text = ADSER.Gender;
                lblAadhaarPopupName.Text = ADSER.Name;

                lblAadhaarPopupState.Text = ADSER.State;

                ImgAadhaarPopupPhoto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ADSER.Photo, 0, (ADSER.Photo).Length);
                lblAadhaarPopupPincode.Text = ADSER.Pincode;

                lblAadhaarPopupDistrict.Text = ADSER.District;
                AadhaarPopup.Show();
            }
            else
            {
                if (ADSER.OTPErrorCode == "AUA-OTP-01")
                {
                    DisplayAlert("Invalid OTP", this);
                }
                else if (ADSER.OTPErrorCode == "AUA-OTP-05")
                {
                    DisplayAlert("OTP Expired", this);
                }
                else if (ADSER.OTPErrorCode == "AUA-OTP-05")
                {
                    DisplayAlert("OTP Expired", this);
                }
                else
                {
                    DisplayAlert("Unable to Connect, Try again", this);
                }
            }
        }
        protected void btnAadhaarkDetailsProceed_Click(object sender, EventArgs e)
        {
            txtAadhaarNumber.ReadOnly = true;
            divMobileOTP.Visible = false;
            btnAadhaarGetOTP.Visible = false;
            divButtonToRDNum.Visible = true;
        }
        protected void btnAadhaarkDetailsBack_Click(object sender, EventArgs e)
        {
            txtAadhaarNumber.ReadOnly = false;
            divMobileOTP.Visible = true;
            btnAadhaarGetOTP.Visible = true;
            divButtonToRDNum.Visible = false;
        }
        protected void btnNextDisplayRDNum_Click(object sender, EventArgs e)
        {
            divMobileOTP.Visible = false;
            divRDNumber.Visible = true;
        }
        protected void btnVerifyRDNumber(object sender, EventArgs e)
        {
            if (NKAR.GetCasteAndIncomeCertificate(txtRDNumber.Text.Trim()))
            {
                if (Int32.Parse(NKSER.NCStatusCode) == 1)
                {
                    if (Int32.Parse(NKSER.NCFacilityCode) == 42)
                    {
                        if (Int32.Parse(NKSER.NCAnnualIncome) < 300000)
                        {
                            if (Convert.ToDateTime(NKSER.NCDateOfIssue) > Convert.ToDateTime("24/12/2019"))
                            {
                                if (NDAR.NCGender == "MALE")
                                {
                                    ODSE.Widow = "NA";
                                    ODSE.Divorced = "NA";
                                }
                                lblNCGSCNumber.Text = NKSER.NCGSCNumber;
                                lblNCAnnualIncome.Text = NKSER.NCAnnualIncome;
                                //NKSER.NCDateOfIssue;
                                lblNCApplicantName.Text = NKSER.NCApplicantName;
                                lblNCApplicantFatherName.Text = NKSER.NCApplicantFatherName;
                                lblNCDistrict.Text = NKSER.NCDistrictName;
                                lblNCTaluk.Text = NKSER.NCTalukName;
                                lblNCFullAddress.Text = NKSER.NCFullAddress;
                            }
                        }
                    }
                }
                CasteCertificatePopup.Show();
            }
            else
            {

            }
        }
        protected void btnNadakachriBack_Click(object sender, EventArgs e)
        {
            divRDNumber.Visible = true;
        }
        protected void rbContactAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (rbContactAddressYes.Checked == true)
            {
                divContactAddress.Visible = false;
                btnSaveContactAddress.Visible = false;
            }
            else if (rbContactAddressNo.Checked == true)
            {
                divContactAddress.Visible = true;
                btnSaveContactAddress.Visible = true;
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