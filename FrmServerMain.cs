using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;// 引入socket的命名空间
using System.Threading;// 引入线程的命名空间

namespace Server
{
    public partial class FrmServerMain : Form
    {
        // clients 数组保存当前在线用户的client对象
        internal static Hashtable clients = new Hashtable();

        // 该服务器默认的监听器
        private TcpListener listener;

        // 默认最大支持的客户端连接数
        static int MAX_USER = 100;

        // 服务器是否开启的标志
        internal static bool serverFlag = false;

        public FrmServerMain()
        {
            InitializeComponent();
        }

        public delegate void AppendMsgEventHandler(RichTextBox rb, string msg);// 定义在线程中操作不同线程创建的控件的委托

        public delegate void AppendUserEventHandler(ListBox lb, string userNamer);

        // 开启服务器
        private void btStartServer_Click(object sender, EventArgs e)
        {
            int iPort = this.ReturnValidPort(tbServerPort.Text.Trim());
            if (iPort < 0)
            {
                MessageBox.Show("错误的端口信息！", "错误提示");
                return;
            }

            string ip = this.ReturnIpAddress();

            try
            {
                IPAddress userIp = IPAddress.Parse(ip);

                // 创建服务器套接字
                listener = new TcpListener(userIp, iPort);
                listener.Start();

                this.rbChatContent.AppendText("服务器已经启动，正在监听" + ip
                    + "端口号：" + tbServerPort.Text + "......\n");

                FrmServerMain.serverFlag = true;
                // 以下方法启动一个新的线程，执行监听方法
                // 以便在一个独立的进程中执行确认与客户端连接的操作
                Thread thread = new Thread(StartListen);
                thread.Start();

                btStartServer.Enabled = false;
                btStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
                this.rbChatContent.AppendText(ex.Message + "\n");
            }
        }

        // 用于接收客户端的请求，确认与客户端的连接
        // 并且启动一个新的线程处理客户端的请求
        private void StartListen()
        {
            while (FrmServerMain.serverFlag)
            {
                try
                {
                    // 当接收到客户端请求时，确认与客户端的连接
                    if (listener.Pending())
                    {
                        Socket socket = listener.AcceptSocket();
                        if (clients.Count >= MAX_USER)
                        {
                            MessageBox.Show("连接数已经超过允许连接的最大数" 
                                + MAX_USER.ToString() + "，拒绝新的连接", "错误提示");
                            this.rbChatContent.AppendText(
                                "连接数已经超过允许连接的最大数" + MAX_USER.ToString() + "，拒绝新的连接");
                            socket.Close();
                        }
                        else
                        {
                            // 启动一个新的线程，处理用户相应的请求
                            ChatClient client = new ChatClient(this, socket);
                            Thread clientThread = new Thread(client.ClientService);
                            clientThread.Start();
                        }
                    }
                    Thread.Sleep(200);
                }
                catch (Exception e)
                {
                    this.UpdateMsg(e.Message);
                }
            }
        }

        // 获取有效的端口号
        private int ReturnValidPort(string strPort)
        {
            int port;
            // 测试端口号是否有效
            try
            {
                if (tbServerPort.Text == "")
                {
                    throw new ArgumentException("端口号为空，不能启动服务器");
                }
                else
                {
                    port = Convert.ToInt32(tbServerPort.Text.Trim());
                }
            }
            catch (Exception e)
            {
                this.rbChatContent.AppendText("无效的端口号：" + e.Message + "\n");
                return -1;
            }
            return port;
        }

        /// <summary>
        /// 获取本机局域网ip地址
        /// </summary>
        /// <returns></returns>
        private string ReturnIpAddress()
        {
            IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            if (addressList.Length < 1)
            {
                return "";
            }
            return addressList[0].ToString();
        }

        /// <summary>
        /// 获得拨号动态分配ip地址
        /// </summary>
        /// <returns></returns>
        private static string GetDynamicIpAddress()
        {
            IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            if (addressList.Length < 2)
            {
                return "";
            }
            return addressList[1].ToString();
        }

        /// <summary>
        /// 更新显示信息
        /// </summary>
        /// <param name="msg"></param>
        public void UpdateMsg(string msg)
        {
            Invoke(new AppendMsgEventHandler(AppendMsgEvent),
                rbChatContent, msg + "\n");
        }

