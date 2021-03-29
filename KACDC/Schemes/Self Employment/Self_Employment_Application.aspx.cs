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
                                                lblNCGSCNumber.Text = NKSER.NCGSCNumber;
                                                lblNCAnnualIncome.Text = NKSER.NCAnnualIncome;
                                                //NKSER.NCDateOfIssue;
                                                lblNCApplicantName.Text = NKSER.NCApplicantName;
                                                lblNCApplicantFatherName.Text = NKSER.NCApplicantFatherName;
                                                lblNCDistrict.Text = NKSER.NCDistrictName;
                                                lblNCTaluk.Text = NKSER.NCTalukName;
                                                lblNCFullAddress.Text = NKSER.NCFullAddress;
                                                ConstituencyDropDownBinding();
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
            divRDNumber.Visible = true;
        }
        protected void rbContactAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (rbContactAddressYes.Checked == true)
            {
                divContactAddress.Visible = false;
                btnSaveContactAddress.Visible = false;
                this.DropDownBinding();
            }
            else if (rbContactAddressNo.Checked == true)
            {
                divContactAddress.Visible = true;
                btnSaveContactAddress.Visible = true;
            }
        }
        private void DropDownBinding()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select DistrictName from MstDistrict where ZoneName=@Zone"))
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
        protected void drpConst_SelectedIndexChanged(object sender, EventArgs e)
        {
            NKSER.NCConstituency = drpConst.SelectedValue;
            if (NKSER.NCDistrictName == "Bengaluru")
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select DistrictName from MstConstituencies,MstDistrict where MstDistrict.DistrictCD=MstConstituencies.DistrictCD and AssemblyName=@Assembly", kvdConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Assembly", NKSER.NCConstituency);
                        cmd.Parameters.Add("@RetValue", SqlDbType.VarChar, -1);
                        cmd.Parameters["@RetValue"].Direction = ParameterDirection.Output;
                        kvdConn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            kvdConn.Close();
                            NKSER.NCDistrictName = cmd.Parameters["@RetValue"].Value.ToString();
                        }
                        //int count = (int)cmd.ExecuteScalar();
                        //return count.ToString();
                    }

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
        }
        protected void btnSaveContactAddress_Click(object sender, EventArgs e)
        {
            if (txtContactAddress.Text.Trim() != "" && txtContactAddress.Text.Trim() != null)
            {
                if (txtContactAddress.Text.Trim().Length>=10)
                {
                    if (drpContDistrict.SelectedValue != "" && drpContDistrict.SelectedValue != null)
                    {
                        if (drpContTaluk.SelectedValue != "" && drpContTaluk.SelectedValue != null)
                        {
                            if (txtContPincode.Text.Trim() != "" && txtContPincode.Text.Trim() != null)
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
                                else { DisplayAlert("enter valid pincode", this); }
                            }
                            else { DisplayAlert("enter pincode", this); }
                        }
                        else { DisplayAlert("select taluk", this); }
                    }
                    else { DisplayAlert("select district", this); }
                }
                else { DisplayAlert("enter valid address", this); }
            }
            else { DisplayAlert("enter contact address", this); }
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
                            }
                        }
                        else
                        {
                            DisplayAlert("invalid ifsc code", this);
                        }
                    }
                    else
                    {
                        DisplayAlert("enter ifsc code", this);
                    }
                }
                else
                {
                    DisplayAlert("invalid bank account number", this);
                }
            }
            else
            {
                DisplayAlert("enter bank account number", this);
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
            divOtherDetails.Visible = true;
            divOtherDetailsNew.Visible = true;
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
        protected void rbApplicantPWD_CheckedChanged(object sender, EventArgs e)
        {
            if (rbApplicantPWDYes.Checked == true)
            {
             
            }
            else if (rbApplicantPWDNo.Checked == true)
            {
                
            }
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
        protected void btnOtherDetailsSave_Click(object sender, EventArgs e)
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
        
        protected void drpContTaluk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnPrintApplication_Click(object sender, EventArgs e)
        {

        }

    }
}