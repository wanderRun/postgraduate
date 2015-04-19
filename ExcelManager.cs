using System;
// using Microsoft.Office.Interop.Excel;
using Excel;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;

namespace Server
{
    class ExcelManager
    {
        private Application excel = new Application();
        
        private int ExcelInstalled()
        {
            int ret = 0;
            RegistryKey rkOffice = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Office\11.0\Common\InstallRoot\");
            RegistryKey rkWps = Registry.CurrentUser.OpenSubKey(@"Software\Kingsoft\Office\6.0\common\");
            string file = null;
            if(rkOffice != null)
            {
                file = rkOffice.GetValue("Path").ToString();
                if(File.Exists(file + "Excel.exe"))
                {
                    ret += 1;
                }
            }
            else if(rkWps != null)
            {
                file = rkWps.GetValue("InstallRoot").ToString();
                if(File.Exists(file + @"\office6\et.exe"))
                {
                    ret += 2;
                }
            }
            return ret;
        }

        public void Load(string name)
        {
            int ret = this.ExcelInstalled();
            if((ret & 1) != 0)
            {
                this.LoadExcel(name);
            }
            else if((ret & 2) != 0)
            {
                this.LoadWPSExcel(name);
            }
        }

        private void LoadExcel(string name)
        {
            try
            {
                Workbook book = excel.Workbooks.Open(name);
                Worksheet sheet = book.Worksheets.Item[1];
                int count = book.Worksheets.Count;
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(sheet);
                GC.Collect();
                Console.WriteLine("load office");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }

        private void LoadWPSExcel(string name)
        {
            try
            {
                Workbook book = excel.Workbooks.Open(name);
                Worksheet sheet = book.Worksheets.Item[1];
                Range range = null;
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                int rowCount = sheet.UsedRange.Rows.Count;
                int columnCount = sheet.UsedRange.Columns.Count;
                for (int i = 1; i <= rowCount; ++i)
                {
                    for(int j = 1; j <= columnCount; ++j)
                    {
                        range = (Range)sheet.Cells[i, j];
                    }
                }
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(sheet);
                GC.Collect();
                Console.WriteLine("load wps");
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }
    }
}
