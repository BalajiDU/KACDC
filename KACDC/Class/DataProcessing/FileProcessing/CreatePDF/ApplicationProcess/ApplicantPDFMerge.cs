using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.FileProcessing.CreatePDF.ApplicationProcess
{
    public class ApplicantPDFMerge
    {
        public void PDFMerge(string[] sourceFiles,string destinationFileName,string destinationFilePath)
        {
            string destinationFile = destinationFilePath +"/"+ destinationFileName;
            if (System.IO.File.Exists(destinationFile))
                System.IO.File.Delete(destinationFile);

            List<PdfReader> pdfReaderList = new List<PdfReader>();
            foreach (string filePath in sourceFiles)
            {
                PdfReader pdfReader = new PdfReader(filePath);
                pdfReaderList.Add(pdfReader);
            }
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Response.Buffer = true;
            Document document = new Document(PageSize.A4, 0, 0, 0, 0);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create));
            document.Open();
            foreach (PdfReader reader in pdfReaderList)
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    document.Add(iTextSharp.text.Image.GetInstance(page));
                }
            }
            document.Close();
            Byte[] FileBuffer = File.ReadAllBytes(destinationFile);
            if (FileBuffer != null)
            {
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-length", FileBuffer.Length.ToString());
                //Response.BinaryWrite(FileBuffer);
            }

        }
    }
}