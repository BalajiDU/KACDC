using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Process
{
    public class PDFCellPrint
    {
        public PdfPCell PrintCell(string Text, string FontName, int size, int TextStyle, BaseColor TextColor, float MinCellHeight, int HAlign, int VAlign)
        {
            PdfPCell cell;
            cell = new PdfPCell(new Phrase(new Chunk(UppercaseFirst(Text), FontFactory.GetFont(FontName, size, TextStyle, TextColor))));
            cell.MinimumHeight = MinCellHeight;
            cell.VerticalAlignment = VAlign;
            cell.HorizontalAlignment = HAlign;
            cell.BorderColor = BaseColor.WHITE;
            cell.PaddingTop = 15f;
            cell.PaddingBottom = 15f;
            return cell;
        }
        protected string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}