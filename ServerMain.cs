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
            this.InitializeListView();
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
            ofdOpenFile.Filter = "所有文件(*.*)|*.*|Excel 文件(*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;*.xlw;)|*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;*.xlw";
            if(ofdOpenFile.ShowDialog() == DialogResult.OK)
            {
                string name = ofdOpenFile.FileName;
                ExcelManager.Load(name);
                this.lvShowStudent.BeginUpdate();
                for (int i = 0; i < ExcelManager.Students.student.Count; ++i)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = ExcelManager.Students.student[i].apply_place;
                    lvi.SubItems.Add(ExcelManager.Students.student[i].aplly_number);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].name_spell);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].number);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].card_type);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].card_number);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].birth);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].nation);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].gender);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].marriage);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].soldier);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].politics_status);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].native_place);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].birth_place);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].register_place);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].register_address);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].record_place);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].record_ministry);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].record_address);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].record_place_postcode);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].work_place);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].work_experience);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].reward_punishment);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].family);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].contact_address);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].contact_postcode);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].fixed_line_phone);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].mobile_phone);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].email);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].source);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].same_education.ToString());
                    lvi.SubItems.Add(ExcelManager.Students.student[i].school_code);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].school_name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].major_name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].study_type);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].last_education);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].diploma_number);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].graduate_date);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].register_number);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].last_degree);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].graduate_number);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].adjust_major_code);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].adjust_major_name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].apply_place_code);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].apply_faculty);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].apply_faculty_name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].apply_major_code);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].apply_major_name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].apply_work_direction);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].apply_work_direction_name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].exam_type);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].special_plan);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].apply_type);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].orientation_train_place_code);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].orientation_train_place);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].standby_information);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].standby_information_one);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].standby_information_two);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].standby_information_three);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].political_code);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].political_name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].foreign_code);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].foreign_name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].business_one_code);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].business_one_name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].business_two_code);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].business_two_name);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].political_score.ToString());
                    lvi.SubItems.Add(ExcelManager.Students.student[i].foreign_score.ToString());
                    lvi.SubItems.Add(ExcelManager.Students.student[i].business_one_score.ToString());
                    lvi.SubItems.Add(ExcelManager.Students.student[i].business_two_score.ToString());
                    lvi.SubItems.Add(ExcelManager.Students.student[i].total_score.ToString());
                    lvi.SubItems.Add(ExcelManager.Students.student[i].volunteer_type);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].tutor);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].student_confirm_status);
                    lvi.SubItems.Add(ExcelManager.Students.student[i].student_confirm_time.ToString());
                    lvi.SubItems.Add(ExcelManager.Students.student[i].student_reexamine);
                    lvShowStudent.Items.Add(lvi);
                }
                this.lvShowStudent.EndUpdate();
            }
        }

    }

    public class ChatClient
    {
        private string name;
        private Socket currentSocket = null;
        private string ipAddress;
        private PosSocket server;

        //保留当前连接的状态
        //CLOSED-->CONNECTED-->CLOSED

        string connState = "closed";

        //public ChatClient(PosSocket server, Socket currentSocket)
        //{
        //    this.server = server;
        //    this.currentSocket = currentSocket;
        //}

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Socket CurrentSocket
        {
            get { return currentSocket; }
            set { currentSocket = value; }
        }
        public string IpAddress
        {
            get { return ipAddress; }
        }
        //获取远程IP地址
        private string getRemoteIp()
        {
            return ((IPEndPoint)currentSocket.RemoteEndPoint).Address.ToString();
        }


    }

}