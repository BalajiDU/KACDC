﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.Class.CreateLog;
using KACDC.Class.DataProcessing.Aadhaar;
using KACDC.Class.DataProcessing.BankData;
using KACDC.Class.DataProcessing.Nadakacheri;
using KACDC.Class.DataProcessing.OnlineApplication;
using KACDC.Class.Declaration.Aadhaar;
using KACDC.Class.Declaration.BankDetails;
using KACDC.Class.Declaration.CollegeData;
using KACDC.Class.Declaration.Nadakacheri;
using KACDC.Class.Declaration.OnlineApplication;
using KACDC.Class.FileSaving;
using KACDC.CreateTextSharpPDF.Process;
using KACDC.CreateTextSharpPDF.Schemes.Arivu;
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

namespace KACDC.Schemes.Arivu
{
    public partial class Arivu_Application : System.Web.UI.Page
    {
        AadhaarService ADAR = new AadhaarService();
        AadhaarServiceData ADSER = new AadhaarServiceData();

        
        NadaKacheri NDAR = new NadaKacheri();
        NadakacheriProcess NKAR = new NadakacheriProcess();
        OtherDataArivu ODAR = new OtherDataArivu();
        NadaKacheri NKSER = new NadaKacheri();
        BankDetails GETBD = new BankDetails();
        DecBankDetails BD = new DecBankDetails();
        ApplicantPDFTableAR APPLITAB = new ApplicantPDFTableAR();
        BankTable BT = new BankTable();
        CollegeTable CT = new CollegeTable();
        AgreementTable AT = new AgreementTable();
        SignatureTable ST = new SignatureTable();
        HeadingTable HT = new HeadingTable();
        ApplicantCollegeData ACD = new ApplicantCollegeData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                            ODAR.FinancialYear = sdr["FinancialYear"].ToString();

                        }
                        kvdConn.Close();
                    }
                }
            }
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
                        AadhaarError AE = new AadhaarError();
                        DisplayAlert(AE.GetAadhaarErrorMessage(ADSER.SendOTPErrorMessage), this);
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
        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
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
                                                
                                                rbContactAddressYes.Checked = false;
                                                rbContactAddressNo.Checked = false;
                                                btnNadakachriOK.Visible = false;
                                                btnSaveContactAddress.Visible = false;
                                                divContactAddress.Visible = false;
                                                divButtonBankDetails.Visible = true;

                                                btnVerifyRDNumber.Visible = false;
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
                            DisplayAlert("You have already avail the loan in " + IsRDExist + " financial year", this);
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
        protected void btnNextChangeRDNumber_Click(object sender, EventArgs e)
        {
            divButtonBankDetails.Visible = false;
            txtRDNumber.ReadOnly = false;
            btnVerifyRDNumber.Visible = true;
            btnViewRDNumber.Visible = false;
        }
        protected void btnNextDisplayBankDetails_Click(object sender, EventArgs e)
        {
            btnViewRDNumber.Visible = true;
            divButtonBankDetails.Visible = false;
            divBankDetails.Visible = true;
            txtRDNumber.ReadOnly = true;
        }

        protected void btnGetBankDetails_Click(object sender, EventArgs e)
        {
            if (txtAccountNumber.Text.Trim() != null && txtAccountNumber.Text.Trim() != "")
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
        protected void btnNextShowRDNumber_Click(object sender, EventArgs e)
        {
            divButtonToOtherDetails.Visible = false;
            divBankDetails.Visible = false;
            divButtonBankDetails.Visible = true;
        }
        protected void btnNextChangeBankDetails_Click(object sender, EventArgs e)
        {
            txtAccountNumber.ReadOnly = false;
            txtIFSCCode.ReadOnly = false;
            btnGetBankDetails.Visible = true;
            btnViewBankDetails.Visible = false;
            divButtonToOtherDetails.Visible = false;
        }
        protected void btnNextDisplayCollegeDetails_Click(object sender, EventArgs e)
        {
        }
        protected void btnViewCollegeDetails_Click(object sender, EventArgs e)
        {
        }
        protected void btnUploadCETAdmission_Click(object sender, EventArgs e)
        {
        }
        protected void btnUploadStudyCertificate_Click(object sender, EventArgs e)
        {
        }
        protected void btnUploadPrevMarksCard_Click(object sender, EventArgs e)
        {
        }
        protected void btnUploadFeesStructure_Click(object sender, EventArgs e)
        {
        }
        protected void btnUploadCollegeHostel_Click(object sender, EventArgs e)
        {
        }
        protected void btnCollegeDetailsSaveReturnToPreview_Click(object sender, EventArgs e)
        {
        }
        protected void btnCollegeDetailsSave_Click(object sender, EventArgs e)
        {
            this.VerifyCollegeDetails();
        }
        private void VerifyCollegeDetails()
        {
            if (txtCollegeCode.Text.Trim()!="" && txtCollegeCode.Text.Trim()!=null  )
            {
                if (txtCollegeCode.Text.Trim().Length > 3)
                {
                    if (txtCETAdmTicNum.Text.Trim() != "" && txtCETAdmTicNum.Text.Trim() != null)
                    {
                        if (txtCETAdmTicNum.Text.Trim().Length > 3)
                        {
                            if (txtCETAppNum.Text.Trim() != "" && txtCETAppNum.Text.Trim() != null)
                            {
                                if (txtCETAppNum.Text.Trim().Length > 3)
                                {
                                    if (txtCollegeName.Text.Trim() != "" && txtCollegeName.Text.Trim() != null)
                                    {
                                        if (txtCollegeName.Text.Trim().Length > 3)
                                        {
                                            if (txtClgAddress.Text.Trim() != "" && txtClgAddress.Text.Trim() != null)
                                            {
                                                if (txtClgAddress.Text.Trim().Length > 3)
                                                {
                                                    if (txtClgAddress.Text.Trim() != "" && txtClgAddress.Text.Trim() != null)
                                                    {
                                                        if (txtClgAddress.Text.Trim().Length > 3)
                                                        {
                                                            if (txtPreviousMarks.Text.Trim() != "" && txtPreviousMarks.Text.Trim() != null)
                                                            {
                                                                if (txtPreviousMarks.Text.Trim().Length > 2)
                                                                {
                                                                    if (drpCourse.SelectedValue != "0")
                                                                    {
                                                                        if (drpYear.SelectedValue != "0")
                                                                        {
                                                                            if (rbCollegeHostelYes.Checked==true || rbCollegeHostelNo.Checked==true)
                                                                            {

                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            DisplayAlert("Select Year", this);
                                                                            drpYear.Focus();
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        DisplayAlert("Select Course", this);
                                                                        drpCourse.Focus();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    txtRequierdLoanAmount.Text = "Enter valid Previous Year Marks";
                                                                    DisplayAlert("Enter valid Previous Year Marks", this);
                                                                    txtPreviousMarks.Focus();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                txtRequierdLoanAmount.Text = "Enter Previous Year Marks";
                                                                DisplayAlert("Enter Previous Year Marks", this);
                                                                txtPreviousMarks.Focus();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            txtRequierdLoanAmount.Text = "Enter valid Required Loan Amount";
                                                            DisplayAlert("Enter valid Required Loan Amount", this);
                                                            txtClgAddress.Focus();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        txtRequierdLoanAmount.Text = "Enter Required Loan Amount";
                                                        DisplayAlert("Enter Required Loan Amount", this);
                                                        txtClgAddress.Focus();
                                                    }
                                                }
                                                else
                                                {
                                                    lblCollegeCodeError.Text = "Enter valid College Address";
                                                    DisplayAlert("Enter valid College Address", this);
                                                    txtClgAddress.Focus();
                                                }
                                            }
                                            else
                                            {
                                                lblCollegeCodeError.Text = "Enter College Address";
                                                DisplayAlert("Enter College Address", this);
                                                txtClgAddress.Focus();
                                            }
                                        }
                                        else
                                        {
                                            lblCollegeCodeError.Text = "Enter valid College Name";
                                            DisplayAlert("Enter valid College Name", this);
                                            txtCollegeName.Focus();
                                        }
                                    }
                                    else
                                    {
                                        lblCollegeCodeError.Text = "Enter College Name";
                                        DisplayAlert("Enter College Name", this);
                                        txtCollegeName.Focus();
                                    }
                                }
                                else
                                {
                                    lblCollegeCodeError.Text = "Enter valid CET Application Number";
                                    DisplayAlert("Enter valid CET Application Number", this);
                                    txtCETAppNum.Focus();
                                }
                            }
                            else
                            {
                                lblCollegeCodeError.Text = "Enter CET Application Number";
                                DisplayAlert("Enter CET Application Number", this);
                                txtCETAppNum.Focus();
                            }
                        }
                        else
                        {
                            lblCollegeCodeError.Text = "Enter valid CET Admission Ticket";
                            DisplayAlert("Enter valid CET Admission Ticket", this);
                            txtCETAdmTicNum.Focus();
                        }
                    }
                    else
                    {
                        lblCollegeCodeError.Text = "Enter CET Admission Ticket";
                        DisplayAlert("Enter CET Admission Ticket", this);
                        txtCETAdmTicNum.Focus();
                    }
                }
                else
                {
                    lblCollegeCodeError.Text = "Enter valid College Code";
                    DisplayAlert("Enter valid College Code", this);
                    txtCollegeCode.Focus();
                }
            }
            else
            {
                lblCollegeCodeError.Text = "Enter College Code";
                DisplayAlert("Enter College Code", this);
                txtCollegeCode.Focus();
            }
        }
        protected void txtCollegeCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCollegeCode.Text.Trim().Length > 3)
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT CollegeName,CollegeAddress FROM [dbo].[CollegeData] where CollegeCode=@CLGCode"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@CLGCode", txtCollegeCode.Text.Trim());
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            txtCollegeName.Text = sdr["CollegeName"].ToString();
                            txtClgAddress.Text = sdr["CollegeAddress"].ToString();

                        }
                        kvdConn.Close();
                    }
                }
            }
            else
            {
                lblCollegeCodeError.Text = "Invalid College Code";
            }
        }
        protected void btnCollegeDetailsOk_Click(object sender, EventArgs e)
        {
        }
        protected void btnNextDisplayOtherDetails_Click(object sender, EventArgs e)
        {
            //divOtherDetails.Visible = true;
            divOtherDetailsNew.Visible = true;
            divButtonToOtherDetails.Visible = false;
        }
        protected void btnNextChangeCollegeDetails_Click(object sender, EventArgs e)
        {
        }
        protected void btnOtherDetailsUpdate_Click(object sender, EventArgs e)
        {
        }
        protected void btnOtherDetailsView_Click(object sender, EventArgs e)
        {
            divOtherDetailsNew.Visible = true;
            divOtherDetails.Visible = false;
        }

        protected void btnOtherDetailsOk_Click(object sender, EventArgs e)
        {
            divOtherDetailsNew.Visible = false;
            divOtherDetails.Visible = true;
        }
        protected void btnOtherDetailsSave_Click(object sender, EventArgs e)
        {
            this.VerifyOtherDetails();
        }
        private bool VerifyOtherDetails()
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
                                                    ODAR.PersonWithDisabilities = txtPwdIdNumber.Text.Trim();
                                                }
                                                this.SaveOtherDetails();
                                                return true;
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
            ODAR.EmailID = txtEmailID.Text.Trim();
            ODAR.MobileNumber = txtApplicantMobileNumber.Text.Trim();
            ODAR.AlternateMobileNumber = txtAlternateMobileNumber.Text.Trim();
            ODAR.PersonWithDisabilities = rbApplicantPWDYes.Checked == true ? txtPwdIdNumber.Text.Trim() : "NA";
            divOtherDetailsNew.Visible = false;
            divOtherDetails.Visible = true;
            divButtonToAgrement.Visible = true;
            btnOtherDetailsUpdate.Visible = false;
            btnOtherDetailsView.Visible = true;
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
            
            lblPhysicallyCha.Text = ODAR.PersonWithDisabilities;
            lblAnualIncome.Text = NDAR.NCAnnualIncome;
            lblMobileNum.Text = ODAR.MobileNumber;
            lblAlternateNum.Text = ODAR.AlternateMobileNumber;
            lblEmailID.Text = ODAR.EmailID;
            lblAadhar.Text = "VERIFIED";
            lblContactAddr.Text = ODAR.ContactFullAddress;
            lblParmanentAddr.Text = NDAR.NCFullAddress;
            lblContDistrict.Text = ODAR.ContactDistrictName;
            lblParDistrict.Text = NDAR.NCDistrictName;
            lblContTaluk.Text = ODAR.ContactTalukName;
            lblParTaluk.Text = NDAR.NCTalukName;
            lblParConstituency.Text = NDAR.NCConstituency;
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
        protected void btnPreviewEditCollegeDetails_Click(object sender, EventArgs e)
        {
        }
        protected void btnPreviewSubmitApplication_Click(object sender, EventArgs e)
        {
            ODAR.ApplicationDateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:sss tt");
            if (SaveApplicationDB())
            {
                if (GenerateApplicantPDF())
                {
                    if (SendSMSEmail())
                    {

                    }

                }
            }
        }
        private bool SaveApplicationDB()
        {
            //NDAR;
            //ADSER;
            StoreSEApplication SaveSE = new StoreSEApplication();

            ODAR.GeneratedApplicationNumber = SaveSE.StoreSE(ADSER.Name, NDAR.NCApplicantFatherName, ADSER.Gender, ODAR.Widow, ODAR.Divorced, ODAR.PersonWithDisabilities, NDAR.NCAnnualIncome, NDAR.NCGSCNumber, ODAR.EmailID, ODAR.MobileNumber, ODAR.AlternateMobileNumber,
            ADSER.DOB, ODAR.PurposeOfLoan, ADSER.AadhaarVaultToken, "", ODAR.ContactFullAddress, ODAR.ContactDistrictName, ODAR.ContactPinCode, NDAR.NCFullAddress, NDAR.NCDistrictName, NKSER.NCConstituency, NDAR.NCApplicantCAddressPin,
            ADSER.Name, BD.AccountNumber, BD.BANK, BD.BRANCH, BD.IFSC, BD.ADDRESS, ODAR.ApplicationDateTime, ODAR.ApplicationDateTime, NDAR.NCTalukName, ODAR.ContactTalukName, ODAR.LoanDESCRIPTION, NDAR.NCApplicantName);
            if (ODAR.GeneratedApplicationNumber != "NA")
            {
                string ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];
                ApplicationLog LOG = new ApplicationLog();
                LOG.OnlineApplicationLog(ipaddress, Path.GetFileName(Request.Path), "SaveAR", ODAR.GeneratedApplicationNumber, "Success", ODAR.ApplicationDateTime);
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
                string SelfEnglish = "I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Arivu Education Loan. If any discrepancies are found later, I agree to take legal action against me.";
                string SelfKannada = "\n ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು  ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು  ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣೀಕರಿಸುತ್ತೇನೆ.  ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ  ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು \n ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿಯ ಕ್ರಮ ಜರುಗಿಸಲು ಒಪ್ಪಿರುತ್ತೇನೆ.";
                string AadhaarEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
                string AadhaarKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";
                string ShareEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
                string ShareKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";

                PdfPTable HeadingTable = null;
                HeadingTable = new PdfPTable(4);
                HeadingTable = HT.GenerateHeading(HeadingTable, "Self Employment Loan", ODAR.ApplicationDateTime);
                PdfPTable Table = null;
                Table = new PdfPTable(4);
                Table = APPLITAB.ApplicantMainTable(Table, ODAR.GeneratedApplicationNumber, ADSER.Name, NDAR.NCApplicantFatherName, ADSER.Gender, ODAR.Widow, ODAR.Divorced, ODAR.PersonWithDisabilities, NDAR.NCAnnualIncome, NDAR.NCGSCNumber, ODAR.EmailID, ODAR.MobileNumber, ODAR.AlternateMobileNumber,
            ADSER.DOB, ODAR.PurposeOfLoan, ADSER.AadhaarVaultToken, "", ODAR.ContactFullAddress, ODAR.ContactDistrictName, ODAR.ContactPinCode, NDAR.NCFullAddress, NDAR.NCDistrictName, NKSER.NCConstituency, NDAR.NCApplicantCAddressPin,
             ODAR.ApplicationDateTime, ODAR.ApplicationDateTime, NDAR.NCTalukName, ODAR.ContactTalukName, ODAR.LoanDESCRIPTION, NDAR.NCApplicantName, NKSER.NCLanguage);
                PdfPTable CollegeTable = null;
                CollegeTable = new PdfPTable(4);
                CollegeTable = CT.GenerateCollegeTable(CollegeTable, ACD.CETAdmissionTicketNumber, ACD.CETApplicationNumber, ACD.CollegeName , ACD.CollegeAddress , ACD.Course , ACD.Year ,
             ACD.PreviousYearMarks , ACD.RequiredLoanAmount , ACD.CollegeHostel);
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
                    Response.Clear();

                    SaveFile SV = new SaveFile();
                    SV.SavingFileOnServer(Server.MapPath("~/Files_Arivu/Application/" + ODAR.FinancialYear + "/"), ODAR.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf", bytes);
                    if (File.Exists(Server.MapPath("~/Files_Arivu/Application/" + ODAR.FinancialYear + "/") + ODAR.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf"))
                    {
                        SendSMSEmail();
                    }
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + ODAR.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool SendSMSEmail()
        {
            SubmitApplicationSMS SMS = new SubmitApplicationSMS();
            ApplicationSubmitEmail EMAIL = new ApplicationSubmitEmail();
            SMS.ApplicantSMSConfirmation(ODAR.MobileNumber, ODAR.GeneratedApplicationNumber, "Self Employment", ADSER.Name);
            EMAIL.ApplicantEmailConfirmation(ODAR.EmailID, ODAR.GeneratedApplicationNumber, "Self Employment", ADSER.Name,
                File.ReadAllBytes(Server.MapPath("~/Files_Arivu/Application/" + ODAR.FinancialYear + "/") + ODAR.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf"),
                ODAR.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf");
            return true;
        }
        protected void btnPrintApplication_Click(object sender, EventArgs e)
        {
            //This is used to get Project Location.
            string filePath = Server.MapPath("~/Files_Arivu/Application/" + ODAR.FinancialYear + "/") + ODAR.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf";
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
        //popup
        protected void btnNadakachriBack_Click(object sender, EventArgs e)
        {
            divButtonBankDetails.Visible = false;
            btnViewRDNumber.Visible = false;
            btnVerifyRDNumber.Visible = true;
            divRDNumber.Visible = true;
        }
        protected void btnSaveContactAddress_Click(object sender, EventArgs e)
        {

            if (drpConst.SelectedIndex != 0)
            {
                if (rbContactAddressNo.Checked == true)
                {
                    if (txtContactAddress.Text.Trim() != "" && txtContactAddress.Text.Trim() != null)
                    {
                        if (txtContactAddress.Text.Trim().Length >= 10)
                        {
                            if (drpContDistrict.SelectedValue != "" && drpContDistrict.SelectedValue != null && drpContDistrict.SelectedIndex != 0)
                            {
                                if (drpContTaluk.SelectedValue != "" && drpContTaluk.SelectedValue != null && drpContTaluk.SelectedIndex != 0)
                                {
                                    if (txtContPincode.Text.Trim() != "" && txtContPincode.Text.Trim() != null)
                                    {
                                        if (Regex.IsMatch(txtContPincode.Text.Trim(), @"^\d+$"))
                                        {
                                            if (txtContPincode.Text.Trim().Length == 6)
                                            {
                                                ODAR.ContactFullAddress = txtContactAddress.Text.Trim();
                                                ODAR.ContactDistrictName = drpContDistrict.SelectedValue;
                                                ODAR.ContactTalukName = drpContTaluk.SelectedValue;
                                                ODAR.ContactPinCode = txtContPincode.Text.Trim();
                                                divButtonBankDetails.Visible = true;
                                                btnVerifyRDNumber.Visible = false;
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


        protected void btnCollegeDetailsUpdate_Click(object sender, EventArgs e)
        {
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
        protected void btnNextDisplayAgrement_Click(object sender, EventArgs e)
        {
            divButtonToAgrement.Visible = false;
            divApproveAggrement.Visible = true;
            divPreviewButton.Visible = true;
        }
        protected void ChkDeclarationChange(object sender, EventArgs e)
        {

        }
        protected void btnBankDetailsBack_Click(object sender, EventArgs e)
        {
            txtAccountNumber.ReadOnly = false;
            txtIFSCCode.ReadOnly = false;
            btnGetBankDetails.Visible = true;
            btnViewBankDetails.Visible = false;
            divButtonToOtherDetails.Visible = false;
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
        protected void rbCollegeHostel_CheckChanged(object sender, EventArgs e)
        {
            if (rbCollegeHostelYes.Checked == true)
            {
                divCollegeHostelFile.Visible=true;
            }
            else if (rbCollegeHostelNo.Checked == true)
            {
                divCollegeHostelFile.Visible = false;
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

    }
}