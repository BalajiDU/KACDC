using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF.PDFReports
{
    public class LoanAndApplicantDetails
    {
        public PdfPTable GenerateApplicantInfo(string Name, string ApplicationNumber, string LoanNumber, string LoanAmount, string LoanDate)
        {
            PdfPTable HeadingTable = null;
            HeadingTable = new PdfPTable(5);
            Phrase phrase = null;
            //Create Header Table
            HeadingTable.TotalWidth = 550f;
            HeadingTable.LockedWidth = true;
            //HeadingTable.SetWidths(new float[] { 0.6f });
            OrderHeader(HeadingTable, phrase,  Name,  ApplicationNumber,  LoanNumber,  LoanAmount,  LoanDate);
            return HeadingTable;
        }
        private Paragraph OrderHeader(PdfPTable table, Phrase phrase, string Name,string ApplicationNumber,string LoanNumber,string LoanAmount,string LoanDate)
        {
            Paragraph p = new Paragraph();
            table.AddCell(NameAddr("ಫಲಾನುಭವಿಯ \n  ಹೆಸರು", 24f, System.Drawing.Color.Black));
            table.AddCell(NameAddr("ಫಲಾನುಭವಿಯ \n ಅರ್ಜಿ ಸಂಖ್ಯೆ", 24f, System.Drawing.Color.Black));
            table.AddCell(NameAddr("ಸಾಲದ ಐ.ಡಿ \n  ಸಂಖ್ಯೆ", 24f, System.Drawing.Color.Black));
            table.AddCell(NameAddr("ಒಟ್ಟು ಸಾಲ ಮತ್ತು\nಸಹಾಯಧನ ಮೊತ್ತ", 22f, System.Drawing.Color.Black));
            table.AddCell(NameAddr("ಸಾಲ ಬಿಡುಗಡೆ \nಮಾಡಿದ ದಿನಾಂಕ", 24f, System.Drawing.Color.Black));
            table.AddCell(DetailsEngCell(Name));
            table.AddCell(DetailsEngCell(ApplicationNumber));
            table.AddCell(DetailsEngCell(LoanNumber));
            table.AddCell(DetailsEngCell(LoanAmount));
            table.AddCell(DetailsEngCell(LoanDate));
            return p;
        }
        private static PdfPCell NameAddr(string Text, float KanFontSize, System.Drawing.Color TextColor)
        {
            PdfImgConvert GIC = new PdfImgConvert();
            PdfPCell cell = null;
            BaseColor color = new BaseColor(123, 0, 0);
            Phrase KaPhrase = new Phrase();
            cell = new PdfPCell(GIC.GenerateImgCell(15, Text, KanFontSize, TextColor));
            cell.BorderWidth = 1f;
            cell.BorderColor = BaseColor.BLACK;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.PaddingTop = 5f;
            cell.PaddingBottom = 5f;
            return cell;
        }
        private static PdfPCell DetailsEngCell(string Text)
        {
            Paragraph Paragraph = new Paragraph(new Chunk(Text, FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            PdfPCell cell = null;
            cell = new PdfPCell(Paragraph);
            cell.BorderWidth = 1f;
            cell.BorderColor = BaseColor.BLACK;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.PaddingTop = 5f;
            cell.PaddingBottom = 5f;
            return cell;
        }
        public PdfPTable GenerateLoanInfo(string SlNo, string Moratorium, string LoanAmount, string Instalments, string Principle, string Intrest, string Total)
        {
            PdfPTable HeadingTable = null;
            HeadingTable = new PdfPTable(7);
            Phrase phrase = null;
            //Create Header Table
            HeadingTable.TotalWidth = 550f;
            HeadingTable.LockedWidth = true;
            HeadingTable.SetWidths(new float[] { 0.1f, 0.1f, 0.1f, 0.15f, 0.1f, 0.15f, 0.1f });
            LoanInfoOrderHeader(HeadingTable, phrase, SlNo, Moratorium, LoanAmount, Instalments,  Principle,  Intrest,  Total);
            return HeadingTable;
        }
        private Paragraph LoanInfoOrderHeader(PdfPTable table, Phrase phrase, string SlNo, string Moratorium, string LoanAmount, string Instalments, string Principle, string Intrest, string Total)
        {
            Paragraph p = new Paragraph();
            PdfPCell cell = new PdfPCell();
            cell = NameAddr("ಕ್ರ.ಸಂ", 26f, System.Drawing.Color.Black);
            cell.Rowspan = 2;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            table.AddCell(cell);
            cell = NameAddr("ವಿರಾಮ \nಅವಧಿ\n(ತಿಂಗಳು)", 26f, System.Drawing.Color.Black);
            cell.Rowspan = 2;
            table.AddCell(cell);
            cell = NameAddr("ಸಾಲದ \nಮೊತ್ತ", 26f, System.Drawing.Color.Black);
            cell.Rowspan = 2;
            table.AddCell(cell);
            cell = NameAddr("ನಿಗಧಿಪಡಿಸಿರುವ \nಕಂತುಗಳು", 26f, System.Drawing.Color.Black);
            cell.Rowspan = 2;
            table.AddCell(cell);

            cell = NameAddr("ಪ್ರತಿ ಕಂತಿನ ಮೊತ್ತ", 26f, System.Drawing.Color.Black);
            cell.Colspan = 3;
            table.AddCell(cell);

            table.AddCell(NameAddr("ಅಸಲು", 26f, System.Drawing.Color.Black));
            table.AddCell(NameAddr("ಬಡ್ಡಿ\n(ವಾರ್ಷಿಕ ಶೇ. 4)", 26f, System.Drawing.Color.Black));
            table.AddCell(NameAddr("ಒಟ್ಟು \nಮೊತ್ತ", 26f, System.Drawing.Color.Black));

            table.AddCell(DetailsEngCell(SlNo));
            table.AddCell(DetailsEngCell(Moratorium));
            table.AddCell(DetailsEngCell(LoanAmount));
            table.AddCell(DetailsEngCell(Instalments));
            table.AddCell(DetailsEngCell(Principle));
            table.AddCell(DetailsEngCell(Intrest));
            table.AddCell(DetailsEngCell(Total));
            return p;
        }
    }
}