using System;
//using Microsoft.Office.Interop.Excel;
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
        private static message.Students students = new message.Students();

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
                loadDataFromExcel(sheet);
                
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

        private static void loadDataFromExcel(Worksheet sheet)
        {
            int rowCount = sheet.UsedRange.Rows.Count;
            int columnCount = sheet.UsedRange.Columns.Count;
            Range range = (Range)sheet.Cells[1, 1];
            for (int j = 2; j <= rowCount; ++j)
            {
                message.StudentInfo studentInfo = new message.StudentInfo();
                students.student.Add(studentInfo);
            }
            for (int i = 1; i <= columnCount; ++i)
            {
                range = (Range)sheet.Cells[1, i];
                int index = 0;
                if(range.Text.ToString().Contains("报名点代码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生报名号"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].aplly_number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生姓名拼音"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].name_spell = range.Value2;
                        index++;
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
                else if (range.Text.ToString().Contains("考生编号"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("证件类型"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].card_type = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("证件号码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].card_number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("出生日期"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].birth = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("民族"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].nation = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("性别"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].gender = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("婚否"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].marriage = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("现役军人"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].soldier = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("政治面貌"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].politics_status = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("籍贯所在地码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].native_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("出生地码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].birth_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("户口所在地码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].register_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("户口所在地详细地址"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].register_address = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生档案所在地码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].record_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生档案所在单位邮政编码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].record_place_postcode = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生档案所在单位地址"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].record_address = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生档案所在单位"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].record_ministry = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("现在学习或工作单位"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].work_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("学习与工作经历"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].work_experience = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("何时何地何原因受过何种奖励或处分"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].reward_punishment = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("家庭主要成员"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].family = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生通讯地址邮政编码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].contact_postcode = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生通讯地址"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].contact_address = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("固定电话"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].fixed_line_phone = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("移动电话"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].mobile_phone = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("电子信箱"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].email = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生来源"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].source = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("是否同等学历"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].same_education = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("毕业学校代码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].school_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("毕业学校名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].school_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("毕业专业名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].major_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("取得最后学历的学习形式"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].study_type = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("获得最后学历毕业年月"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].graduate_date = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("最后学历"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].last_education = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("毕业证书编号"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].diploma_number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("注册学号"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].register_number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("最后学位"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].last_degree = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("学位证书编号"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].graduate_number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("调剂前报考专业代码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].adjust_major_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("调剂前报考专业名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].adjust_major_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考单位代码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_place_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考院系所码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_faculty = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考院系所名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_faculty_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考专业代码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_major_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考专业名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_major_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考研究方向码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_work_direction = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考研究方向名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_work_direction_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考试方式"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].exam_type = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("专项计划"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].special_plan = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考类别"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_type = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("定向委培单位所在地码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].orientation_train_place_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("定向委培单位"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].orientation_train_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("备用信息1"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].standby_information_one = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("备用信息2"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].standby_information_two = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("备用信息3"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].standby_information_three = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("备用信息"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].standby_information = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("政治理论码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].political_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("政治理论名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].political_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("外国语码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].foreign_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("外国语名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].foreign_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课一码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_one_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课一名称"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_one_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课二码"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_two_code = range.Value2;
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
                else if (range.Text.ToString().Contains("政治理论成绩"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].political_score = Convert.ToUInt32(range.Value2);
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("外国语成绩"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].foreign_score = Convert.ToUInt32(range.Value2);
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课一成绩"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_one_score = Convert.ToUInt32(range.Value2);
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课二成绩"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_two_score = Convert.ToUInt32(range.Value2);
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("总分"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].total_score = Convert.ToUInt32(range.Value2);
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("志愿类别"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].volunteer_type = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("导师"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].tutor = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生确认状态"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].student_confirm_status = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生确认时间"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].student_confirm_time = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("复试科目"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].student_reexamine = range.Value2;
                        index++;
                    }
                }
            }
        }
    }
}
