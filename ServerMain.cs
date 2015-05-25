using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Threading;//引入线程的命名空间
using System.Net.Sockets;
using System.Net;
using Microsoft.VisualBasic;

namespace Server
{
    public partial class ServerMain : Form
    {
        public ServerMain()
        {
            InitializeComponent();
            cbStudentType.Items.Add("学生类型");
            cbStudentType.Items.Add("专业硕士");
            cbStudentType.Items.Add("学术硕士");
            cbGroupNumber.Items.Add("学生分组");
            cbStudentType.SelectedIndex = 0;
            if(DataManager.LoadSchoolTypeFromExcel(System.Environment.CurrentDirectory + "\\高校类型列表.xls") == -1)
            {
                MessageBox.Show("高校类型列表打开失败请自行打开");
            }
            if (DataManager.LoadComputerAndListenScoreFromExcel(System.Environment.CurrentDirectory + "\\kssjhtl.xls") == -1)
            {
                MessageBox.Show("上机成绩和听力成绩打开失败请自行打开");
            }
        }

        private void InitializeListView()
        {
            dgvShowStudent.Columns.Clear();
            dgvShowStudent.Columns.Add("applyPlace", "报名点代码");
            dgvShowStudent.Columns.Add("apllyNumber", "考生报名号");
            dgvShowStudent.Columns.Add("name", "考生姓名");
            dgvShowStudent.Columns.Add("nameSpell", "考生姓名拼音");
            dgvShowStudent.Columns.Add("number", "考生编号");
            dgvShowStudent.Columns.Add("cardType", "证件类型");
            dgvShowStudent.Columns.Add("cardNumber", "证件号码");
            dgvShowStudent.Columns.Add("birth", "出生日期");
            dgvShowStudent.Columns.Add("nation", "民族");
            dgvShowStudent.Columns.Add("gender", "性别");
            dgvShowStudent.Columns.Add("marriage", "婚否");
            dgvShowStudent.Columns.Add("soldier", "现役军人");
            dgvShowStudent.Columns.Add("politicsStatus", "政治面貌");
            dgvShowStudent.Columns.Add("nativePlace", "籍贯所在地码");
            dgvShowStudent.Columns.Add("birthPlace", "出生地码");
            dgvShowStudent.Columns.Add("registerPlace", "户口所在地码");
            dgvShowStudent.Columns.Add("registerAddress", "户口所在地详细地址");
            dgvShowStudent.Columns.Add("recordPlace", "考生档案所在地码");
            dgvShowStudent.Columns.Add("recordMinistry", "考生档案所在单位");
            dgvShowStudent.Columns.Add("recordAddress", "考生档案所在单位地址");
            dgvShowStudent.Columns.Add("recordPlacePostcode", "考生档案所在单位邮政编码");
            dgvShowStudent.Columns.Add("workPlace", "现在学习或工作单位");
            dgvShowStudent.Columns.Add("workExperience", "学习与工作经历");
            dgvShowStudent.Columns.Add("rewardPunishment", "何时何地何原因受过何种奖励或处分（含研究生招生考试中的违纪处理结果）");
            dgvShowStudent.Columns.Add("family", "家庭主要成员");
            dgvShowStudent.Columns.Add("contactAddress", "考生通讯地址");
            dgvShowStudent.Columns.Add("contactPostcode", "考生通讯地址邮政编码");
            dgvShowStudent.Columns.Add("fixedLinePhone", "固定电话");
            dgvShowStudent.Columns.Add("mobilePhone", "移动电话");
            dgvShowStudent.Columns.Add("email", "电子信箱");
            dgvShowStudent.Columns.Add("source", "考生来源");
            dgvShowStudent.Columns.Add("sameEducation", "是否同等学历");
            dgvShowStudent.Columns.Add("schoolCode", "毕业学校代码");
            dgvShowStudent.Columns.Add("schoolName", "毕业学校名称");
            dgvShowStudent.Columns.Add("majorName", "毕业专业名称");
            dgvShowStudent.Columns.Add("studyType", "取得最后学历的学习形式");
            dgvShowStudent.Columns.Add("lastEducation", "最后学历");
            dgvShowStudent.Columns.Add("diplomaNumber", "毕业证书编号");
            dgvShowStudent.Columns.Add("graduateDate", "获得最后学历毕业年月");
            dgvShowStudent.Columns.Add("registerNumber", "注册学号");
            dgvShowStudent.Columns.Add("lastDegree", "最后学位");
            dgvShowStudent.Columns.Add("graduateNumber", "学位证书编号");
            dgvShowStudent.Columns.Add("adjustMajorCode", "调剂前报考专业代码");
            dgvShowStudent.Columns.Add("adjustMajorName", "调剂前报考专业名称");
            dgvShowStudent.Columns.Add("applyPlaceCode", "报考单位代码");
            dgvShowStudent.Columns.Add("applyFaculty", "报考院系所码");
            dgvShowStudent.Columns.Add("applyFacultyName", "报考院系所名称");
            dgvShowStudent.Columns.Add("applyMajorCode", "报考专业代码");
            dgvShowStudent.Columns.Add("applyMajorName", "报考专业名称");
            dgvShowStudent.Columns.Add("applyWorkDirection", "报考研究方向码");
            dgvShowStudent.Columns.Add("applyWorkDirectionName", "报考研究方向名称");
            dgvShowStudent.Columns.Add("examType", "考试方式");
            dgvShowStudent.Columns.Add("specialPlan", "专项计划");
            dgvShowStudent.Columns.Add("applyType", "报考类别");
            dgvShowStudent.Columns.Add("orientationTrainPlaceCode", "定向委培单位所在地码");
            dgvShowStudent.Columns.Add("orientationTrainPlace", "定向委培单位");
            dgvShowStudent.Columns.Add("standbyInformation", "备用信息");
            dgvShowStudent.Columns.Add("standbyInformationOne", "备用信息1");
            dgvShowStudent.Columns.Add("standbyInformationTwo", "备用信息2");
            dgvShowStudent.Columns.Add("standbyInformationThree", "备用信息3");
            dgvShowStudent.Columns.Add("politicalCode", "政治理论码");
            dgvShowStudent.Columns.Add("politicalName", "政治理论名称");
            dgvShowStudent.Columns.Add("foreignCode", "外国语码");
            dgvShowStudent.Columns.Add("foreignName", "外国语名称");
            dgvShowStudent.Columns.Add("businessOneCode", "业务课一码");
            dgvShowStudent.Columns.Add("businessOneName", "业务课一名称");
            dgvShowStudent.Columns.Add("businessTwoCode", "业务课二码");
            dgvShowStudent.Columns.Add("businessTwoName", "业务课二名称");
            dgvShowStudent.Columns.Add("politicalScore", "政治理论成绩");
            dgvShowStudent.Columns.Add("foreignScore", "外国语成绩");
            dgvShowStudent.Columns.Add("businessOneScore", "业务课一成绩");
            dgvShowStudent.Columns.Add("businessTwoScore", "业务课二成绩");
            dgvShowStudent.Columns.Add("totalScore", "总分");
            dgvShowStudent.Columns.Add("volunteerType", "志愿类别");
            dgvShowStudent.Columns.Add("tutor", "导师");
            dgvShowStudent.Columns.Add("studentConfirmStatus", "考生确认状态");
            dgvShowStudent.Columns.Add("studentConfirmTime", "考生确认时间");
            dgvShowStudent.Columns.Add("studentReexamine", "复试科目");
        }

