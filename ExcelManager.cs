using System;
using Microsoft.Office.Interop.Excel;
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
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey rkOffice = rk.OpenSubKey(@"SOFTWARE\Microsoft\Office\11.0\Common\InstallRoot\");
            RegistryKey rkWps = rk.OpenSubKey(@"SOFTWARE\Kingsoft\Office\6.0\common\");
            string file = null;
            if(rkOffice != null)
            {
                file = rkOffice.GetValue("Path").ToString();
                if(File.Exists(file + "Excel.exe"))
                {
                    ret += 1;
                }
            }
            return ret;
        }

        public void LoadExcel(string name)
        {
            try
            {
                Workbook book = excel.Workbooks.Open(name);
                Worksheet sheet = book.Worksheets.Item[1];
                int count = book.Worksheets.Count;
                sheet.Name = "wang";
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(sheet);
                GC.Collect();
                Console.WriteLine("hell");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }

        public void LoadWPSExcel(string name)
        {
            try
            {
                Workbook book = excel.Workbooks.Open(name);
                Worksheet sheet = book.Worksheets.Item[1];
                int count = book.Worksheets.Count;
                sheet.Name = "wang";
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(sheet);
                GC.Collect();
                Console.WriteLine("hell");
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }
    }
}
