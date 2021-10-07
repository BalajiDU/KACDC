using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.CreateTextSharpPDF.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF.PDFReports
{
    public class HeadingKanTable
    {
        public PdfPTable GenerateHeading(string ZoneName)
        {
            PdfPTable HeadingTable = null;
            HeadingTable = new PdfPTable(3);
            Phrase phrase = null;
            //Create Header Table
            HeadingTable.TotalWidth = 550f;
            HeadingTable.LockedWidth = true;
            HeadingTable.SetWidths(new float[] { 0.1f, 0.6f, 0.1f });
            PageHeader(HeadingTable, phrase, ZoneName);
            return HeadingTable;
        }
        private PdfPTable PageHeader(PdfPTable table, Phrase phrase, string ZoneName)
        {
            //DateTime.ParseExact(AppDate, "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //Convert.ToDateTime(AppDate, System.Globalization.CultureInfo.InvariantCulture);
            //DateTime.Now.ToString("MM/dd/yyyy hh:mm:sss:fffffff tt");
            //Convert.ToDateTime(AppDate, System.Globalization.CultureInfo.InvariantCulture).ToString("dd MMMM yyyy hh:mm tt");

            table.AddCell(AddLogo("~/Image/GOK_PDF.png", phrase, PdfPCell.ALIGN_TOP)); //GOV Logo  
            table.AddCell(NameAddr("ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ)", 30f, System.Drawing.Color.Brown));

            //table.AddCell(NameAddr2("ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ)", FontFactory.GetFont("Verdana", 16, iTextSharp.text.Font.BOLD, new BaseColor(125, 88, 15))));

            //table.AddCell(Cell);//Page Heading
            //Cell = NameAddr("(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ)", 20f, System.Drawing.Color.Black);
            //table.AddCell(Cell);//Page Heading
            table.AddCell(AddLogo("~/Image/KACDC_PDF.png", phrase, PdfPCell.ALIGN_RIGHT));//KACDC Logo  
            table.AddCell(NameAddr("(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ)", 23f, System.Drawing.Color.Black));
            table.AddCell(NameAddr("\nಸಹಾಯಕ ಪ್ರಧಾನ ವ್ಯವಸ್ಥಾಪಕರ ಕಛೇರಿ "+ ZoneName + " ವಿಭಾಗ", 25f, System.Drawing.Color.Black));

            return table;
        }
        private static PdfPCell AddLogo(string Path, Phrase phrase, int align)
        {
            LOGOImageCell LOGO = new LOGOImageCell();
            PdfPCell cell = new PdfPCell(phrase);
            cell = LOGO.ImageCell(Path, 28f, align, BaseColor.WHITE);
            cell.Rowspan = 3;
            return cell;
        }
        private static PdfPCell NameAddr(string Text, float KanFontSize, System.Drawing.Color TextColor)
        {
            PdfImgConvert GIC = new PdfImgConvert();
            PdfPCell cell = null;
            BaseColor color = new BaseColor(123, 0, 0);
            Phrase KaPhrase = new Phrase();
            cell = new PdfPCell(GIC.GenerateImgCell(15, Text, KanFontSize, TextColor));
            cell.BorderWidth = 2f;cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            return cell;
        }
        private static PdfPCell NameAddr2(string Text, Font font)
        {
            PdfImgConvert GIC = new PdfImgConvert();
            PdfPCell cell = null;
            BaseColor color = new BaseColor(123, 0, 0);
            Phrase KaPhrase = new Phrase();
            cell = new PdfPCell(GIC.GenerateImgCell(15, Text, 23f, System.Drawing.Color.Black));
            cell.BorderWidth = 2f;cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            return cell;
        }
        private static PdfPCell NameAddr1(string LoanName, string FinancialYear, Phrase phrase, string Date)
        {
            PdfImgConvert GIC = new PdfImgConvert();
            PdfPCell cell = null;
            phrase = new Phrase();
            BaseColor color = new BaseColor(123, 0, 0);
          

            Phrase KaPhrase= new Phrase();
            KaPhrase.Add(new Chunk(GIC.GenerateImgCell(15, "ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ)", 30f, System.Drawing.Color.Brown),0,0));
            //KaPhrase.Add(new Chunk("\n", FontFactory.GetFont("sans-serif", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            //KaPhrase.Add(new Chunk(GIC.GenerateImgCell(15, "(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ)", 12f, System.Drawing.Color.Black),0,0));
            //KaPhrase.Add(new Chunk("\n", FontFactory.GetFont("sans-serif", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            //KaPhrase.Add(new Chunk(GIC.GenerateImgCell(15, "ವಿಭಾಗದ ಸಹಾಯಕ ಪ್ರಧಾನ ವ್ಯವಸ್ಥಾಪಕರ ಕಛೇರಿ", 15f, System.Drawing.Color.Black),0,0));

            //cell = PhraseCell(KaPhrase, PdfPCell.ALIGN_CENTER);
            //cell = GIC.GenerateImgCell(15, "ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ)", 30f, System.Drawing.Color.Brown);
            cell = new PdfPCell(KaPhrase);
            //cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            //cell.BorderWidth = 2f;cell.BorderColor = BaseColor.BLACK;
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