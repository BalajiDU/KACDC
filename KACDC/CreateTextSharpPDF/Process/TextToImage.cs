using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Process
{
    public class TextToImage
    {
        public iTextSharp.text.Image ConvertTextToImage(string text, string fontname, int fontsize, Color bgcolor, Color fcolor)
        {
            text = text.Replace("<br />", "\n").Replace("<br/>", "\n");
            Bitmap bitmap = new Bitmap(1, 1);
            System.Drawing.Font font11 = new System.Drawing.Font("Arial", 50, FontStyle.Regular, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = (int)graphics.MeasureString(text, font11).Width;
            int height = (int)graphics.MeasureString(text, font11).Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(bgcolor);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font11, new SolidBrush(fcolor), 0, 0);
            graphics.Flush();
            graphics.Dispose();
            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
            return pdfImage;
        }
        public iTextSharp.text.Image ConvertTextToImageAddress(string text, string fontname, int fontsize, Color bgcolor, Color fcolor)
        {
            text = text.Replace("<br />", "\n").Replace("<br/>", "\n");
            Bitmap bitmap = new Bitmap(1, 1);
            System.Drawing.Font font11 = new System.Drawing.Font("Arial", 50, FontStyle.Regular, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = (int)graphics.MeasureString(text, font11).Width;
            int height = (int)graphics.MeasureString(text, font11).Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(bgcolor);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font11, new SolidBrush(fcolor), 0, 0);
            graphics.Flush();
            graphics.Dispose();
            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
            return pdfImage;
        }
    }
}