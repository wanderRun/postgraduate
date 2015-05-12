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
            cbStudentType.Items.Add("全部学生");
            cbStudentType.Items.Add("专业硕士");
            cbStudentType.Items.Add("学术硕士");
            cbGroupNumber.Items.Add("全部学生");
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

        public delegate void AppendMsgEventHandler(RichTextBox rb, string msg);//定义在线程中操作不同线程创建的控件的委托
        public delegate void AppendUserEventHandler(ListBox lb, string username);

        //开启服务器
        private void btStartServer_Click(object sender, EventArgs e)
        {
            // posSocket.ServerFlag = true;
            posSocket.StartServer(1234);
            UpdateMsg("服务器开始监听1234.\n");
        }

        /// <summary>
        /// 更新显示信息
        /// </summary>
        /// <param name="msg"></param>
        public void UpdateMsg(string msg)
        {
            Invoke(new AppendMsgEventHandler(AppendMsgEvent), rbChatContent, msg + "\n");
        }

        /// <summary>
        /// 添加用户更新界面
        /// </summary>
        /// <param name="name"></param>
        public void AddUser(string name)
        {
            string str = "【" + name + "】" + "已经加入聊天！\n";
            Invoke(new AppendMsgEventHandler(AppendMsgEvent), rbChatContent, str);  //AppendMsgEvent(rbChatContent,"【" + name + "】" + "已经加入聊天！\n");
            //将刚加入的用户添加进用户列表

            // Invoke(new AppendUserEventHandler(AppendUserEvent), lbOnlineUser, name);

            // this.tslOnlineUserNum.Text = Convert.ToString(clients.Count);
        }

        public void AppendMsgEvent(RichTextBox rb, string msg)
        {
            rb.AppendText(msg);
        }
        public void AppendUserEvent(ListBox lb, string username)
        {
            lb.Items.Add(username);
        }

        /// <summary>
        /// 移出用户
        /// </summary>
        /// <param name="name"></param>
        public void RemoveUser(string name)
        {
            this.rbChatContent.AppendText(name + " 已经离开聊天室\n");
        }

        //停止服务器
        private void btStopServer_Click(object sender, EventArgs e)
        {
            UpdateMsg("服务器已经停止监听.\n");
        }

        //关闭窗体
        private void FrmServerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // posSocket.ServerFlag = false;
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
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sfdSaveFile.ShowDialog() == DialogResult.OK)
            {
                string name = sfdSaveFile.FileName;
                DataManager.SaveDataFromExcel(name);
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
            tbGroupNumber.Text = "";
        }

        private void cbStudentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("大类选择的序号是{0}", cbStudentType.SelectedIndex);
            this.lvShowStudent.Clear();
            this.lvShowStudent.BeginUpdate();
            this.InitializeListView();
            cbGroupNumber.Items.Clear();
            cbGroupNumber.Items.Add("全部学生");
            if (cbStudentType.SelectedIndex == 0)
            {
                for (int i = 0; i < DataManager.Students.student.Count; ++i)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = DataManager.Students.student[i].apply_place;
                    lvi.SubItems.Add(DataManager.Students.student[i].aplly_number);
                    lvi.SubItems.Add(DataManager.Students.student[i].name);
                    lvi.SubItems.Add(DataManager.Students.student[i].name_spell);
                    lvi.SubItems.Add(DataManager.Students.student[i].number);
                    lvi.SubItems.Add(DataManager.Students.student[i].card_type);
                    lvi.SubItems.Add(DataManager.Students.student[i].card_number);
                    lvi.SubItems.Add(DataManager.Students.student[i].birth);
                    lvi.SubItems.Add(DataManager.Students.student[i].nation);
                    lvi.SubItems.Add(DataManager.Students.student[i].gender);
                    lvi.SubItems.Add(DataManager.Students.student[i].marriage);
                    lvi.SubItems.Add(DataManager.Students.student[i].soldier);
                    lvi.SubItems.Add(DataManager.Students.student[i].politics_status);
                    lvi.SubItems.Add(DataManager.Students.student[i].native_place);
                    lvi.SubItems.Add(DataManager.Students.student[i].birth_place);
                    lvi.SubItems.Add(DataManager.Students.student[i].register_place);
                    lvi.SubItems.Add(DataManager.Students.student[i].register_address);
                    lvi.SubItems.Add(DataManager.Students.student[i].record_place);
                    lvi.SubItems.Add(DataManager.Students.student[i].record_ministry);
                    lvi.SubItems.Add(DataManager.Students.student[i].record_address);
                    lvi.SubItems.Add(DataManager.Students.student[i].record_place_postcode);
                    lvi.SubItems.Add(DataManager.Students.student[i].work_place);
                    lvi.SubItems.Add(DataManager.Students.student[i].work_experience);
                    lvi.SubItems.Add(DataManager.Students.student[i].reward_punishment);
                    lvi.SubItems.Add(DataManager.Students.student[i].family);
                    lvi.SubItems.Add(DataManager.Students.student[i].contact_address);
                    lvi.SubItems.Add(DataManager.Students.student[i].contact_postcode);
                    lvi.SubItems.Add(DataManager.Students.student[i].fixed_line_phone);
                    lvi.SubItems.Add(DataManager.Students.student[i].mobile_phone);
                    lvi.SubItems.Add(DataManager.Students.student[i].email);
                    lvi.SubItems.Add(DataManager.Students.student[i].source);
                    lvi.SubItems.Add(DataManager.Students.student[i].same_education.ToString());
                    lvi.SubItems.Add(DataManager.Students.student[i].school_code);
                    lvi.SubItems.Add(DataManager.Students.student[i].school_name);
                    lvi.SubItems.Add(DataManager.Students.student[i].major_name);
                    lvi.SubItems.Add(DataManager.Students.student[i].study_type);
                    lvi.SubItems.Add(DataManager.Students.student[i].last_education);
                    lvi.SubItems.Add(DataManager.Students.student[i].diploma_number);
                    lvi.SubItems.Add(DataManager.Students.student[i].graduate_date);
                    lvi.SubItems.Add(DataManager.Students.student[i].register_number);
                    lvi.SubItems.Add(DataManager.Students.student[i].last_degree);
                    lvi.SubItems.Add(DataManager.Students.student[i].graduate_number);
                    lvi.SubItems.Add(DataManager.Students.student[i].adjust_major_code);
                    lvi.SubItems.Add(DataManager.Students.student[i].adjust_major_name);
                    lvi.SubItems.Add(DataManager.Students.student[i].apply_place_code);
                    lvi.SubItems.Add(DataManager.Students.student[i].apply_faculty);
                    lvi.SubItems.Add(DataManager.Students.student[i].apply_faculty_name);
                    lvi.SubItems.Add(DataManager.Students.student[i].apply_major_code);
                    lvi.SubItems.Add(DataManager.Students.student[i].apply_major_name);
                    lvi.SubItems.Add(DataManager.Students.student[i].apply_work_direction);
                    lvi.SubItems.Add(DataManager.Students.student[i].apply_work_direction_name);
                    lvi.SubItems.Add(DataManager.Students.student[i].exam_type);
                    lvi.SubItems.Add(DataManager.Students.student[i].special_plan);
                    lvi.SubItems.Add(DataManager.Students.student[i].apply_type);
                    lvi.SubItems.Add(DataManager.Students.student[i].orientation_train_place_code);
                    lvi.SubItems.Add(DataManager.Students.student[i].orientation_train_place);
                    lvi.SubItems.Add(DataManager.Students.student[i].standby_information);
                    lvi.SubItems.Add(DataManager.Students.student[i].standby_information_one);
                    lvi.SubItems.Add(DataManager.Students.student[i].standby_information_two);
                    lvi.SubItems.Add(DataManager.Students.student[i].standby_information_three);
                    lvi.SubItems.Add(DataManager.Students.student[i].political_code);
                    lvi.SubItems.Add(DataManager.Students.student[i].political_name);
                    lvi.SubItems.Add(DataManager.Students.student[i].foreign_code);
                    lvi.SubItems.Add(DataManager.Students.student[i].foreign_name);
                    lvi.SubItems.Add(DataManager.Students.student[i].business_one_code);
                    lvi.SubItems.Add(DataManager.Students.student[i].business_one_name);
                    lvi.SubItems.Add(DataManager.Students.student[i].business_two_code);
                    lvi.SubItems.Add(DataManager.Students.student[i].business_two_name);
                    lvi.SubItems.Add(DataManager.Students.student[i].political_score.ToString());
                    lvi.SubItems.Add(DataManager.Students.student[i].foreign_score.ToString());
                    lvi.SubItems.Add(DataManager.Students.student[i].business_one_score.ToString());
                    lvi.SubItems.Add(DataManager.Students.student[i].business_two_score.ToString());
                    lvi.SubItems.Add(DataManager.Students.student[i].total_score.ToString());
                    lvi.SubItems.Add(DataManager.Students.student[i].volunteer_type);
                    lvi.SubItems.Add(DataManager.Students.student[i].tutor);
                    lvi.SubItems.Add(DataManager.Students.student[i].student_confirm_status);
                    lvi.SubItems.Add(DataManager.Students.student[i].student_confirm_time.ToString());
                    lvi.SubItems.Add(DataManager.Students.student[i].student_reexamine);
                    lvShowStudent.Items.Add(lvi);
                }
            }
            else if (cbStudentType.SelectedIndex == 1)
            {
                for (int i = 1; i <= DataManager.ProfessionalMasterGroup.Count; ++i)
                {
                    cbGroupNumber.Items.Add("第" + i + "组");
                }
                for (int i = 0; i < DataManager.ProfessionalMaster.Count; ++i)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = DataManager.ProfessionalMaster[i].apply_place;
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].aplly_number);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].name_spell);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].number);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].card_type);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].card_number);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].birth);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].nation);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].gender);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].marriage);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].soldier);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].politics_status);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].native_place);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].birth_place);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].register_place);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].register_address);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].record_place);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].record_ministry);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].record_address);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].record_place_postcode);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].work_place);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].work_experience);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].reward_punishment);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].family);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].contact_address);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].contact_postcode);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].fixed_line_phone);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].mobile_phone);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].email);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].source);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].same_education.ToString());
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].school_code);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].school_name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].major_name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].study_type);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].last_education);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].diploma_number);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].graduate_date);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].register_number);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].last_degree);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].graduate_number);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].adjust_major_code);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].adjust_major_name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_place_code);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_faculty);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_faculty_name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_major_code);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_major_name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_work_direction);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_work_direction_name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].exam_type);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].special_plan);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_type);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].orientation_train_place_code);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].orientation_train_place);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].standby_information);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].standby_information_one);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].standby_information_two);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].standby_information_three);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].political_code);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].political_name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].foreign_code);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].foreign_name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_one_code);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_one_name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_two_code);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_two_name);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].political_score.ToString());
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].foreign_score.ToString());
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_one_score.ToString());
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_two_score.ToString());
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].total_score.ToString());
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].volunteer_type);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].tutor);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].student_confirm_status);
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].student_confirm_time.ToString());
                    lvi.SubItems.Add(DataManager.ProfessionalMaster[i].student_reexamine);
                    lvShowStudent.Items.Add(lvi);
                }
            }
            else if (cbStudentType.SelectedIndex == 2)
            {
                for (int i = 1; i <= DataManager.AcademicMasterGroup.Count; ++i)
                {
                    cbGroupNumber.Items.Add("第" + i + "组");
                }
                for (int i = 0; i < DataManager.AcademicMaster.Count; ++i)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = DataManager.AcademicMaster[i].apply_place;
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].aplly_number);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].name_spell);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].number);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].card_type);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].card_number);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].birth);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].nation);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].gender);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].marriage);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].soldier);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].politics_status);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].native_place);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].birth_place);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].register_place);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].register_address);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].record_place);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].record_ministry);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].record_address);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].record_place_postcode);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].work_place);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].work_experience);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].reward_punishment);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].family);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].contact_address);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].contact_postcode);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].fixed_line_phone);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].mobile_phone);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].email);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].source);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].same_education.ToString());
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].school_code);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].school_name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].major_name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].study_type);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].last_education);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].diploma_number);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].graduate_date);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].register_number);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].last_degree);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].graduate_number);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].adjust_major_code);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].adjust_major_name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_place_code);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_faculty);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_faculty_name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_major_code);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_major_name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_work_direction);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_work_direction_name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].exam_type);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].special_plan);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_type);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].orientation_train_place_code);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].orientation_train_place);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].standby_information);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].standby_information_one);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].standby_information_two);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].standby_information_three);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].political_code);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].political_name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].foreign_code);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].foreign_name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].business_one_code);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].business_one_name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].business_two_code);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].business_two_name);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].political_score.ToString());
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].foreign_score.ToString());
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].business_one_score.ToString());
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].business_two_score.ToString());
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].total_score.ToString());
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].volunteer_type);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].tutor);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].student_confirm_status);
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].student_confirm_time.ToString());
                    lvi.SubItems.Add(DataManager.AcademicMaster[i].student_reexamine);
                    lvShowStudent.Items.Add(lvi);
                }
            }
            this.lvShowStudent.EndUpdate();
            cbGroupNumber.SelectedIndex = 0;
        }

        private void cbGroupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("小类选择的序号是{0}", cbGroupNumber.SelectedIndex);
            this.lvShowStudent.Clear();
            this.lvShowStudent.BeginUpdate();
            this.InitializeListView();
            if (cbGroupNumber.SelectedIndex == 0)
            {
                if (cbStudentType.SelectedIndex == 0)
                {
                    for (int i = 0; i < DataManager.Students.student.Count; ++i)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = DataManager.Students.student[i].apply_place;
                        lvi.SubItems.Add(DataManager.Students.student[i].aplly_number);
                        lvi.SubItems.Add(DataManager.Students.student[i].name);
                        lvi.SubItems.Add(DataManager.Students.student[i].name_spell);
                        lvi.SubItems.Add(DataManager.Students.student[i].number);
                        lvi.SubItems.Add(DataManager.Students.student[i].card_type);
                        lvi.SubItems.Add(DataManager.Students.student[i].card_number);
                        lvi.SubItems.Add(DataManager.Students.student[i].birth);
                        lvi.SubItems.Add(DataManager.Students.student[i].nation);
                        lvi.SubItems.Add(DataManager.Students.student[i].gender);
                        lvi.SubItems.Add(DataManager.Students.student[i].marriage);
                        lvi.SubItems.Add(DataManager.Students.student[i].soldier);
                        lvi.SubItems.Add(DataManager.Students.student[i].politics_status);
                        lvi.SubItems.Add(DataManager.Students.student[i].native_place);
                        lvi.SubItems.Add(DataManager.Students.student[i].birth_place);
                        lvi.SubItems.Add(DataManager.Students.student[i].register_place);
                        lvi.SubItems.Add(DataManager.Students.student[i].register_address);
                        lvi.SubItems.Add(DataManager.Students.student[i].record_place);
                        lvi.SubItems.Add(DataManager.Students.student[i].record_ministry);
                        lvi.SubItems.Add(DataManager.Students.student[i].record_address);
                        lvi.SubItems.Add(DataManager.Students.student[i].record_place_postcode);
                        lvi.SubItems.Add(DataManager.Students.student[i].work_place);
                        lvi.SubItems.Add(DataManager.Students.student[i].work_experience);
                        lvi.SubItems.Add(DataManager.Students.student[i].reward_punishment);
                        lvi.SubItems.Add(DataManager.Students.student[i].family);
                        lvi.SubItems.Add(DataManager.Students.student[i].contact_address);
                        lvi.SubItems.Add(DataManager.Students.student[i].contact_postcode);
                        lvi.SubItems.Add(DataManager.Students.student[i].fixed_line_phone);
                        lvi.SubItems.Add(DataManager.Students.student[i].mobile_phone);
                        lvi.SubItems.Add(DataManager.Students.student[i].email);
                        lvi.SubItems.Add(DataManager.Students.student[i].source);
                        lvi.SubItems.Add(DataManager.Students.student[i].same_education.ToString());
                        lvi.SubItems.Add(DataManager.Students.student[i].school_code);
                        lvi.SubItems.Add(DataManager.Students.student[i].school_name);
                        lvi.SubItems.Add(DataManager.Students.student[i].major_name);
                        lvi.SubItems.Add(DataManager.Students.student[i].study_type);
                        lvi.SubItems.Add(DataManager.Students.student[i].last_education);
                        lvi.SubItems.Add(DataManager.Students.student[i].diploma_number);
                        lvi.SubItems.Add(DataManager.Students.student[i].graduate_date);
                        lvi.SubItems.Add(DataManager.Students.student[i].register_number);
                        lvi.SubItems.Add(DataManager.Students.student[i].last_degree);
                        lvi.SubItems.Add(DataManager.Students.student[i].graduate_number);
                        lvi.SubItems.Add(DataManager.Students.student[i].adjust_major_code);
                        lvi.SubItems.Add(DataManager.Students.student[i].adjust_major_name);
                        lvi.SubItems.Add(DataManager.Students.student[i].apply_place_code);
                        lvi.SubItems.Add(DataManager.Students.student[i].apply_faculty);
                        lvi.SubItems.Add(DataManager.Students.student[i].apply_faculty_name);
                        lvi.SubItems.Add(DataManager.Students.student[i].apply_major_code);
                        lvi.SubItems.Add(DataManager.Students.student[i].apply_major_name);
                        lvi.SubItems.Add(DataManager.Students.student[i].apply_work_direction);
                        lvi.SubItems.Add(DataManager.Students.student[i].apply_work_direction_name);
                        lvi.SubItems.Add(DataManager.Students.student[i].exam_type);
                        lvi.SubItems.Add(DataManager.Students.student[i].special_plan);
                        lvi.SubItems.Add(DataManager.Students.student[i].apply_type);
                        lvi.SubItems.Add(DataManager.Students.student[i].orientation_train_place_code);
                        lvi.SubItems.Add(DataManager.Students.student[i].orientation_train_place);
                        lvi.SubItems.Add(DataManager.Students.student[i].standby_information);
                        lvi.SubItems.Add(DataManager.Students.student[i].standby_information_one);
                        lvi.SubItems.Add(DataManager.Students.student[i].standby_information_two);
                        lvi.SubItems.Add(DataManager.Students.student[i].standby_information_three);
                        lvi.SubItems.Add(DataManager.Students.student[i].political_code);
                        lvi.SubItems.Add(DataManager.Students.student[i].political_name);
                        lvi.SubItems.Add(DataManager.Students.student[i].foreign_code);
                        lvi.SubItems.Add(DataManager.Students.student[i].foreign_name);
                        lvi.SubItems.Add(DataManager.Students.student[i].business_one_code);
                        lvi.SubItems.Add(DataManager.Students.student[i].business_one_name);
                        lvi.SubItems.Add(DataManager.Students.student[i].business_two_code);
                        lvi.SubItems.Add(DataManager.Students.student[i].business_two_name);
                        lvi.SubItems.Add(DataManager.Students.student[i].political_score.ToString());
                        lvi.SubItems.Add(DataManager.Students.student[i].foreign_score.ToString());
                        lvi.SubItems.Add(DataManager.Students.student[i].business_one_score.ToString());
                        lvi.SubItems.Add(DataManager.Students.student[i].business_two_score.ToString());
                        lvi.SubItems.Add(DataManager.Students.student[i].total_score.ToString());
                        lvi.SubItems.Add(DataManager.Students.student[i].volunteer_type);
                        lvi.SubItems.Add(DataManager.Students.student[i].tutor);
                        lvi.SubItems.Add(DataManager.Students.student[i].student_confirm_status);
                        lvi.SubItems.Add(DataManager.Students.student[i].student_confirm_time.ToString());
                        lvi.SubItems.Add(DataManager.Students.student[i].student_reexamine);
                        lvShowStudent.Items.Add(lvi);
                    }
                }
                else if (cbStudentType.SelectedIndex == 1)
                {
                    for (int i = 0; i < DataManager.ProfessionalMaster.Count; ++i)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = DataManager.ProfessionalMaster[i].apply_place;
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].aplly_number);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].name_spell);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].number);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].card_type);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].card_number);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].birth);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].nation);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].gender);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].marriage);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].soldier);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].politics_status);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].native_place);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].birth_place);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].register_place);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].register_address);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].record_place);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].record_ministry);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].record_address);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].record_place_postcode);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].work_place);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].work_experience);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].reward_punishment);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].family);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].contact_address);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].contact_postcode);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].fixed_line_phone);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].mobile_phone);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].email);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].source);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].same_education.ToString());
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].school_code);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].school_name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].major_name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].study_type);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].last_education);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].diploma_number);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].graduate_date);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].register_number);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].last_degree);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].graduate_number);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].adjust_major_code);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].adjust_major_name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_place_code);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_faculty);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_faculty_name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_major_code);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_major_name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_work_direction);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_work_direction_name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].exam_type);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].special_plan);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].apply_type);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].orientation_train_place_code);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].orientation_train_place);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].standby_information);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].standby_information_one);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].standby_information_two);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].standby_information_three);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].political_code);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].political_name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].foreign_code);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].foreign_name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_one_code);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_one_name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_two_code);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_two_name);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].political_score.ToString());
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].foreign_score.ToString());
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_one_score.ToString());
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].business_two_score.ToString());
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].total_score.ToString());
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].volunteer_type);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].tutor);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].student_confirm_status);
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].student_confirm_time.ToString());
                        lvi.SubItems.Add(DataManager.ProfessionalMaster[i].student_reexamine);
                        lvShowStudent.Items.Add(lvi);
                    }
                }
                else if (cbStudentType.SelectedIndex == 2)
                {
                    for (int i = 0; i < DataManager.AcademicMaster.Count; ++i)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = DataManager.AcademicMaster[i].apply_place;
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].aplly_number);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].name_spell);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].number);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].card_type);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].card_number);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].birth);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].nation);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].gender);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].marriage);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].soldier);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].politics_status);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].native_place);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].birth_place);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].register_place);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].register_address);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].record_place);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].record_ministry);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].record_address);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].record_place_postcode);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].work_place);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].work_experience);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].reward_punishment);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].family);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].contact_address);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].contact_postcode);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].fixed_line_phone);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].mobile_phone);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].email);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].source);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].same_education.ToString());
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].school_code);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].school_name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].major_name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].study_type);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].last_education);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].diploma_number);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].graduate_date);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].register_number);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].last_degree);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].graduate_number);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].adjust_major_code);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].adjust_major_name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_place_code);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_faculty);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_faculty_name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_major_code);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_major_name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_work_direction);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_work_direction_name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].exam_type);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].special_plan);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].apply_type);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].orientation_train_place_code);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].orientation_train_place);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].standby_information);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].standby_information_one);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].standby_information_two);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].standby_information_three);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].political_code);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].political_name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].foreign_code);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].foreign_name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].business_one_code);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].business_one_name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].business_two_code);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].business_two_name);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].political_score.ToString());
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].foreign_score.ToString());
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].business_one_score.ToString());
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].business_two_score.ToString());
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].total_score.ToString());
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].volunteer_type);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].tutor);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].student_confirm_status);
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].student_confirm_time.ToString());
                        lvi.SubItems.Add(DataManager.AcademicMaster[i].student_reexamine);
                        lvShowStudent.Items.Add(lvi);
                    }
                }
            }
            this.lvShowStudent.EndUpdate();
        }

        private void btAdjustGroups_Click(object sender, EventArgs e)
        {
        }
    }
}