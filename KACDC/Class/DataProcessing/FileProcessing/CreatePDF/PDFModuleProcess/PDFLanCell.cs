using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.CreateTextSharpPDF.Process;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF
{
    public class PDFLanCell
    {
        TextToImage TTI = new TextToImage();
        public PdfPCell GenerateCell(string Englisg, int fontSize, string Kannada, float scale, string FontName = BaseFont.TIMES_ROMAN)
        {
            BaseFont bf = BaseFont.CreateFont(FontName, BaseFont.CP1252, false);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, fontSize, iTextSharp.text.Font.NORMAL);
            PdfPCell cell = new PdfPCell();
            Paragraph p = new Paragraph();
            p.SpacingAfter = 0f;
            p.Leading = 10f;
            p.Add(new Phrase(Englisg, FontFactory.GetFont(FontName, fontSize, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            cell.AddElement(p);
            iTextSharp.text.Image KannadaImage = TTI.ConvertTextToImage(Kannada, "sans-serif", 10, Color.White, Color.Black);
            KannadaImage.ScalePercent(scale);
            cell.AddElement(KannadaImage);
            cell.BorderColor = BaseColor.WHITE;
            return cell;

        }
    }
}