        /// <summary>
        /// 添加用户更新界面
        /// </summary>
        /// <param name="name"></param>
        public void AddUser(string name)
        {
            string str = "【" + name + "】" + "已经加入聊天！\n";
            Invoke(new AppendMsgEventHandler(AppendMsgEvent), rbChatContent, str);
            // 将刚加入的用户添加进用户列表

            Invoke(new AppendUserEventHandler(AppendUserEvent),
                lbOnlineUser, name);

            this.tslOnlineUserNum.Text = Convert.ToString(clients.Count);
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
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public string GetUserList()
        {
            string userList = "";
            for(int i = 0; i < lbOnlineUser.Items.Count; ++i)
            {
                userList = userList + lbOnlineUser.Items[i].ToString() + "|";
            }
            return userList;
        }

        /// <summary>
        /// 移出用户
        /// </summary>
        /// <param name="name"></param>
        public void RemoveUser(string name)
        {
            this.rbChatContent.AppendText(name + " 已经离开聊天室\n");

            this.lbOnlineUser.Items.Remove(name);
            this.tslOnlineUserNum.Text = System.Convert.ToString(clients.Count);
        }
        
        private void btStopServer_Click(object sender, EventArgs e)
        {
            FrmServerMain.serverFlag = false;
            btStartServer.Enabled = true;
            btStopServer.Enabled = false;
            UpdateMsg("服务器已经停止监听。\n");
        }

        private void tbServerPort_TextChanged(object sender, EventArgs e)
        {
            this.btStartServer.Enabled = (this.tbServerPort.Text != "");
        }

        // 关闭窗体
        private void FrmServerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmServerMain.serverFlag = false;
        }
    }

    public class ChatClient
    {
        private string name;
        private Socket currentSocket = null;
        private string ipAddress;
        private FrmServerMain server;

        // 保留当前连接的状态
        // CLOSED --> CONNECTED --> CLOSED

        string connState = "closed";

        public ChatClient(FrmServerMain server, Socket currentSocket)
        {
            this.server = server;
            this.currentSocket = currentSocket;
        }

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

        // 获取远程ip地址
        private string getRemoteIp()
        {
            return ((IPEndPoint)currentSocket.RemoteEndPoint).Address.ToString();
        }

