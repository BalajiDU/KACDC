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
            txtRDNumber.Text.Trim();
            if(NDAR.NCGender == "MALE")
            {
                ODSE.Widow = "NA";
                ODSE.Divorced = "NA";
            }
        }

    }
}