using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Process
{
    public class BankTable
    {
        PDFLanCell LAN = new PDFLanCell();
        PDFCellPrint PCell = new PDFCellPrint();
        PDFHeaderCell HCell = new PDFHeaderCell();
        SetTableSize TS = new SetTableSize();

        public PdfPTable GenerateBankTable(PdfPTable Table)
        {
            Table = TS.SetSize(Table);


            int Center = PdfPCell.ALIGN_CENTER;
            int VCenter = PdfPCell.ALIGN_MIDDLE;
            int Left = PdfPCell.ALIGN_LEFT;

            PdfPCell EmptyCell = new PdfPCell();
            EmptyCell = PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter);


            Table.AddCell(EmptyCell);
            PdfPCell BankCell = new PdfPCell(HCell.PrintHeaderCell("Bank Details".ToUpper(), "sans-serif", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
            BankCell.Colspan = 2;
            Table.AddCell(BankCell);
            Table.AddCell(EmptyCell);

            Table.AddCell(LAN.GenerateCell("Account Holder Name", 12, "ಖಾತೆದಾರರ ಹೆಸರು", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("A/C Number", 12, "ಖಾತೆ ಸಂಖ್ಯೆ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            Table.AddCell(LAN.GenerateCell("Bank", 12, "ಬ್ಯಾಂಕ್", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("Branch", 12, "ಶಾಖೆ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            Table.AddCell(LAN.GenerateCell("IFSC Code", 12, "ಐಎಫ್‌ಎಸ್‌ಸಿ ಕೋಡ್", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("Address", 12, "ವಿಳಾಸ", 20f));
            Table.AddCell(PCell.PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            return Table;
        }
    }
}