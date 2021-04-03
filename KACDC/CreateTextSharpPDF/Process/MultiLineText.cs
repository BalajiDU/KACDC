using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace KACDC.CreateTextSharpPDF
{
    public class MultiLineText
    {
        //public StringBuilder TextArea { get; set; } = new StringBuilder();
        public string GenerateMultiLineText(StringBuilder TextArea ,string value, int length)
        {
            if (value.Length <= length && value.Length != 0)
            {

                TextArea.Append($"{value.PadRight(length)}");
            }
            else
            {
                TextArea.Append($"{value.Substring(0, length).ToString()}".PadLeft(length) + "\r\n");
                value = value.Substring(length, (value.Length) - (length));
                GenerateMultiLineText(TextArea,value, length);
            }
            return TextArea.ToString();
        }
    }
}