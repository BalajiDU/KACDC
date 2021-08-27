using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.CreateTextSharpPDF;
using KACDC.CreateTextSharpPDF.Process;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;

namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF.ArivuRenewalAcknoledgement
{
    public class GenerateRenewalAcknolegdement
    {
        PDFCellPrint PCell = new PDFCellPrint();
        PDFHeaderCell HCell = new PDFHeaderCell();
        PDFLanCell LAN = new PDFLanCell();
        TextToImage TTI = new TextToImage();
        MultiLineText MLT = new MultiLineText();
        LOGOImageCell LOGO = new LOGOImageCell();
        SetTableSize TS = new SetTableSize();

        public PdfPTable ApplicantMainTable(PdfPTable Table, string ApplicationNumber , string ApplicantName ,string MobileNumber,string Installment)
        {

            Table = SetSize(Table);
            int Center = PdfPCell.ALIGN_CENTER;
            int VCenter = PdfPCell.ALIGN_MIDDLE;
            int Left = PdfPCell.ALIGN_LEFT;



            PdfPCell EmptyCell = new PdfPCell();
            EmptyCell = PCell.PrintCell("", "sans-serif", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter);

            //Todo
            //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));
            PdfPCell cellWithRowspan = new PdfPCell(LOGO.ImageCell("~/Image/KACDC_PDF.png", 30f, PdfPCell.ALIGN_CENTER, BaseColor.BLACK));

            //System.Drawing.Image imageBIt = ConvertTextToImage("ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ<br />ABCjhk", "Arial", 12, Color.Yellow, Color.Black);
            //iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageBIt, System.Drawing.Imaging.ImageFormat.Jpeg);
            //pdfImage.ScaleToFit( 0.3f, 0.4f, 0.3f, 0.4f );

            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);

            //Row 2
            Table.AddCell(EmptyCell);
            PdfPCell cell = new PdfPCell(HCell.PrintHeaderCell("RENEWAL DETAILS".ToUpper(), "sans-serif", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
            cell.Colspan = 2;
            Table.AddCell(cell);
            Table.AddCell(EmptyCell);


            //Row 1
            PdfPCell cell1 = new PdfPCell(PCell.PrintCell("Application Number", "sans-serif", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            cell1.Colspan = 2;
            Table.AddCell(cell1);
            PdfPCell cell1_1 = new PdfPCell(PCell.PrintCell(ApplicationNumber, "sans-serif", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            cell1_1.Colspan = 2;
            Table.AddCell(cell1_1);

            //Row 2
            PdfPCell cell2 = new PdfPCell(PCell.PrintCell("Application Number", "sans-serif", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            cell2.Colspan = 2;
            Table.AddCell(cell2);
            PdfPCell cell2_1 = new PdfPCell(PCell.PrintCell(ApplicantName.ToUpper(), "sans-serif", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            cell2_1.Colspan = 2;
            Table.AddCell(cell2_1);

            //Row 3
            PdfPCell cell3 = new PdfPCell(PCell.PrintCell("Mobile Number", "sans-serif", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            cell3.Colspan = 2;
            Table.AddCell(cell3);
            PdfPCell cell3_1 = new PdfPCell(PCell.PrintCell(MobileNumber, "sans-serif", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            cell3_1.Colspan = 2;
            Table.AddCell(cell3_1);


            //Row 4
            PdfPCell cell4 = new PdfPCell(PCell.PrintCell("Requesting Instalment", "sans-serif", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            cell4.Colspan = 2;
            Table.AddCell(cell4);
            PdfPCell cell4_1 = new PdfPCell(PCell.PrintCell(Installment.ToUpper(), "sans-serif", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            cell4_1.Colspan = 2;
            Table.AddCell(cell4_1);

           

            return Table;
        }
        public PdfPTable SetSize(PdfPTable Table)
        {
            Table.TotalWidth = 400f;
            Table.LockedWidth = true;
            Table.SetWidths(new float[] { 0.2f, 0.3f, 0.3f, 0.2f });
            return Table;
        }
        public PdfPCell GenerateCell(string Englisg, int fontSize, string FontName = BaseFont.TIMES_ROMAN)
        {
            BaseFont bf = BaseFont.CreateFont(FontName, BaseFont.CP1252, false);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, fontSize, iTextSharp.text.Font.NORMAL);
            PdfPCell cell = new PdfPCell();
            Paragraph p = new Paragraph();
            p.SpacingAfter = 0f;
            p.Leading = 10f;
            p.Add(new Phrase(Englisg, FontFactory.GetFont(FontName, fontSize, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            cell.AddElement(p);
            cell.BorderColor = BaseColor.WHITE;
            return cell;

        }
    }
}