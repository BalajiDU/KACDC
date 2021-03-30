using KACDC.Class.DataProcessing.Aadhaar;
using KACDC.Class.DataProcessing.BankData;
using KACDC.Class.DataProcessing.Nadakacheri;
using KACDC.Class.Declaration.Aadhaar;
using KACDC.Class.Declaration.BankDetails;
using KACDC.Class.Declaration.Nadakacheri;
using KACDC.Class.Declaration.OnlineApplication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        BankDetails GETBD = new BankDetails();
        DecBankDetails BD = new DecBankDetails();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAadhaarGetOTP_Click(object sender, EventArgs e)
        {
            if (txtRDNumber.Text.Trim().Length == 12)
            {
                if (Regex.IsMatch(txtAadhaarNumber.Text.Trim(), @"^\d+$"))
                {
                    ADSER.AadhaarNumber = txtAadhaarNumber.Text.Trim();
                    if (ADAR.SendOTP(txtAadhaarNumber.Text.Trim()))
                    {
                        divMobileOTP.Visible = true;
                    }
                    else
                    {
                        DisplayAlert(ADSER.SendOTPErrorMessage, this);
                    }
                }
                else
                {
                    DisplayAlert("Invalid Aadhaar Number", this);
                }
            }
            else
            {
                DisplayAlert("Invalid Aadhaar Number", this);
            }
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
            divButtonToRDNum.Visible = false;
            divMobileOTP.Visible = false;
            divRDNumber.Visible = true;
        }
        protected void btnVerifyRDNumber_Click(object sender, EventArgs e)
        {
            if (txtRDNumber.Text.Trim().Length == 15)
            {
                if (txtRDNumber.Text.Trim().ToUpper().Substring(0, 2) == "RD")
                {
                    if (Regex.IsMatch(txtRDNumber.Text.Trim().Substring(2, 13), @"^\d+$"))
                    {
                        string IsRDExist = NKAR.CheckRDNumberExist(txtRDNumber.Text.Trim());
                        if (IsRDExist == "NA")
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
                                                rbContactAddressYes.Checked = false;
                                                rbContactAddressNo.Checked = false;
                                                btnNadakachriOK.Visible = false;
                                                btnSaveContactAddress.Visible = false;
                                                divContactAddress.Visible = false;
                                                divButtonBankDetails.Visible = true;
                                                btnViewRDNumber.Visible = true;
                                                btnVerifyRdNumber.Visible = false;
                                                NKAR.UpdateDistrict();
                                                ConstituencyDropDownBinding();
                                                lblNCGSCNumber.Text = NKSER.NCGSCNumber;
                                                lblNCAnnualIncome.Text = NKSER.NCAnnualIncome;
                                                //NKSER.NCDateOfIssue;
                                                lblNCApplicantName.Text = NKSER.NCApplicantName;
                                                lblNCApplicantFatherName.Text = NKSER.NCApplicantFatherName;
                                                lblNCDistrict.Text = NKSER.NCDistrictName;
                                                lblNCTaluk.Text = NKSER.NCTalukName;
                                                lblNCFullAddress.Text = NKSER.NCFullAddress;
                                                
                                                CasteCertificatePopup.Show();
                                            }
                                            else
                                            {
                                                DisplayAlert("new Caste and Income certificate must be taken, which is issued after 24/12/2019", this);
                                            }
                                        }
                                        else
                                        {
                                            DisplayAlert("Income must be less then 1,00,000", this);
                                        }
                                    }
                                    else
                                    {
                                        DisplayAlert("Only Arya vysya Community is eligible", this);
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Invalid RD Number", this);
                                }

                            }
                            else
                            {
                                DisplayAlert("Invalid RD Number", this);
                            }
                        }
                        else
                        {
                            DisplayAlert("You have already avail the loan in "+ IsRDExist + " financial year", this);
                        }
                    }
                    else
                    {
                        DisplayAlert("Invalid RD Number", this);
                    }
                }
                else
                {
                    DisplayAlert("Invalid RD Number", this);
                }
            }
            else
            {
                DisplayAlert("Invalid RD Number", this);
            }
        }
        protected void btnNadakachriBack_Click(object sender, EventArgs e)
        {
            divButtonBankDetails.Visible = false;
            btnViewRDNumber.Visible = false;
            btnVerifyRdNumber.Visible = true;
            divRDNumber.Visible = true;
        }
        protected void rbContactAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (rbContactAddressYes.Checked == true)
            {
                divContactAddress.Visible = false;
                this.DropDownBinding();
                btnNadakachriOK.Visible = false;
                btnSaveContactAddress.Visible = true;
                CasteCertificatePopup.Show();
            }
            else if (rbContactAddressNo.Checked == true)
            {
                divContactAddress.Visible = true;
                btnSaveContactAddress.Visible = true;
                btnNadakachriOK.Visible = false;
                CasteCertificatePopup.Show();
            }
        }
        private void DropDownBinding()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select DistrictName from MstDistrict"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpContDistrict.DataSource = cmd.ExecuteReader();
                    drpContDistrict.DataTextField = "DistrictName";
                    drpContDistrict.DataValueField = "DistrictName";
                    drpContDistrict.DataBind();
                    drpContDistrict.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
        }
        private void ConstituencyDropDownBinding()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                if (NKSER.NCLanguage == "1")
                {
                    using (SqlCommand cmd = new SqlCommand("select AssemblyCode,AssemblyName from MstConstituencies,MstDistrict where MstDistrict.DistrictCD=MstConstituencies.DistrictCD and NC_District_Name_Kan=@District"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@District", NKSER.NCDistrictName);
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        drpConst.DataSource = cmd.ExecuteReader();
                        drpConst.DataTextField = "AssemblyName";
                        drpConst.DataValueField = "AssemblyName";
                        drpConst.DataBind();
                        drpConst.Items.Insert(0, "--SELECT--");
                        kvdConn.Close();
                    }
                }
                if (NKSER.NCLanguage == "99")
                {
                    using (SqlCommand cmd = new SqlCommand("select AssemblyCode,AssemblyName from MstConstituencies,MstDistrict where MstDistrict.DistrictCD=MstConstituencies.DistrictCD and NC_District_Name_Eng=@District"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@District", NKSER.NCDistrictName);
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        drpConst.DataSource = cmd.ExecuteReader();
                        drpConst.DataTextField = "AssemblyName";
                        drpConst.DataValueField = "AssemblyName";
                        drpConst.DataBind();
                        drpConst.Items.Insert(0, "--SELECT--");
                        kvdConn.Close();
                    }
                }
            }
        }
        protected void drpConst_SelectedIndexChanged(object sender, EventArgs e)
        {
            NKSER.NCConstituency = drpConst.SelectedValue;
            if (NKSER.NCDistrictName == "Bengaluru" || NKSER.NCDistrictName == "Bengaluru Uttara" || NKSER.NCDistrictName == "Bengaluru Dakshina")
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select DistrictName from MstConstituencies,MstDistrict where MstDistrict.DistrictCD=MstConstituencies.DistrictCD and AssemblyName=@Assembly", kvdConn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Assembly", drpConst.SelectedValue);

                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            NKSER.NCDistrictName = sdr["DistrictName"].ToString();
                        }
                        kvdConn.Close();
                    }

                }
            }
            lblNCDistrict.Text = NKSER.NCDistrictName;
            CasteCertificatePopup.Show();
        }
        protected void drpContDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select MstTaluk.DistrictCD,MstTaluk.TalukNm from MstTaluk,MstDistrict where MstTaluk.DistrictCd=MstDistrict.DistrictCD and MstDistrict.DistrictName=@District"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@District", drpContDistrict.SelectedValue);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpContTaluk.DataSource = cmd.ExecuteReader();
                    drpContTaluk.DataTextField = "TalukNm";
                    drpContTaluk.DataValueField = "TalukNm";
                    drpContTaluk.DataBind();
                    drpContTaluk.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
            CasteCertificatePopup.Show();
        }
        protected void drpContTaluk_SelectedIndexChanged(object sender, EventArgs e)
        {
            CasteCertificatePopup.Show();
        }
        protected void btnSaveContactAddress_Click(object sender, EventArgs e)
        {
            if (drpConst.SelectedIndex!=0) {
                if (rbContactAddressNo.Checked == true)
                {
                    if (txtContactAddress.Text.Trim() != "" && txtContactAddress.Text.Trim() != null)
                    {
                        if (txtContactAddress.Text.Trim().Length >= 10)
                        {
                            if (drpContDistrict.SelectedValue != "" && drpContDistrict.SelectedValue != null && drpContDistrict.SelectedIndex!=0)
                            {
                                if (drpContTaluk.SelectedValue != "" && drpContTaluk.SelectedValue != null && drpContTaluk.SelectedIndex!=0)
                                {
                                    if (txtContPincode.Text.Trim() != "" && txtContPincode.Text.Trim() != null)
                                    {
                                        if (Regex.IsMatch(txtContPincode.Text.Trim(), @"^\d+$"))
                                        {
                                            if (txtContPincode.Text.Trim().Length == 6)
                                            {
                                                ODSE.ContactFullAddress = txtContactAddress.Text.Trim();
                                                ODSE.ContactDistrictName = drpContDistrict.SelectedValue;
                                                ODSE.ContactTalukName = drpContTaluk.SelectedValue;
                                                ODSE.ContactPinCode = txtContPincode.Text.Trim();
                                                divButtonBankDetails.Visible = true;
                                                btnVerifyRdNumber.Visible = false;
                                                btnViewRDNumber.Visible = true;
                                                txtRDNumber.ReadOnly = true;
                                            }
                                            else
                                            {
                                                DisplayAlert("enter valid pincode", this);
                                                CasteCertificatePopup.Show(); txtContPincode.Focus();
                                            }
                                        }
                                        else
                                        {
                                            DisplayAlert("enter valid pincode", this);
                                            CasteCertificatePopup.Show(); txtContPincode.Focus();
                                        }
                                    }
                                    else { DisplayAlert("enter pincode", this); CasteCertificatePopup.Show(); txtContPincode.Focus(); }
                                }
                                else { DisplayAlert("select taluk", this); CasteCertificatePopup.Show(); drpContTaluk.Focus(); }
                            }
                            else { DisplayAlert("select district", this); CasteCertificatePopup.Show(); drpContDistrict.Focus(); }
                        }
                        else { DisplayAlert("enter valid address", this); CasteCertificatePopup.Show(); txtContactAddress.Focus(); }
                    }
                    else { DisplayAlert("enter contact address", this); CasteCertificatePopup.Show(); txtContactAddress.Focus(); }
                }
                else if (rbContactAddressYes.Checked == true)
                {

                }
            }
            else
            {
                DisplayAlert("Select Constituency", this);
                CasteCertificatePopup.Show();
            }
        }
        protected void btnNextDisplayBankDetails_Click(object sender, EventArgs e)
        {
            divButtonBankDetails.Visible = false;
            divBankDetails.Visible = true;
            txtRDNumber.ReadOnly = true;
        }
        protected void btnNextChangeRDNumber_Click(object sender, EventArgs e)
        {
            divButtonBankDetails.Visible = false;
            txtRDNumber.ReadOnly = false;
            btnVerifyRdNumber.Visible = true;
            btnViewRDNumber.Visible = false;
        }
        protected void btnGetBankDetails_Click(object sender, EventArgs e)
        {
            if(txtAccountNumber.Text.Trim()!=null && txtAccountNumber.Text.Trim() != "")
            {
                if (txtAccountNumber.Text.Trim().Length>5)
                {
                    BD.AccountNumber = txtAccountNumber.Text.Trim();
                    if (txtIFSCCode.Text.Trim() != null && txtIFSCCode.Text.Trim() != "")
                    {
                        if (txtIFSCCode.Text.Trim().Length > 10)
                        {
                            if (GETBD.GetBankDetails(txtIFSCCode.Text.Trim()))
                            {
                                if(BD.STATE== "KARNATAKA")
                                {
                                    if (BD.NEFT.ToUpper() == "TRUE")
                                    {
                                        if (BD.RTGS.ToUpper() == "TRUE")
                                        {
                                            lblAccountHolderName.Text = ADSER.Name;
                                            lblAccountNumber.Text = BD.AccountNumber;
                                            lblBankName.Text = BD.BANK;
                                            lblBranch.Text = BD.BRANCH;
                                            lblIFSCCode.Text = BD.IFSC;
                                            lblBankAddress.Text = BD.FULLADDRESS;
                                            BankDetailsPopup.Show();

                                            txtAccountNumber.ReadOnly = true;
                                            txtIFSCCode.ReadOnly = true;
                                            btnGetBankDetails.Visible = false;
                                            btnViewBankDetails.Visible = true;
                                            divButtonToOtherDetails.Visible = true;
                                        }
                                        else
                                        {
                                            DisplayAlert("ENTER RTGS FACILITY AVAILABLE BANK", this);
                                        }
                                    }
                                    else
                                    {
                                        DisplayAlert("ENTER NEFT FACILITY AVAILABLE BANK", this);
                                    }
                                }
                                else
                                {
                                    DisplayAlert("bank must be related to karnataka state", this);
                                }
                            }
                            else
                            {
                                DisplayAlert("invalid ifsc code",this);
                                txtIFSCCode.Focus();
                            }
                        }
                        else
                        {
                            DisplayAlert("invalid ifsc code", this);
                            txtIFSCCode.Focus();
                        }
                    }
                    else
                    {
                        DisplayAlert("enter ifsc code", this);
                        txtIFSCCode.Focus();
                    }
                }
                else
                {
                    DisplayAlert("enter valid bank account number", this);
                    txtAccountNumber.Focus();
                }
            }
            else
            {
                DisplayAlert("enter bank account number", this);
                txtAccountNumber.Focus();
            }
        }
        protected void btnBankDetailsBack_Click(object sender, EventArgs e)
        {
            txtAccountNumber.ReadOnly = false;
            txtIFSCCode.ReadOnly = false;
            btnGetBankDetails.Visible = true;
            btnViewBankDetails.Visible = false;
            divButtonToOtherDetails.Visible = false;
        }
        protected void btnNextChangeBankDetails_Click(object sender, EventArgs e)
        {
            txtAccountNumber.ReadOnly = false;
            txtIFSCCode.ReadOnly = false;
            btnGetBankDetails.Visible = true;
            btnViewBankDetails.Visible = false;
            divButtonToOtherDetails.Visible = false;
        }
        protected void btnNextDisplayOtherDetails_Click(object sender, EventArgs e)
        {
            //divOtherDetails.Visible = true;
            divOtherDetailsNew.Visible = true;
            divButtonToOtherDetails.Visible = false;
        }
        protected void btnOtherDetailsSave_Click(object sender, EventArgs e)
        {
            if (txtEmailID.Text.Trim() != "")
            {
                if (IsValidEmail(txtEmailID.Text.Trim()))
                {
                    if (txtApplicantMobileNumber.Text.Trim() != "")
                    {
                        if (Regex.IsMatch(txtApplicantMobileNumber.Text.Trim(), @"^\d+$"))
                        {
                            if (txtApplicantMobileNumber.Text.Trim().Length == 10)
                            {
                                if (txtAlternateMobileNumber.Text.Trim() != "")
                                {
                                    if (Regex.IsMatch(txtAlternateMobileNumber.Text.Trim(), @"^\d+$"))
                                    {
                                        if (txtAlternateMobileNumber.Text.Trim().Length == 10)
                                        {
                                            if(rbApplicantPWDYes.Checked==true || rbApplicantPWDNo.Checked == true)
                                            {
                                                if (rbApplicantPWDYes.Checked == true && txtPwdIdNumber.Text.Trim() == "")
                                                {
                                                    DisplayAlert("enter person with disabilities ID number", this);
                                                    txtPwdIdNumber.Focus();
                                                }
                                                else if(txtPwdIdNumber.Text.Trim() != "")
                                                {
                                                    ODSE.PersonWithDisabilities = txtPwdIdNumber.Text.Trim();
                                                }


                                                if (drpLoanPurpose.SelectedIndex != 0)
                                                {
                                                    if (txtLoanDescription.Text.Trim() != "")
                                                    {
                                                        if (txtLoanDescription.Text.Trim().Length > 10 && txtLoanDescription.Text.Trim().Length <= 100)
                                                        {
                                                            ODSE.EmailID = txtEmailID.Text.Trim();
                                                            ODSE.MobileNumber = txtApplicantMobileNumber.Text.Trim();
                                                            ODSE.AlternateMobileNumber = txtAlternateMobileNumber.Text.Trim();
                                                            ODSE.PurposeOfLoan = drpLoanPurpose.SelectedValue;
                                                            ODSE.LoanDESCRIPTION = txtLoanDescription.Text.Trim();
                                                            ODSE.PersonWithDisabilities = rbApplicantPWDYes.Checked == true ? txtPwdIdNumber.Text.Trim() : "NA";
                                                        }
                                                        else
                                                        {
                                                            DisplayAlert("enter valid DESCRIPTION OF LOAN", this);
                                                            txtLoanDescription.Focus();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        DisplayAlert("enter DESCRIPTION OF LOAN", this);
                                                        txtLoanDescription.Focus();
                                                    }
                                                }
                                                else
                                                {
                                                    DisplayAlert("select purpose of loan", this);
                                                    drpLoanPurpose.Focus();
                                                }

                                            }
                                            else
                                            {
                                                DisplayAlert("select person with disabilities option", this);
                                                txtAlternateMobileNumber.Focus();
                                            }
                                        }
                                        else
                                        {
                                            DisplayAlert("enter valid mobile number", this);
                                            txtAlternateMobileNumber.Focus();
                                        }
                                    }
                                    else
                                    {
                                        DisplayAlert("enter valid mobile number", this);
                                        txtAlternateMobileNumber.Focus();
                                    }
                                }
                                else
                                {
                                    DisplayAlert("enter mobile number", this);
                                    txtAlternateMobileNumber.Focus();
                                }
                            }
                            else
                            {
                                DisplayAlert("enter valid mobile number", this);
                                txtApplicantMobileNumber.Focus();
                            }
                        }
                        else
                        {
                            DisplayAlert("enter valid mobile number", this);
                            txtApplicantMobileNumber.Focus();
                        }
                    }
                    else
                    {
                        DisplayAlert("enter mobile number", this);
                        txtApplicantMobileNumber.Focus();
                    }
                }
                else
                {
                    DisplayAlert("enter valid email id", this);
                    txtEmailID.Focus();
                }
            }
            else
            {
                DisplayAlert("enter email id",this);
                txtEmailID.Focus();
            }
        }
        protected void rbApplicantPWD_CheckedChanged(object sender, EventArgs e)
        {
            if (rbApplicantPWDYes.Checked == true)
            {
                divPWDIdNumber.Visible = true;
            }
            else if (rbApplicantPWDNo.Checked == true)
            {
                divPWDIdNumber.Visible = false;
            }
        }
        private bool CheckMobileNumber(string MobileNumber)
        {
            if (txtApplicantMobileNumber.Text.Trim() != "")
            {
                if (Regex.IsMatch(txtApplicantMobileNumber.Text.Trim(), @"^\d+$"))
                {
                    if (txtApplicantMobileNumber.Text.Trim().Length == 10)
                    {

                    }
                    else
                    {
                        DisplayAlert("enter valid mobile number", this);
                        txtApplicantMobileNumber.Focus();
                    }
                }
                else
                {
                    DisplayAlert("enter valid mobile number", this);
                    txtApplicantMobileNumber.Focus();
                }
            }
            else
            {
                DisplayAlert("enter mobile number", this);
                txtApplicantMobileNumber.Focus();
            }
            return true;
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new System.Globalization.IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
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
        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {

        }
        protected void btnViewRDNumber_Click(object sender, EventArgs e)
        {

        }
        protected void btnViewBankDetails_Click(object sender, EventArgs e)
        {

        }
        protected void btnNextShowRDNumber_Click(object sender, EventArgs e)
        {

        }
        protected void btnOtherDetailsUpdate_Click(object sender, EventArgs e)
        {

        }
        protected void btnOtherDetailsView_Click(object sender, EventArgs e)
        {

        }
        
        protected void rbMarriedYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMarriedYes.Checked == true)
            {
             
            }
            else if (rbMarriedNo.Checked == true)
            {
               
            }
        }
        protected void rbWidow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWidowYes.Checked == true)
            {
             
            }
            else if (rbWidowNo.Checked == true)
            {
                
            }
        }
        protected void rbDivorced_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDivorcedYes.Checked == true)
            {
             
            }
            else if (rbDivorcedNo.Checked == true)
            {
                
            }
        }
        protected void btnOtherDetailsSaveReturnToPreview_Click(object sender, EventArgs e)
        {

        }
        
        protected void btnOtherDetailsOk_Click(object sender, EventArgs e)
        {

        }
        protected void btnNextShowBankDetails_Click(object sender, EventArgs e)
        {

        }
        protected void btnNextChangeOtherDetails_Click(object sender, EventArgs e)
        {

        }
        protected void btnNextDisplayAgrement_Click(object sender, EventArgs e)
        {

        }
        protected void ChkDeclarationChange(object sender, EventArgs e)
        {
            if (ChkSelfDeclaration.Checked == true)
            {

            }
            else if (ChkAadharDeclaration.Checked == true)
            {

            }
        }
        protected void btnPreviewApplication_Click(object sender, EventArgs e)
        {

        }
        protected void btnPreviewEditOtherDetails_Click1(object sender, EventArgs e)
        {

        }
        protected void btnPreviewEditBankDetails_Click(object sender, EventArgs e)
        {

        }
        protected void btnPreviewSubmitApplication_Click(object sender, EventArgs e)
        {

        }
        
        
        protected void btnPrintApplication_Click(object sender, EventArgs e)
        {

        }

    }
}