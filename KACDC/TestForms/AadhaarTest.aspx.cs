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

namespace KACDC.TestForms
{
    public partial class AadhaarTest : System.Web.UI.Page
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
                        divMobileOTP.Visible = true;
                    }
                    else
                    {
                        AadhaarError AE = new AadhaarError();
                        DisplayAlert(AE.GetAadhaarErrorMessage(ADSER.SendOTPErrorCode), this);
                        lblAllError.Text = ADSER.SendOTPErrorMessage+"<br />"+AE.GetAadhaarErrorMessage(ADSER.SendOTPErrorCode);
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
                lblAllError.Text = ADSER.OTPErrorCode + "<br />" + AE.GetAadhaarErrorMessage(ADSER.OTPErrorCode);
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