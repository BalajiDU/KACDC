using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF
{
    public class AddPDFWaterMark
    {
        public void PdfStampInExistingFile(string sourceFilePath,string watermarkImagePath)
        {
            byte[] bytes = File.ReadAllBytes(sourceFilePath);
            var img = iTextSharp.text.Image.GetInstance(watermarkImagePath);
            img.SetAbsolutePosition(100, 200);
            PdfContentByte waterMark;

            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);
                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {
                    int pages = reader.NumberOfPages;
                    for (int i = 1; i <= pages; i++)
                    {
                        PdfContentByte under = stamper.GetUnderContent(i);
                        iTextSharp.text.Rectangle pagesize = reader.GetPageSize(i);
                        float x = (pagesize.Left + pagesize.Right) / 2;
                        float y = (pagesize.Bottom + pagesize.Top) / 2;
                        PdfGState gs = new PdfGState();
                        gs.FillOpacity = 0.3f;
                        under.SaveState();
                        under.SetGState(gs);
                        under.SetRGBColorFill(200, 200, 0);

                        waterMark = stamper.GetUnderContent(i);
                        waterMark.AddImage(img);
                    }
                }
                bytes = stream.ToArray();
            }
            File.WriteAllBytes(sourceFilePath, bytes);
        }
    }
}