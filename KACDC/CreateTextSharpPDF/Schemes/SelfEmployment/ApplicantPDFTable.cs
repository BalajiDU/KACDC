using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.CreateTextSharpPDF.Process;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Schemes.SelfEmployment
{
    public class ApplicantPDFTable
    {
        PDFCellPrint PCell = new PDFCellPrint();
        PDFHeaderCell HCell = new PDFHeaderCell();
        PDFLanCell LAN = new PDFLanCell();
        TextToImage TTI = new TextToImage();
        MultiLineText MLT = new MultiLineText();
        LOGOImageCell LOGO = new LOGOImageCell();
        SetTableSize TS = new SetTableSize();

        StringBuilder TextArea1 { get; set; } = new StringBuilder();
        StringBuilder TextArea2 { get; set; } = new StringBuilder();
        public PdfPTable SEApplicantMainTable(PdfPTable Table)
        {
            
            Table = TS.SetSize(Table);
            int Center = PdfPCell.ALIGN_CENTER;
            int VCenter = PdfPCell.ALIGN_MIDDLE;
            int Left = PdfPCell.ALIGN_LEFT;

            

            PdfPCell EmptyCell = new PdfPCell();
            EmptyCell = PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter);

            //Todo
            //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));
            PdfPCell cellWithRowspan = new PdfPCell(LOGO.ImageCell("~/Image/KACDC_PDF.png", 30f, PdfPCell.ALIGN_CENTER, BaseColor.BLACK));

            //System.Drawing.Image imageBIt = ConvertTextToImage("ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ<br />ABCjhk", "Arial", 10, Color.Yellow, Color.Black);
            //iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageBIt, System.Drawing.Imaging.ImageFormat.Jpeg);
            //pdfImage.ScaleToFit( 0.3f, 0.4f, 0.3f, 0.4f );

            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);

            //Row 2
            Table.AddCell(EmptyCell);
            PdfPCell cell = new PdfPCell(HCell.PrintHeaderCell("Applicant Details".ToUpper(), "sans-serif", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
            cell.Colspan = 2;
            Table.AddCell(cell);
            Table.AddCell(EmptyCell);


            //Row 2
            Table.AddCell(LAN.GenerateCell("Application Number", 12, "ಅರ್ಜಿ ಸಂಖ್ಯೆ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXX XXXXXXXXXXXXXXXXX XXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 3
            Table.AddCell(LAN.GenerateCell("NAME", 12, "ಹೆಸರು", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            // Applicant Photo
            cellWithRowspan.Rowspan = 5;
            cellWithRowspan.BorderColor = BaseColor.WHITE;
            Table.AddCell(cellWithRowspan);

            //Row 4
            Table.AddCell(LAN.GenerateCell("Father / Guardian Name", 12, "ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 5
            Table.AddCell(LAN.GenerateCell("Gender", 12, "ಲಿಂಗ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 6
            Table.AddCell(LAN.GenerateCell("DOB", 12, "ಜನ್ಮ ದಿನಾಂಕ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 7
            Table.AddCell(LAN.GenerateCell("Emai ID", 12, "ಇ-ಮೇಲ್ ಐಡಿ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 8

            Table.AddCell(LAN.GenerateCell("Person With Disablities", 12, "ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("Anual Income", 12, "ವಾರ್ಷಿಕ ಆದಾಯ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 9

            Table.AddCell(LAN.GenerateCell("Purpose of Loan", 12, "ಸಾಲದ ಉದ್ದೇಶ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("Description of Loan", 12, "ಸಾಲದ ವಿವರಣೆ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 10
            Table.AddCell(LAN.GenerateCell("Mobile Number", 12, "ಮೊಬೈಲ್ ಸಂಖ್ಯೆ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("Alternate Mobile Number", 12, "ಪರ್ಯಾಯ ಮೊಬೈಲ್ ಸಂಖ್ಯೆ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));


            //Row 
            Table.AddCell(LAN.GenerateCell("RD Number", 12, "R D ಸಂಖ್ಯೆ", 20f));
            Table.AddCell(PCell.PrintCell("VERIFIED", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("Aadhar", 12, "ಆಧಾರ್", 20f));
            Table.AddCell(PCell.PrintCell("VERIFIED", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 10
            Table.AddCell(LAN.GenerateCell("Parmanent Address", 12, "ಶಾಶ್ವತ ವಿಳಾಸ", 20f));
            PdfPCell FullAddresscell;

            

        iTextSharp.text.Image FullAddressImage = TTI.ConvertTextToImage(MLT.GenerateMultiLineText(TextArea1,"ಅನವಾಲ , ಬಾದಾಮಿ, ಬಾಗಲಕೋಟ", 18), "sans-serif", 10, Color.White, Color.Black);
            FullAddressImage.ScalePercent(20f);


            FullAddresscell = new PdfPCell(FullAddressImage);
            FullAddresscell.VerticalAlignment = VCenter;
            FullAddresscell.HorizontalAlignment = Left;
            FullAddresscell.BorderColor = BaseColor.WHITE;

            Table.AddCell(FullAddresscell);


            Table.AddCell(LAN.GenerateCell("Contact Address", 12, "ಸಂಪರ್ಕ ವಿಳಾಸ", 20f));
            PdfPCell ContactAddresscell;

            //string Caddress = MLT.GenerateMultiLineText("ಮದು ಬಸವರಾಜ ಬಿಜಾಪುರ", 18);
            iTextSharp.text.Image ContactFullAddressImage = TTI.ConvertTextToImage((MLT.GenerateMultiLineText(TextArea2,"ಮದು ಬಸವರಾಜ ಬಿಜಾಪುರ", 18)), "sans-serif", 10, Color.White, Color.Black);
            ContactFullAddressImage.ScalePercent(20f);

            ContactAddresscell = new PdfPCell(ContactFullAddressImage);
            ContactAddresscell.VerticalAlignment = VCenter;
            ContactAddresscell.HorizontalAlignment = Left;
            ContactAddresscell.BorderColor = BaseColor.WHITE;

            Table.AddCell(ContactAddresscell);
            //Row 11
            Table.AddCell(LAN.GenerateCell("District", 12, "ಜಿಲ್ಲೆ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("District", 12, "ಜಿಲ್ಲೆ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 12
            Table.AddCell(LAN.GenerateCell("Taluk", 12, "ತಾಲ್ಲೂಕು", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("Taluk", 12, "ತಾಲ್ಲೂಕು", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 13
            Table.AddCell(LAN.GenerateCell("Pin code", 12, "ಪಿನ್ ಕೋಡ್", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("Pin code", 12, "ಪಿನ್ ಕೋಡ್", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //Row 13
            Table.AddCell(LAN.GenerateCell("Constituency", 12, "ಕ್ಷೇತ್ರ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);

           
            ////BankTable.AddCell(LAN.GenerateCell("Account Holder Name", 12, "ಖಾತೆದಾರರ ಹೆಸರು", 20f));
            ////BankTable.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            ////BankTable.AddCell(LAN.GenerateCell("A/C Number", 12, "ಖಾತೆ ಸಂಖ್ಯೆ", 20f));
            ////BankTable.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            //string abc = @"I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation, (Government of Karnataka Undertaking), to use my Aadhaar number for performing all such validations which may be, required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
            //PdfPCell BankDetailsHeade = new PdfPCell(PCell.PrintCell(abc, "Times New Roman", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, PdfPCell.ALIGN_JUSTIFIED, PdfPCell.ALIGN_JUSTIFIED));
            //BankDetailsHeade.Colspan = 4;
            ////BankTable.AddCell(BankDetailsHeade);



            //string SelfEnglish = "I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Arivu Education Loan. If any discrepancies are found later, I agree to take legal action against me.";
            //string SelfKannada = "\n ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು  ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು  ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣೀಕರಿಸುತ್ತೇನೆ.  ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ  ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು \n ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿಯ ಕ್ರಮ ಜರುಗಿಸಲು ಒಪ್ಪಿರುತ್ತೇನೆ.";
            //string AadhaarEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
            //string AadhaarKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";


            //PdfPCell SelfDeclaration = new PdfPCell(LAN.GenerateCell(SelfEnglish, 8, SelfKannada, 15f, BaseFont.COURIER));
            //SelfDeclaration.Colspan = 4;
            //BankTable.AddCell(SelfDeclaration);

            //PdfPCell AadhaarDeclaration = new PdfPCell(LAN.GenerateCell(AadhaarEnglish, 8, AadhaarKannada, 15f, BaseFont.COURIER));
            //AadhaarDeclaration.Colspan = 4;
            //BankTable.AddCell(AadhaarDeclaration);

            //PdfPCell EmptyHeader = new PdfPCell(PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
            //EmptyHeader.Colspan = 4;
            //BankTable.AddCell(EmptyHeader);

            //PdfPCell SignatureCell = new PdfPCell(LAN.GenerateCell("Signature", 15, "    ಸಹಿ", 25f));
            //BankTable.AddCell(EmptyCell);
            //BankTable.AddCell(EmptyCell);
            //BankTable.AddCell(EmptyCell);
            //BankTable.AddCell(SignatureCell);

            return Table;
        }
    }
}