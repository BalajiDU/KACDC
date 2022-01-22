using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.Class.DataProcessing.ApplicationProcess;
using KACDC.Class.DataProcessing.EncryptionProcess;
using KACDC.Class.DataProcessing.OTPService;
using KACDC.Class.Declaration.ApprovalProcess;
using KACDC.Class.Declaration.BankDetails;
using KACDC.Class.FileSaving;
using KACDC.Class.MessageSending;
using KACDC.CreateTextSharpPDF.Process;
using KACDC.CreateTextSharpPDF.Schemes.SelfEmployment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.Schemes.Self_Employment
{
    public partial class SEApplicationDownload : System.Web.UI.Page
    {
        DownloadApplicationDec DAD = new DownloadApplicationDec();
        DownloadApplication DA = new DownloadApplication();
        OTP OTP = new OTP();
        Encryption ENC = new Encryption();
        SendMessage SM = new SendMessage();
        ApplicantDetails AD = new ApplicantDetails();

        DecBankDetails BD = new DecBankDetails();
        ApplicantPDFTable APPLITAB = new ApplicantPDFTable();
        BankTable BT = new BankTable();
        AgreementTable AT = new AgreementTable();
        SignatureTable ST = new SignatureTable();
        HeadingTable HT = new HeadingTable();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoanType_CheckChanged(object sender, EventArgs e)
        {
            if (rbArivu.Checked == true)
            {
                divGetOTP.Visible = true;
                txtApplicationNumber.Text = "KACDCAR";
                divLoanSelection.Visible = false;
                DAD.LoanType = "AR";
            }
            else if (rbSelfEmployment.Checked == true)
            {
                divGetOTP.Visible = true;
                txtApplicationNumber.Text = "KACDCSE";
                divLoanSelection.Visible = false;
                DAD.LoanType = "SE";

            }
        }
        protected void btnGetOTP_Click(object sender, EventArgs e)
        {
            DAD.ApplicationNumber = txtApplicationNumber.Text.Trim();
            DA.GetApplicantDetails();
            if (DAD.MobileNum != "")
            {
                btnGetOTP.Visible = false;
                DAD.OTP = ENC.Encrypt(OTP.NewOTP());
                string MSG = ENC.Decrypt(DAD.OTP)+ " is your OTP to verify your mobile number to download application. do not share with others.   From: KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION LTD";
                SM.OTPMessageRequest(MSG, DAD.MobileNum, "MOBVER");
                divVerifyOTP.Visible = true;
                txtApplicationNumber.ReadOnly = true;
                DisplayAlert("OTP sent to registered mobile number", this);
            }
            else
            {
                btnGetOTP.Visible = true;
                DisplayAlert("Invalid Application number", this);
            }
        }
        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            if(txtOTP.Text.Trim()== ENC.Decrypt(DAD.OTP))
            {
                lblApplicantName.Text = DAD.AppliName;
                divDownloadApplication.Visible = true;
                divVerifyOTP.Visible = false;
            }
            else
            {
                divDownloadApplication.Visible = false;
                divVerifyOTP.Visible = true;
                DisplayAlert("Invalid otp", this);
            }
        }
        protected void btnResendOTP_Click(object sender, EventArgs e)
        {
            string MSG = ENC.Decrypt(DAD.OTP) + " is your OTP to verify your mobile number to download application. do not share with others.   From: KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION LTD";
            SM.OTPMessageRequest(MSG, DAD.MobileNum, "MOBVER");
            DisplayAlert("OTP sent to registered mobile number", this);
        }
        protected void btnApplicationDownload_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/Files_SelfEmployment/Application/" + DAD.FinancialYear + "/") + DAD.ApplicationNumber + "_" + DAD.AppliName + ".pdf";
            if (File.Exists(filePath))
            {
                DownloadApplication(filePath);
            }
            else
            {
                CreateApplication();
                DownloadApplication(filePath);
            }

        }
        private void DownloadApplication(string filePath)
        {
            HttpResponse res = HttpContext.Current.Response;
            res.Clear();
            res.AppendHeader("content-disposition", "attachment; filename=" + filePath);
            res.ContentType = "application/octet-stream";
            res.WriteFile(filePath);
            res.Flush();
            res.End();
        }
        private void CreateApplication()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from SelfEmpLoan where ApplicationNumber=@ApplicationNum"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ApplicationNum", DAD.ApplicationNumber);

                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        AD.ApplicationNumber = sdr["ApplicationNumber"].ToString();
                        AD.ApplicantName = sdr["ApplicantName"].ToString();
                        AD.FatherName = sdr["FatherName"].ToString();
                        AD.Gender = sdr["Gender"].ToString();
                        AD.Widowed = sdr["Widowed"].ToString();
                        AD.Divorced = sdr["Divorced"].ToString();
                        AD.PhysicallyChallenged = sdr["PhysicallyChallenged"].ToString();
                        AD.AnualIncome = sdr["AnualIncome"].ToString();
                        AD.RDNumber = sdr["RDNumber"].ToString();
                        AD.EmailID = sdr["EmailID"].ToString();
                        AD.MobileNumber = sdr["MobileNumber"].ToString();
                        AD.AlternateNumber = sdr["AlternateNumber"].ToString();
                        AD.DoB = sdr["DoB"].ToString();
                        AD.LoanPurpose = sdr["LoanPurpose"].ToString();
                        AD.AadharNum = sdr["AadharNum"].ToString();
                        AD.Occupation = sdr["Occupation"].ToString();
                        AD.ContactAddress = sdr["ContactAddress"].ToString();
                        AD.ContDistrict = sdr["ContDistrict"].ToString();
                        AD.ContPincode = sdr["ContPincode"].ToString();
                        AD.ParmanentAddress = sdr["ParmanentAddress"].ToString();
                        AD.ParDistrict = sdr["ParDistrict"].ToString();
                        AD.ParConstituency = sdr["ParConstituency"].ToString();
                        AD.ParPincode = sdr["ParPincode"].ToString();
                        AD.AccHolderName = sdr["AccHolderName"].ToString();
                        AD.AccountNumber = sdr["AccountNumber"].ToString();
                        AD.BankName = sdr["BankName"].ToString();
                        AD.Branch = sdr["Branch"].ToString();
                        AD.IFSCCode = sdr["IFSCCode"].ToString();
                        AD.BankAddress = sdr["BankAddress"].ToString();
                        AD.AppliedDate = sdr["AppliedDate"].ToString();
                        AD.ModifiedDate = sdr["ModifiedDate"].ToString();
                        AD.ParTaluk = sdr["ParTaluk"].ToString();
                        AD.ContTaluk = sdr["ContTaluk"].ToString();
                        AD.FinancialYear = sdr["FinancialYear"].ToString();
                        AD.LoanDescription = sdr["LoanDescription"].ToString();
                        AD.ApplicantNameNC = sdr["ApplicantNameNC"].ToString();
                        AD.ApprovedApplicationNum = sdr["ApprovedApplicationNum"].ToString();
                        


                    }
                    kvdConn.Close();
                }
            }


            string SelfEnglish = "I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Self Employment Loan. If any discrepancies are found later, I agree to take legal action against me.";
            string SelfKannada = "\n ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು  ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು  ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣೀಕರಿಸುತ್ತೇನೆ.  ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ  ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು \n ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿಯ ಕ್ರಮ ಜರುಗಿಸಲು ಒಪ್ಪಿರುತ್ತೇನೆ.";
            string AadhaarEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation LTD (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
            string AadhaarKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ)(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";
            string ShareEnglish = "I hereby Certify that the above furnished information is true to my Knowledge. I shall give concurrence to share my details to any other Govt Organizations also for awareness of Government Scheme.";
            string ShareKannada = "\n ಮೇಲಿನ ಮಾಹಿತಿಯು ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯವಾಗಿದೆ ಎಂದು ನಾನು ಪ್ರಮಾಣೀಕರಿಸುತ್ತೇನೆ. ಸರ್ಕಾರಿ ಯೋಜನೆಯ ಅರಿವಿಗಾಗಿ ಬೇರೆ ಯಾವುದೇ ಸರ್ಕಾರಿ ಸಂಸ್ಥೆಗಳಿಗೆ\n ನನ್ನ ವಿವರಗಳನ್ನು ಹಂಚಿಕೊಳ್ಳಲು ನಾನು ಸಮ್ಮತಿಸುತ್ತೇನೆ.";

            PdfPTable HeadingTable = null;
            HeadingTable = new PdfPTable(4);
            HeadingTable = HT.GenerateHeading(HeadingTable, "Self Employment Loan", (Convert.ToDateTime(AD.AppliedDate)).ToString("MM/dd/yyyy hh:mm:sss tt"));
            PdfPTable Table = null;
            Table = new PdfPTable(4);
            Table = APPLITAB.SEApplicantMainTable(Table, AD.ApprovedApplicationNum, AD.ApplicantName, AD.FatherName, AD.Gender, AD.Widowed, AD.Divorced, AD.PhysicallyChallenged, AD.AnualIncome, AD.RDNumber, AD.EmailID, AD.MobileNumber, AD.AlternateNumber,
        AD.DoB, AD.LoanPurpose, "", "", AD.ContactAddress, AD.ContDistrict, AD.ContPincode, AD.ParmanentAddress, AD.ParDistrict, AD.ParConstituency, AD.ParPincode,
         (Convert.ToDateTime(AD.AppliedDate)).ToString("MM/dd/yyyy hh:mm:sss tt"), (Convert.ToDateTime(AD.AppliedDate)).ToString("MM/dd/yyyy hh:mm:sss tt"), AD.ParTaluk, AD.ContTaluk, AD.LoanDescription, AD.ApplicantName, DA.GetIncomeCertificate(AD.RDNumber), AD.ApplicationNumber + "_" + AD.AadharNum);
            PdfPTable BankTable = null;
            BankTable = new PdfPTable(4);
            BankTable = BT.GenerateBankTable(BankTable, AD.ApplicantName, BD.AccountNumber, BD.BANK, BD.BRANCH, BD.IFSC, BD.ADDRESS);
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
                SV.SavingFileOnServer(Server.MapPath("~/Files_SelfEmployment/Application/" + AD.FinancialYear + "/"), AD.ApplicationNumber + "_" + AD.ApplicantName + ".pdf", bytes);
                //if (File.Exists(Server.MapPath("~/Files_SelfEmployment/Application/" + AD.FinancialYear + "/") + AD.ApplicationNumber + "_" + AD.ApplicantName + ".pdf"))
                //{
                //    SendSMSEmail();
                //}
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + AD.ApplicationNumber + "_" + AD.ApplicantName + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
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