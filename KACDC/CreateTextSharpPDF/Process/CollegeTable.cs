using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Process
{
    public class CollegeTable
    {
        PDFLanCell LAN = new PDFLanCell();
        PDFCellPrint PCell = new PDFCellPrint();
        PDFHeaderCell HCell = new PDFHeaderCell();
        SetTableSize TS = new SetTableSize();
        public PdfPTable GenerateCollegeTable(PdfPTable Table, string CETAdmissionTicketNumber = "", string CETApplicationNumber = "", string CollegeName = "", string CollegeAddress = "", string Course = "", string Year = "", 
            string PreviousYearMarks = "", string RequiredLoanAmount = "")
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

            Table.AddCell(LAN.GenerateCell("CET AdmissionTicket Number", 12, "ಸಿಇಟಿ ಪ್ರವೇಶ ಪತ್ರ ಸಂಖ್ಯೆ", 20f));
            Table.AddCell(PCell.PrintCell(CETAdmissionTicketNumber, "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("CET Application Number", 12, "ಸಿಇಟಿ ಅರ್ಜಿ ಸಂಖ್ಯೆ", 20f));
            Table.AddCell(PCell.PrintCell(CETApplicationNumber, "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            Table.AddCell(LAN.GenerateCell("College Name", 12, "ಕಾಲೇಜಿನ ಹೆಸರು", 20f));
            Table.AddCell(PCell.PrintCell(CollegeName, "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("College Address", 12, "ಕಾಲೇಜಿನ ವಿಳಾಸ", 20f));
            Table.AddCell(PCell.PrintCell(CollegeAddress, "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            Table.AddCell(LAN.GenerateCell("Course", 12, "ಕೋರ್ಸ್", 20f));
            Table.AddCell(PCell.PrintCell(Course, "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("Year", 12, "ವರ್ಷ", 20f));
            Table.AddCell(PCell.PrintCell(Year, "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            Table.AddCell(LAN.GenerateCell("Marks Obtained in Previous Year", 12, "ಹಿಂದಿನ ವರ್ಷದಲ್ಲಿ ಪಡೆದ ಅಂಕಗಳು", 20f));
            Table.AddCell(PCell.PrintCell(PreviousYearMarks, "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(LAN.GenerateCell("Required Loan Amount", 12, "ಅಗತ್ಯವಿರುವ ಸಾಲದ ಮೊತ್ತ", 20f));
            Table.AddCell(PCell.PrintCell(RequiredLoanAmount, "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

            return Table;
        }

    }
}