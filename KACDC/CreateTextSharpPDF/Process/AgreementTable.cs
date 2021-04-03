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

        public PdfPTable GenerateAgreementTable(PdfPTable Table, string SelfEnglish, string SelfKannada, string AadhaarEnglish, string AadhaarKannada, string ShareEnglish, string ShareKannada)
        {
            Table = new PdfPTable(4);
            Table.TotalWidth = 550f;
            Table.LockedWidth = true;
            Table.SetWidths(new float[] { 0.3f, 0.4f, 0.3f, 0.4f });

            int VCenter = PdfPCell.ALIGN_MIDDLE;
            int Left = PdfPCell.ALIGN_LEFT;

            PdfPCell EmptyCell = new PdfPCell();
            EmptyCell = PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK, 20f, Left, VCenter);


            Table.AddCell(EmptyCell);
            Table.AddCell(AGC.AGCell(SelfEnglish, SelfKannada));
            Table.AddCell(AGC.AGCell(AadhaarEnglish, AadhaarKannada));
            Table.AddCell(AGC.AGCell(ShareEnglish, ShareKannada));

            return Table;
        }
    }
}