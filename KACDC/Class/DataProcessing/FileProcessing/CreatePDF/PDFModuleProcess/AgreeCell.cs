using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Process
{
    public class AgreeCell
    {
        PDFLanCell LAN = new PDFLanCell();

        public PdfPCell AGCell(string English,string Kannada)
        {
            PdfPCell Declaration = new PdfPCell(LAN.GenerateCell(English, 8, Kannada, 15f, BaseFont.COURIER));
            Declaration.Colspan = 4;
            return Declaration;
        }
    }
}