        // 与客户端进行数据通信，包括接收客户端的请求
        // 根据不同的请求命令，执行相应的操作，并将操作结果返回给客户端
        public void ClientService()
        {
            string[] acceptStr = null;// 保存消息字符
            byte[] buff = new byte[1024];// 缓冲区
            bool keepConnected = true;

            // 用循环不断地与客户端进行交互，直到其发出EXIT或者QUIT命令
            // 将keepConnect设置为false，退出循环，关闭当前连接，中止当前线程
            while(keepConnected && FrmServerMain.serverFlag)
            {
                acceptStr = null;
                try
                {
                    if(currentSocket == null || currentSocket.Available < 1)
                    {
                        Thread.Sleep(300);
                        continue;
                    }

                    // 以旧换新信息存入buff数组中
                    int length = currentSocket.Receive(buff);

                    // 将字符数组转换为字符串
                    string command = Encoding.Default.GetString(buff, 0, length);

                    // 将字符串按分隔符拆分
                    acceptStr = command.Split(new char[] { '|' });

                    if(acceptStr == null)
                    {
                        Thread.Sleep(200);
                        continue;
                    }
                }
                catch(Exception ex)
                {
                    server.UpdateMsg("程序发生异常，异常信息：" + ex.Message);
                }
                if(acceptStr[0] == "CONNECT")
                {
                    // 如果为CONNECT，刚它的命令格式为“CONNECT|发送者的用户名：附件信息”
                    // 刚acceptStr[1]保存的就是用户名
                    this.name = acceptStr[1];

                    if(FrmServerMain.clients.Contains(this.name))
                    {
                        SendToClient(this, "ERROR|USER" + this.name + "已经存在！");
                    }
                    else
                    {
                        Hashtable synClients = Hashtable.Synchronized(FrmServerMain.clients);
                        synClients.Add(this.name, this);

                        // 更新界面
                        server.AddUser(this.name);

                        // 对每一个在线用户发送JOIN和LIST消息命令更新用户列表
                        IEnumerator myIEnumerator = FrmServerMain.clients.Values.GetEnumerator();
                        while(myIEnumerator.MoveNext())
                        {
                            ChatClient cClient = (ChatClient)myIEnumerator.Current;
                            SendToClient(cClient, "JOIN|" + this.name + "|");
                            Thread.Sleep(100);
                        }
                        // 更新连接状态
                        connState = "connected";
                        SendToClient(this, "OK");

                        // 向客户端发送LIST命令更新用户列表
                        string msgUsers = "LIST|" + server.GetUserList();
                        SendToClient(this, msgUsers);
                    }
                }
                else if(acceptStr[0] == "LIST")
                {
                    if(connState == "CONNECTED")
                    {
                        // 向客户端发送LIST命令，以此更新客户端的当前在线用户列表
                        string msgUsers = "LIST|" + server.GetUserList();
                        SendToClient(this, msgUsers);
                    }
                    else
                    {
                        SendToClient(this, "ERROR|服务器未连接，请重新登录");
                    }
                }
                else if(acceptStr[0] == "CHAT")
                {
                    if(connState == "connected")
                    {
                        // 此时接收到的命令格式为：
                        // 命令标识符（CHAT）|发送者的用户名：发送内容|
                        // 向所有当前在线的用户转发此消息
                        IEnumerator myEnumberator = FrmServerMain.clients.Values.GetEnumerator();
                        while(myEnumberator.MoveNext())
                        {
                            ChatClient client = (ChatClient)myEnumberator.Current;
                            // 将“发送者的用户名：发送内容”转发给用户
                            SendToClient(client, acceptStr[1]);
                        }
                        server.UpdateMsg(acceptStr[1]);
                    }
                    else
                    {
                        // 发送错误信息
                        SendToClient(this, "ERROR|服务器未连接，请重新登录");
                    }
                }
                else if (acceptStr[0] == "PRIV")
                {
                    if (connState == "connected")
                    {
                        // 此时接收到的命令格式为：
                        // 命令标识符（PRIV）|发送者的用户名|接收者用户名|发送内容|
                        // acceptStr[1]中保存了发送者的用户名
                        string sender = acceptStr[1];
                        // acceptStr[2]中保存了接收者用户名
                        string recevier = acceptStr[2];
                        // acceptStr[2]中保存了发送内容
                        string content = acceptStr[3];
                        string message = sender + " ---> " + recevier + "：" + content;

                        // 仅将信息转发给发送者和接收者
                        if(FrmServerMain.clients.Contains(sender))
                        {
                            SendToClient((ChatClient)FrmServerMain.clients[sender], message);
                        }
                        if (FrmServerMain.clients.Contains(recevier))
                        {
                            SendToClient((ChatClient)FrmServerMain.clients[recevier], message);
                        }
                        server.UpdateMsg(message);
                    }
                    else
                    {
                        // 发送错误信息
                        SendToClient(this, "ERROR|服务器未连接，请重新登录");
                    }
                }
                else if (acceptStr[0] == "EXIT")
                {
                    // 此时接收到的命令格式为：命令标识符（EXIT）|发送者的用户名
                    // 向所有当前在线的用户发送该用户已离开的信息
                    if(FrmServerMain.clients.Contains(acceptStr[1]))
                    {
                        ChatClient client = (ChatClient)FrmServerMain.clients[acceptStr[1]];
                        // 将该用户对应的Client对象从clients中删除
                        Hashtable syncClients = Hashtable.Synchronized(FrmServerMain.clients);
                        syncClients.Remove(client.name);
                        server.RemoveUser(client.name);

                        // 向客户端发送QUIT命令
                        string message = "QUIT|" + acceptStr[1];
                        System.Collections.IEnumerator myEnumerator = FrmServerMain.clients.Values.GetEnumerator();
                        while(myEnumerator.MoveNext())
                        {
                            ChatClient newClient = (ChatClient)myEnumerator.Current;
                            SendToClient(newClient, message);
                        }
                        server.UpdateMsg("QUIT");
                    }
                    // 退出当前线程
                    break;
                }
            }
        }

        // 回发消息给客户端
        private void SendToClient(ChatClient client, string msg)
        {
            Byte[] message = System.Text.Encoding.Default.GetBytes(msg.ToCharArray());
            client.CurrentSocket.Send(message, message.Length, 0);
        }
    }
}
