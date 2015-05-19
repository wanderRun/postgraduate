using System;
using Microsoft.Office.Interop.Excel;
//using Excel;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

using System.Data;
namespace Server
{
    class DataManager
    {
        private static message.Students students = new message.Students();
        private static List<message.StudentInfo> academicMaster = new List<message.StudentInfo>();// 学硕
        private static List<message.StudentInfo> professionalMaster = new List<message.StudentInfo>();// 专硕
        private static List<List<message.StudentInfo>> academicMasterGroup = new List<List<message.StudentInfo>>();// 学硕分组
        private static List<List<message.StudentInfo>> professionalMasterGroup = new List<List<message.StudentInfo>>();// 专硕分组
        private static message.Teachers teachers = new message.Teachers();

        public static message.Students Students
        {
            get { return students; }
        }

        public static List<message.StudentInfo> AcademicMaster
        {
            get { return academicMaster; }
        }

        public static List<message.StudentInfo> ProfessionalMaster
        {
            get { return professionalMaster; }
        }

        public static List<List<message.StudentInfo>> AcademicMasterGroup
        {
            get { return academicMasterGroup; }
        }
        public static List<List<message.StudentInfo>> ProfessionalMasterGroup
        {
            get { return professionalMasterGroup; }
        }

        public static message.Teachers Teachers
        {
            get { return teachers; }
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
            else if ((ret & 2) != 0)
            {
                LoadWPSExcel(name);
            }
            else
            {
                LoadWPSExcel(name);
            }
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
                Marshal.ReleaseComObject(sheet);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(excel);
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
                LoadDataFromExcel(sheet);
                Console.WriteLine("total={0}", students.student.Count);
                book.Close();
                excel.Quit();
                Marshal.ReleaseComObject(sheet);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(excel);
                GC.Collect();
                Console.WriteLine("load wps");
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }

        private static void LoadDataFromExcel(Worksheet sheet)
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
            foreach (message.StudentInfo student in students.student)
            {
                if (student.apply_major_code.Equals("081200") || student.apply_major_code.Equals("083500"))
                {
                    academicMaster.Add(student);
                }
                else if (student.apply_major_code.Equals("085211") || student.apply_major_code.Equals("085212"))
                {
                    professionalMaster.Add(student);
                }
            }
        }

