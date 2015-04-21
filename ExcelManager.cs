using System;
// using Microsoft.Office.Interop.Excel;
using Excel;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;

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
                message.Students students = new message.Students();
                // for (int i = 1; i <= columnCount; ++i)
                {
                    range = (Range)sheet.Cells[1, 2];
                    int index = 0;
                    if(range.Text.ToString().Contains("考生姓名"))
                    {
                        for (int j = 2; j <= rowCount; ++j)
                        {
                            message.StudentInfo studentInfo = new message.StudentInfo();
                            range = (Range)sheet.Cells[j, 2];
                            studentInfo.name = range.Value2;
                            index++;
                            students.student.Add(studentInfo);
                        }
                    }
                }
                for(int i = 0; i < students.student.Count; ++i)
                {
                    Console.WriteLine("{0}", students.student[i].name);
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
