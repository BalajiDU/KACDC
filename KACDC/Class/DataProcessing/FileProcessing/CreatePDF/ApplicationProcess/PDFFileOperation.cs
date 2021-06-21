using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.Class.FileSaving;
using KACDC.CreateTextSharpPDF;
using KACDC.CreateTextSharpPDF.Process;

namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF.ApplicationProcess
{
    public class PDFFileOperation
    {
        PDFCellPrint PCell = new PDFCellPrint();
        PDFHeaderCell HCell = new PDFHeaderCell();
        PDFLanCell LAN = new PDFLanCell();
        TextToImage TTI = new TextToImage();
        MultiLineText MLT = new MultiLineText();
        LOGOImageCell LOGO = new LOGOImageCell();
        SetTableSize TS = new SetTableSize();

        public PdfPTable ExportToPDF(DataSet dataset, string FilePath, string District, string ReportType = "")
        {
            PdfPTable Table = null;
            Table = new PdfPTable(4);
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
            PdfPCell cell = new PdfPCell(HCell.PrintHeaderCell("Applicant Details".ToUpper(), "sans-serif", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Center, VCenter));
            Table.AddCell(PCell.PrintCell("fxghfg\ndfgddfgdfgsfgsdf", "sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("fxghfg", "sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("fxghfg", "sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("fxghfg", "sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("fxghfg\n\n\n", "sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            
            cell.Colspan = 2;
            Table.AddCell(cell);
            Table.AddCell(EmptyCell);



            return Table;
        }
    }
}