using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF.PDFReports
{
    public class OrderTable
    {
        public PdfPTable GenerateOrderTable()
        {
            PdfPTable HeadingTable = null;
            HeadingTable = new PdfPTable(2);
            Phrase phrase = null;
            //Create Header Table
            HeadingTable.TotalWidth = 550f;
            HeadingTable.LockedWidth = true;
            HeadingTable.SetWidths(new float[] { 0.1f, 0.6f});
            OrderTableHeader(HeadingTable, phrase);
            return HeadingTable;
        }
        private PdfPTable OrderTableHeader(PdfPTable table, Phrase phrase)
        {
            PdfPCell Cell = new PdfPCell(NameAddr("ಸಾಲ ಮಂಜೂರಾತಿ ಆದೇಶ", 28f, System.Drawing.Color.Black));
            Cell.Colspan = 2;
            table.AddCell(Cell);
            table.AddCell(NameAddr("ವಿಷಯ", 25f, System.Drawing.Color.Black));
            table.AddCell(NameAddr("ಸ್ವಯಂ ಉದ್ಯೋಗ ನೇರ ಸಾಲ ಯೋಜನೆ ಅಡಿಯಲ್ಲಿ ಆಯ್ಕೆಯಾದ ಫಲಾನುಭವಿಗಳಿಗೆ\n ಮಂಜೂರಾತಿ ಆದೇಶ ನೀಡುವ ಬಗ್ಗೆ.", 23f, System.Drawing.Color.Black));
            table.AddCell(NameAddr("ಉಲ್ಲೇಖ", 25f, System.Drawing.Color.Black));
            table.AddCell(NameAddr("2020-21 ನೇ ಸಾಲಿನ ನಿಗಮದ ವಾರ್ಷಿಕ ಕ್ರಿಯಾ ಯೋಜನೆಯಲ್ಲಿನ ಸೂಚನೆಗಳು.", 25f, System.Drawing.Color.Black));

            return table;
        }
        private static PdfPCell NameAddr(string Text, float KanFontSize, System.Drawing.Color TextColor)
        {
            PdfImgConvert GIC = new PdfImgConvert();
            PdfPCell cell = null;
            BaseColor color = new BaseColor(123, 0, 0);
            Phrase KaPhrase = new Phrase();
            cell = new PdfPCell(GIC.GenerateImgCell(15, Text, KanFontSize, TextColor));
            cell.BorderWidth = 2f; cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            return cell;
        }
    }
}