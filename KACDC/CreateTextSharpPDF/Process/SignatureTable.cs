using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Process
{
    public class SignatureTable
    {
        PDFLanCell LAN = new PDFLanCell();
        PDFCellPrint PCell = new PDFCellPrint();

        int VCenter = PdfPCell.ALIGN_MIDDLE;
        int Left = PdfPCell.ALIGN_LEFT;

        public PdfPTable GenerateSignatureTable(PdfPTable Table)
        {
            Table = new PdfPTable(4);
            Table.TotalWidth = 550f;
            Table.LockedWidth = true;
            Table.SetWidths(new float[] { 0.3f, 0.4f, 0.3f, 0.4f });

            PdfPCell EmptyCell = new PdfPCell();
            EmptyCell = PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK, 20f, Left, VCenter);

            PdfPCell SignatureCell = new PdfPCell(LAN.GenerateCell("Signature", 15, "    ಸಹಿ", 25f));
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(SignatureCell);
            return Table;
        }
    }
}