using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF.PDFModuleProcess.ZMBankPDF
{
    public class PDFParagraph
    {
        public PdfPCell PrintCell(string Text, string FontName, int size, int TextStyle, BaseColor TextColor, float MinCellHeight, int HAlign, int VAlign)
        {
            PdfPCell cell;
            cell = new PdfPCell(new Phrase(new Chunk(Text, FontFactory.GetFont(FontName, size, TextStyle, TextColor))));
            cell.MinimumHeight = MinCellHeight;
            cell.VerticalAlignment = VAlign;
            cell.HorizontalAlignment = HAlign;
            cell.BorderColor = BaseColor.WHITE;
            cell.PaddingTop = 15f;
            cell.PaddingBottom = 15f;
            return cell;
        }
        public Paragraph ToAddressBlock(string BankName,string BankBranch,string BankCity, string FontName, int size, int TextStyle, BaseColor TextColor,  int HAlign, int VAlign)
        {
            
            Phrase TOPhrase = new Phrase();
            TOPhrase.Add(new Chunk("To,\n", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            TOPhrase.Add(new Chunk("The Cheif Manager,\n", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            TOPhrase.Add(new Chunk(BankName + ",\n", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            TOPhrase.Add(new Chunk(BankBranch + ",\n", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            TOPhrase.Add(new Chunk(BankCity + ",\n", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));

            Paragraph ToParagraph = new Paragraph();
            ToParagraph.Add(TOPhrase);
            ToParagraph.IndentationLeft = 50;
            ToParagraph.SpacingAfter = 10f;
            return ToParagraph;
        }
        
        public Paragraph SingleLineParagraph(string Text, string FontName, int size, int TextStyle, BaseColor TextColor, int HAlign, int VAlign)
        {
            Phrase TOPhrase = new Phrase();
            TOPhrase.Add(new Chunk(Text, FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            
            Paragraph ToParagraph = new Paragraph();
            ToParagraph.Add(TOPhrase);
            ToParagraph.IndentationLeft = 50;
            ToParagraph.IndentationRight = 50;
            ToParagraph.Alignment = HAlign;
            ToParagraph.SpacingAfter = 8f;
            return ToParagraph;
        }

        public Paragraph MainBlock(string ChequeNumber, string Amount, string BeneficiaryCount,string AccountNumber, string FontName, int size, int TextStyle, BaseColor TextColor, int HAlign, int VAlign)
        {
            Phrase MainPhrase1 = new Phrase();
            Phrase MainPhrase2 = new Phrase();
            MainPhrase1.Add(new Chunk("     We are enclosing here with a crossed cheque bearing No ", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            MainPhrase1.Add(new Chunk(ChequeNumber + ", ", FontFactory.GetFont(FontName, size, iTextSharp.text.Font.BOLD, TextColor)));
            MainPhrase1.Add(new Chunk(" for Rs ", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            MainPhrase1.Add(new Chunk(Amount + ", ", FontFactory.GetFont(FontName, size, iTextSharp.text.Font.BOLD, TextColor)));
            MainPhrase1.Add(new Chunk(" along with the list of ", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            MainPhrase1.Add(new Chunk(BeneficiaryCount , FontFactory.GetFont(FontName, size, iTextSharp.text.Font.BOLD, TextColor)));
            if(Int32.Parse(BeneficiaryCount)==1)
                MainPhrase1.Add(new Chunk(" beneficiary ", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            else
                MainPhrase1.Add(new Chunk(" beneficiaries ", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));


            MainPhrase2.Add(new Chunk("\n", FontFactory.GetFont(FontName, size, iTextSharp.text.Font.BOLD, TextColor)));
            MainPhrase2.Add(new Chunk("     We are request you to transferthe amount to the beneficiaries SB accounts as mentioned in the list enclosed to this letter through RTGS/NEFT transfer by debeting the amount to our SB Account Number: ", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            MainPhrase2.Add(new Chunk(AccountNumber, FontFactory.GetFont(FontName, size, iTextSharp.text.Font.BOLD, TextColor)));
            MainPhrase2.Add(new Chunk("Assistant General Manager K.A.C.D.C Kalaburgi Division and inform to this office in case of non transfer / failure to trasfer the amount to the ", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));

            if (Int32.Parse(BeneficiaryCount) == 1)
                MainPhrase2.Add(new Chunk(" beneficiary ", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            else
                MainPhrase2.Add(new Chunk(" beneficiaries ", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            MainPhrase2.Add(new Chunk(" account, the amount to be recredited to the our SB account of the Assistant General Manager.", FontFactory.GetFont(FontName, size, TextStyle, TextColor)));
            MainPhrase2.Add(new Chunk("\n\n", FontFactory.GetFont(FontName, size, iTextSharp.text.Font.BOLD, TextColor)));
            //MainPhrase2.Add(new Chunk("Thank You", FontFactory.GetFont(FontName, size, iTextSharp.text.Font.BOLD, TextColor)));
            //MainPhrase2.Add(new Chunk("Thank You", FontFactory.GetFont(FontName, size, iTextSharp.text.Font.BOLD, TextColor)));




            Paragraph MainParagraph1 = new Paragraph();
            MainParagraph1.Add(MainPhrase1);
            MainParagraph1.Add(MainPhrase2);
            MainParagraph1.IndentationLeft = 50;
            MainParagraph1.IndentationRight = 45;

            
            MainParagraph1.SetLeading(1, 2);
            MainParagraph1.Alignment= Element.ALIGN_JUSTIFIED;
            return MainParagraph1;
        }
    }
}