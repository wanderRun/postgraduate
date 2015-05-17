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
        }

        /// <summary>
        /// 初始化列表
        /// </summary>
        private void InitializeListView()
        {
            ColumnHeader ch = new ColumnHeader();
            ch.Text = "报名点代码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生报名号";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生姓名";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生姓名拼音";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生编号";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "证件类型";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "证件号码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "出生日期";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "民族";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "性别";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "婚否";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "现役军人";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "政治面貌";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "籍贯所在地码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "出生地码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "户口所在地码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "户口所在地详细地址";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生档案所在地码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生档案所在单位";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生档案所在单位地址";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生档案所在单位邮政编码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "现在学习或工作单位";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "学习与工作经历";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "何时何地何原因受过何种奖励或处分（含研究生招生考试中的违纪处理结果）";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "家庭主要成员";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生通讯地址";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生通讯地址邮政编码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "固定电话";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "移动电话";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "电子信箱";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生来源";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "是否同等学历";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "毕业学校代码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "毕业学校名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "毕业专业名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "取得最后学历的学习形式";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "最后学历";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "毕业证书编号";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "获得最后学历毕业年月";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "注册学号";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "最后学位";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "学位证书编号";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "调剂前报考专业代码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "调剂前报考专业名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "报考单位代码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "报考院系所码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "报考院系所名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "报考专业代码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "报考专业名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "报考研究方向码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "报考研究方向名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考试方式";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "专项计划";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "报考类别";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "定向委培单位所在地码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "定向委培单位";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "备用信息";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "备用信息1";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "备用信息2";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "备用信息3";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "政治理论码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "政治理论名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "外国语码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "外国语名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "业务课一码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "业务课一名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "业务课二码";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "业务课二名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "政治理论成绩";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "外国语成绩";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "业务课一成绩";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "业务课二成绩";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "总分";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "志愿类别";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "导师";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生确认状态";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生确认时间";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "复试科目";
            lvShowStudent.Columns.Add(ch);
        }

        PosSocket posSocket = new PosSocket();
        RedisManager redisManager = new RedisManager();
        
        //关闭窗体
        private void FrmServerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void ServerMain_Load(object sender, EventArgs e)
        {

        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ofdOpenFile.ShowDialog() == DialogResult.OK)
            {
                string name = ofdOpenFile.FileName;
                DataManager.Load(name);
                this.lvShowStudent.Visible = true;
                this.btSeparate.Visible = true;
                this.tbGroupNumber.Visible = true;
                this.cbGroupNumber.Visible = true;
                this.cbStudentType.Visible = true;
                this.cbStudentType.SelectedIndex = 0;
                this.btDispatchTeacher.Visible = true;
                this.btAdjustStudent.Visible = true;
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
            if(tbGroupNumber.Text == "" || tbGroupNumber.Text == "0")
            {
                MessageBox.Show("分组不能为零或空");
                return;
            }
            if(cbStudentType.SelectedIndex == 0)
            {
                MessageBox.Show("全部学生不能分组");
                return;
            }
            int number = Convert.ToInt32(tbGroupNumber.Text);
            DataManager.DivideIntoGroups(cbStudentType.SelectedIndex, number);
            if(cbStudentType.SelectedIndex == 1)
            {
                cbGroupNumber.Items.Clear();
                cbGroupNumber.Items.Add("全部学生");
                for(int i = 1; i <= DataManager.ProfessionalMasterGroup.Count; ++i)
                {
                    cbGroupNumber.Items.Add("第" + i + "组");
                }
                cbGroupNumber.SelectedIndex = 0;
            }
            else if (cbStudentType.SelectedIndex == 2)
            {
                cbGroupNumber.Items.Clear();
                cbGroupNumber.Items.Add("全部学生");
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
            Console.WriteLine("大类选择的序号是{0}", cbStudentType.SelectedIndex);
            this.lvShowStudent.Clear();
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
            this.lvShowStudent.BeginUpdate();
            this.InitializeListView();
            for (int i = 0; i < student.Count; ++i)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = student[i].apply_place;
                lvi.SubItems.Add(student[i].aplly_number);
                lvi.SubItems.Add(student[i].name);
                lvi.SubItems.Add(student[i].name_spell);
                lvi.SubItems.Add(student[i].number);
                lvi.SubItems.Add(student[i].card_type);
                lvi.SubItems.Add(student[i].card_number);
                lvi.SubItems.Add(student[i].birth);
                lvi.SubItems.Add(student[i].nation);
                lvi.SubItems.Add(student[i].gender);
                lvi.SubItems.Add(student[i].marriage);
                lvi.SubItems.Add(student[i].soldier);
                lvi.SubItems.Add(student[i].politics_status);
                lvi.SubItems.Add(student[i].native_place);
                lvi.SubItems.Add(student[i].birth_place);
                lvi.SubItems.Add(student[i].register_place);
                lvi.SubItems.Add(student[i].register_address);
                lvi.SubItems.Add(student[i].record_place);
                lvi.SubItems.Add(student[i].record_ministry);
                lvi.SubItems.Add(student[i].record_address);
                lvi.SubItems.Add(student[i].record_place_postcode);
                lvi.SubItems.Add(student[i].work_place);
                lvi.SubItems.Add(student[i].work_experience);
                lvi.SubItems.Add(student[i].reward_punishment);
                lvi.SubItems.Add(student[i].family);
                lvi.SubItems.Add(student[i].contact_address);
                lvi.SubItems.Add(student[i].contact_postcode);
                lvi.SubItems.Add(student[i].fixed_line_phone);
                lvi.SubItems.Add(student[i].mobile_phone);
                lvi.SubItems.Add(student[i].email);
                lvi.SubItems.Add(student[i].source);
                lvi.SubItems.Add(student[i].same_education.ToString());
                lvi.SubItems.Add(student[i].school_code);
                lvi.SubItems.Add(student[i].school_name);
                lvi.SubItems.Add(student[i].major_name);
                lvi.SubItems.Add(student[i].study_type);
                lvi.SubItems.Add(student[i].last_education);
                lvi.SubItems.Add(student[i].diploma_number);
                lvi.SubItems.Add(student[i].graduate_date);
                lvi.SubItems.Add(student[i].register_number);
                lvi.SubItems.Add(student[i].last_degree);
                lvi.SubItems.Add(student[i].graduate_number);
                lvi.SubItems.Add(student[i].adjust_major_code);
                lvi.SubItems.Add(student[i].adjust_major_name);
                lvi.SubItems.Add(student[i].apply_place_code);
                lvi.SubItems.Add(student[i].apply_faculty);
                lvi.SubItems.Add(student[i].apply_faculty_name);
                lvi.SubItems.Add(student[i].apply_major_code);
                lvi.SubItems.Add(student[i].apply_major_name);
                lvi.SubItems.Add(student[i].apply_work_direction);
                lvi.SubItems.Add(student[i].apply_work_direction_name);
                lvi.SubItems.Add(student[i].exam_type);
                lvi.SubItems.Add(student[i].special_plan);
                lvi.SubItems.Add(student[i].apply_type);
                lvi.SubItems.Add(student[i].orientation_train_place_code);
                lvi.SubItems.Add(student[i].orientation_train_place);
                lvi.SubItems.Add(student[i].standby_information);
                lvi.SubItems.Add(student[i].standby_information_one);
                lvi.SubItems.Add(student[i].standby_information_two);
                lvi.SubItems.Add(student[i].standby_information_three);
                lvi.SubItems.Add(student[i].political_code);
                lvi.SubItems.Add(student[i].political_name);
                lvi.SubItems.Add(student[i].foreign_code);
                lvi.SubItems.Add(student[i].foreign_name);
                lvi.SubItems.Add(student[i].business_one_code);
                lvi.SubItems.Add(student[i].business_one_name);
                lvi.SubItems.Add(student[i].business_two_code);
                lvi.SubItems.Add(student[i].business_two_name);
                lvi.SubItems.Add(student[i].political_score.ToString());
                lvi.SubItems.Add(student[i].foreign_score.ToString());
                lvi.SubItems.Add(student[i].business_one_score.ToString());
                lvi.SubItems.Add(student[i].business_two_score.ToString());
                lvi.SubItems.Add(student[i].total_score.ToString());
                lvi.SubItems.Add(student[i].volunteer_type);
                lvi.SubItems.Add(student[i].tutor);
                lvi.SubItems.Add(student[i].student_confirm_status);
                lvi.SubItems.Add(student[i].student_confirm_time.ToString());
                lvi.SubItems.Add(student[i].student_reexamine);
                lvShowStudent.Items.Add(lvi);
            }
            this.lvShowStudent.EndUpdate();
            cbGroupNumber.SelectedIndex = 0;
        }

        private void cbGroupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("小类选择的序号是{0}", cbGroupNumber.SelectedIndex);
            this.lvShowStudent.Clear();
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
            this.lvShowStudent.BeginUpdate();
            this.InitializeListView();
            for (int i = 0; i < student.Count; ++i)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = student[i].apply_place;
                lvi.SubItems.Add(student[i].aplly_number);
                lvi.SubItems.Add(student[i].name);
                lvi.SubItems.Add(student[i].name_spell);
                lvi.SubItems.Add(student[i].number);
                lvi.SubItems.Add(student[i].card_type);
                lvi.SubItems.Add(student[i].card_number);
                lvi.SubItems.Add(student[i].birth);
                lvi.SubItems.Add(student[i].nation);
                lvi.SubItems.Add(student[i].gender);
                lvi.SubItems.Add(student[i].marriage);
                lvi.SubItems.Add(student[i].soldier);
                lvi.SubItems.Add(student[i].politics_status);
                lvi.SubItems.Add(student[i].native_place);
                lvi.SubItems.Add(student[i].birth_place);
                lvi.SubItems.Add(student[i].register_place);
                lvi.SubItems.Add(student[i].register_address);
                lvi.SubItems.Add(student[i].record_place);
                lvi.SubItems.Add(student[i].record_ministry);
                lvi.SubItems.Add(student[i].record_address);
                lvi.SubItems.Add(student[i].record_place_postcode);
                lvi.SubItems.Add(student[i].work_place);
                lvi.SubItems.Add(student[i].work_experience);
                lvi.SubItems.Add(student[i].reward_punishment);
                lvi.SubItems.Add(student[i].family);
                lvi.SubItems.Add(student[i].contact_address);
                lvi.SubItems.Add(student[i].contact_postcode);
                lvi.SubItems.Add(student[i].fixed_line_phone);
                lvi.SubItems.Add(student[i].mobile_phone);
                lvi.SubItems.Add(student[i].email);
                lvi.SubItems.Add(student[i].source);
                lvi.SubItems.Add(student[i].same_education.ToString());
                lvi.SubItems.Add(student[i].school_code);
                lvi.SubItems.Add(student[i].school_name);
                lvi.SubItems.Add(student[i].major_name);
                lvi.SubItems.Add(student[i].study_type);
                lvi.SubItems.Add(student[i].last_education);
                lvi.SubItems.Add(student[i].diploma_number);
                lvi.SubItems.Add(student[i].graduate_date);
                lvi.SubItems.Add(student[i].register_number);
                lvi.SubItems.Add(student[i].last_degree);
                lvi.SubItems.Add(student[i].graduate_number);
                lvi.SubItems.Add(student[i].adjust_major_code);
                lvi.SubItems.Add(student[i].adjust_major_name);
                lvi.SubItems.Add(student[i].apply_place_code);
                lvi.SubItems.Add(student[i].apply_faculty);
                lvi.SubItems.Add(student[i].apply_faculty_name);
                lvi.SubItems.Add(student[i].apply_major_code);
                lvi.SubItems.Add(student[i].apply_major_name);
                lvi.SubItems.Add(student[i].apply_work_direction);
                lvi.SubItems.Add(student[i].apply_work_direction_name);
                lvi.SubItems.Add(student[i].exam_type);
                lvi.SubItems.Add(student[i].special_plan);
                lvi.SubItems.Add(student[i].apply_type);
                lvi.SubItems.Add(student[i].orientation_train_place_code);
                lvi.SubItems.Add(student[i].orientation_train_place);
                lvi.SubItems.Add(student[i].standby_information);
                lvi.SubItems.Add(student[i].standby_information_one);
                lvi.SubItems.Add(student[i].standby_information_two);
                lvi.SubItems.Add(student[i].standby_information_three);
                lvi.SubItems.Add(student[i].political_code);
                lvi.SubItems.Add(student[i].political_name);
                lvi.SubItems.Add(student[i].foreign_code);
                lvi.SubItems.Add(student[i].foreign_name);
                lvi.SubItems.Add(student[i].business_one_code);
                lvi.SubItems.Add(student[i].business_one_name);
                lvi.SubItems.Add(student[i].business_two_code);
                lvi.SubItems.Add(student[i].business_two_name);
                lvi.SubItems.Add(student[i].political_score.ToString());
                lvi.SubItems.Add(student[i].foreign_score.ToString());
                lvi.SubItems.Add(student[i].business_one_score.ToString());
                lvi.SubItems.Add(student[i].business_two_score.ToString());
                lvi.SubItems.Add(student[i].total_score.ToString());
                lvi.SubItems.Add(student[i].volunteer_type);
                lvi.SubItems.Add(student[i].tutor);
                lvi.SubItems.Add(student[i].student_confirm_status);
                lvi.SubItems.Add(student[i].student_confirm_time.ToString());
                lvi.SubItems.Add(student[i].student_reexamine);
                lvShowStudent.Items.Add(lvi);
            }
            this.lvShowStudent.EndUpdate();
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
            this.lvShowStudent.Visible = false;
            this.btSeparate.Visible = false;
            this.tbGroupNumber.Visible = false;
            this.cbGroupNumber.Visible = false;
            this.cbStudentType.Visible = false;
            this.btDispatchTeacher.Visible = false;
            this.btAdjustStudent.Visible = false;
        }

        private void openServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int port = 1234;
            posSocket.StartServer(port);
            MessageBox.Show("服务器开启成功，端口号为" + port);
        }

        private void tbGroupNumber_Enter(object sender, EventArgs e)
        {
            tbGroupNumber.Text = "";
        }

        private void tbGroupNumber_Leave(object sender, EventArgs e)
        {
            if(tbGroupNumber.Text == "")
            {
                tbGroupNumber.Text = "分组数目";
            }
        }

        private void btAddTeacher_Click(object sender, EventArgs e)
        {
            AddTeacher addTeacher = new AddTeacher();
            addTeacher.ShowDialog();
            Console.WriteLine("添加老师结束");
        }
    }
}