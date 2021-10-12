using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.Class.DataProcessing.FileProcessing.CreatePDF;
using KACDC.Class.DataProcessing.FileProcessing.CreatePDF.PDFReports;
using KACDC.Class.FileSaving;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess
{
    public class GenerateSanctionCopy
    {
        public void CreateSanctionCopy(string ApplicantName, string ApplicationNumber, string LOANNUMBER, string LoanAmount, string ReleaseDate, string SlNo, string Moratorium, string Repayable, string Months, string Principle, string Intrest, string INSTALMENT, string FilePath, string FileName, string WaterMarkImg)
        {
            PdfImgConvert GIC = new PdfImgConvert();
            HeadingKanTable Heading = new HeadingKanTable();
            OrderTable OT = new OrderTable();
            OrderTableParagraph OP = new OrderTableParagraph();
            LoanAndApplicantDetails LAD = new LoanAndApplicantDetails();
            SaveFile SV = new SaveFile();
            AddPDFWaterMark WM = new AddPDFWaterMark();
            //PdfPTable HeadingTable = null;
            //HeadingTable = new PdfPTable(4);
            //HeadingTable = Heading.GenerateHeading(HeadingTable, "Self Employment Loan", (Convert.ToDateTime(ODSE.ApplicationDateTime)).ToString("MM/dd/yyyy hh:mm:sss tt"));

            Document pdfDoc = new Document(PageSize.A4, 0, 0, 20, 0);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                pdfDoc.Add(Heading.GenerateHeading("ಕರ್ನಾಟಕ"));
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1.0F, 95.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));
                //p.setSpacingBefore = 20f;
                pdfDoc.Add(p);

                //pdfDoc.Add(Table);
                //pdfDoc.Add(BankTable);
                //pdfDoc.Add(AgreeTable);
                //pdfDoc.Add(SignatureTable);
                pdfDoc.Add(new PdfPCell(GIC.GenerateImgCell(10, "ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ)", 15f, Color.Brown)));
                pdfDoc.Add(OT.GenerateOrderTable());
                //pdfDoc.Add(new Paragraph(new Chunk("\n")));
                pdfDoc.Add(OP.GenerateOrderParagraph("  ಮೇಲ್ಕಂಡ ಉಲ್ಲೇಖದಲ್ಲಿ 2020-21 ನೇ ಸಾಲಿನಲ್ಲಿ ಕೆಲವು ಸೂಚನೆಗಳನ್ನು ಒಳಗೊಂಡಂತೆ \nನಿಗಮದ ವಾರ್ಷಿಕ ಕ್ರಿಯಾ ಯೋಜನೆಯನ್ನು ರೂಪಿಸಲಾಗಿರುತ್ತದೆ. ಈ ಸಂಬಂಧ ಸ್ವಯಂ ಉದ್ಯೋಗ \nನೇರ ಸಾಲ ಯೋಜನೆಯಲ್ಲಿ ಸಾಲವನ್ನು ಮಂಜೂರು ಮಾಡಿ ಆರ್‍.ಟಿ.ಜಿ.ಎಸ್ ಮೂಲಕ \nಆಯ್ಕೆಯಾದ ಫಲಾನುಭವಿಗಳಿಗೆ ಸಾಲ ಬಿಡುಗಡೆ ಮಾಡಲಾಗಿದೆ.", 10f));
                pdfDoc.Add(new Paragraph(new Chunk("\n", FontFactory.GetFont("sans-serif", 5, iTextSharp.text.Font.BOLD, BaseColor.BLACK))));
                pdfDoc.Add(LAD.GenerateApplicantInfo(ApplicantName, ApplicationNumber, LOANNUMBER, LoanAmount, ReleaseDate));
                pdfDoc.Add(new Paragraph(new Chunk("\n", FontFactory.GetFont("sans-serif", 5, iTextSharp.text.Font.BOLD, BaseColor.BLACK))));
                pdfDoc.Add(OP.GenerateOrderParagraph("  ಅರ್ಜಿದಾರರಿಗೆ ಕೆಳಗೆ ತಿಳಿಸಿರುವ ನಿಬಂಧನೆಗಳು ಮತ್ತು ಸಾಲ ಮಂಜೂರಾತಿಯ ಕೆಲವು ಷರತ್ತುಗಳಿಗೆ \nಒಳಪಟ್ಟು ಸಾಲ ಮಂಜೂರಾತಿ ನೀಡಿದೆ."));
                pdfDoc.Add(OP.GenerateOrderParagraph("1.	ಫಲಾನುಭವಿಯು ನಿಗಮದಿಂದ ಪಡೆದ ಸಾಲದ ಮೊತ್ತದಿಂದ ಅಗತ್ಯವಿರುವ ಆಧುನಿಕ \nಉಪಕರಣಗಳನ್ನು ಕೊಂಡು ಘಟಕವನ್ನು ಸ್ಥಾಪಿಸಿ ನಡೆಸಬೇಕು. ಈ ರೀತಿ ಘಟಕವನ್ನು ಸ್ಥಾಪಿಸಿರುವ \nಬಗ್ಗೆ ಜಿಲ್ಲಾ ವ್ಯವಸ್ಥಾಪಕರು ಪರಿಶೀಲನೆ ಮಾಡಿ ದೃಢೀಕರಿಸಬೇಕು. ಫಲಾನುಭವಿಯು ಘಟಕ \nಸ್ಥಾಪಿಸದಿದ್ದಲ್ಲಿ, ಸಾಲದ ಮೊತ್ತವನ್ನು ಕಡ್ಡಾಯವಾಗಿ ಒಂದೇ ಇಡುಗಂಟಿನಲ್ಲಿ ಬಡ್ಡಿ ಸಮೇತ\n ಪಾವತಿಸಬೇಕಾಗಿರುತ್ತದೆ."));
                pdfDoc.Add(OP.GenerateOrderParagraph("2.	ಫಲಾನುಭವಿಯು ಪಡೆದ ಸಹಾಯಧನ ಮತ್ತು ಸಾಲವನ್ನು ಮಂಜೂರಾದ ಉದ್ದೇಶಕ್ಕೆ \nಉಪಯೋಗಿಸಿಕೊಳ್ಳಬೇಕು. ಒಂದು ಪಕ್ಷ ಸಾಲವನ್ನು ದುರುಪಯೋಗ ಮಾಡಿದರೆ ಹಾಗೂ ಸಾಲ \nಮಂಜೂರಾತಿಯ ನಿಯಮಗಳನ್ನು ಉಲ್ಲಂಘಿಸಿದ ಸಂದರ್ಭದಲ್ಲಿ ಪೂರ್ಣ ಸಾಲವನ್ನು ಒಂದೇ \nಇಡುಗಂಟಿನಲ್ಲಿ ವಸೂಲಿ ಮಾಡಲು ಕ್ರಮ ವಹಿಸಲಾಗುತ್ತದೆ."));
                pdfDoc.Add(OP.GenerateOrderParagraph("3.	ಫಲಾನುಭವಿಯ ಘಟಕದ ಮುಂದೆ “ಆರ್ಥಿಕ ನೆರವು, ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ \nಅಭಿವೃದ್ಧಿ ನಿಗಮ ನಿಯಮಿತ, ಬೆಂಗಳೂರು” ಎಂದು ಬರೆಯಿಸಿ ಹಾಕಬೇಕು."));
                pdfDoc.Add(OP.GenerateOrderParagraph("4.	ಸಾಲದಿಂದ ಉತ್ಪನ್ನವಾದ ಘಟಕಗಳಿಗೆ ಫಲಾನುಭವಿಯು ವಿಮೆಯನ್ನು ಪಾವತಿಸಿ ವಿಮೆಗೆ \nಒಳಪಡಿಸಬೇಕು."));
                pdfDoc.Add(LAD.GenerateLoanInfo(SlNo, Moratorium, Repayable, Months, Principle, Intrest, INSTALMENT));
                pdfDoc.Add(new Paragraph(new Chunk("\n", FontFactory.GetFont("sans-serif", 5, iTextSharp.text.Font.BOLD, BaseColor.BLACK))));
                pdfDoc.Add(OP.GenerateOrderParagraph("  ಪ್ರತಿ ಮಾಹೆಯ ಕಂತಾಗಿ ಆಯಾ ತಿಂಗಳ 10 ನೆಯ ದಿನಾಂಕದೊಳಗಾಗಿ ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ \nಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ) ಇವರಿಗೆ ಗೂಗಲ್‍ ಪ್ಲೇ ಸ್ಟೋರ್‍ ನಲ್ಲಿ ಲಭ್ಯವಿರುವ ಕೆ.ಎ.ಸಿ.ಡಿ.ಸಿ \nಮೊಬೈಲ್‍ ಆಪ್‍ ಅನ್ನು ಡೌನ್‍ಲೋಡ್‍ ಮಾಡಿ ಫಲಾನುಭವಿಯ ರಿಜಿಸ್ಟರ್‍ ಮೊಬೈಲ್‍ ನಂಬರ್‍ ಮೂಲಕ \nಲಾಗಿನ್‍ ಆಗಿ  ಗೂಗಲ್‍ ಪೇ / ಫೋನ್‍ ಪೇ ಬಳಸಿ ಮರುಪಾವತಿಸಬೇಕು. "));
                pdfDoc.Add(OP.GenerateOrderParagraph("  *ನಿಗಧಿತ ಕಂತಿನಂತೆ ಮರಪಾವತಿಯನ್ನು ನಿಗಮದ ನಿಗಧಿತ ಕಾಲಕ್ಕೆ ಮಾಡದಿದ್ದರೆ ಬಾಕಿಯಾಗುವ \nಸಾಲಕ್ಕೆ ಹೆಚ್ಚುವರಿಯಾಗಿ ಬಡ್ಡಿಯನ್ನು ವಿಧಿಸಲಾಗುವುದು.*"));
                pdfDoc.Add(OP.GenerateOrderParagraph("  (ಇದು ಸ್ವಯಂ ರಚಿಸಲಾದ (Auto Generated) ಮಂಜೂರಾತಿ ಆದೇಶವಾಗಿರುವುದರಿಂದ ನಿಗಮದ \nಸಹಾಯಕ ಪ್ರಧಾನ ವ್ಯವಸ್ಥಾಪಕರ ಸಹಿಯ ಅವಶ್ಯಕತೆ ಇರುವುದಿಲ್ಲ.)"));



                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                //Response.Clear();


                SV.SavingFileOnServer(FilePath, FileName + ".pdf", bytes);
                //WM.PdfStampInExistingFileOver(FilePath + FileName + ".pdf", WaterMarkImg);

                //if (File.Exists(Server.MapPath("~/Files_SelfEmployment/Application/" + ODSE.FinancialYear + "/") + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf"))
                //{
                //    //SendSMSEmail();
                //}



                //Response.ContentEncoding = System.Text.Encoding.UTF8;
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + "Test" + ".pdf");
                ////Response.AddHeader("Content-Disposition", "attachment; filename=" + ODSE.GeneratedApplicationNumber + "_" + ADSER.Name + ".pdf");
                //Response.ContentType = "application/pdf";
                //Response.Buffer = true;
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.BinaryWrite(bytes);
                //Response.End();
                //Response.Close();
            }
        }
    }
}