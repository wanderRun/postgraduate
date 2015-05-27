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
        public struct SchoolType
        {
            public string name;
            public string type;
            public uint score;
        }

        public struct ComputerAndListenScore
        {
            public string number;
            public string name;
            public uint computer;
            public uint listen;
        }

        private static message.Students students = new message.Students();
        private static List<message.StudentInfo> academicMaster = new List<message.StudentInfo>();// 学硕
        private static List<message.StudentInfo> professionalMaster = new List<message.StudentInfo>();// 专硕
        private static List<List<message.StudentInfo>> academicMasterGroup = new List<List<message.StudentInfo>>();// 学硕分组
        private static List<List<message.StudentInfo>> professionalMasterGroup = new List<List<message.StudentInfo>>();// 专硕分组
        private static message.Teachers teachers = new message.Teachers();
        private static Dictionary<string, SchoolType> schoolTypeList = new Dictionary<string, SchoolType>();// 学校类型
        private static Dictionary<string, ComputerAndListenScore> computerAndListenScoreList = new Dictionary<string, ComputerAndListenScore>();// 上机和听力成绩
        private static message.Teachers teachersLogin = new message.Teachers();// 教师登录
        private static List<message.TeacherScore> teacherScore = new List<message.TeacherScore>();// 老师打分数

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

        public static Dictionary<string, SchoolType> SchoolTypeList
        {
            get { return schoolTypeList; }
        }

        public static Dictionary<string, ComputerAndListenScore> ComputerAndListenScoreList
        {
            get { return computerAndListenScoreList; }
        }

        public static message.Teachers TeachersLogin
        {
            get { return teachersLogin; }
        }

        public static List<message.TeacherScore> TeacherScore
        {
            get { return teacherScore; }
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
                LoadDataFromExcel(sheet);
                Console.WriteLine("total={0}", students.student.Count);
                book.Close();
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
            foreach(message.StudentInfo student in students.student)
            {
                if(schoolTypeList.ContainsKey(student.school_name))
                {
                    student.school_type = schoolTypeList[student.school_name].type;
                    student.school_score = schoolTypeList[student.school_name].score;
                }
                else
                {
                    student.school_type = "其它";
                    student.school_score = 10;
                }
                if(computerAndListenScoreList.ContainsKey(student.number))
                {
                    student.operation = System.Convert.ToUInt32(computerAndListenScoreList[student.number].computer * 0.7);
                    student.hear = computerAndListenScoreList[student.number].listen;
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
                }
            }
            else if(type == 2)
            {
                for (int i = 0; i < academicMasterGroup[group].Count; ++i)
                {
                    academicMasterGroup[group][i].teacher_id.Add(teacherId);
                    academicMasterGroup[group][i].teacher_name.Add(teacherName);
                }
            }
        }

        public static void RemoveTeacher(int type, int group, string teacherId)
        {
            if (type == 1)
            {
                int index = professionalMasterGroup[group][0].teacher_id.FindIndex(t => t == teacherId);
                if(index == -1)
                {
                    return;
                }
                for (int i = 0; i < professionalMasterGroup[group].Count; ++i)
                {
                    int tmp = students.student.FindIndex(s => s.number == professionalMasterGroup[group][i].number);
                    int tmp1 = students.student[tmp].teacher_id.FindIndex(t => t == professionalMasterGroup[group][i].teacher_id[index]);
                    students.student[tmp].teacher_id.RemoveAt(tmp1);
                    students.student[tmp].teacher_name.RemoveAt(tmp1);
                }
            }
            else if (type == 2)
            {
                int index = academicMasterGroup[group][0].teacher_id.FindIndex(t => t == teacherId);
                if(index == -1)
                {
                    return;
                }
                for (int i = 0; i < academicMasterGroup[group].Count; ++i)
                {
                    int tmp = students.student.FindIndex(s => s.number == academicMasterGroup[group][i].number);
                    int tmp1 = students.student[tmp].teacher_id.FindIndex(t => t == academicMasterGroup[group][i].teacher_id[index]);
                    students.student[tmp].teacher_id.RemoveAt(tmp1);
                    students.student[tmp].teacher_name.RemoveAt(tmp1);
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

        public static void LoadTeacherFromSQL()
        {
            System.Data.DataTable dataTable = MysqlManager.SelectData("teacher_information");
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

        public static void SaveTeacherToSQL()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            foreach (message.TeacherInfo teacherInfo in teachers.teacher)
            {
                data.Clear();
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>("teacher_id", teacherInfo.id);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("teacher_name", teacherInfo.name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("teacher_password", teacherInfo.password);
                data.Add(kvp);
                MysqlManager.InsertData("teacher_information", data);
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

        public static int LoadSchoolTypeFromExcel(string path)
        {
            try
            {
                if(!File.Exists(path))
                {
                    return -1;
                }
                Application excel = new Application();
                Workbook book = excel.Workbooks.Open(path);
                Worksheet sheet = book.Worksheets.Item[1];
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                for (int i = 2; i <= sheet.UsedRange.Rows.Count; ++i)
                {
                    SchoolType schoolType = new SchoolType();
                    Range range = (Range)sheet.Cells[i, 1];
                    schoolType.name = (string)range.Text;
                    range = (Range)sheet.Cells[i, 2];
                    schoolType.type = (string)range.Text;
                    range = (Range)sheet.Cells[i, 3];
                    schoolType.score = Convert.ToUInt32(range.Text);
                    if(!schoolTypeList.ContainsKey(schoolType.name))
                    {
                        schoolTypeList.Add(schoolType.name, schoolType);
                    }
                }
                excel.Quit();
                Marshal.ReleaseComObject(sheet);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(excel);
                GC.Collect();
                Console.WriteLine("load school type from excel compelete");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
            return 0;
        }

        public static int LoadComputerAndListenScoreFromExcel(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    return -1;
                }
                Application excel = new Application();
                Workbook book = excel.Workbooks.Open(path);
                Worksheet sheet = book.Worksheets.Item[1];
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                for (int i = 2; i <= sheet.UsedRange.Rows.Count; ++i)
                {
                    ComputerAndListenScore computerAndListenScore = new ComputerAndListenScore();
                    Range range = (Range)sheet.Cells[i, 1];
                    computerAndListenScore.number = (string)range.Text;
                    range = (Range)sheet.Cells[i, 2];
                    computerAndListenScore.name = (string)range.Text;
                    range = (Range)sheet.Cells[i, 3];
                    computerAndListenScore.computer = Convert.ToUInt32(range.Text);
                    range = (Range)sheet.Cells[i, 4];
                    computerAndListenScore.listen = Convert.ToUInt32(range.Text);
                    if (!schoolTypeList.ContainsKey(computerAndListenScore.number))
                    {
                        computerAndListenScoreList.Add(computerAndListenScore.number, computerAndListenScore);
                    }
                }
                excel.Quit();
                Marshal.ReleaseComObject(sheet);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(excel);
                GC.Collect();
                Console.WriteLine("load computer and listen score from excel compelete");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
            return 0;
        }

        public static int RemoveTeacherByIndex(int index)
        {
            if(index >= teachers.teacher.Count || index < 0)
            {
                return 0;
            }
            teachers.teacher.RemoveAt(index);
            return 1;
        }

        public static int RemoveTeacherByName(string name)
        {
            return teachers.teacher.RemoveAll(t => t.name == name);
        }

        public static void LoadStudentFromSQL()
        {
            System.Data.DataTable dataTable = MysqlManager.SelectData("student_information");
            students.student.Clear();
            academicMaster.Clear();
            professionalMaster.Clear();
            for (int i = 0; i < dataTable.Rows.Count; ++i)
            {
                message.StudentInfo studentInfo = new message.StudentInfo();
                studentInfo.apply_place = dataTable.Rows[i]["apply_place"].ToString();
                studentInfo.aplly_number = dataTable.Rows[i]["aplly_number"].ToString();
                studentInfo.name = dataTable.Rows[i]["name"].ToString();
                studentInfo.name_spell = dataTable.Rows[i]["name_spell"].ToString();
                studentInfo.number = dataTable.Rows[i]["number"].ToString();
                studentInfo.card_type = dataTable.Rows[i]["card_type"].ToString();
                studentInfo.card_number = dataTable.Rows[i]["card_number"].ToString();
                studentInfo.birth = dataTable.Rows[i]["birth"].ToString();
                studentInfo.nation = dataTable.Rows[i]["nation"].ToString();
                studentInfo.gender = dataTable.Rows[i]["gender"].ToString();
                studentInfo.marriage = dataTable.Rows[i]["marriage"].ToString();
                studentInfo.soldier = dataTable.Rows[i]["soldier"].ToString();
                studentInfo.politics_status = dataTable.Rows[i]["politics_status"].ToString();
                studentInfo.native_place = dataTable.Rows[i]["native_place"].ToString();
                studentInfo.birth_place = dataTable.Rows[i]["birth_place"].ToString();
                studentInfo.register_place = dataTable.Rows[i]["register_place"].ToString();
                studentInfo.register_address = dataTable.Rows[i]["register_address"].ToString();
                studentInfo.record_place = dataTable.Rows[i]["record_place"].ToString();
                studentInfo.record_ministry = dataTable.Rows[i]["record_ministry"].ToString();
                studentInfo.record_address = dataTable.Rows[i]["record_address"].ToString();
                studentInfo.record_place_postcode = dataTable.Rows[i]["record_place_postcode"].ToString();
                studentInfo.work_place = dataTable.Rows[i]["work_place"].ToString();
                studentInfo.work_experience = dataTable.Rows[i]["work_experience"].ToString();
                studentInfo.reward_punishment = dataTable.Rows[i]["reward_punishment"].ToString();
                studentInfo.family = dataTable.Rows[i]["family"].ToString();
                studentInfo.contact_address = dataTable.Rows[i]["contact_address"].ToString();
                studentInfo.contact_postcode = dataTable.Rows[i]["contact_postcode"].ToString();
                studentInfo.fixed_line_phone = dataTable.Rows[i]["fixed_line_phone"].ToString();
                studentInfo.mobile_phone = dataTable.Rows[i]["mobile_phone"].ToString();
                studentInfo.email = dataTable.Rows[i]["email"].ToString();
                studentInfo.source = dataTable.Rows[i]["source"].ToString();
                studentInfo.same_education = dataTable.Rows[i]["same_education"].ToString();
                studentInfo.school_code = dataTable.Rows[i]["school_code"].ToString();
                studentInfo.school_name = dataTable.Rows[i]["school_name"].ToString();
                studentInfo.major_name = dataTable.Rows[i]["major_name"].ToString();
                studentInfo.study_type = dataTable.Rows[i]["study_type"].ToString();
                studentInfo.last_education = dataTable.Rows[i]["last_education"].ToString();
                studentInfo.diploma_number = dataTable.Rows[i]["diploma_number"].ToString();
                studentInfo.graduate_date = dataTable.Rows[i]["graduate_date"].ToString();
                studentInfo.register_number = dataTable.Rows[i]["register_number"].ToString();
                studentInfo.last_degree = dataTable.Rows[i]["last_degree"].ToString();
                studentInfo.graduate_number = dataTable.Rows[i]["graduate_number"].ToString();
                studentInfo.adjust_major_code = dataTable.Rows[i]["adjust_major_code"].ToString();
                studentInfo.adjust_major_name = dataTable.Rows[i]["adjust_major_name"].ToString();
                studentInfo.apply_place_code = dataTable.Rows[i]["apply_place_code"].ToString();
                studentInfo.apply_faculty = dataTable.Rows[i]["apply_faculty"].ToString();
                studentInfo.apply_faculty_name = dataTable.Rows[i]["apply_faculty_name"].ToString();
                studentInfo.apply_major_code = dataTable.Rows[i]["apply_major_code"].ToString();
                studentInfo.apply_major_name = dataTable.Rows[i]["apply_major_name"].ToString();
                studentInfo.apply_work_direction = dataTable.Rows[i]["apply_work_direction"].ToString();
                studentInfo.apply_work_direction_name = dataTable.Rows[i]["apply_work_direction_name"].ToString();
                studentInfo.exam_type = dataTable.Rows[i]["exam_type"].ToString();
                studentInfo.special_plan = dataTable.Rows[i]["special_plan"].ToString();
                studentInfo.apply_type = dataTable.Rows[i]["apply_type"].ToString();
                studentInfo.orientation_train_place_code = dataTable.Rows[i]["orientation_train_place_code"].ToString();
                studentInfo.orientation_train_place = dataTable.Rows[i]["orientation_train_place"].ToString();
                studentInfo.standby_information = dataTable.Rows[i]["standby_information"].ToString();
                studentInfo.standby_information_one = dataTable.Rows[i]["standby_information_one"].ToString();
                studentInfo.standby_information_two = dataTable.Rows[i]["standby_information_two"].ToString();
                studentInfo.standby_information_three = dataTable.Rows[i]["standby_information_three"].ToString();
                studentInfo.political_code = dataTable.Rows[i]["political_code"].ToString();
                studentInfo.political_name = dataTable.Rows[i]["political_name"].ToString();
                studentInfo.foreign_code = dataTable.Rows[i]["foreign_code"].ToString();
                studentInfo.foreign_name = dataTable.Rows[i]["foreign_name"].ToString();
                studentInfo.business_one_code = dataTable.Rows[i]["business_one_code"].ToString();
                studentInfo.business_one_name = dataTable.Rows[i]["business_one_name"].ToString();
                studentInfo.business_two_code = dataTable.Rows[i]["business_two_code"].ToString();
                studentInfo.business_two_name = dataTable.Rows[i]["business_two_name"].ToString();
                studentInfo.political_score = System.Convert.ToUInt32(dataTable.Rows[i]["political_score"].ToString());
                studentInfo.foreign_score = System.Convert.ToUInt32(dataTable.Rows[i]["foreign_score"].ToString());
                studentInfo.business_one_score = System.Convert.ToUInt32(dataTable.Rows[i]["business_one_score"].ToString());
                studentInfo.business_two_score = System.Convert.ToUInt32(dataTable.Rows[i]["business_two_score"].ToString());
                studentInfo.total_score = System.Convert.ToUInt32(dataTable.Rows[i]["total_score"].ToString());
                studentInfo.volunteer_type = dataTable.Rows[i]["volunteer_type"].ToString();
                studentInfo.tutor = dataTable.Rows[i]["tutor"].ToString();
                studentInfo.student_confirm_status = dataTable.Rows[i]["student_confirm_status"].ToString();
                studentInfo.student_confirm_time = dataTable.Rows[i]["student_confirm_time"].ToString();
                studentInfo.student_confirm_time = dataTable.Rows[i]["student_reexamine"].ToString();
                students.student.Add(studentInfo);
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

        public static void SaveStudentToSQL()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            foreach (message.StudentInfo student in students.student)
            {
                data.Clear();
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>("apply_place", student.apply_place);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("aplly_number", student.aplly_number);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("name", student.name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("name_spell", student.name_spell);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("number", student.number);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("card_type", student.card_type);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("card_number", student.card_number);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("birth", student.birth);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("nation", student.nation);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("gender", student.gender);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("marriage", student.marriage);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("soldier", student.soldier);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("politics_status", student.politics_status);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("native_place", student.native_place);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("birth_place", student.birth_place);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("register_place", student.register_place);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("register_address", student.register_address);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("record_place", student.record_place);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("record_ministry", student.record_ministry);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("record_address", student.record_address);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("record_place_postcode", student.record_place_postcode);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("work_place", student.work_place);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("work_experience", student.work_experience);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("reward_punishment", student.reward_punishment);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("family", student.family);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("contact_address", student.contact_address);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("contact_postcode", student.contact_postcode);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("fixed_line_phone", student.fixed_line_phone);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("mobile_phone", student.mobile_phone);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("email", student.email);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("source", student.source);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("same_education", student.same_education);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("school_code", student.school_code);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("school_name", student.school_name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("major_name", student.major_name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("study_type", student.study_type);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("last_education", student.last_education);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("diploma_number", student.diploma_number);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("graduate_date", student.graduate_date);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("register_number", student.register_number);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("last_degree", student.last_degree);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("graduate_number", student.graduate_number);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("adjust_major_code", student.adjust_major_code);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("adjust_major_name", student.adjust_major_name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("apply_place_code", student.apply_place_code);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("apply_faculty", student.apply_faculty);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("apply_faculty_name", student.apply_faculty_name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("apply_major_code", student.apply_major_code);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("apply_major_name", student.apply_major_name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("apply_work_direction", student.apply_work_direction);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("apply_work_direction_name", student.apply_work_direction_name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("exam_type", student.exam_type);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("special_plan", student.special_plan);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("apply_type", student.apply_type);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("orientation_train_place_code", student.orientation_train_place_code);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("orientation_train_place", student.orientation_train_place);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("standby_information", student.standby_information);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("standby_information_one", student.standby_information_one);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("standby_information_two", student.standby_information_two);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("standby_information_three", student.standby_information_three);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("political_code", student.political_code);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("political_name", student.political_name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("foreign_code", student.foreign_code);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("foreign_name", student.foreign_name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("business_one_code", student.business_one_code);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("business_one_name", student.business_one_name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("business_two_code", student.business_two_code);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("business_two_name", student.business_two_name);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("political_score", student.political_score.ToString());
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("foreign_score", student.foreign_score.ToString());
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("business_one_score", student.business_one_score.ToString());
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("business_two_score", student.business_two_score.ToString());
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("total_score", student.total_score.ToString());
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("volunteer_type", student.volunteer_type);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("tutor", student.tutor);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("student_confirm_status", student.student_confirm_status);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("student_confirm_time", student.student_confirm_time);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("student_reexamine", student.student_reexamine);
                data.Add(kvp);
                MysqlManager.InsertData("student_information", data);
            }
        }

        public static uint CheckTeacherLogin(message.Login login)
        {
            int index = teachers.teacher.FindIndex(t => t.id == login.name);
            if (index == -1)
            {
                return 2;
            }
            if (teachers.teacher[index].password != login.password)
            {
                return 3;
            }
            teachersLogin.teacher.Add(teachers.teacher[index]);
            return 1;
        }

        public static bool TeacherScoreStudent(message.TeacherScore rev)
        {
            message.StudentInfo studentInfo = students.student.Find(s => s.number == rev.number);
            if(studentInfo == null)
            {
                return false;
            }
            int index = studentInfo.teacher_id.FindIndex(t => t == rev.teacher_id);
            if(index == -1)
            {
                return false;
            }
            bool isFind = false;
            for(int i = 0; i < teacherScore.Count; ++i)
            {
                if(teacherScore[i].number == rev.number && teacherScore[i].teacher_id == rev.teacher_id)
                {
                    teacherScore[i] = rev;
                    isFind = true;
                }
            }
            if(!isFind)
            {
                teacherScore.Add(rev);
            }
            uint count = 0;
            studentInfo.introduction_score = 0;
            studentInfo.translation_score = 0;
            studentInfo.topic_score = 0;
            studentInfo.answer_score = 0;
            studentInfo.result_score = 0;
            foreach(message.TeacherScore score in teacherScore)
            {
                if(studentInfo.number == score.number)
                {
                    studentInfo.introduction_score += score.introduction_score;
                    studentInfo.translation_score += score.translation_score; ;
                    studentInfo.topic_score += score.topic_score;
                    studentInfo.answer_score += score.answer_score;
                    studentInfo.result_score += score.result_score;
                    count++;
                }
            }
            studentInfo.introduction_score /= count;
            studentInfo.translation_score /= count;
            studentInfo.topic_score /= count;
            studentInfo.answer_score /= count;
            studentInfo.result_score /= count;
            return true;
        }

        public static void SaveTeacherScoreToSQL()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            foreach(message.TeacherScore score in teacherScore)
            {
                data.Clear();
                KeyValuePair<string, string>  kvp = new KeyValuePair<string, string>("number", score.number);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("teacher_id", score.teacher_id);
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("introduction_score", score.introduction_score.ToString());
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("translation_score", score.translation_score.ToString());
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("topic_score", score.topic_score.ToString());
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("answer_score", score.answer_score.ToString());
                data.Add(kvp);
                MysqlManager.InsertData("score_information", data);
            }
        }

        public static void LoadTeacherScoreFromSQL()
        {
            System.Data.DataTable dataTable = MysqlManager.SelectData("score_information");
            teacherScore.Clear();
            for (int i = 0; i < dataTable.Rows.Count; ++i)
            {
                message.TeacherScore score = new message.TeacherScore();
                score.number = dataTable.Rows[i]["number"].ToString();
                score.teacher_id = dataTable.Rows[i]["teacher_id"].ToString();
                score.introduction_score = System.Convert.ToUInt32(dataTable.Rows[i]["introduction_score"]);
                score.translation_score = System.Convert.ToUInt32(dataTable.Rows[i]["translation_score"]);
                score.topic_score = System.Convert.ToUInt32(dataTable.Rows[i]["topic_score"]);
                score.answer_score = System.Convert.ToUInt32(dataTable.Rows[i]["answer_score"]);
                score.result_score = score.introduction_score + score.translation_score + score.topic_score + score.answer_score;
                teacherScore.Add(score);
            }
            foreach(message.TeacherScore score in teacherScore)
            {
                message.StudentInfo student = students.student.Find(s => s.number == score.number);
                if(student == null)
                {
                    continue;
                }
                student.introduction_score += score.introduction_score;
                student.translation_score += score.translation_score;
                student.topic_score += score.topic_score;
                student.answer_score += score.answer_score;
                student.result_score += score.result_score;
            }
            foreach(message.StudentInfo student in students.student)
            {
                if(student.teacher_id.Count == 0)
                {
                    continue;
                }
                student.introduction_score /= (uint)student.teacher_id.Count;
                student.translation_score /= (uint)student.teacher_id.Count;
                student.topic_score /= (uint)student.teacher_id.Count;
                student.answer_score /= (uint)student.teacher_id.Count;
                student.result_score /= (uint)student.teacher_id.Count;
            }
        }

        public static void SaveGroupToSQL()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            int group = 0;
            foreach (List<message.StudentInfo> studentGroup in AcademicMasterGroup)
            {
                int index = 0;
                data.Clear();
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>("student_type", "academic");
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("group_id", group.ToString());
                data.Add(kvp);
                string number = "";
                foreach (message.StudentInfo student in studentGroup)
                {
                    if(index++ != 0)
                    {
                        number += ";";
                    }
                    number += student.number;
                }
                kvp = new KeyValuePair<string, string>("number", number);
                data.Add(kvp);
                group++;
                MysqlManager.InsertData("group_information", data);
            }
            group = 0;
            foreach (List<message.StudentInfo> studentGroup in ProfessionalMasterGroup)
            {
                int index = 0;
                data.Clear();
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>("student_type", "professional");
                data.Add(kvp);
                kvp = new KeyValuePair<string, string>("group_id", group.ToString());
                data.Add(kvp);
                string number = "";
                foreach (message.StudentInfo student in studentGroup)
                {
                    if (index++ != 0)
                    {
                        number += ";";
                    }
                    number += student.number;
                }
                kvp = new KeyValuePair<string, string>("number", number);
                data.Add(kvp);
                group++;
                MysqlManager.InsertData("group_information", data);
            }
        }

        public static void LoadGroupFromSQL()
        {
            System.Data.DataTable dataTable = MysqlManager.SelectData("group_information");
            academicMasterGroup.Clear();
            professionalMasterGroup.Clear();
            for (int i = 0; i < dataTable.Rows.Count; ++i)
            {
                if (dataTable.Rows[i]["student_type"].ToString() == "academic" && System.Convert.ToInt32(dataTable.Rows[i]["group_id"].ToString()) >= academicMasterGroup.Count)
                {
                    List<message.StudentInfo> master = new List<message.StudentInfo>();
                    academicMasterGroup.Add(master);
                }
                if (dataTable.Rows[i]["student_type"].ToString() == "professional" && System.Convert.ToInt32(dataTable.Rows[i]["group_id"].ToString()) >= professionalMasterGroup.Count)
                {
                    List<message.StudentInfo> master = new List<message.StudentInfo>();
                    professionalMasterGroup.Add(master);
                }
            }
            for (int i = 0; i < dataTable.Rows.Count; ++i)
            {
                if (dataTable.Rows[i]["student_type"].ToString() == "academic")
                {
                    string num = dataTable.Rows[i]["number"].ToString();
                    string[] groups = num.Split(new char[] { ';' });
                    foreach (string number in groups)
                    {
                        message.StudentInfo master = academicMaster.Find(a => a.number == number);
                        if (master != null)
                        {
                            academicMasterGroup[System.Convert.ToInt32(dataTable.Rows[i]["group_id"].ToString())].Add(master);
                        }
                    }
                }
                else if(dataTable.Rows[i]["student_type"].ToString() == "professional")
                {
                    string num = dataTable.Rows[i]["number"].ToString();
                    string[] groups = num.Split(new char[] { ';' });
                    foreach (string number in groups)
                    {
                        message.StudentInfo master = professionalMaster.Find(a => a.number == number);
                        if (master != null)
                        {
                            professionalMasterGroup[System.Convert.ToInt32(dataTable.Rows[i]["group_id"].ToString())].Add(master);
                        }
                    }
                }
            }
        }

        public static void TeacherExit(string teacherId)
        {
            message.TeacherInfo teacher = teachersLogin.teacher.Find(t => t.id == teacherId);
            if(teacher == null)
            {
                return;
            }
            teachersLogin.teacher.Remove(teacher);
        }
    }
}
