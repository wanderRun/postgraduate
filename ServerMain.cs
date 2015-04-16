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
            ch.Text = "序号";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生编号";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "考生姓名";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "毕业学校名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "学校类型";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "外国语";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "政治";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "业务课一";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "业务课二名称";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "业务课二";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "初试总分";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "上机成绩百分制";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "听力";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "是否一志愿";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "本科院校";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "自我介绍";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "翻译";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "TOPIC";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "回答提问";
            lvShowStudent.Columns.Add(ch);
            ch = new ColumnHeader();
            ch.Text = "面试(总评分)";
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
                ExcelManager excel = new ExcelManager();
                excel.LoadWPSExcel(name);
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