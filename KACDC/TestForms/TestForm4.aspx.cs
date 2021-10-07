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
using KACDC.Class.DataProcessing.FileProcessing.CreatePDF.PDFReports;
using System.Drawing;

namespace KACDC.TestForms
{
    public partial class TestForm4 : System.Web.UI.Page
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
        HeadingKanTable Heading = new HeadingKanTable();

        PdfImgConvert GIC = new PdfImgConvert();

        protected void Page_Load(object sender, EventArgs e)
        {

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
                    if (File.Exists(Server.MapPath("~/Files_SelfEmployment/Application/" + ODSE.FinancialYear + "/") + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf"))
                    {
                        //SendSMSEmail();
                    }
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Response.Write("File Creation: " + ex.ToString());
                return false;
            }
        }

        protected void btnPrintPDF_Click(object sender, EventArgs e)
        {
            OrderTable OT = new OrderTable();
            OrderTableParagraph OP = new OrderTableParagraph();
            LoanAndApplicantDetails LAD = new LoanAndApplicantDetails();
            //PdfPTable HeadingTable = null;
            //HeadingTable = new PdfPTable(4);
            //HeadingTable = Heading.GenerateHeading(HeadingTable, "Self Employment Loan", (Convert.ToDateTime(ODSE.ApplicationDateTime)).ToString("MM/dd/yyyy hh:mm:sss tt"));

            Document pdfDoc = new Document(PageSize.A4, 0, 0, 20, 0);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                pdfDoc.Add(Heading.GenerateHeading("ಕರ್ನಾಟಕ"));
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 95.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));
                //p.setSpacingBefore = 20f;
                pdfDoc.Add(p);