        PosSocket posSocket = new PosSocket();
        RedisManager redisManager = new RedisManager();

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ofdOpenFile.ShowDialog() == DialogResult.OK)
            {
                if(DataManager.SchoolTypeList.Count == 0 || DataManager.ComputerAndListenScoreList.Count == 0)
                {
                    MessageBox.Show("学校类型或者上机听力成绩还没导入，请先导入");
                    return;
                }
                string name = ofdOpenFile.FileName;
                DataManager.Load(name);
                this.cbStudentType.SelectedIndex = -1;
                this.cbStudentType.SelectedIndex = 0;
                //this.dgvShowStudent.Visible = true;
                //this.btSeparate.Visible = true;
                //this.cbGroupNumber.Visible = true;
                //this.cbStudentType.Visible = true;
                //this.btDispatchTeacher.Visible = true;
                //this.btAdjustStudent.Visible = true;
                //this.btManagerTeacher.Visible = true;
                //this.btScoreManager.Visible = true;
                MessageBox.Show("数据加载成功");
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sfdSaveFile.ShowDialog() == DialogResult.OK)
            {
                string name = sfdSaveFile.FileName;
                DataManager.SaveDataFromExcel(name);
                MessageBox.Show("数据保存成功");
            }
        }

        private void btSeparate_Click(object sender, EventArgs e)
        {
            if(DataManager.Students.student.Count == 0)
            {
                MessageBox.Show("没有学生信息无法分组");
                return;
            }
            string input = Interaction.InputBox("分组数目", "学生信息分组", "", 0, 0).Trim();
            if(input == "")
            {
                MessageBox.Show("分组不能或空");
                return;
            }
            if(cbStudentType.SelectedIndex <= 0)
            {
                MessageBox.Show("全部学生不能分组");
                return;
            }
            int number = Convert.ToInt32(input);
            if(number <= 0 || (cbStudentType.SelectedIndex == 1 && number > DataManager.ProfessionalMaster.Count) || (cbStudentType.SelectedIndex == 2 && number > DataManager.AcademicMaster.Count))
            {
                MessageBox.Show("分组数量超过学生数量");
                return;
            }
            DataManager.DivideIntoGroups(cbStudentType.SelectedIndex, number);
            if(cbStudentType.SelectedIndex == 1)
            {
                cbGroupNumber.Items.Clear();
                cbGroupNumber.Items.Add("全部分组");
                for(int i = 1; i <= DataManager.ProfessionalMasterGroup.Count; ++i)
                {
                    cbGroupNumber.Items.Add("第" + i + "组");
                }
                cbGroupNumber.SelectedIndex = 0;
            }
            else if (cbStudentType.SelectedIndex == 2)
            {
                cbGroupNumber.Items.Clear();
                cbGroupNumber.Items.Add("全部分组");
                for (int i = 1; i <= DataManager.AcademicMasterGroup.Count; ++i)
                {
                    cbGroupNumber.Items.Add("第" + i + "组");
                }
                cbGroupNumber.SelectedIndex = 0;
            }
            MessageBox.Show("分组成功");
        }

        private void cbStudentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbStudentType.SelectedIndex == -1)
            {
                return;
            }
            Console.WriteLine("大类选择的序号是{0}", cbStudentType.SelectedIndex);
            cbGroupNumber.Items.Clear();
            cbGroupNumber.Items.Add("学生分组");
            List<message.StudentInfo> student = null;
            if (cbStudentType.SelectedIndex == 0)
            {
                student = DataManager.Students.student;
            }
            else if (cbStudentType.SelectedIndex == 1)
            {
                for (int i = 1; i <= DataManager.ProfessionalMasterGroup.Count; ++i)
                {
                    cbGroupNumber.Items.Add("第" + i + "组");
                }
                student = DataManager.ProfessionalMaster;
            }
            else if (cbStudentType.SelectedIndex == 2)
            {
                for (int i = 1; i <= DataManager.AcademicMasterGroup.Count; ++i)
                {
                    cbGroupNumber.Items.Add("第" + i + "组");
                }
                student = DataManager.AcademicMaster;
            }
            this.InitializeListView();
            for (int i = 0; i < student.Count; ++i)
            {
                int index = dgvShowStudent.Rows.Add();
                dgvShowStudent.Rows[index].Cells["applyPlace"].Value = student[i].apply_place;
                dgvShowStudent.Rows[index].Cells["apllyNumber"].Value = student[i].aplly_number;
                dgvShowStudent.Rows[index].Cells["name"].Value = student[i].name;
                dgvShowStudent.Rows[index].Cells["nameSpell"].Value = student[i].name_spell;
                dgvShowStudent.Rows[index].Cells["number"].Value = student[i].number;
                dgvShowStudent.Rows[index].Cells["cardType"].Value = student[i].card_type;
                dgvShowStudent.Rows[index].Cells["cardNumber"].Value = student[i].card_number;
                dgvShowStudent.Rows[index].Cells["birth"].Value = student[i].birth;
                dgvShowStudent.Rows[index].Cells["nation"].Value = student[i].nation;
                dgvShowStudent.Rows[index].Cells["gender"].Value = student[i].gender;
                dgvShowStudent.Rows[index].Cells["marriage"].Value = student[i].marriage;
                dgvShowStudent.Rows[index].Cells["soldier"].Value = student[i].soldier;
                dgvShowStudent.Rows[index].Cells["politicsStatus"].Value = student[i].politics_status;
                dgvShowStudent.Rows[index].Cells["nativePlace"].Value = student[i].native_place;
                dgvShowStudent.Rows[index].Cells["birthPlace"].Value = student[i].birth_place;
                dgvShowStudent.Rows[index].Cells["registerPlace"].Value = student[i].register_place;
                dgvShowStudent.Rows[index].Cells["registerAddress"].Value = student[i].register_address;
                dgvShowStudent.Rows[index].Cells["recordPlace"].Value = student[i].record_place;
                dgvShowStudent.Rows[index].Cells["recordMinistry"].Value = student[i].record_ministry;
                dgvShowStudent.Rows[index].Cells["recordAddress"].Value = student[i].record_address;
                dgvShowStudent.Rows[index].Cells["recordPlacePostcode"].Value = student[i].record_place_postcode;
                dgvShowStudent.Rows[index].Cells["workPlace"].Value = student[i].work_place;
                dgvShowStudent.Rows[index].Cells["workExperience"].Value = student[i].work_experience;
                dgvShowStudent.Rows[index].Cells["rewardPunishment"].Value = student[i].reward_punishment;
                dgvShowStudent.Rows[index].Cells["family"].Value = student[i].family;
                dgvShowStudent.Rows[index].Cells["contactAddress"].Value = student[i].contact_address;
                dgvShowStudent.Rows[index].Cells["contactPostcode"].Value = student[i].contact_postcode;
                dgvShowStudent.Rows[index].Cells["fixedLinePhone"].Value = student[i].fixed_line_phone;
                dgvShowStudent.Rows[index].Cells["mobilePhone"].Value = student[i].mobile_phone;
                dgvShowStudent.Rows[index].Cells["email"].Value = student[i].email;
                dgvShowStudent.Rows[index].Cells["source"].Value = student[i].source;
                dgvShowStudent.Rows[index].Cells["sameEducation"].Value = student[i].same_education.ToString();
                dgvShowStudent.Rows[index].Cells["schoolCode"].Value = student[i].school_code;
                dgvShowStudent.Rows[index].Cells["schoolName"].Value = student[i].school_name;
                dgvShowStudent.Rows[index].Cells["majorName"].Value = student[i].major_name;
                dgvShowStudent.Rows[index].Cells["studyType"].Value = student[i].study_type;
                dgvShowStudent.Rows[index].Cells["lastEducation"].Value = student[i].last_education;
                dgvShowStudent.Rows[index].Cells["diplomaNumber"].Value = student[i].diploma_number;
                dgvShowStudent.Rows[index].Cells["graduateDate"].Value = student[i].graduate_date;
                dgvShowStudent.Rows[index].Cells["registerNumber"].Value = student[i].register_number;
                dgvShowStudent.Rows[index].Cells["lastDegree"].Value = student[i].last_degree;
                dgvShowStudent.Rows[index].Cells["graduateNumber"].Value = student[i].graduate_number;
                dgvShowStudent.Rows[index].Cells["adjustMajorCode"].Value = student[i].adjust_major_code;
                dgvShowStudent.Rows[index].Cells["adjustMajorName"].Value = student[i].adjust_major_name;
                dgvShowStudent.Rows[index].Cells["applyPlaceCode"].Value = student[i].apply_place_code;
                dgvShowStudent.Rows[index].Cells["applyFaculty"].Value = student[i].apply_faculty;
                dgvShowStudent.Rows[index].Cells["applyFacultyName"].Value = student[i].apply_faculty_name;
                dgvShowStudent.Rows[index].Cells["applyMajorCode"].Value = student[i].apply_major_code;
                dgvShowStudent.Rows[index].Cells["applyMajorName"].Value = student[i].apply_major_name;
                dgvShowStudent.Rows[index].Cells["applyWorkDirection"].Value = student[i].apply_work_direction;
                dgvShowStudent.Rows[index].Cells["applyWorkDirectionName"].Value = student[i].apply_work_direction_name;
                dgvShowStudent.Rows[index].Cells["examType"].Value = student[i].exam_type;
                dgvShowStudent.Rows[index].Cells["specialPlan"].Value = student[i].special_plan;
                dgvShowStudent.Rows[index].Cells["applyType"].Value = student[i].apply_type;
                dgvShowStudent.Rows[index].Cells["orientationTrainPlaceCode"].Value = student[i].orientation_train_place_code;
                dgvShowStudent.Rows[index].Cells["orientationTrainPlace"].Value = student[i].orientation_train_place;
                dgvShowStudent.Rows[index].Cells["standbyInformation"].Value = student[i].standby_information;
                dgvShowStudent.Rows[index].Cells["standbyInformationOne"].Value = student[i].standby_information_one;
                dgvShowStudent.Rows[index].Cells["standbyInformationTwo"].Value = student[i].standby_information_two;
                dgvShowStudent.Rows[index].Cells["standbyInformationThree"].Value = student[i].standby_information_three;
                dgvShowStudent.Rows[index].Cells["politicalCode"].Value = student[i].political_code;
                dgvShowStudent.Rows[index].Cells["politicalName"].Value = student[i].political_name;
                dgvShowStudent.Rows[index].Cells["foreignCode"].Value = student[i].foreign_code;
                dgvShowStudent.Rows[index].Cells["foreignName"].Value = student[i].foreign_name;
                dgvShowStudent.Rows[index].Cells["businessOneCode"].Value = student[i].business_one_code;
                dgvShowStudent.Rows[index].Cells["businessOneName"].Value = student[i].business_one_name;
                dgvShowStudent.Rows[index].Cells["businessTwoCode"].Value = student[i].business_two_code;
                dgvShowStudent.Rows[index].Cells["businessTwoName"].Value = student[i].business_two_name;
                dgvShowStudent.Rows[index].Cells["politicalScore"].Value = student[i].political_score.ToString();
                dgvShowStudent.Rows[index].Cells["foreignScore"].Value = student[i].foreign_score.ToString();
                dgvShowStudent.Rows[index].Cells["businessOneScore"].Value = student[i].business_one_score.ToString();
                dgvShowStudent.Rows[index].Cells["businessTwoScore"].Value = student[i].business_two_score.ToString();
                dgvShowStudent.Rows[index].Cells["totalScore"].Value = student[i].total_score.ToString();
                dgvShowStudent.Rows[index].Cells["volunteerType"].Value = student[i].volunteer_type;
                dgvShowStudent.Rows[index].Cells["tutor"].Value = student[i].tutor;
                dgvShowStudent.Rows[index].Cells["studentConfirmStatus"].Value = student[i].student_confirm_status;
                dgvShowStudent.Rows[index].Cells["studentConfirmTime"].Value = student[i].student_confirm_time.ToString();
                dgvShowStudent.Rows[index].Cells["studentReexamine"].Value = student[i].student_reexamine;
            }
            cbGroupNumber.SelectedIndex = 0;
        }

        private void cbGroupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbGroupNumber.SelectedIndex == -1)
            {
                return;
            }
            Console.WriteLine("小类选择的序号是{0}", cbGroupNumber.SelectedIndex);
            List<message.StudentInfo> student = null;
            if (cbGroupNumber.SelectedIndex == 0)
            {
                if (cbStudentType.SelectedIndex == 0)
                {
                    student = DataManager.Students.student;
                }
                else if (cbStudentType.SelectedIndex == 1)
                {
                    student = DataManager.ProfessionalMaster;
                }
                else if (cbStudentType.SelectedIndex == 2)
                {
                    student = DataManager.AcademicMaster;
                }
            }
            else
            {
                if (cbStudentType.SelectedIndex == 1)
                {
                    student = DataManager.ProfessionalMasterGroup[cbGroupNumber.SelectedIndex - 1];
                }
                else if (cbStudentType.SelectedIndex == 2)
                {
                    student = DataManager.AcademicMasterGroup[cbGroupNumber.SelectedIndex - 1];
                }
            }
            this.InitializeListView();
            for (int i = 0; i < student.Count; ++i)
            {
                int index = dgvShowStudent.Rows.Add();
                dgvShowStudent.Rows[index].Cells["applyPlace"].Value = student[i].apply_place;
                dgvShowStudent.Rows[index].Cells["apllyNumber"].Value = student[i].aplly_number;
                dgvShowStudent.Rows[index].Cells["name"].Value = student[i].name;
                dgvShowStudent.Rows[index].Cells["nameSpell"].Value = student[i].name_spell;
                dgvShowStudent.Rows[index].Cells["number"].Value = student[i].number;
                dgvShowStudent.Rows[index].Cells["cardType"].Value = student[i].card_type;
                dgvShowStudent.Rows[index].Cells["cardNumber"].Value = student[i].card_number;
                dgvShowStudent.Rows[index].Cells["birth"].Value = student[i].birth;
                dgvShowStudent.Rows[index].Cells["nation"].Value = student[i].nation;
                dgvShowStudent.Rows[index].Cells["gender"].Value = student[i].gender;
                dgvShowStudent.Rows[index].Cells["marriage"].Value = student[i].marriage;
                dgvShowStudent.Rows[index].Cells["soldier"].Value = student[i].soldier;
                dgvShowStudent.Rows[index].Cells["politicsStatus"].Value = student[i].politics_status;
                dgvShowStudent.Rows[index].Cells["nativePlace"].Value = student[i].native_place;
                dgvShowStudent.Rows[index].Cells["birthPlace"].Value = student[i].birth_place;
                dgvShowStudent.Rows[index].Cells["registerPlace"].Value = student[i].register_place;
                dgvShowStudent.Rows[index].Cells["registerAddress"].Value = student[i].register_address;
                dgvShowStudent.Rows[index].Cells["recordPlace"].Value = student[i].record_place;
                dgvShowStudent.Rows[index].Cells["recordMinistry"].Value = student[i].record_ministry;
                dgvShowStudent.Rows[index].Cells["recordAddress"].Value = student[i].record_address;
                dgvShowStudent.Rows[index].Cells["recordPlacePostcode"].Value = student[i].record_place_postcode;
                dgvShowStudent.Rows[index].Cells["workPlace"].Value = student[i].work_place;
                dgvShowStudent.Rows[index].Cells["workExperience"].Value = student[i].work_experience;
                dgvShowStudent.Rows[index].Cells["rewardPunishment"].Value = student[i].reward_punishment;
                dgvShowStudent.Rows[index].Cells["family"].Value = student[i].family;
                dgvShowStudent.Rows[index].Cells["contactAddress"].Value = student[i].contact_address;
                dgvShowStudent.Rows[index].Cells["contactPostcode"].Value = student[i].contact_postcode;
                dgvShowStudent.Rows[index].Cells["fixedLinePhone"].Value = student[i].fixed_line_phone;
                dgvShowStudent.Rows[index].Cells["mobilePhone"].Value = student[i].mobile_phone;
                dgvShowStudent.Rows[index].Cells["email"].Value = student[i].email;
                dgvShowStudent.Rows[index].Cells["source"].Value = student[i].source;
                dgvShowStudent.Rows[index].Cells["sameEducation"].Value = student[i].same_education.ToString();
                dgvShowStudent.Rows[index].Cells["schoolCode"].Value = student[i].school_code;
                dgvShowStudent.Rows[index].Cells["schoolName"].Value = student[i].school_name;
                dgvShowStudent.Rows[index].Cells["majorName"].Value = student[i].major_name;
                dgvShowStudent.Rows[index].Cells["studyType"].Value = student[i].study_type;
                dgvShowStudent.Rows[index].Cells["lastEducation"].Value = student[i].last_education;
                dgvShowStudent.Rows[index].Cells["diplomaNumber"].Value = student[i].diploma_number;
                dgvShowStudent.Rows[index].Cells["graduateDate"].Value = student[i].graduate_date;
                dgvShowStudent.Rows[index].Cells["registerNumber"].Value = student[i].register_number;
                dgvShowStudent.Rows[index].Cells["lastDegree"].Value = student[i].last_degree;
                dgvShowStudent.Rows[index].Cells["graduateNumber"].Value = student[i].graduate_number;
                dgvShowStudent.Rows[index].Cells["adjustMajorCode"].Value = student[i].adjust_major_code;
                dgvShowStudent.Rows[index].Cells["adjustMajorName"].Value = student[i].adjust_major_name;
                dgvShowStudent.Rows[index].Cells["applyPlaceCode"].Value = student[i].apply_place_code;
                dgvShowStudent.Rows[index].Cells["applyFaculty"].Value = student[i].apply_faculty;
                dgvShowStudent.Rows[index].Cells["applyFacultyName"].Value = student[i].apply_faculty_name;
                dgvShowStudent.Rows[index].Cells["applyMajorCode"].Value = student[i].apply_major_code;
                dgvShowStudent.Rows[index].Cells["applyMajorName"].Value = student[i].apply_major_name;
                dgvShowStudent.Rows[index].Cells["applyWorkDirection"].Value = student[i].apply_work_direction;
                dgvShowStudent.Rows[index].Cells["applyWorkDirectionName"].Value = student[i].apply_work_direction_name;
                dgvShowStudent.Rows[index].Cells["examType"].Value = student[i].exam_type;
                dgvShowStudent.Rows[index].Cells["specialPlan"].Value = student[i].special_plan;
                dgvShowStudent.Rows[index].Cells["applyType"].Value = student[i].apply_type;
                dgvShowStudent.Rows[index].Cells["orientationTrainPlaceCode"].Value = student[i].orientation_train_place_code;
                dgvShowStudent.Rows[index].Cells["orientationTrainPlace"].Value = student[i].orientation_train_place;
                dgvShowStudent.Rows[index].Cells["standbyInformation"].Value = student[i].standby_information;
                dgvShowStudent.Rows[index].Cells["standbyInformationOne"].Value = student[i].standby_information_one;
                dgvShowStudent.Rows[index].Cells["standbyInformationTwo"].Value = student[i].standby_information_two;
                dgvShowStudent.Rows[index].Cells["standbyInformationThree"].Value = student[i].standby_information_three;
                dgvShowStudent.Rows[index].Cells["politicalCode"].Value = student[i].political_code;
                dgvShowStudent.Rows[index].Cells["politicalName"].Value = student[i].political_name;
                dgvShowStudent.Rows[index].Cells["foreignCode"].Value = student[i].foreign_code;
                dgvShowStudent.Rows[index].Cells["foreignName"].Value = student[i].foreign_name;
                dgvShowStudent.Rows[index].Cells["businessOneCode"].Value = student[i].business_one_code;
                dgvShowStudent.Rows[index].Cells["businessOneName"].Value = student[i].business_one_name;
                dgvShowStudent.Rows[index].Cells["businessTwoCode"].Value = student[i].business_two_code;
                dgvShowStudent.Rows[index].Cells["businessTwoName"].Value = student[i].business_two_name;
                dgvShowStudent.Rows[index].Cells["politicalScore"].Value = student[i].political_score.ToString();
                dgvShowStudent.Rows[index].Cells["foreignScore"].Value = student[i].foreign_score.ToString();
                dgvShowStudent.Rows[index].Cells["businessOneScore"].Value = student[i].business_one_score.ToString();
                dgvShowStudent.Rows[index].Cells["businessTwoScore"].Value = student[i].business_two_score.ToString();
                dgvShowStudent.Rows[index].Cells["totalScore"].Value = student[i].total_score.ToString();
                dgvShowStudent.Rows[index].Cells["volunteerType"].Value = student[i].volunteer_type;
                dgvShowStudent.Rows[index].Cells["tutor"].Value = student[i].tutor;
                dgvShowStudent.Rows[index].Cells["studentConfirmStatus"].Value = student[i].student_confirm_status;
                dgvShowStudent.Rows[index].Cells["studentConfirmTime"].Value = student[i].student_confirm_time.ToString();
                dgvShowStudent.Rows[index].Cells["studentReexamine"].Value = student[i].student_reexamine;
            }
        }

        private void btDispatchTeacher_Click(object sender, EventArgs e)
        {
            if (DataManager.ProfessionalMasterGroup.Count == 0 && DataManager.AcademicMasterGroup.Count == 0)
            {
                MessageBox.Show("学生还没有分组，无法分配老师");
                return;
            }
            DispatchTeacher dispatchTeacher = new DispatchTeacher();
            dispatchTeacher.ShowDialog();
            Console.WriteLine("分配老师结束");
        }

        private void btAdjustStudent_Click(object sender, EventArgs e)
        {
            if(DataManager.ProfessionalMasterGroup.Count == 0 && DataManager.AcademicMasterGroup.Count == 0)
            {
                MessageBox.Show("学生还没有分组，无法调整");
                return;
            }
            AdjustStudent adjustStudent = new AdjustStudent();
            adjustStudent.ShowDialog();
            Console.WriteLine("调整学生分组结束");
        }

        private void clearFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataManager.ClearData();
            MessageBox.Show("清空数据完成");
            //this.dgvShowStudent.Visible = false;
            //this.btSeparate.Visible = false;
            //this.cbGroupNumber.Visible = false;
            //this.cbStudentType.Visible = false;
            //this.btDispatchTeacher.Visible = false;
            //this.btAdjustStudent.Visible = false;
            //this.btManagerTeacher.Visible = false;
            //this.btScoreManager.Visible = false;
            //this.cbStudentType.SelectedIndex = -1;
            //this.cbGroupNumber.SelectedIndex = -1;
        }

        private void openServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int port = 1234;
            posSocket.StartServer(port);
            MessageBox.Show("服务器开启成功，端口号为" + port);
        }

        private void btManagerTeacher_Click(object sender, EventArgs e)
        {
            TeacherManager teacherManager = new TeacherManager();
            teacherManager.ShowDialog();
            Console.WriteLine("管理老师结束");
        }
        
        private void btScoreManager_Click(object sender, EventArgs e)
        {
            ScoreManager scoreManager = new ScoreManager();
            scoreManager.ShowDialog();
            Console.WriteLine("学生分数管理结束");
        }

        private void readDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 老师信息
            DataTable dataTable = MysqlManager.SelectData("teacher_information");
            DataManager.LoadTeacherFromSQL(dataTable);
            // 学生信息
            dataTable = MysqlManager.SelectData("student_information");
            DataManager.LoadStudentFromSQL(dataTable);
            cbStudentType.SelectedIndex = -1;
            cbStudentType.SelectedIndex = 0;
            MessageBox.Show("读取数据库完成");
        }

        private void writeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataManager.SaveTeacherToSQL();
            DataManager.SaveStudentToSQL();
            MessageBox.Show("写入数据库完成");
        }

        private void readSchoolTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdLoadSchoolType.ShowDialog() == DialogResult.OK)
            {
                DataManager.LoadSchoolTypeFromExcel(ofdLoadSchoolType.FileName);
                MessageBox.Show("高校类型加载成功");
            }
        }

        private void readComputerAndListenScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdLoadSchoolType.ShowDialog() == DialogResult.OK)
            {
                DataManager.LoadComputerAndListenScoreFromExcel(ofdLoadSchoolType.FileName);
                MessageBox.Show("上机成绩和听力成绩加载成功");
            }
        }

        private void loginTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherLogin teacherLogin = new TeacherLogin();
            teacherLogin.ShowDialog();
        }

        private void studentScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentScore studentScore = new StudentScore();
            studentScore.ShowDialog();
        }
    }
}