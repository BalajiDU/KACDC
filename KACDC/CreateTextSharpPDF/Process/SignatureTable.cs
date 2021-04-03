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
        SetTableSize TS = new SetTableSize();

        int VCenter = PdfPCell.ALIGN_MIDDLE;
        int Left = PdfPCell.ALIGN_LEFT;

        public PdfPTable GenerateSignatureTable(PdfPTable Table)
        {
            Table = TS.SetSize(Table);


            PdfPCell EmptyCell = new PdfPCell();
            EmptyCell = PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK, 20f, Left, VCenter);

            PdfPCell SignatureCell = new PdfPCell(LAN.GenerateCell("Signature", 15, "    ಸಹಿ", 25f));

            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);

            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);

            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);

            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);

            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(SignatureCell);
            return Table;
        }
    }
}