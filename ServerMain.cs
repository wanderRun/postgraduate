using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;//引入Socket的命名空间
using System.Threading;//引入线程的命名空间

namespace Server
{
    public partial class ServerMain : Form
    {
        public ServerMain()
        {
            InitializeComponent();
        }

        PosSocket posSocket = new PosSocket();
        RedisManager redisManager = new RedisManager();

        public delegate void AppendMsgEventHandler(RichTextBox rb, string msg);//定义在线程中操作不同线程创建的控件的委托
        public delegate void AppendUserEventHandler(ListBox lb, string username);

        //开启服务器
        private void btStartServer_Click(object sender, EventArgs e)
        {
            posSocket.ServerFlag = true;
            posSocket.StartServer(1234);
            UpdateMsg("服务器开始监听1234.\n");

            //posSocket.ServerFlag = true;
            //btStartServer.Enabled = false;
            //btStopServer.Enabled = true;
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
            //将刚连接的用户名加入到当前在线用户列表中
            // this.lbOnlineUser.Items.Remove(name);
            // this.tslOnlineUserNum.Text = System.Convert.ToString(clients.Count);
        }

        //停止服务器
        private void btStopServer_Click(object sender, EventArgs e)
        {
            posSocket.ServerFlag = false;
            //btStartServer.Enabled = true;
            //btStopServer.Enabled = false;

            UpdateMsg("服务器已经停止监听.\n");
        }

        //关闭窗体
        private void FrmServerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            posSocket.ServerFlag = false;
        }

        private void ServerMain_Load(object sender, EventArgs e)
        {

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