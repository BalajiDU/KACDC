using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.CreateTextSharpPDF.Process;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF.PDFReports
{
    public class PdfImgConvert
    {
        TextToImage TTI = new TextToImage();
        public iTextSharp.text.Image GenerateImgCell(int fontSize, string Kannada, float scale,Color TextColor , string FontName = BaseFont.TIMES_ROMAN )
        {
            BaseFont bf = BaseFont.CreateFont(FontName, BaseFont.CP1252, false);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, fontSize, iTextSharp.text.Font.NORMAL);
            PdfPCell cell = new PdfPCell();
            BaseColor color1 = new BaseColor(255, 255, 255, 0);
            //Paragraph p = new Paragraph();
            //p.SpacingAfter = 0f;
            //p.Leading = 10f;
            //p.Add(new Phrase(Englisg, FontFactory.GetFont(FontName, fontSize, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            //cell.AddElement(p);
            //iTextSharp.text.Image KannadaImage = TTI.ConvertTextToImage(Kannada, "sans-serif", fontSize, Color.White, TextColor);
            iTextSharp.text.Image KannadaImage = TTI.ConvertTextToImage(Kannada, FontFactory.GetFont("sans-serif", 8, iTextSharp.text.Font.BOLDITALIC, BaseColor.BLACK).ToString(), fontSize, Color.FromArgb(1, 255, 255, 255), TextColor);
            //new Chunk("\n", FontFactory.GetFont("sans-serif", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK))
            KannadaImage.ScalePercent(scale);
            cell.AddElement(KannadaImage);
            cell.BorderColor = color1;
            return KannadaImage;

        }
    }
}