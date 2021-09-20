using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using KACDC.Class.CreateLog;
using KACDC.Class.DataProcessing.Aadhaar;
using KACDC.Class.DataProcessing.BankData;
using KACDC.Class.DataProcessing.Nadakacheri;
using KACDC.Class.DataProcessing.OnlineApplication;
using KACDC.Class.Declaration.Aadhaar;
using KACDC.Class.Declaration.BankDetails;
using KACDC.Class.DataProcessing.EmailService;
using KACDC.Class.Declaration.Nadakacheri;
using KACDC.Class.Declaration.OnlineApplication;
using KACDC.Class.FileSaving;
using KACDC.CreateTextSharpPDF.Process;
using KACDC.CreateTextSharpPDF.Schemes.SelfEmployment;
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
        GetBankDetailsIFSC GETBD = new GetBankDetailsIFSC();
        DecBankDetails BD = new DecBankDetails();
        ApplicantPDFTable APPLITAB = new ApplicantPDFTable();
        BankTable BT = new BankTable();
        AgreementTable AT = new AgreementTable();
        SignatureTable ST = new SignatureTable();
        HeadingTable HT = new HeadingTable();
        VerifyEmailID VEID = new VerifyEmailID();
        protected void Page_Load(object sender, EventArgs e)
        {
            //ODSE.ApplicationDateTime=( DateTime.Now.ToString());
            ////Response.Write( DateTime.Now.ToString());
            //Response.Write( (DateTime.Now).ToString("MM/dd/yyyy hh:mm:sss tt") + "<br />");
            //Response.Write((Convert.ToDateTime(ODSE.ApplicationDateTime)).ToString("MM/dd/yyyy hh:mm:sss tt"));

            if (!IsPostBack)
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    kvdConn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM KACDCSettings where KeyVal=@Key"))
                    {
                        cmd.Parameters.AddWithValue("@Key", "SEApplicationEnable");
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = kvdConn;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            if (bool.Parse(sdr["Value"].ToString().ToUpper()) != true)
                            {
                                Response.Redirect(@"~\Default.aspx");
                            }
                        }
                    }
                    kvdConn.Close();
                }
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT FinancialYear FROM [dbo].[KACDCInfo]"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            ODSE.FinancialYear = sdr["FinancialYear"].ToString();
                            
                        }
                        kvdConn.Close();
                    }
                }
            }
        }
        protected void btnAadhaarGetOTP_Click(object sender, EventArgs e)
        {
            if (txtAadhaarNumber.Text.Trim().Length == 12)
            {
                if (Regex.IsMatch(txtAadhaarNumber.Text.Trim(), @"^\d+$"))
                {
                    ADSER.AadhaarNumber = txtAadhaarNumber.Text.Trim();
                    if (ADAR.SendOTP(txtAadhaarNumber.Text.Trim()))
                    {
                        DisplayAlert("otp sent to registered mobile number", this);
                        divMobileOTP.Visible = true;
                        txtOTP.Focus();
                    }
                    else
                    {
                        AadhaarError AE = new AadhaarError();
                        DisplayAlert(AE.GetAadhaarErrorMessage(ADSER.SendOTPErrorCode), this);
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
                AadhaarError AE = new AadhaarError();
                DisplayAlert(AE.GetAadhaarErrorMessage(ADSER.OTPErrorCode), this);
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
        protected void btnViewRDNumber_Click(object sender, EventArgs e)
        {
            rbContactAddressNo.Enabled = false;
            rbContactAddressYes.Enabled = false;
            drpConst.Enabled = false;
            drpContDistrict.Enabled = false;
            drpContTaluk.Enabled = false;
            txtContactAddress.ReadOnly = true;
            btnSaveContactAddress.Visible = false;
            btnNadakachriBack.Visible = false;
            btnNadakachriOK.Visible = true;
            CasteCertificatePopup.Show();
        }
        protected void btnVerifyRDNumber_Click(object sender, EventArgs e)
        {
            rbContactAddressNo.Enabled = true;
            rbContactAddressYes.Enabled = true;
            drpConst.Enabled = true;
            btnSaveContactAddress.Visible = false;
            btnNadakachriBack.Visible = true;
            txtContactAddress.ReadOnly = false;
            drpContDistrict.Enabled = true;
            drpContTaluk.Enabled = true;
            btnNadakachriOK.Visible = false;
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
                                                    divFemaleOptions.Visible = false;
                                                }
                                                else
                                                {
                                                    divFemaleOptions.Visible = true;
                                                }
                                                rbContactAddressYes.Checked = false;
                                                rbContactAddressNo.Checked = false;
                                                btnNadakachriOK.Visible = false;
                                                btnSaveContactAddress.Visible = false;
                                                divContactAddress.Visible = false;
                                                divButtonBankDetails.Visible = true;
                                                
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
                
                btnNadakachriOK.Visible = false;
                btnSaveContactAddress.Visible = true;
                ODSE.ContactPinCode = NKSER.NCApplicantCAddressPin;
                CasteCertificatePopup.Show();
            }
            else if (rbContactAddressNo.Checked == true)
            {
                this.DropDownBinding();
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
                if (NKSER.NCDistrictName == "Bengaluru" || NKSER.NCDistrictName == "ಬೆಂಗಳೂರು")
                {
                    using (SqlCommand cmd = new SqlCommand("select AssemblyCode,AssemblyName from MstConstituencies,MstDistrict where MstDistrict.DistrictCD=MstConstituencies.DistrictCD and NC_District_Name_Eng=@District"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@District", "Bengaluru");
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
                else
                {
                    using (SqlCommand cmd = new SqlCommand("select AssemblyCode,AssemblyName from MstConstituencies,MstDistrict where MstDistrict.DistrictCD=MstConstituencies.DistrictCD and DistrictName=@District"))
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
            btnViewRDNumber.Visible = true;
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
                if (Regex.IsMatch(txtAccountNumber.Text.Trim(), @"^\d+$"))
                {
                    if (txtAccountNumber.Text.Trim().Length > 5)
                    {
                        BD.AccountNumber = txtAccountNumber.Text.Trim();
                        if (txtIFSCCode.Text.Trim() != null && txtIFSCCode.Text.Trim() != "")
                        {
                            if (txtIFSCCode.Text.Trim().Length > 10)
                            {
                                if (GETBD.GetBankDetails(txtIFSCCode.Text.Trim()))
                                {
                                    if (BD.STATE == "KARNATAKA")
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
                                    DisplayAlert("invalid ifsc code", this);
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
        protected void btnViewBankDetails_Click(object sender, EventArgs e)
        {
            BankDetailsPopup.Show();
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
            this.VerifyOtherDetails();
        }
        private bool VerifyOtherDetails()
        {
            if (txtEmailID.Text.Trim() != "")
            {
                if (VEID.IsValidEmail(txtEmailID.Text.Trim()))
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
                                            if (rbApplicantPWDYes.Checked == true || rbApplicantPWDNo.Checked == true)
                                            {
                                                if (rbApplicantPWDYes.Checked == true && txtPwdIdNumber.Text.Trim() == "")
                                                {
                                                    DisplayAlert("enter person with disabilities ID number", this);
                                                    txtPwdIdNumber.Focus();
                                                    return false;
                                                }
                                                else if (txtPwdIdNumber.Text.Trim() != "")
                                                {
                                                    ODSE.PersonWithDisabilities = txtPwdIdNumber.Text.Trim();
                                                }





                                                if (drpLoanPurpose.SelectedIndex != 0)
                                                {
                                                    if (txtLoanDescription.Text.Trim() != "")
                                                    {
                                                        if (txtLoanDescription.Text.Trim().Length > 10 && txtLoanDescription.Text.Trim().Length <= 100)
                                                        {
                                                            if (NKSER.NCGender == "FEMALE")
                                                            {
                                                                if (rbMarriedYes.Checked == true || rbMarriedNo.Checked == true)
                                                                {
                                                                    if (rbMarriedYes.Checked == true)
                                                                    {
                                                                        if (rbWidowYes.Checked == true || rbWidowNo.Checked == true)
                                                                        {
                                                                            if (rbDivorcedYes.Checked == true || rbDivorcedNo.Checked == true)
                                                                            {
                                                                                this.SaveOtherDetails();
                                                                                return true;
                                                                            }
                                                                            else
                                                                            {
                                                                                DisplayAlert("select any option are you Divorced", this);
                                                                                return false;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            DisplayAlert("select any option are you Widow", this);
                                                                            return false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        this.SaveOtherDetails();
                                                                        return true;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    DisplayAlert("select any option in Are you Married?", this);
                                                                    return false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                this.SaveOtherDetails();
                                                                return true;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            DisplayAlert("enter valid DESCRIPTION OF LOAN", this);
                                                            txtLoanDescription.Focus();
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        DisplayAlert("enter DESCRIPTION OF LOAN", this);
                                                        txtLoanDescription.Focus();
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    DisplayAlert("select purpose of loan", this);
                                                    drpLoanPurpose.Focus();
                                                    return false;
                                                }

                                            }
                                            else
                                            {
                                                DisplayAlert("select person with disabilities option", this);
                                                txtAlternateMobileNumber.Focus();
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            DisplayAlert("enter valid mobile number", this);
                                            txtAlternateMobileNumber.Focus();
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        DisplayAlert("enter valid mobile number", this);
                                        txtAlternateMobileNumber.Focus();
                                        return false;
                                    }
                                }
                                else
                                {
                                    DisplayAlert("enter mobile number", this);
                                    txtAlternateMobileNumber.Focus();
                                    return false;
                                }
                            }
                            else
                            {
                                DisplayAlert("enter valid mobile number", this);
                                txtApplicantMobileNumber.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            DisplayAlert("enter valid mobile number", this);
                            txtApplicantMobileNumber.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        DisplayAlert("enter mobile number", this);
                        txtApplicantMobileNumber.Focus();
                        return false;
                    }
                }
                else
                {
                    DisplayAlert("enter valid email id", this);
                    txtEmailID.Focus();
                    return false;
                }
            }
            else
            {
                DisplayAlert("enter email id", this);
                txtEmailID.Focus();
                return false;
            }
        }
        private void SaveOtherDetails()
        {
            ODSE.EmailID = txtEmailID.Text.Trim();
            ODSE.MobileNumber = txtApplicantMobileNumber.Text.Trim();
            ODSE.AlternateMobileNumber = txtAlternateMobileNumber.Text.Trim();
            ODSE.PurposeOfLoan = drpLoanPurpose.SelectedValue;
            ODSE.LoanDESCRIPTION = txtLoanDescription.Text.Trim();
            ODSE.PersonWithDisabilities = rbApplicantPWDYes.Checked == true ? txtPwdIdNumber.Text.Trim() : "NA";
            divOtherDetailsNew.Visible = false;
            divOtherDetails.Visible = true;
            divButtonToAgrement.Visible = true;
            btnOtherDetailsUpdate.Visible = false;
            btnOtherDetailsView.Visible = true;
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
        protected void rbMarriedYes_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rbMarriedYes.Checked == true)
            {
                divFemaleMarriedOption.Visible = true;
                rbDivorcedYes.Checked = false;
                rbDivorcedNo.Checked = false;
                rbWidowNo.Checked = false;
                rbWidowYes.Checked = false;
            }
            else if (rbMarriedNo.Checked == true)
            {
                divFemaleMarriedOption.Visible = false;
                ODSE.Widow = "NA";
                ODSE.Divorced = "NA";
            }
        }
        protected void rbWidow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWidowYes.Checked == true)
            {
                ODSE.Widow = "YES";
            }
            else if (rbWidowNo.Checked == true)
            {
                ODSE.Widow = "NO";
            }
        }
        protected void rbDivorced_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDivorcedYes.Checked == true)
            {
                ODSE.Divorced = "YES";
            }
            else if (rbDivorcedNo.Checked == true)
            {
                ODSE.Divorced = "NO";
            }
        }
        protected void btnNextShowBankDetails_Click(object sender, EventArgs e)
        {
            divButtonToOtherDetails.Visible = true;
            divButtonToAgrement.Visible = false;
        }
        protected void btnNextChangeOtherDetails_Click(object sender, EventArgs e)
        {
            divOtherDetailsNew.Visible = true;
            divButtonToAgrement.Visible = false;
        }
        protected void btnNextDisplayAgrement_Click(object sender, EventArgs e)
        {
            divButtonToAgrement.Visible = false;
            divApproveAggrement.Visible = true;
            divPreviewButton.Visible = true;
        }
        protected void ChkDeclarationChange(object sender, EventArgs e)
        {
            if (ChkSelfDeclaration.Checked == true && ChkAadharDeclaration.Checked == true)
            {
                divPreviewButton.Visible = true;
                ODSE.SelfDeclaration = "YES";
                ODSE.AadharDeclaration = "YES";
            }
            else
            {
                divPreviewButton.Visible = false;
            }
            if (ChkAgreetoProvideData.Checked == true)
            {
                ODSE.ShareData = "YES";
            }
            else
            {
                ODSE.ShareData = "NO";
            }
        }
        protected void btnPreviewApplication_Click(object sender, EventArgs e)
        {
            if (ChkAadharDeclaration.Checked == true)
            {
                if (ChkSelfDeclaration.Checked == true)
                {
                    if (ChkAgreetoProvideData.Checked == true)
                    {
                        this.fillApplicationPreview();
                        divPreviewApplication.Visible = true;
                    }
                    else
                    {
                        ChkAgreetoProvideData.Focus();
                        DisplayAlert("Agree to share information for government facilities", this);
                    }
                }
                else
                {
                    ChkSelfDeclaration.Focus();
                    DisplayAlert("Agree for self declaration", this);
                }
            }
            else
            {
                ChkAadharDeclaration.Focus();
                DisplayAlert("Agree for aadhaar consent/declaration", this);
            }
        }
        private void fillApplicationPreview()
        {
            lblName.Text = ADSER.Name;
            ImgCandPhoto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(ADSER.Photo, 0, (ADSER.Photo).Length);
            lblFatherName.Text = NDAR.NCApplicantFatherName;
            lblGender.Text = NDAR.NCGender;
            lblDOB.Text = ADSER.DOB;
            lblRDNum.Text = "VERIFIED";
            lblWidowed.Text = ODSE.Widow==null ? "NA" : ODSE.Widow;
            lblDivorced.Text = ODSE.Divorced==null ? "NA" : ODSE.Divorced;
            lblPurpose.Text = ODSE.PurposeOfLoan;
            lblLoanDescription.Text = ODSE.LoanDESCRIPTION;
            lblPhysicallyCha.Text = ODSE.PersonWithDisabilities;
            lblAnualIncome.Text = NDAR.NCAnnualIncome;
            lblMobileNum.Text = ODSE.MobileNumber;
            lblAlternateNum.Text = ODSE.AlternateMobileNumber;
            lblEmailID.Text = ODSE.EmailID;
            lblAadhar.Text = "VERIFIED";
            lblContactAddr.Text = ODSE.ContactFullAddress;
            lblParmanentAddr.Text = NDAR.NCFullAddress;
            lblContDistrict.Text = ODSE.ContactDistrictName;
            lblParDistrict.Text = NDAR.NCDistrictName;
            lblContTaluk.Text = ODSE.ContactTalukName;
            lblParTaluk.Text = NDAR.NCTalukName;
            lblParConstituency.Text = NDAR.NCConstituency;
            lblParPincode.Text = NDAR.NCApplicantCAddressPin;
            lblContPincode.Text = ODSE.ContactPinCode;
            lblAccountHolder.Text = ADSER.Name;
            lblAccountNum.Text = BD.AccountNumber;
            lblBank.Text = BD.BANK;
            lblBranchName.Text = BD.BRANCH;
            lblIFCSCode.Text = BD.IFSC;
            lblBankAddr.Text = BD.FULLADDRESS;
        }
        protected void btnPreviewEditOtherDetails_Click1(object sender, EventArgs e)
        {
            divPreviewApplication.Visible = false;
            divOtherDetailsNew.Visible = true;
            divApproveAggrement.Visible = false;
            divPreviewButton.Visible = false;
            btnOtherDetailsSave.Visible = false;
            btnOtherDetailsOk.Visible = false;
            btnOtherDetailsSaveReturnToPreview.Visible = true;
        }
        protected void btnPreviewEditBankDetails_Click(object sender, EventArgs e)
        {
            btnNextDisplayBankDetails_Click(sender, e);
        }
        protected void btnPreviewSubmitApplication_Click(object sender, EventArgs e)
        {
            //ODSE.ApplicationDateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:sss");
            ODSE.ApplicationDateTime = DateTime.Now.ToString();
            if(SaveApplicationDB())
            {
                btnPreviewEditOtherDetails.Visible = false;
                //btnPreviewSubmitApplication.Visible = false;
                divSubmitandEdit.Visible = false;
                File.WriteAllBytes(Server.MapPath("~/Files_SelfEmployment/AadhaarApplicantPhoto/"+ODSE.GeneratedApplicationNumber+"_"+ADSER.AadhaarVaultToken + ".png"), ADSER.Photo);
                if (GenerateApplicantPDF())
                {
                    //if (SendSMSEmail())
                    //{

                    //}

                }
            }
            else
            {
                DisplayAlert(ODSE.GeneratedApplicationNumber, this);
            }
        }
        private bool SaveApplicationDB()
        {
            //NDAR;
            //ADSER;
            StoreSEApplication SaveSE = new StoreSEApplication();

            ODSE.GeneratedApplicationNumber = SaveSE.StoreSE(ADSER.Name, NDAR.NCApplicantFatherName, ADSER.Gender, ODSE.Widow, ODSE.Divorced, ODSE.PersonWithDisabilities, NDAR.NCAnnualIncome, NDAR.NCGSCNumber, ODSE.EmailID, ODSE.MobileNumber, ODSE.AlternateMobileNumber,
            ADSER.DOB, ODSE.PurposeOfLoan, ADSER.AadhaarVaultToken, "", ODSE.ContactFullAddress, ODSE.ContactDistrictName, ODSE.ContactPinCode, NDAR.NCFullAddress, NDAR.NCDistrictName, NKSER.NCConstituency, NDAR.NCApplicantCAddressPin,
            ADSER.Name, BD.AccountNumber, BD.BANK, BD.BRANCH, BD.IFSC, BD.ADDRESS, ODSE.ApplicationDateTime, ODSE.ApplicationDateTime, NDAR.NCTalukName, ODSE.ContactTalukName, ODSE.LoanDESCRIPTION, NDAR.NCApplicantName);


            string ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            ApplicationLog LOG = new ApplicationLog();
            LOG.OnlineApplicationLog(ipaddress, Path.GetFileName(Request.Path), "SaveSE", ODSE.GeneratedApplicationNumber, "Success", (Convert.ToDateTime(ODSE.ApplicationDateTime)).ToString("MM/dd/yyyy hh:mm:sss tt"));

            //TODO delete 2 lines
            //HttpContext.Current.Response.Write(ODSE.GeneratedApplicationNumber);
            //Response.Write("<br />ApplicationDateTime: " + ODSE.ApplicationDateTime);
            //Response.Write("<br />DOB: "+ ADSER.DOB);

            if (ODSE.GeneratedApplicationNumber.Contains("KACDCSE")) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GenerateApplicantPDF()
        {
            string ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            try
            {
                string SelfEnglish = "I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Self Employment Loan. If any discrepancies are found later, I agree to take legal action against me.";
                string SelfKannada = "\n ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು  ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು  ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣೀಕರಿಸುತ್ತೇನೆ.  ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ  ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು \n ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿಯ ಕ್ರಮ ಜರುಗಿಸಲು ಒಪ್ಪಿರುತ್ತೇನೆ.";
                string AadhaarEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
                string AadhaarKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";
                string ShareEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
                string ShareKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";

                PdfPTable HeadingTable = null;
                HeadingTable = new PdfPTable(4);
                HeadingTable = HT.GenerateHeading(HeadingTable, "Self Employment Loan", (Convert.ToDateTime(ODSE.ApplicationDateTime)).ToString("MM/dd/yyyy hh:mm:sss tt"));
                PdfPTable Table = null;
                Table = new PdfPTable(4);
                Table = APPLITAB.SEApplicantMainTable(Table, ODSE.GeneratedApplicationNumber, ADSER.Name, NDAR.NCApplicantFatherName, ADSER.Gender, ODSE.Widow, ODSE.Divorced, ODSE.PersonWithDisabilities, NDAR.NCAnnualIncome, NDAR.NCGSCNumber, ODSE.EmailID, ODSE.MobileNumber, ODSE.AlternateMobileNumber,
            ADSER.DOB, ODSE.PurposeOfLoan, ADSER.AadhaarVaultToken, "", ODSE.ContactFullAddress, ODSE.ContactDistrictName, ODSE.ContactPinCode, NDAR.NCFullAddress, NDAR.NCDistrictName, NKSER.NCConstituency, NDAR.NCApplicantCAddressPin,
             (Convert.ToDateTime(ODSE.ApplicationDateTime)).ToString("MM/dd/yyyy hh:mm:sss tt"), (Convert.ToDateTime(ODSE.ApplicationDateTime)).ToString("MM/dd/yyyy hh:mm:sss tt"), NDAR.NCTalukName, ODSE.ContactTalukName, ODSE.LoanDESCRIPTION, NDAR.NCApplicantName, NKSER.NCLanguage, ODSE.GeneratedApplicationNumber + "_" + ADSER.AadhaarVaultToken);
                PdfPTable BankTable = null;
                BankTable = new PdfPTable(4);
                BankTable = BT.GenerateBankTable(BankTable, ADSER.Name, BD.AccountNumber, BD.BANK, BD.BRANCH, BD.IFSC, BD.ADDRESS);
                PdfPTable AgreeTable = null;
                AgreeTable = new PdfPTable(4);
                AgreeTable = AT.GenerateAgreementTable(AgreeTable, SelfEnglish, SelfKannada, AadhaarEnglish, AadhaarKannada, ShareEnglish, ShareKannada);
                PdfPTable SignatureTable = null;
                SignatureTable = new PdfPTable(4);
                SignatureTable = ST.GenerateSignatureTable(SignatureTable);

                Document pdfDoc = new Document(PageSize.A4, 0, 0, 35, 0);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    pdfDoc.Open();
                    pdfDoc.Add(HeadingTable);
                    pdfDoc.Add(Table);
                    pdfDoc.Add(BankTable);
                    pdfDoc.Add(AgreeTable);
                    pdfDoc.Add(SignatureTable);

                    pdfDoc.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    //Response.Clear();

                    SaveFile SV = new SaveFile();
                    SV.SavingFileOnServer(Server.MapPath("~/Files_SelfEmployment/Application/" + ODSE.FinancialYear + "/"), ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf", bytes);
                    if (File.Exists(Server.MapPath("~/Files_SelfEmployment/Application/" + ODSE.FinancialYear + "/")+ ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf"))
                    {
                        SendSMSEmail();
                    }
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + ODSE.GeneratedApplicationNumber+"_"+ ADSER.Name + ".pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                Response.Write("File Creation: "+ex.ToString());
                return false;
            }
        }
        private bool SendSMSEmail()
        {
            try
            {
                SubmitApplicationSMS SMS = new SubmitApplicationSMS();
                ApplicationSubmitEmail EMAIL = new ApplicationSubmitEmail();
                SMS.ApplicantSMSConfirmation(ODSE.MobileNumber, ODSE.GeneratedApplicationNumber, "Self Employment", ADSER.Name);
                EMAIL.ApplicantEmailConfirmation(ODSE.EmailID, ODSE.GeneratedApplicationNumber, "Self Employment", ADSER.Name,
                    File.ReadAllBytes(Server.MapPath("~/Files_SelfEmployment/Application/" + ODSE.FinancialYear + "/") + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf"),
                    ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf");
                return true;
            }
            catch(Exception ex)
            {
                Response.Write("Send mail: "+ex.ToString());
                return false;
            }
        }
        protected void btnPrintApplication_Click(object sender, EventArgs e)
        {
            //This is used to get Project Location.
            string filePath = Server.MapPath("~/Files_SelfEmployment/Application/" + ODSE.FinancialYear + "/") + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf";
            //This is used to get the current response.
            HttpResponse res = GetHttpResponse();
            res.Clear();
            res.AppendHeader("content-disposition", "attachment; filename=" + filePath);
            res.ContentType = "application/octet-stream";
            res.WriteFile(filePath);
            res.Flush();
            res.End();
        }
        public static HttpResponse GetHttpResponse()
        {
            return HttpContext.Current.Response;
        }
        //protected void btnpdfprint_Click()
        //{
        //    Document pdfDoc = new Document(PageSize.A4, 0, 0, 35, 0);
        //    //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    Phrase phrase = null;
        //    //PdfPCell cell = null;
        //    PdfPTable table = null;

        //    PdfPTable BankTable = null;
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    int Center = PdfPCell.ALIGN_CENTER;
        //    int VCenter = PdfPCell.ALIGN_MIDDLE;
        //    int Left = PdfPCell.ALIGN_LEFT;
        //    //int Justify = PdfPCell.ALIGN_JUSTIFIED;
        //    //BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ArialUni.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //    BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\tunga.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //    string arialuniTff = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
        //    iTextSharp.text.FontFactory.Register(arialuniTff);
        //    //List<IElement> list = HTMLWorker.ParseToList(new StringReader(stringBuilder.ToString()), ST);

        //    iTextSharp.text.html.simpleparser.StyleSheet ST = new iTextSharp.text.html.simpleparser.StyleSheet();
        //    ST.LoadTagStyle(HtmlTags.BODY, HtmlTags.FACE, "Arial Unicode MS");
        //    ST.LoadTagStyle(HtmlTags.BODY, HtmlTags.ENCODING, BaseFont.IDENTITY_H);


        //    iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
        //        pdfDoc.Open();
        //        table = new PdfPTable(4);


        //        table.TotalWidth = 550f;
        //        table.LockedWidth = true;
        //        table.SetWidths(new float[] { 0.3f, 0.4f, 0.3f, 0.4f });

        //        BankTable = new PdfPTable(4);
        //        BankTable.TotalWidth = 550f;
        //        BankTable.LockedWidth = true;
        //        BankTable.SetWidths(new float[] { 0.3f, 0.4f, 0.3f, 0.4f });

        //        pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));
        //        PdfPCell cellWithRowspan = new PdfPCell(ImageCell("~/Image/KACDC_PDF.png", 30f, PdfPCell.ALIGN_CENTER, BaseColor.BLACK));

        //        //System.Drawing.Image imageBIt = ConvertTextToImage("ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ<br />ABCjhk", "Arial", 10, Color.Yellow, Color.Black);
        //        //iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageBIt, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        //pdfImage.ScaleToFit( 0.3f, 0.4f, 0.3f, 0.4f );

        //        //Row 2
        //        table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        PdfPCell cell = new PdfPCell(PrintHeaderCell("Applicant Details".ToUpper(), "sans-serif", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
        //        cell.Colspan = 2;
        //        table.AddCell(cell);
        //        table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));


        //        //Row 2
        //        table.AddCell(GenerateCell("Application Number", 12, "ಅರ್ಜಿ ಸಂಖ್ಯೆ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(GenerateCell("Application Date", 12, "ಅರ್ಜಿ ದಿನಾಂಕ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 3
        //        table.AddCell(GenerateCell("NAME", 12, "ಹೆಸರು", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        // Applicant Photo
        //        cellWithRowspan.Rowspan = 5;
        //        cellWithRowspan.BorderColor = BaseColor.WHITE;
        //        table.AddCell(cellWithRowspan);

        //        //Row 4
        //        table.AddCell(GenerateCell("Father / Guardian Name", 12, "ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 5
        //        table.AddCell(GenerateCell("Gender", 12, "ಲಿಂಗ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 6
        //        table.AddCell(GenerateCell("DOB", 12, "ಜನ್ಮ ದಿನಾಂಕ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 7
        //        table.AddCell(GenerateCell("RD Number", 12, "R D ಸಂಖ್ಯೆ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 8
        //        table.AddCell(GenerateCell("Father / Guardian Name", 12, "ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(GenerateCell("Person With Disablities", 12, "ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 9
        //        table.AddCell(GenerateCell("Anual Income", 12, "ವಾರ್ಷಿಕ ಆದಾಯ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(GenerateCell("Purpose of Loan", 12, "ಸಾಲದ ಉದ್ದೇಶ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 10
        //        table.AddCell(GenerateCell("Mobile Number", 12, "ಮೊಬೈಲ್ ಸಂಖ್ಯೆ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(GenerateCell("Alternate Mobile Number", 12, "ಪರ್ಯಾಯ ಮೊಬೈಲ್ ಸಂಖ್ಯೆ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 9
        //        table.AddCell(GenerateCell("Emai ID", 12, "ಇ-ಮೇಲ್ ಐಡಿ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(GenerateCell("Aadhar", 12, "ಆಧಾರ್", 20f));
        //        table.AddCell(PrintCell("VERIFIED", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 10
        //        table.AddCell(GenerateCell("Parmanent Address", 12, "ಶಾಶ್ವತ ವಿಳಾಸ", 20f));
        //        PdfPCell FullAddresscell;

        //        iTextSharp.text.Image FullAddressImage = ConvertTextToImagePAddress(GenerateMultiLineTextAreaPAddress("ಅನವಾಲ , ಬಾದಾಮಿ, ಬಾಗಲಕೋಟ", 18), "sans-serif", 10, Color.White, Color.Black);
        //        FullAddressImage.ScalePercent(20f);


        //        FullAddresscell = new PdfPCell(FullAddressImage);
        //        FullAddresscell.VerticalAlignment = VCenter;
        //        FullAddresscell.HorizontalAlignment = Left;
        //        FullAddresscell.BorderColor = BaseColor.WHITE;

        //        table.AddCell(FullAddresscell); table.AddCell(GenerateCell("Contact Address", 12, "ಸಂಪರ್ಕ ವಿಳಾಸ", 20f));
        //        PdfPCell ContactAddresscell;

        //        string Caddress = GenerateMultiLineTextAreaCAddress("ಮದು ಬಸವರಾಜ ಬಿಜಾಪುರ", 18);
        //        iTextSharp.text.Image ContactFullAddressImage = ConvertTextToImageCAddress(Caddress, "sans-serif", 10, Color.White, Color.Black);
        //        ContactFullAddressImage.ScalePercent(20f);

        //        ContactAddresscell = new PdfPCell(ContactFullAddressImage);
        //        ContactAddresscell.VerticalAlignment = VCenter;
        //        ContactAddresscell.HorizontalAlignment = Left;
        //        ContactAddresscell.BorderColor = BaseColor.WHITE;

        //        table.AddCell(ContactAddresscell);
        //        //Row 11
        //        table.AddCell(GenerateCell("District", 12, "ಜಿಲ್ಲೆ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(GenerateCell("District", 12, "ಜಿಲ್ಲೆ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 12
        //        table.AddCell(GenerateCell("Taluk", 12, "ತಾಲ್ಲೂಕು", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(GenerateCell("Taluk", 12, "ತಾಲ್ಲೂಕು", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 13
        //        table.AddCell(GenerateCell("Pin code", 12, "ಪಿನ್ ಕೋಡ್", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(GenerateCell("Pin code", 12, "ಪಿನ್ ಕೋಡ್", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //Row 13
        //        table.AddCell(GenerateCell("Constituency", 12, "ಕ್ಷೇತ್ರ", 20f));
        //        table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));


        //        PdfPCell BankDetailsHeader = new PdfPCell(PrintHeaderCell("Bank Details".ToUpper(), "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
        //        BankDetailsHeader.Colspan = 4;
        //        BankTable.AddCell(BankDetailsHeader);

        //        BankTable.AddCell(GenerateCell("Account Holder Name", 12, "ಖಾತೆದಾರರ ಹೆಸರು", 20f));
        //        BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        BankTable.AddCell(GenerateCell("A/C Number", 12, "ಖಾತೆ ಸಂಖ್ಯೆ", 20f));
        //        BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        BankTable.AddCell(GenerateCell("Bank", 12, "ಬ್ಯಾಂಕ್", 20f));
        //        BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        BankTable.AddCell(GenerateCell("Branch", 12, "ಶಾಖೆ", 20f));
        //        BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        BankTable.AddCell(GenerateCell("IFSC Code", 12, "ಐಎಫ್‌ಎಸ್‌ಸಿ ಕೋಡ್", 20f));
        //        BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        BankTable.AddCell(GenerateCell("Address", 12, "ವಿಳಾಸ", 20f));
        //        BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        //BankTable.AddCell(GenerateCell("Account Holder Name", 12, "ಖಾತೆದಾರರ ಹೆಸರು", 20f));
        //        //BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        //BankTable.AddCell(GenerateCell("A/C Number", 12, "ಖಾತೆ ಸಂಖ್ಯೆ", 20f));
        //        //BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

        //        string abc = @"I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation, (Government of Karnataka Undertaking), to use my Aadhaar number for performing all such validations which may be, required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
        //        PdfPCell BankDetailsHeade = new PdfPCell(PrintCell(abc, "Times New Roman", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, PdfPCell.ALIGN_JUSTIFIED, PdfPCell.ALIGN_JUSTIFIED));
        //        BankDetailsHeade.Colspan = 4;
        //        //BankTable.AddCell(BankDetailsHeade);



        //        string SelfEnglish = "I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Arivu Education Loan. If any discrepancies are found later, I agree to take legal action against me.";
        //        string SelfKannada = "\n ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು  ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು  ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣೀಕರಿಸುತ್ತೇನೆ.  ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ  ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು \n ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿಯ ಕ್ರಮ ಜರುಗಿಸಲು ಒಪ್ಪಿರುತ್ತೇನೆ.";
        //        string AadhaarEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
        //        string AadhaarKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";


        //        PdfPCell SelfDeclaration = new PdfPCell(GenerateCell(SelfEnglish, 8, SelfKannada, 15f, BaseFont.COURIER));
        //        SelfDeclaration.Colspan = 4;
        //        BankTable.AddCell(SelfDeclaration);

        //        PdfPCell AadhaarDeclaration = new PdfPCell(GenerateCell(AadhaarEnglish, 8, AadhaarKannada, 15f, BaseFont.COURIER));
        //        AadhaarDeclaration.Colspan = 4;
        //        BankTable.AddCell(AadhaarDeclaration);

        //        PdfPCell EmptyHeader = new PdfPCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
        //        EmptyHeader.Colspan = 4;
        //        BankTable.AddCell(EmptyHeader);

        //        PdfPCell SignatureCell = new PdfPCell(GenerateCell("Signature", 15, "    ಸಹಿ", 25f));
        //        BankTable.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        BankTable.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        BankTable.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
        //        BankTable.AddCell(SignatureCell);



        //        pdfDoc.Add(table);
        //        pdfDoc.NewPage();
        //        pdfDoc.Add(BankTable);



        //        pdfDoc.Close();
        //        byte[] bytes = memoryStream.ToArray();
        //        memoryStream.Close();
        //        Response.Clear();
        //        Response.ContentEncoding = System.Text.Encoding.UTF8;
        //        string fname = "EmpFile";
        //        Response.AddHeader("Content-Disposition", "attachment; filename=" + fname + ".pdf");
        //        Response.ContentType = "application/pdf";
        //        Response.Buffer = true;
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.BinaryWrite(bytes);
        //        Response.End();
        //        Response.Close();
        //    }
        //}


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
        
        
        protected void btnNextShowRDNumber_Click(object sender, EventArgs e)
        {
            divButtonToOtherDetails.Visible = false;
            divBankDetails.Visible = false;
            divButtonBankDetails.Visible = true;
        }
        protected void btnOtherDetailsUpdate_Click(object sender, EventArgs e)
        {

        }
        protected void btnOtherDetailsView_Click(object sender, EventArgs e)
        {
            divOtherDetailsNew.Visible = true;
            divOtherDetails.Visible = false;
        }
        
        protected void btnOtherDetailsSaveReturnToPreview_Click(object sender, EventArgs e)
        {
            if (this.VerifyOtherDetails())
            {
                this.fillApplicationPreview();
                divOtherDetailsNew.Visible = false;
                divOtherDetails.Visible = true;

                divPreviewApplication.Visible = true;
            }
        }
        
        protected void btnOtherDetailsOk_Click(object sender, EventArgs e)
        {
            divOtherDetailsNew.Visible = false;
            divOtherDetails.Visible = true;
        }
    }
}