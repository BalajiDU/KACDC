using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Process
{
    public class AgreementTable
    {
        PDFLanCell LAN = new PDFLanCell();
        AgreeCell AGC = new AgreeCell();
        PDFCellPrint PCell = new PDFCellPrint();
        SetTableSize TS = new SetTableSize();

        public PdfPTable GenerateAgreementTable(PdfPTable Table, string SelfEnglish, string SelfKannada, string AadhaarEnglish, string AadhaarKannada, string ShareEnglish, string ShareKannada)
        {
            Table = TS.SetSize(Table);


            int VCenter = PdfPCell.ALIGN_MIDDLE;
            int Left = PdfPCell.ALIGN_LEFT;

            PdfPCell EmptyCell = new PdfPCell();
            EmptyCell = PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK, 20f, Left, VCenter);


            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(AGC.AGCell(SelfEnglish, SelfKannada));
            Table.AddCell(AGC.AGCell(AadhaarEnglish, AadhaarKannada));
            Table.AddCell(AGC.AGCell(ShareEnglish, ShareKannada));

            return Table;
        }
    }
}