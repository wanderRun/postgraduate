using System;
using Microsoft.Office.Interop.Excel;
//using Excel;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;

namespace Server
{
    class ExcelManager
    {
        private Application excel = new Application();
        private message.Students students = new message.Students();

        public message.Students Students
        {
            get { return students; }
        }
        
        private int ExcelInstalled()
        {
            int ret = 0;
            RegistryKey rkOffice = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Office\14.0\Common\InstallRoot\");
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
            this.LoadWPSExcel(name);
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
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                this.loadDataFromExcel(sheet);
                
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

        private void loadDataFromExcel(Worksheet sheet)
        {
            int rowCount = sheet.UsedRange.Rows.Count;
            int columnCount = sheet.UsedRange.Columns.Count;
            Range range = null;
            for (int i = 1; i <= columnCount; ++i)
            {
                range = (Range)sheet.Cells[1, i];
                int index = 0;
                if(range.Text.ToString().Contains("序号"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        message.StudentInfo studentInfo = new message.StudentInfo();
                        students.student.Add(studentInfo);
                    }
                }
                else if (range.Text.ToString().Contains("考生姓名"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("学校名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].school = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("学校类型"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].type = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("外国语"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].foreign = (int)range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("政治"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].political = (int)range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课一"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_one = (int)range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课二名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_two_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课二成绩"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_two = (int)range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("总分"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].score = (int)range.Value2;
                        index++;
                    }
                }
            }
        }
    }
}