        public static void SaveDataFromExcel(string path)
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
                    sheet.Cells[i, 1] = students.student[i - 1].apply_place;
                    sheet.Cells[i, 2] = students.student[i - 1].aplly_number;
                    sheet.Cells[i, 3] = students.student[i - 1].name;
                    sheet.Cells[i, 4] = students.student[i - 1].name_spell;
                    sheet.Cells[i, 5] = students.student[i - 1].number;
                    sheet.Cells[i, 6] = students.student[i - 1].card_type;
                    sheet.Cells[i, 7] = students.student[i - 1].card_number;
                    sheet.Cells[i, 8] = students.student[i - 1].birth;
                    sheet.Cells[i, 9] = students.student[i - 1].nation;
                    sheet.Cells[i, 10] = students.student[i - 1].gender;
                    sheet.Cells[i, 11] = students.student[i - 1].marriage;
                    sheet.Cells[i, 12] = students.student[i - 1].soldier;
                    sheet.Cells[i, 13] = students.student[i - 1].politics_status;
                    sheet.Cells[i, 14] = students.student[i - 1].native_place;
                    sheet.Cells[i, 15] = students.student[i - 1].birth_place;
                    sheet.Cells[i, 16] = students.student[i - 1].register_place;
                    sheet.Cells[i, 17] = students.student[i - 1].register_address;
                    sheet.Cells[i, 18] = students.student[i - 1].record_place;
                    sheet.Cells[i, 19] = students.student[i - 1].record_ministry;
                    sheet.Cells[i, 20] = students.student[i - 1].record_address;
                    sheet.Cells[i, 21] = students.student[i - 1].record_place_postcode;
                    sheet.Cells[i, 22] = students.student[i - 1].work_place;
                    sheet.Cells[i, 23] = students.student[i - 1].work_experience;
                    sheet.Cells[i, 24] = students.student[i - 1].reward_punishment;
                    sheet.Cells[i, 25] = students.student[i - 1].family;
                    sheet.Cells[i, 26] = students.student[i - 1].contact_address;
                    sheet.Cells[i, 27] = students.student[i - 1].contact_postcode;
                    sheet.Cells[i, 28] = students.student[i - 1].fixed_line_phone;
                    sheet.Cells[i, 29] = students.student[i - 1].mobile_phone;
                    sheet.Cells[i, 30] = students.student[i - 1].email;
                    sheet.Cells[i, 31] = students.student[i - 1].source;
                    sheet.Cells[i, 32] = students.student[i - 1].same_education;
                    sheet.Cells[i, 33] = students.student[i - 1].school_code;
                    sheet.Cells[i, 34] = students.student[i - 1].school_name;
                    sheet.Cells[i, 35] = students.student[i - 1].major_name;
                    sheet.Cells[i, 36] = students.student[i - 1].study_type;
                    sheet.Cells[i, 37] = students.student[i - 1].last_education;
                    sheet.Cells[i, 38] = students.student[i - 1].diploma_number;
                    sheet.Cells[i, 39] = students.student[i - 1].graduate_date;
                    sheet.Cells[i, 40] = students.student[i - 1].register_number;
                    sheet.Cells[i, 41] = students.student[i - 1].last_degree;
                    sheet.Cells[i, 42] = students.student[i - 1].graduate_number;
                    sheet.Cells[i, 43] = students.student[i - 1].adjust_major_code;
                    sheet.Cells[i, 44] = students.student[i - 1].adjust_major_name;
                    sheet.Cells[i, 45] = students.student[i - 1].apply_place_code;
                    sheet.Cells[i, 46] = students.student[i - 1].apply_faculty;
                    sheet.Cells[i, 47] = students.student[i - 1].apply_faculty_name;
                    sheet.Cells[i, 48] = students.student[i - 1].apply_major_code;
                    sheet.Cells[i, 49] = students.student[i - 1].apply_major_name;
                    sheet.Cells[i, 50] = students.student[i - 1].apply_work_direction;
                    sheet.Cells[i, 51] = students.student[i - 1].apply_work_direction_name;
                    sheet.Cells[i, 52] = students.student[i - 1].exam_type;
                    sheet.Cells[i, 53] = students.student[i - 1].special_plan;
                    sheet.Cells[i, 54] = students.student[i - 1].apply_type;
                    sheet.Cells[i, 55] = students.student[i - 1].orientation_train_place_code;
                    sheet.Cells[i, 56] = students.student[i - 1].orientation_train_place;
                    sheet.Cells[i, 57] = students.student[i - 1].standby_information;
                    sheet.Cells[i, 58] = students.student[i - 1].standby_information_one;
                    sheet.Cells[i, 59] = students.student[i - 1].standby_information_two;
                    sheet.Cells[i, 60] = students.student[i - 1].standby_information_three;
                    sheet.Cells[i, 61] = students.student[i - 1].political_code;
                    sheet.Cells[i, 62] = students.student[i - 1].political_name;
                    sheet.Cells[i, 63] = students.student[i - 1].foreign_code;
                    sheet.Cells[i, 64] = students.student[i - 1].foreign_name;
                    sheet.Cells[i, 65] = students.student[i - 1].business_one_code;
                    sheet.Cells[i, 66] = students.student[i - 1].business_one_name;
                    sheet.Cells[i, 67] = students.student[i - 1].business_two_code;
                    sheet.Cells[i, 68] = students.student[i - 1].business_two_name;
                    sheet.Cells[i, 69] = students.student[i - 1].political_score;
                    sheet.Cells[i, 70] = students.student[i - 1].foreign_score;
                    sheet.Cells[i, 71] = students.student[i - 1].business_one_score;
                    sheet.Cells[i, 72] = students.student[i - 1].business_two_score;
                    sheet.Cells[i, 73] = students.student[i - 1].total_score;
                    sheet.Cells[i, 74] = students.student[i - 1].volunteer_type;
                    sheet.Cells[i, 75] = students.student[i - 1].tutor;
                    sheet.Cells[i, 76] = students.student[i - 1].student_confirm_status;
                    sheet.Cells[i, 77] = students.student[i - 1].student_confirm_time;
                    sheet.Cells[i, 78] = students.student[i - 1].student_reexamine;
                }
                book.SaveAs(path);
                book.Close();
                excel.Quit();
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(sheet);
                GC.Collect();
                Console.WriteLine("保存到文件");
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }

        public static void DivideIntoGroups(int type, int number)
        {
            List<bool> isSelect = new List<bool>();
            if (type == 1)
            {
                professionalMasterGroup.Clear();
                for (int i = 0; i < professionalMaster.Count; ++i)
                {
                    isSelect.Add(false);
                }
            }// 专业硕士
            else if (type == 2)
            {
                academicMasterGroup.Clear();
                for (int i = 0; i < academicMaster.Count; ++i)
                {
                    isSelect.Add(false);
                }
            }// 学术硕士
            else
            {
                return;
            }
            int groupNumber = isSelect.Count / number;
            for (int i = 0; i < number - 1; ++i)
            {
                List<message.StudentInfo> master = new List<message.StudentInfo>();
                Random ran = new Random();
                for (int j = 0; j < groupNumber; ++j)
                {
                    int index = ran.Next(isSelect.Count);
                    while (isSelect[index])
                    {
                        index = ran.Next(isSelect.Count);
                    }
                    isSelect[index] = true;
                    if (type == 1)
                    {
                        master.Add(professionalMaster[index]);
                    }
                    else
                    {
                        master.Add(academicMaster[index]);
                    }
                }
                if (type == 1)
                {
                    professionalMasterGroup.Add(master);
                }
                else
                {
                    academicMasterGroup.Add(master);
                }
            }
            {
                List<message.StudentInfo> master = new List<message.StudentInfo>();
                for (int i = 0; i < isSelect.Count; ++i)
                {
                    if (!isSelect[i])
                    {
                        isSelect[i] = true;
                        if (type == 1)
                        {
                            master.Add(professionalMaster[i]);
                        }
                        else
                        {
                            master.Add(academicMaster[i]);
                        }
                    }
                }
                if (master.Count != 0)
                {
                    if (type == 1)
                    {
                        professionalMasterGroup.Add(master);
                    }
                    else
                    {
                        academicMasterGroup.Add(master);
                    }
                }
            }
        }

        public static void DispatchTeacher(int type, int group, string teacherId, string teacherName)
        {
            if (type == 1)
            {
                for (int i = 0; i < professionalMasterGroup[group].Count; ++i)
                {
                    professionalMasterGroup[group][i].teacher_id.Add(teacherId);
                    professionalMasterGroup[group][i].teacher_name.Add(teacherName);
                    int index = students.student.FindIndex(s => s.number == professionalMasterGroup[group][i].number);
                    students.student[index].teacher_id.Add(teacherId);
                    students.student[index].teacher_name.Add(teacherName);
                }
            }
            else if(type == 2)
            {
                for (int i = 0; i < academicMasterGroup[group].Count; ++i)
                {
                    academicMasterGroup[group][i].teacher_id.Add(teacherId);
                    academicMasterGroup[group][i].teacher_name.Add(teacherName);
                    int index = students.student.FindIndex(s => s.number == academicMasterGroup[group][i].number);
                    students.student[index].teacher_id.Add(teacherId);
                    students.student[index].teacher_name.Add(teacherName);
                }
            }
        }

        public static void RemoveTeacher(int type, int group, string teacherId)
        {
            if (type == 1)
            {
                int index = 0;
                for (int i = 0; i < professionalMasterGroup[group][0].teacher_id.Count; ++i)
                {
                    if(professionalMasterGroup[group][0].teacher_id[i] == teacherId)
                    {
                        index = i;
                        break;
                    }
                }
                for (int i = 0; i < professionalMasterGroup[group].Count; ++i)
                {
                    int tmp = students.student.FindIndex(s => s.number == professionalMasterGroup[group][i].number);
                    int tmp1 = students.student[tmp].teacher_id.FindIndex(t => t == professionalMasterGroup[group][i].teacher_id[index]);
                    students.student[tmp].teacher_id.RemoveAt(tmp1);
                    students.student[tmp].teacher_name.RemoveAt(tmp1);
                    professionalMasterGroup[group][i].teacher_id.RemoveAt(index);
                    professionalMasterGroup[group][i].teacher_name.RemoveAt(index);
                }
            }
            else if (type == 2)
            {
                int index = 0;
                for (int i = 0; i < academicMasterGroup[group][0].teacher_id.Count; ++i)
                {
                    if (academicMasterGroup[group][0].teacher_id[i] == teacherId)
                    {
                        index = i;
                        break;
                    }
                }
                for (int i = 0; i < academicMasterGroup[group].Count; ++i)
                {
                    int tmp = students.student.FindIndex(s => s.number == academicMasterGroup[group][i].number);
                    int tmp1 = students.student[tmp].teacher_id.FindIndex(t => t == academicMasterGroup[group][i].teacher_id[index]);
                    students.student[tmp].teacher_id.RemoveAt(tmp1);
                    students.student[tmp].teacher_name.RemoveAt(tmp1);
                    academicMasterGroup[group][i].teacher_id.RemoveAt(index);
                    academicMasterGroup[group][i].teacher_name.RemoveAt(index);
                }
            }
        }

        public static void AdjustStudent(int type, int from, int to, string number)
        {
            if(from == to)
            {
                return;
            }
            if(type == 1)
            {
                int index = professionalMasterGroup[from].FindIndex(p => p.number == number);
                professionalMasterGroup[to].Add(professionalMasterGroup[from][index]);
                professionalMasterGroup[from].RemoveAt(index);
            }
            else if(type == 2)
            {
                int index = academicMasterGroup[from].FindIndex(a => a.number == number);
                academicMasterGroup[to].Add(academicMasterGroup[from][index]);
                academicMasterGroup[from].RemoveAt(index);
            }
        }

        public static void ClearData()
        {
            students.student.Clear();
            academicMaster.Clear();
            professionalMaster.Clear();
            academicMasterGroup.Clear();
            professionalMasterGroup.Clear();
            teachers.teacher.Clear();
        }

        public static void LoadTeacherFromExcel(string path)
        {
            try
            {
                Application excel = new Application();
                Workbook book = excel.Workbooks.Open(path);
                Worksheet sheet = book.Worksheets.Item[1];
                int count = book.Worksheets.Count;
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                message.TeacherInfo teacherInfo;
                for (int i = 2; i <= sheet.UsedRange.Rows.Count; ++i )
                {
                    teacherInfo = new message.TeacherInfo();
                    Range range = (Range)sheet.Cells[i, 2];
                    teacherInfo.id = range.Text;
                    range = (Range)sheet.Cells[i, 3];
                    teacherInfo.name = range.Text;
                    range = (Range)sheet.Cells[i, 4];
                    teacherInfo.password = range.Text;
                    teachers.teacher.Add(teacherInfo);
                }
                excel.Quit();
                Marshal.ReleaseComObject(sheet);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(excel);
                GC.Collect();
                Console.WriteLine("load teacher from excel compelete");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }

        public static void LoadTeacherFromSQL(System.Data.DataTable dataTable)
        {
            message.TeacherInfo teacherInfo;
            for(int i = 0; i < dataTable.Rows.Count; ++i)
            {
                teacherInfo = new message.TeacherInfo();
                teacherInfo.id = dataTable.Rows[i]["teacher_id"].ToString();
                teacherInfo.name = dataTable.Rows[i]["teacher_name"].ToString();
                teacherInfo.password = dataTable.Rows[i]["teacher_password"].ToString();
                teachers.teacher.Add(teacherInfo);
            }
        }

        public static void AddTeacher(string id, string name, string password="dhu@123")
        {
            message.TeacherInfo teacherInfo = new message.TeacherInfo();
            teacherInfo.id = id;
            teacherInfo.name = name;
            teacherInfo.password = password;
            teachers.teacher.Add(teacherInfo);
        }

        public static int ChangeTeacherPassword(string id, string oldPassword, string newPassword)
        {
            int index = teachers.teacher.FindIndex(t => t.id == id);
            if(index == -1)
            {
                return 2;
            }
            if(teachers.teacher[index].password != oldPassword)
            {
                return 3;
            }
            teachers.teacher[index].password = newPassword;
            return 1;
        }

        public static void ClearTeacher()
        {
            teachers.teacher.Clear();
        }
    }
}
