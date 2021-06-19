using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Process
{
    public class LOGOImageCell
    {
        public  PdfPCell ImageCell(string path, float scale, int align, iTextSharp.text.BaseColor CellBorderColer)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = CellBorderColer;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 2f;
            return cell;
        }
    }
}