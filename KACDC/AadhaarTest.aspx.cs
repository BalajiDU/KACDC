using KACDC.Class;
using System;
using krdh.connector;
using krdh.parameters;
using KRDHConnector;
using System.Web.UI;
using KACDC.Class.Declaration.Aadhaar;

namespace KACDC
{
    public partial class AadhaarTest : System.Web.UI.Page
    {
        AadhaarServiceData ADSE = new AadhaarServiceData();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAadhaarGetOTP_Click(object sender, EventArgs e)
        {
            //string abc = ConfigurationSettings.AppSettings["naeUser"].ToString();
            //DisplayAlert(abc,this);
            //AadhaarSendOTP();
            ADSE.AadhaarNumber = txtAadhaar.Text.Trim();
            //DisplayAlert("Before", this);
            try
            {
                if (AadhaarSendOTP())
                {
                    //DisplayAlert("OTP sent to registerd mobile number", this);
                    lblTransID.Text = ADSE.AadhaarOTPResponseTransactionID;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //WriteErrorLog(ADSE.SendOTPErrorCode, ADSE.SendOTPErrorMessage);
                //if (ADSE.SendOTPErrorCode == "AUA-OTP-03")
                //    DisplayAlert("Try after some time", this);
                //else if (ADSE.SendOTPErrorCode == "AUA-OTP-01")
                //    DisplayAlert("Invalid Information", this);
                //else
                //    DisplayAlert(ADSE.SendOTPErrorMessage, this);
            }
        }
        protected bool AadhaarSendOTP()
        {
            RequestObject request = new RequestObject();

            request.setAadhaarNumber(ADSE.AadhaarNumber);
            request.setTransaction(Util.generateTransactionId(TypeOfRequest.Others));
            request.setOtpRequestType(OTPRequestType.AADHAAR);
            request.setTimeStamp(Util.getTimeStamp());

            krdh.connector.KRDHConnectorImpl krdhConnector = new KRDHConnectorImpl();
            ResponseObject response = krdhConnector.RequestOTP(request);

            if (response.getStatus().Equals("N"))
            {
                Response.Write(response.getUIDToken());
                ADSE.SendOTPErrorMessage = response.getErrorMessage();
                ADSE.SendOTPErrorCode = response.getError();
                return false;
            }
            else
            {
                if (response.getResponseStatus().ToLower().Equals("y"))
                {
                    Response.Write(response.getTimeStamp());
                    ADSE.AadhaarOTPResponseTransactionID = response.getTransaction();
                    Response.Write("SUCCESS");
                    Response.Write("OTP Sent: " + response.getTransaction() + "\n");
                    Response.Write("Var OTP Sent: " + ADSE.AadhaarOTPResponseTransactionID + "\n");
                    return true;
                }
                else
                {
                    Response.Write(response.getError());
                    Response.Write(response.getErrorMessage());
                    ADSE.SendOTPErrorMessage = response.getErrorMessage();
                    ADSE.SendOTPErrorCode = response.getError();
                    return false;
                }
            }

        }
        protected void btnAadhaarOTPVerify_Click(object sender, EventArgs e)
        {
            try
            {
                ADSE.AadhaarApplicantOTP = txtAadhaarOTP.Text.Trim();
                if (VerifyAadhaarOTP())
                {
                    Response.Write("OTP Verified Successful");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
               
            }

        }
        private bool VerifyAadhaarOTP()
        {
            KYCRequest kYCRequest = new KYCRequest();
            kYCRequest.setAuthenticationType(ResidentAuthenticationType.OTP);
            kYCRequest.setDecryptionRequired(false);
            kYCRequest.setLocalLanguageRequired(false);
            kYCRequest.setPrintFormatRequired(false);
            RequestObject request = new RequestObject();
            request.setAadhaarNumber(ADSE.AadhaarNumber);
            request.setVersion("2.5");
            //request.setUdc(UDCCode);
            request.setTimeStamp(Util.getTimeStamp());
            request.setResidentConsent(true);
            request.setKycRequest(kYCRequest);
            PinValue pv = new PinValue();
            pv.setOtp(ADSE.AadhaarApplicantOTP);
            request.setTransaction(ADSE.AadhaarOTPResponseTransactionID);
            Response.Write("Verifying OTP(var): " + ADSE.AadhaarOTPResponseTransactionID + "\n");
            request.setPinValue(pv);
            KRDHConnectorImpl krdhConnector = new KRDHConnectorImpl();
            ResponseObject response = krdhConnector.requestKYC(request);
            Response.Write("Response Received\n");
            Response.Write(response.getInfo());
            if (response.getStatus().Equals("N"))
            {
                Response.Write("Failed to generate the request.\n");
                Response.Write(response.getError() + "\n");
                Response.Write(response.getErrorMessage() + "\n");
                Response.Write("Var : " + ADSE.AadhaarOTPResponseTransactionID + "\n");
                ADSE.OTPErrorCode = response.getError();
                ADSE.OTPErrorMessage = response.getErrorMessage();
                return false;
            }
            else
            {
                if (response.getResponseStatus().ToLower().Equals("y"))
                {
                    Response.Write(response.getTimeStamp() + "\n");
                    Response.Write(response.getTransaction() + "\n");
                    Response.Write("SUCCESS" + "\n");
                    lblToken.Text = ADSE.AadhaarVaultToken;
                    ADSE.DOB = response.GetKycRes().UidData.Poi.dob;
                    ADSE.Gender = response.GetKycRes().UidData.Poi.gender;
                    ADSE.Name = response.GetKycRes().UidData.Poi.name;
                    ADSE.State = response.GetKycRes().UidData.Poa.state;
                    ADSE.District = response.GetKycRes().UidData.Poa.state;
                    ADSE.Photo = response.GetKycRes().UidData.Pht;
                    ADSE.Pincode = response.GetKycRes().UidData.Poa.pc;
                    Response.Write("___" + ADSE.Name + "___" + ADSE.DOB + "_" + ADSE.Gender + "_" + ADSE.District + "_" + ADSE.State);
                    return true;
                }
                else
                {
                    Response.Write(response.getError() + "\n");
                    Response.Write(response.getErrorMessage() + "\n");
                    ADSE.OTPErrorCode = response.getError();
                    ADSE.OTPErrorMessage = response.getErrorMessage();
                    return false;
                }
            }
        }

        protected void btnProcessTest_Click(object sender, EventArgs e)
        {
            try
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_File" + 0,
                "window.open('https://aryavysya.karnataka.gov.in/Schemes/Arivu/" + "STUDY_CERTIFICATE_FORMAT.pdf" + "','_blank');", true);
                System.Diagnostics.Process.Start(Server.MapPath("~/Schemes/Arivu/STUDY_CERTIFICATE_FORMAT.pdf"));
                System.Diagnostics.Process.Start("notepad.exe");

            }
            catch (Exception ex)
            {
                DisplayAlert(ex.ToString(),this);
            }
        }
        public static void DisplayAlert(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            //page.ClientScript.RegisterStartupScript(owner.GetType(),"ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    message));
            message = message.ToUpper();
            ScriptManager.RegisterClientScriptBlock(owner, owner.GetType(), "alertMessage", "alert('" + message + "')", true);
        }
    }
}