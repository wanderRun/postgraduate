using System;
//using Microsoft.Office.Interop.Excel;
using Excel;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace Server
{
    class ExcelManager
    {
        private static message.Students students = new message.Students();

        public static message.Students Students
        {
            get { return students; }
        }
        
        private static int ExcelInstalled()
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

        public static void Load(string name)
        {
            int ret = ExcelInstalled();
            if((ret & 1) != 0)
            {
                LoadExcel(name);
            }
            else if((ret & 2) != 0)
            {
                LoadWPSExcel(name);
            }
            LoadWPSExcel(name);
        }

        private static void LoadExcel(string name)
        {
            try
            {
                Application excel = new Application();
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

        private static void LoadWPSExcel(string name)
        {
            try
            {
                Application excel = new Application();
                Workbook book = excel.Workbooks.Open(name);
                Worksheet sheet = book.Worksheets.Item[1];
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                loadDataFromExcel(sheet);
                for(int i = 0; i < students.student.Count; ++i)
                {
                    Console.WriteLine("{0}", students.student[i].name);
                }
                book.Close();
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
                if (range.Text.ToString().Contains("报名点代码") || range.Text.ToString().Contains("bmddm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生报名号") || range.Text.ToString().Contains("bmh"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].aplly_number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生姓名拼音") || range.Text.ToString().Contains("xmpy"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].name_spell = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生姓名") || range.Text.ToString().Equals("xm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生编号") || range.Text.ToString().Contains("ksbh"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("证件类型") || range.Text.ToString().Contains("zjlx"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].card_type = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("证件号码") || range.Text.ToString().Contains("zjhm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].card_number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("出生日期") || range.Text.ToString().Contains("csrq"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].birth = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("民族") || range.Text.ToString().Contains("mzm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].nation = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("性别") || range.Text.ToString().Contains("xbm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].gender = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("婚否") || range.Text.ToString().Contains("hfm"))
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
                else if (range.Text.ToString().Contains("政治面貌") || range.Text.ToString().Contains("zzmmm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].politics_status = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("籍贯所在地码") || range.Text.ToString().Contains("jgszdm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].native_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("出生地码") || range.Text.ToString().Contains("csdm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].birth_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("户口所在地码") || range.Text.ToString().Contains("hkszdm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].register_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("户口所在地详细地址") || range.Text.ToString().Contains("hkszdxxdz"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].register_address = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生档案所在地码") || range.Text.ToString().Contains("daszdm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].record_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生档案所在单位邮政编码") || range.Text.ToString().Contains("daszdwyzbm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].record_place_postcode = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生档案所在单位地址") || range.Text.ToString().Contains("daszdwdz"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].record_address = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生档案所在单位") || range.Text.ToString().Contains("daszdw"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].record_ministry = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("现在学习或工作单位") || range.Text.ToString().Contains("xxgzdw"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].work_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("学习与工作经历") || range.Text.ToString().Contains("xxgzjl"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].work_experience = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("何时何地何原因受过何种奖励或处分") || range.Text.ToString().Contains("jlcf"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].reward_punishment = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("家庭主要成员") || range.Text.ToString().Contains("jtcy"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].family = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生通讯地址邮政编码") || range.Text.ToString().Equals("yzbm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].contact_postcode = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生通讯地址") || range.Text.ToString().Contains("txdz"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].contact_address = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("固定电话") || range.Text.ToString().Contains("lxdh"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].fixed_line_phone = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("移动电话") || range.Text.ToString().Contains("yddh"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].mobile_phone = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("电子信箱") || range.Text.ToString().Contains("dzxx"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].email = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考生来源") || range.Text.ToString().Contains("kslym"))
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
                else if (range.Text.ToString().Contains("毕业学校代码") || range.Text.ToString().Contains("bydwm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].school_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("毕业学校名称") || range.Text.ToString().Equals("bydw"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].school_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("毕业专业名称") || range.Text.ToString().Contains("byzymc"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].major_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("取得最后学历的学习形式") || range.Text.ToString().Contains("xxxs"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].study_type = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("获得最后学历毕业年月") || range.Text.ToString().Contains("byny"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].graduate_date = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("最后学历") || range.Text.ToString().Contains("xlm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].last_education = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("毕业证书编号") || range.Text.ToString().Contains("xlzsbh"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].diploma_number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("注册学号") || range.Text.ToString().Contains("zcxh"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].register_number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("最后学位") || range.Text.ToString().Contains("xwm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].last_degree = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("学位证书编号") || range.Text.ToString().Contains("xwzsbh"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].graduate_number = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("调剂前报考专业代码") || range.Text.ToString().Contains("tj_zydm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].adjust_major_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("调剂前报考专业名称") || range.Text.ToString().Contains("tj_zymc"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].adjust_major_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考单位代码") || range.Text.ToString().Contains("bkdwdm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_place_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考院系所码") || range.Text.ToString().Contains("bkyxsm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_faculty = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考院系所名称") || range.Text.ToString().Contains("bkyxsmc"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_faculty_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考专业代码") || range.Text.ToString().Contains("bkzydm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_major_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考专业名称") || range.Text.ToString().Contains("bkzymc"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_major_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考研究方向码") || range.Text.ToString().Contains("yjfxm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_work_direction = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考研究方向名称") || range.Text.ToString().Contains("yjfxmc"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_work_direction_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("考试方式") || range.Text.ToString().Contains("ksfsm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].exam_type = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("专项计划") || range.Text.ToString().Contains("zxjh"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].special_plan = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("报考类别") || range.Text.ToString().Contains("bklbm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].apply_type = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("定向委培单位所在地码") || range.Text.ToString().Contains("dxwpdwszdm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].orientation_train_place_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("定向委培单位") || range.Text.ToString().Contains("dxwpdw"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].orientation_train_place = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("备用信息1") || range.Text.ToString().Contains("byxx1"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].standby_information_one = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("备用信息2") || range.Text.ToString().Contains("byxx2"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].standby_information_two = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("备用信息3") || range.Text.ToString().Contains("byxx3"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].standby_information_three = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("备用信息") || range.Text.ToString().Contains("byxx"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].standby_information = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("政治理论码") || range.Text.ToString().Equals("zzllm"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].political_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("政治理论名称") || range.Text.ToString().Contains("zzllmc"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].political_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("外国语码") || range.Text.ToString().Equals("wgym"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].foreign_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("外国语名称") || range.Text.ToString().Contains("wgymc"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].foreign_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课一码") || range.Text.ToString().Equals("ywk1m"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_one_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课一名称") || range.Text.ToString().Contains("ywk1mc"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_one_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课二码") || range.Text.ToString().Equals("ywk2m"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_two_code = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课二名称") || range.Text.ToString().Contains("ywk2mc"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_two_name = range.Value2;
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("政治理论成绩") || range.Text.ToString().Contains("zzll"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].political_score = Convert.ToUInt32(range.Value2);
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("外国语成绩") || range.Text.ToString().Contains("wgy"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].foreign_score = Convert.ToUInt32(range.Value2);
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课一成绩") || range.Text.ToString().Contains("ywk1"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_one_score = Convert.ToUInt32(range.Value2);
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("业务课二成绩") || range.Text.ToString().Contains("ywk2"))
                {
                    for (int j = 2; j <= rowCount; ++j)
                    {
                        range = (Range)sheet.Cells[j, i];
                        students.student[index].business_two_score = Convert.ToUInt32(range.Value2);
                        index++;
                    }
                }
                else if (range.Text.ToString().Contains("总分") || range.Text.ToString().Contains("zf"))
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

        public static void saveDataFromExcel(string path)
        {
            try
            {
                if(File.Exists(path))
                {
                    File.Delete(path);
                }
                Application excel = new Application();
                Workbook book = excel.Workbooks.Add(Missing.Value);
                //Worksheet sheet = book.ActiveSheet;
                Worksheet sheet = book.Sheets[1];
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                for (int i = 1; i <= students.student.Count; ++i)
                {
                    sheet.Cells[i, 1] = students.student[i - 1].name;
                }
                book.SaveAs(path);
                book.Close();
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(sheet);
                GC.Collect();
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }
    }
}
