using KACDC.Class.FileSaving;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using KACDC.Class.Log;

namespace KACDC.Class.DataProcessing.FileProcessing
{
    public class ExcelFileOperations
    {
        DataLogging DL = new DataLogging();
        SaveFile SF = new SaveFile();
        string strPath = null;
        string Filename1 = string.Format(@"{0}.xlsx",Guid.NewGuid());
        public void ExportToExcel(DataSet dataset,string FilePath,string FileName,string number,string District,string ReportType="")
        {
            try
            {
                //SF.CheckDirExist(FilePath);
                //SF.IfFileExistDelete(FilePath, FileName);
                //Directory.GetAccessControl(FilePath+ FileName);
                DL.WriteErrorLog("Ex-File_Cre_Started", "Comp", FilePath+"__"+FileName, FileName, FilePath);

                int inHeaderLength = 2, inColumn = 0, inRow = 0;
                System.Reflection.Missing Default = System.Reflection.Missing.Value;
                //Create Excel File
                strPath += @"\Excel" + DateTime.Now.ToString().Replace(':', '-') + ".xlsx";
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);

                foreach (DataTable dtbl in dataset.Tables)
                {
                    //Create Excel WorkSheet
                    Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add(Default, excelWorkBook.Sheets[excelWorkBook.Sheets.Count], 1, Default);
                    excelWorkSheet.Name = dtbl.TableName.ToUpper();//Name worksheet

                    //Write Column Name
                    for (int i = 0; i < dtbl.Columns.Count + 1; i++)
                    {
                        if (i == 0)
                            excelWorkSheet.Cells[inHeaderLength + 1, i + 1] = "SL NO";
                        else
                            excelWorkSheet.Cells[inHeaderLength + 1, i + 1] = dtbl.Columns[i - 1].ColumnName.ToUpper();
                    }
                    //Write Rows
                    int ma = dtbl.Rows.Count;
                    int na = dtbl.Columns.Count + 2;
                    for (int m = 0; m < dtbl.Rows.Count; m++)
                    {
                        for (int n = 0; n < dtbl.Columns.Count + 1; n++)
                        {
                            inColumn = n + 1;
                            inRow = inHeaderLength + 2 + m;
                            if (n == 0)
                            {
                                excelWorkSheet.Cells[inRow, inColumn] = m + 1;
                            }
                            else
                            {
                                excelWorkSheet.Cells[inRow, inColumn] = dtbl.Rows[m].ItemArray[n - 1].ToString();
                                if (m % 2 == 0)
                                    excelWorkSheet.get_Range("A" + inRow.ToString(), ColumnIndexToColumnLetter(dtbl.Columns.Count + 1) + inRow.ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FCE4D6");

                                na = n;

                            }
                        }
                    }
                    //Excel Header
                    Excel.Range cellRang = excelWorkSheet.get_Range("A1", ColumnIndexToColumnLetter(dtbl.Columns.Count + 1) + "2");
                    cellRang.Merge(false);
                    cellRang.Interior.Color = System.Drawing.Color.White;
                    cellRang.Font.Color = System.Drawing.Color.Gray;
                    cellRang.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    cellRang.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    cellRang.Font.Size = 14;
                    excelWorkSheet.Cells[1, 1] = "Report of " + DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
                    //excelWorkSheet.Cells[60, 5] = "=SUM(E4,E59)";
                    //excelWorkSheet.Cells[dtbl.Rows.Count + 2, dtbl.Columns.Count].Formula = a;

                    if (ReportType == "ZM")
                    {
                        //Create Total
                        int r = dtbl.Rows.Count + 3;
                        excelWorkSheet.Cells[dtbl.Rows.Count + 4, dtbl.Columns.Count + 1] = "=SUM(" + ColumnIndexToColumnLetter(dtbl.Columns.Count + 1) + "4:" + ColumnIndexToColumnLetter(dtbl.Columns.Count + 1) + "" + (dtbl.Rows.Count + 3) + ")";
                        //excelWorkSheet.Cells[dtbl.Rows.Count + 4, dtbl.Columns.Count + 1] = "=SUM(BN4:BN" + (dtbl.Rows.Count + 3) + ")";
                        ((Excel.Range)excelWorkSheet.get_Range((dtbl.Rows.Count + 4) + ":" + dtbl.Columns.Count + 1)).Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    }

                    //Style table column names
                    cellRang = excelWorkSheet.get_Range("A3", ColumnIndexToColumnLetter(dtbl.Columns.Count + 1) + "3");
                    cellRang.Font.Bold = true;
                    cellRang.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    cellRang.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#ED7D31");
                    excelWorkSheet.get_Range("E4").EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //Formate price column
                    //excelWorkSheet.get_Range("F5").EntireColumn.NumberFormat = "0.00";
                    //Auto fit columns
                    excelWorkSheet.Columns.AutoFit();
                }
                //Delete First Page
                excelApp.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Worksheet lastWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkBook.Worksheets[1];
                lastWorkSheet.Delete();
                excelApp.DisplayAlerts = true;
                //DL.WriteErrorLog("Ex-File_Cre_DataStored", "Comp", FilePath + "__"+FileName, "ExFile", FilePath);

                //Set Defualt Page
                (excelWorkBook.Sheets[1] as Excel._Worksheet).Activate();

                //if (System.IO.File.Exists(FilePath))
                //{
                //    System.IO.File.Delete(FilePath);
                //}
                //DL.WriteErrorLog("Ex-File_Cre_ExistChecked", "Comp", FilePath + "__"+FileName, "ExFile", FilePath);

                excelWorkBook.SaveAs(ReportType + Filename1, Default, Default, Default, false, Default, Excel.XlSaveAsAccessMode.xlNoChange, Default, Default, Default, Default, Default);
                //DL.WriteErrorLog("Ex-File_Cre_Created", "Comp", "SYS", "ExFile", FilePath);

                excelWorkBook.Close();
                excelApp.Quit();
                //DL.WriteErrorLog("Ex-File_Cre_Closed", "Comp", FilePath + "__"+ FileName, "ExFile", FilePath);
            }catch(Exception ex)
            {
                DL.WriteErrorLog("Ex-File_Cre_Error___"+ ReportType, ex.ToString(), "\n"+ex.Message, "\n\n"+FilePath + "__"+ FileName, FilePath);

            }
        }
        static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }

    }
}