                //pdfDoc.Add(Table);
                //pdfDoc.Add(BankTable);
                //pdfDoc.Add(AgreeTable);
                //pdfDoc.Add(SignatureTable);
                pdfDoc.Add(new PdfPCell( GIC.GenerateImgCell(10, "ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ)", 15f, Color.Brown)));
                pdfDoc.Add(OT.GenerateOrderTable());
                //pdfDoc.Add(new Paragraph(new Chunk("\n")));
                pdfDoc.Add(OP.GenerateOrderParagraph("  ಮೇಲ್ಕಂಡ ಉಲ್ಲೇಖದಲ್ಲಿ 2020-21 ನೇ ಸಾಲಿನಲ್ಲಿ ಕೆಲವು ಸೂಚನೆಗಳನ್ನು ಒಳಗೊಂಡಂತೆ \nನಿಗಮದ ವಾರ್ಷಿಕ ಕ್ರಿಯಾ ಯೋಜನೆಯನ್ನು ರೂಪಿಸಲಾಗಿರುತ್ತದೆ. ಈ ಸಂಬಂಧ ಸ್ವಯಂ ಉದ್ಯೋಗ \nನೇರ ಸಾಲ ಯೋಜನೆಯಲ್ಲಿ ಸಾಲವನ್ನು ಮಂಜೂರು ಮಾಡಿ ಆರ್‍.ಟಿ.ಜಿ.ಎಸ್ ಮೂಲಕ \nಆಯ್ಕೆಯಾದ ಫಲಾನುಭವಿಗಳಿಗೆ ಸಾಲ ಬಿಡುಗಡೆ ಮಾಡಲಾಗಿದೆ.",10f));
                pdfDoc.Add(new Paragraph(new Chunk("\n", FontFactory.GetFont("sans-serif", 5, iTextSharp.text.Font.BOLD, BaseColor.BLACK))));
                pdfDoc.Add(LAD.GenerateApplicantInfo("djfn sdjnf jdf", "KACDCSE2002000003", "KACDC/SE/01/CR-05(000001)2019-20/20-09-2021", "100000", "20-01-2021"));
                pdfDoc.Add(new Paragraph(new Chunk("\n", FontFactory.GetFont("sans-serif", 5, iTextSharp.text.Font.BOLD, BaseColor.BLACK))));
                pdfDoc.Add(OP.GenerateOrderParagraph("  ಅರ್ಜಿದಾರರಿಗೆ ಕೆಳಗೆ ತಿಳಿಸಿರುವ ನಿಬಂಧನೆಗಳು ಮತ್ತು ಸಾಲ ಮಂಜೂರಾತಿಯ ಕೆಲವು ಷರತ್ತುಗಳಿಗೆ \nಒಳಪಟ್ಟು ಸಾಲ ಮಂಜೂರಾತಿ ನೀಡಿದೆ."));
                pdfDoc.Add(OP.GenerateOrderParagraph("1.	ಫಲಾನುಭವಿಯು ನಿಗಮದಿಂದ ಪಡೆದ ಸಾಲದ ಮೊತ್ತದಿಂದ ಅಗತ್ಯವಿರುವ ಆಧುನಿಕ \nಉಪಕರಣಗಳನ್ನು ಕೊಂಡು ಘಟಕವನ್ನು ಸ್ಥಾಪಿಸಿ ನಡೆಸಬೇಕು. ಈ ರೀತಿ ಘಟಕವನ್ನು ಸ್ಥಾಪಿಸಿರುವ \nಬಗ್ಗೆ ಜಿಲ್ಲಾ ವ್ಯವಸ್ಥಾಪಕರು ಪರಿಶೀಲನೆ ಮಾಡಿ ದೃಢೀಕರಿಸಬೇಕು. ಫಲಾನುಭವಿಯು ಘಟಕ \nಸ್ಥಾಪಿಸದಿದ್ದಲ್ಲಿ, ಸಾಲದ ಮೊತ್ತವನ್ನು ಕಡ್ಡಾಯವಾಗಿ ಒಂದೇ ಇಡುಗಂಟಿನಲ್ಲಿ ಬಡ್ಡಿ ಸಮೇತ\n ಪಾವತಿಸಬೇಕಾಗಿರುತ್ತದೆ."));
                pdfDoc.Add(OP.GenerateOrderParagraph("2.	ಫಲಾನುಭವಿಯು ಪಡೆದ ಸಹಾಯಧನ ಮತ್ತು ಸಾಲವನ್ನು ಮಂಜೂರಾದ ಉದ್ದೇಶಕ್ಕೆ \nಉಪಯೋಗಿಸಿಕೊಳ್ಳಬೇಕು. ಒಂದು ಪಕ್ಷ ಸಾಲವನ್ನು ದುರುಪಯೋಗ ಮಾಡಿದರೆ ಹಾಗೂ ಸಾಲ \nಮಂಜೂರಾತಿಯ ನಿಯಮಗಳನ್ನು ಉಲ್ಲಂಘಿಸಿದ ಸಂದರ್ಭದಲ್ಲಿ ಪೂರ್ಣ ಸಾಲವನ್ನು ಒಂದೇ \nಇಡುಗಂಟಿನಲ್ಲಿ ವಸೂಲಿ ಮಾಡಲು ಕ್ರಮ ವಹಿಸಲಾಗುತ್ತದೆ."));
                pdfDoc.Add(OP.GenerateOrderParagraph("3.	ಫಲಾನುಭವಿಯ ಘಟಕದ ಮುಂದೆ “ಆರ್ಥಿಕ ನೆರವು, ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ \nಅಭಿವೃದ್ಧಿ ನಿಗಮ ನಿಯಮಿತ, ಬೆಂಗಳೂರು” ಎಂದು ಬರೆಯಿಸಿ ಹಾಕಬೇಕು."));
                pdfDoc.Add(OP.GenerateOrderParagraph("4.	ಸಾಲದಿಂದ ಉತ್ಪನ್ನವಾದ ಘಟಕಗಳಿಗೆ ಫಲಾನುಭವಿಯು ವಿಮೆಯನ್ನು ಪಾವತಿಸಿ ವಿಮೆಗೆ \nಒಳಪಡಿಸಬೇಕು."));
                pdfDoc.Add(LAD.GenerateLoanInfo("1","2","80000","34","2000","500","2500"));
                pdfDoc.Add(new Paragraph(new Chunk("\n", FontFactory.GetFont("sans-serif", 5, iTextSharp.text.Font.BOLD, BaseColor.BLACK))));
                pdfDoc.Add(OP.GenerateOrderParagraph("  ಪ್ರತಿ ಮಾಹೆಯ ಕಂತಾಗಿ ಆಯಾ ತಿಂಗಳ 10 ನೆಯ ದಿನಾಂಕದೊಳಗಾಗಿ ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ \nಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ) ಇವರಿಗೆ ಗೂಗಲ್‍ ಪ್ಲೇ ಸ್ಟೋರ್‍ ನಲ್ಲಿ ಲಭ್ಯವಿರುವ ಕೆ.ಎ.ಸಿ.ಡಿ.ಸಿ \nಮೊಬೈಲ್‍ ಆಪ್‍ ಅನ್ನು ಡೌನ್‍ಲೋಡ್‍ ಮಾಡಿ ಫಲಾನುಭವಿಯ ರಿಜಿಸ್ಟರ್‍ ಮೊಬೈಲ್‍ ನಂಬರ್‍ ಮೂಲಕ \nಲಾಗಿನ್‍ ಆಗಿ  ಗೂಗಲ್‍ ಪೇ / ಫೋನ್‍ ಪೇ ಬಳಸಿ ಮರುಪಾವತಿಸಬೇಕು. "));
                pdfDoc.Add(OP.GenerateOrderParagraph("  *ನಿಗಧಿತ ಕಂತಿನಂತೆ ಮರಪಾವತಿಯನ್ನು ನಿಗಮದ ನಿಗಧಿತ ಕಾಲಕ್ಕೆ ಮಾಡದಿದ್ದರೆ ಬಾಕಿಯಾಗುವ \nಸಾಲಕ್ಕೆ ಹೆಚ್ಚುವರಿಯಾಗಿ ಬಡ್ಡಿಯನ್ನು ವಿಧಿಸಲಾಗುವುದು.*"));
                pdfDoc.Add(OP.GenerateOrderParagraph("  (ಇದು ಸ್ವಯಂ ರಚಿಸಲಾದ (Auto Generated) ಮಂಜೂರಾತಿ ಆದೇಶವಾಗಿರುವುದರಿಂದ ನಿಗಮದ \nಸಹಾಯಕ ಪ್ರಧಾನ ವ್ಯವಸ್ಥಾಪಕರ ಸಹಿಯ ಅವಶ್ಯಕತೆ ಇರುವುದಿಲ್ಲ.)"));



                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                //Response.Clear();

                SaveFile SV = new SaveFile();
                SV.SavingFileOnServer(Server.MapPath("~/DownloadFiles/"), "Test"+ ".pdf", bytes);
                //if (File.Exists(Server.MapPath("~/Files_SelfEmployment/Application/" + ODSE.FinancialYear + "/") + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf"))
                //{
                //    //SendSMSEmail();
                //}
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "Test" + ".pdf");
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }

            //GIC.GenerateImgCell(10, "ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ)", 15f, Color.Brown);
        }
    }
}