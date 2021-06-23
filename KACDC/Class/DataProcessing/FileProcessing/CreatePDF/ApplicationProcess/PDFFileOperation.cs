using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.Class.FileSaving;
using KACDC.CreateTextSharpPDF;
using KACDC.CreateTextSharpPDF.Process;

namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF.ApplicationProcess
{
    public class PDFFileOperation
    {
        PDFCellPrint PCell = new PDFCellPrint();
        PDFHeaderCell HCell = new PDFHeaderCell();
        PDFLanCell LAN = new PDFLanCell();
        TextToImage TTI = new TextToImage();
        MultiLineText MLT = new MultiLineText();
        LOGOImageCell LOGO = new LOGOImageCell();
        SetTableSize TS = new SetTableSize();

        public PdfPTable ExportToPDF(DataSet dataset, string FilePath, string District, string ReportType = "")
        {
            PdfPTable Table = null;
            Table = new PdfPTable(4);
            Table = TS.SetSize(Table);
            int Center = PdfPCell.ALIGN_CENTER;
            int VCenter = PdfPCell.ALIGN_MIDDLE;
            int Left = PdfPCell.ALIGN_LEFT;

            PdfPCell EmptyCell = new PdfPCell();
            EmptyCell = PCell.PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter);

            //Todo
            //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));
            PdfPCell cellWithRowspan = new PdfPCell(LOGO.ImageCell("~/Image/KACDC_PDF.png", 30f, PdfPCell.ALIGN_CENTER, BaseColor.BLACK));

            //System.Drawing.Image imageBIt = ConvertTextToImage("ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ<br />ABCjhk", "Arial", 10, Color.Yellow, Color.Black);
            //iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageBIt, System.Drawing.Imaging.ImageFormat.Jpeg);
            //pdfImage.ScaleToFit( 0.3f, 0.4f, 0.3f, 0.4f );

            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);
            Table.AddCell(EmptyCell);

            //Row 2
            Table.AddCell(EmptyCell);
            PdfPCell cell = new PdfPCell(HCell.PrintHeaderCell("Applicant Details".ToUpper(), "sans-serif", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Center, VCenter));
            Table.AddCell(PCell.PrintCell("fxghfg\ndfgddfgdfgsfgsdf", "sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("fxghfg", "sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("fxghfg", "sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("fxghfg", "sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            Table.AddCell(PCell.PrintCell("fxghfg\n\n\n", "sans-serif", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK, 20f, Left, VCenter));
            
            cell.Colspan = 2;
            Table.AddCell(cell);
            Table.AddCell(EmptyCell);



            return Table;
        }
        public PdfPTable ZMBankTable(DataTable BankDataTable,string TotalFund)
        {
            PdfPTable BankTable = new PdfPTable(BankDataTable.Columns.Count);
            BankTable.WidthPercentage = 95f ;
            //BankTable.AddCell(new PdfPCell(new Phrase(BankDataTable.TableName.ToUpper())) { Colspan = BankDataTable.Columns.Count });
            PdfPCell c1 = new PdfPCell(new Phrase(new Chunk(BankDataTable.TableName.ToUpper(), FontFactory.GetFont("sans-serif", 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))) { Colspan = BankDataTable.Columns.Count };
            c1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            c1.BorderColor = BaseColor.WHITE;
            BankTable.AddCell(c1);
            //BankTable.AddCell(PhraseCell((BankDataTable.TableName.ToUpper()), PdfPCell.ALIGN_CENTER, BaseColor.WHITE,14));

            for (int i = 0; i < BankDataTable.Columns.Count; i++)
            {
                string cellText = BankDataTable.Columns[i].ColumnName;
                PdfPCell cell = new PdfPCell();
                cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                //cell.Phrase = new Phrase(cellText, new Font(Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(grdStudent.HeaderStyle.ForeColor)));  
                //cell.BackgroundColor = new BaseColor(grdStudent.HeaderStyle.BackColor);  
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingBottom = 5;
                BankTable.AddCell(cell);
            }

            //writing table Data  
            for (int i = 0; i < BankDataTable.Rows.Count; i++)
            {
                for (int j = 0; j < BankDataTable.Columns.Count; j++)
                {
                    if(j==0)
                        BankTable.AddCell(PhraseCell(((i + 1).ToString()), PdfPCell.ALIGN_CENTER, BaseColor.BLACK));
                    //BankTable.AddCell((i+1).ToString());
                    //BankTable.AddCell(PhraseCell(new Chunk((i + 1).ToString(), PdfPCell.ALIGN_CENTER));
                    else
                        BankTable.AddCell(PhraseCell(BankDataTable.Rows[i][j].ToString(), PdfPCell.ALIGN_CENTER, BaseColor.BLACK));
                }
            }
            BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("TOTAL", FontFactory.GetFont("sans-serif", 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))) { Colspan = BankDataTable.Columns.Count - 1, HorizontalAlignment= PdfPCell.ALIGN_CENTER });
            BankTable.AddCell(new PdfPCell(new Phrase(new Chunk(TotalFund, FontFactory.GetFont("sans-serif", 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))) { HorizontalAlignment= PdfPCell.ALIGN_CENTER });
            //BankTable.AddCell(new PdfPCell(new Phrase(TotalFund)) );
            BankTable.PaddingTop = 10;
            return BankTable;
        }
        private static PdfPCell PhraseCell(string  PhraseText, int align, BaseColor BorderColor, int FontType = iTextSharp.text.Font.NORMAL,float FontSize=12, string FontName= "sans-serif")
        {
            Phrase phrase = new Phrase();
            phrase.Add(new Chunk(PhraseText, FontFactory.GetFont(FontName, FontSize, FontType, BaseColor.BLACK)));
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BorderColor;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            
            return cell;
        }
    }
}