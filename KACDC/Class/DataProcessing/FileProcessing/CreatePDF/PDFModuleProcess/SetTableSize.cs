using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.CreateTextSharpPDF.Process
{
    public class SetTableSize
    {
        public PdfPTable SetSize(PdfPTable Table)
        {
            Table.TotalWidth = 550f;
            Table.LockedWidth = true;
            Table.SetWidths(new float[] { 0.3f, 0.4f, 0.3f, 0.4f });
            return Table;
        }
    }
}