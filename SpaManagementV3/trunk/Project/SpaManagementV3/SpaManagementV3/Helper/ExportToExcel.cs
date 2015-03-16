using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SpaCommon;
using System.Windows.Forms;
using System.IO;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.TextBased.Csv;
using Telerik.Windows.Documents.Spreadsheet.Model;

using System.Drawing.Printing;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;



namespace SpaManagementV3.Helper
{
    public class ExportToExcel
    {
        private static string GetTemplatePath()
        {
            string res = Application.StartupPath + "\\Template";
            if (!Directory.Exists(res))
            {
                Directory.CreateDirectory(res);
            }

            return res;
        }

        public static string GetBillPath()
        {
            string res = Application.StartupPath + "\\Bills";
            if (!Directory.Exists(res))
            {
                Directory.CreateDirectory(res);
            }
            return res;
        }

        public static bool ExportToExcel_PrintBill1(List<InvoiceData> data, int billNumber, out string textBill)
        {
            bool res = false;
            textBill = "";
            XlsxFormatProvider formatProvider = new XlsxFormatProvider();
            Workbook workbook = null;
            string templateFile = string.Format("{0}\\BillTemplate.xlsx", GetTemplatePath());
            using (FileStream file = File.Open(templateFile, FileMode.Open))
            {
                try
                {
                    workbook = formatProvider.Import(file);
                    Worksheet worksheet = workbook.Worksheets[0];

                    for (int j = 0; j < data.Count; j++)
                    {
                        if (data[j].Data != null)
                        {
                            CellIndex index = new CellIndex(data[j].X, data[j].Y);
                           // ICellValue cellValue = worksheet.Cells[index].GetValue().Value;

                            string value = worksheet.Cells[index].GetValue().Value.RawValue + " " + data[j].Data;
                            worksheet.Cells[index].SetValue(value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageHandler.Error(ex.Message);
                }
            }

            if (workbook != null)
            {
                try
                {
                    string fileName = string.Format("{0}\\Bill_{1}.xlsx", GetBillPath(), billNumber);
                    using (FileStream file = new FileStream(fileName, FileMode.Create))
                    {
                        formatProvider.Export(workbook, file);
                    }
                }
                catch(Exception ex)
                {

                }
                

            }
            return res;
        }

        public static bool ExportToExcel_PrintBill(List<InvoiceData> data, string billNumber, bool isCash, bool isCredit, out string textBill)
        {
            bool res = false;
            string fileName = string.Format("{0}\\Bill_{1}.xls", GetBillPath(), billNumber);
            //   SaveFileDialog f = new SaveFileDialog();
            //   f.Filter = "Excel file (*.xls)|*.xls";
            //   if (f.ShowDialog() == DialogResult.OK)
            {
                object missValue = System.Reflection.Missing.Value;
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Open(GetTemplatePath() + "\\BillTemplate.xlsx", 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                for (int j = 0; j < data.Count; j++)
                {
                    if (data[j].Data != null)
                    {
                        exSheet.get_Range(data[j].Cell).FormulaR1C1 += " " + data[j].Data;
                    }
                }

                exSheet.get_Range("H25").FormulaR1C1 = isCredit.ToString(); // khach tra bang the visa
                exSheet.get_Range("H26").FormulaR1C1 = isCash.ToString(); // khach tra bang tien mat

                //   exSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA5;
                //   exSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

                //save file

                bool IsSaved = false;
                exBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                exBook.PrintOutEx(missValue, missValue, 2, missValue, missValue, missValue, missValue, missValue, missValue);

                textBill = "";
                bool isCopySuccess = false;
                for (int j = 0; j < 3; j++)
                {
                    try
                    {
                        exSheet.get_Range("A1", "H24").Copy();
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                    }
                    // exSheet.get_Range("A1", "H28").Select();


                    IDataObject iData = Clipboard.GetDataObject();
                    // Is Data Text?
                    if (iData.GetDataPresent(DataFormats.Text))
                    {
                        string cf_html = (string)iData.GetData(DataFormats.Html, true);
                        // .NET 4.5 started with version 4.0.30319.17929
                        if (Environment.Version.CompareTo(new System.Version("4.0.30319.17929")) >= 0)
                        {
                            // .NET 4.5+
                            // do nothing, it's OK
                        }
                        else
                        {
                            // .NET 4.0-
                            cf_html = Encoding.UTF8.GetString(Encoding.Default.GetBytes(cf_html));
                        }
                        textBill = cf_html;
                        isCopySuccess = true;
                    }
                    else
                    {
                        textBill = "Data not found.";
                    }

                    int index = textBill.IndexOf("<html");
                    if (index > -1)
                    {
                        textBill = textBill.Substring(index - 1);
                    }
                    if (isCopySuccess == true)
                    {
                        exSheet.Application.CutCopyMode = (Excel.XlCutCopyMode)0;
                        Clipboard.Clear();
                        break;
                    }
                }


                exBook.Close(true, missValue, missValue);
                exApp.Quit();
                IsSaved = true;
                // release cac doi tuong COM
                ReleaseObject(exSheet);
                ReleaseObject(exBook);
                ReleaseObject(exApp);

                //if (IsSaved)
                //{
                //    var m = MessageBox.Show("Sucessful!\r\n Open file ?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                //    if (m == System.Windows.Forms.DialogResult.Yes)
                //    {
                //        Process.Start(f.FileName);
                //    }
                //}
            }
            return res;
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw new Exception("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
      
    }
}
