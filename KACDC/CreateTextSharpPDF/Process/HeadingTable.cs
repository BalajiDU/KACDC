using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Process
{
    public class HeadingTable
    {

        public PdfPTable GenerateHeading(PdfPTable Table, string LoanName,string AppDate)
        {
            Phrase phrase = null;
            //Create Header Table
            Table.TotalWidth = 550f;
            Table.LockedWidth = true;
            Table.SetWidths(new float[] { 0.2f, 0.3f, 0.3f, 0.2f });
            PageHeader(Table, phrase, LoanName,AppDate);
            return Table;
        }
        private PdfPTable PageHeader(PdfPTable table, Phrase phrase, string LoanType, string AppDate)
        {
            //DateTime.ParseExact(AppDate, "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //Convert.ToDateTime(AppDate, System.Globalization.CultureInfo.InvariantCulture);
            //DateTime.Now.ToString("MM/dd/yyyy hh:mm:sss:fffffff tt");
            //Convert.ToDateTime(AppDate, System.Globalization.CultureInfo.InvariantCulture).ToString("dd MMMM yyyy hh:mm tt");

            string FinancialYear = "";
            table.AddCell(AddLogo("~/Image/GOK_PDF.png", phrase, PdfPCell.ALIGN_LEFT)); //GOV Logo  
            PdfPCell nested = NameAddr(LoanType, FinancialYear, phrase, Convert.ToDateTime(AppDate, System.Globalization.CultureInfo.InvariantCulture).ToString("dd MMMM yyyy hh:mm tt"));
            nested.Colspan = 2;
            table.AddCell(nested);//Page Heading
            table.AddCell(AddLogo("~/Image/KACDC_PDF.png", phrase, PdfPCell.ALIGN_RIGHT));//KACDC Logo   
            return table;
        }
        private static PdfPCell AddLogo(string Path, Phrase phrase, int align)
        {
            LOGOImageCell LOGO = new LOGOImageCell();
            PdfPCell cell = new PdfPCell(phrase);
            cell = LOGO.ImageCell(Path, 30f, align, BaseColor.WHITE);
            return cell;
        }
        private static PdfPCell NameAddr(string LoanName, string FinancialYear, Phrase phrase, string Date)
        {
            //PdfPCell cell = null;
            //phrase = new Phrase();
            //Paragraph p1 = new Paragraph();
            //Paragraph p2 = new Paragraph();
            //Paragraph p3 = new Paragraph();


            //p1.Add(new Chunk("KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION\n", FontFactory.GetFont("sans-serif", 15, iTextSharp.text.Font.BOLD, BaseColor.RED)));
            //p2.Add(new Chunk(LoanName + " ( " + FinancialYear + " )" + "\n", FontFactory.GetFont("sans-serif", 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            ////phrase.Add(new Chunk("Year of: " + FinancialYear + "\n", FontFactory.GetFont("sans-serif", 12, Font.NORMAL, BaseColor.BLACK)));
            ////phrase.Add(new Chunk("District: " + District + "\n", FontFactory.GetFont("sans-serif", 12, Font.NORMAL, BaseColor.BLACK)));
            //p3.Add(new Chunk("Date: " + Date, FontFactory.GetFont("sans-serif", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            //p1.SpacingAfter = 50;
            //p2.SpacingAfter = 50;
            //p3.SpacingAfter = 50;
            //phrase.Add(p1);
            //phrase.Add(p2);
            //phrase.Add(p3);
            //cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            //cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            PdfPCell cell = null;
            phrase = new Phrase();
            BaseColor color = new BaseColor(123, 0, 0);
            phrase.Add(new Chunk("KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION\n", FontFactory.GetFont("sans-serif", 15, iTextSharp.text.Font.BOLD, color)));
            phrase.Add(new Chunk("\n", FontFactory.GetFont("sans-serif", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            phrase.Add(new Chunk(LoanName.ToUpper() + " ( " + FinancialYear + " )" + "\n", FontFactory.GetFont("sans-serif", 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            phrase.Add(new Chunk("\n", FontFactory.GetFont("sans-serif", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            //phrase.Add(new Chunk("Year of: " + FinancialYear + "\n", FontFactory.GetFont("sans-serif", 12, Font.NORMAL, BaseColor.BLACK)));
            //phrase.Add(new Chunk("District: " + District + "\n", FontFactory.GetFont("sans-serif", 12, Font.NORMAL, BaseColor.BLACK)));
            phrase.Add(new Chunk("Date: " + Date, FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            return cell;
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
    }
}