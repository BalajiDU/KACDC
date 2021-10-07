using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF.PDFReports
{
    public class OrderTableParagraph
    {
        public PdfPTable GenerateOrderParagraph(string Text,float PaddingTop=3f)
        {
            PdfPTable HeadingTable = null;
            HeadingTable = new PdfPTable(1);
            Phrase phrase = null;
            //Create Header Table
            HeadingTable.TotalWidth = 550f;
            HeadingTable.LockedWidth = true;
            HeadingTable.SetWidths(new float[] { 0.6f });
            OrderHeader(HeadingTable, phrase, Text, PaddingTop);
            return HeadingTable;
        }
        private Paragraph OrderHeader(PdfPTable table, Phrase phrase, string Text,float PaddingTop)
        {
            Paragraph p = new Paragraph();
            table.AddCell(NameAddr(Text, 25f, System.Drawing.Color.Black, PaddingTop));
            return p; 
        }
        private static PdfPCell NameAddr(string Text, float KanFontSize, System.Drawing.Color TextColor,float PaddingTop)
        {
            PdfImgConvert GIC = new PdfImgConvert();
            PdfPCell cell = null;
            BaseColor color = new BaseColor(123, 0, 0);
            Phrase KaPhrase = new Phrase();
            cell = new PdfPCell(GIC.GenerateImgCell(15, Text, KanFontSize, TextColor));
            cell.BorderWidth = .5f;
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cell.PaddingTop = PaddingTop;
            cell.PaddingBottom = 3f;
            return cell;
        }
    }
}