using System;
using Excel;
using Office;
using AddInDesignerObjects;

namespace Server
{
    class ExcelManager
    {
        private Application excel = new Application();
        
        private bool IsExcelInstalled()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            return type != null;
        }

        public void LoadExcel()
        {

        }

        public void LoadWPSExcel(string name)
        {
            try
            {
                Workbook book = excel.Workbooks.Open(name);
                Worksheet sheet = book.Worksheets.Item[0];
                sheet.Name = "wang";
                sheet.Visible = XlSheetVisibility.xlSheetVisible;

                //Marshal.ReleaseComObject(excel);
                //Marshal.ReleaseComObject(book);
                //Marshal.ReleaseComObject(sheet);
                //GC.Collect();
                Console.WriteLine("hell");
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }
    }
}
