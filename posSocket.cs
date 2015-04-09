using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace Server
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    struct Command
    {
        public int size;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string type;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string data;
    }

    class PosSocket
    {
        // 该服务器默认的监听器
        private TcpListener listener;

        // clients 数组保存当前在线用户的client对象
        internal static Hashtable clients = new Hashtable();

        // 默认最大支持的客户端连接数
        static int MAX_USER = 100;

        private bool serverFlag = false;// 服务器开启标志 true-开启

        public bool ServerFlag
        {
            get { return serverFlag; }
            set { serverFlag = value; }
        }

        public int StartServer(int port)
        {
            int iPort = port;
            if (iPort < 0)
            {
                return -1;
            }

            string ip = this.ReturnIpAddress();

            try
            {
                IPAddress userIp = IPAddress.Parse(ip);

                // 创建服务器套接字
                listener = new TcpListener(userIp, iPort);
                listener.Start();

                // 以下方法启动一个新的线程，执行监听方法
                // 以便在一个独立的进程中执行确认与客户端连接的操作
                Thread thread = new Thread(StartListen);
                thread.Start();

                return 0;
            }
            catch (Exception ex)
            {
                // this.rbChatContent.AppendText(ex.Message + "\n");
                return 1;
            }
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

        // 用于接收客户端的请求，确认与客户端的连接
        // 并且启动一个新的线程处理客户端的请求
        private void StartListen()
        {
            while (serverFlag)
            {
                try
                {
                    // 当接收到客户端请求时，确认与客户端的连接
                    if (listener.Pending())
                    {
                        Socket socket = listener.AcceptSocket();
                        if (clients.Count >= MAX_USER)
                        {
                            socket.Close();
                        }
                        else
                        {
                            // 启动一个新的线程，处理用户相应的请求
                            Thread clientThread = new Thread(ReceiveCmdFromClient);
                            clientThread.Start(socket);
                        }
                    }
                    Thread.Sleep(200);
                }
                catch (Exception e)
                {
                }
            }
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

        //和客户端进行数据通信,包括接收客户端的请求
        //根据不同的请求命令,执行相应的操作,并将操作结果返回给客户端
        public void ReceiveCmdFromClient(Object socket)
        {
            string[] acceptStr = null;//保存消息字符
            byte[] buff = new byte[1024];//缓冲区
            bool keepConnected = true;
            string name;
            Socket currentSocket = (Socket)socket;

            //用循环不断地与客户端进行交互,直到其发出EXIT或者QUIT命令
            //将keepConnected设置为false,退出循环，关闭当前连接,中止当前线程
            while (keepConnected && serverFlag)
            {
                acceptStr = null;
                try
                {
                    if (currentSocket == null || currentSocket.Available < 1)
                    {
                        Thread.Sleep(300);
                        continue;
                    }

                    //接收信息存入buff数组中
                    int length = currentSocket.Receive(buff);
                    Command command = new Command();
                    command = (Command)this.BytesToStruct(buff, command.GetType());
                    // object obj = Activator.CreateInstance(t);
                    MemoryStream memStream = new MemoryStream();
                    StreamWriter strWriter = new StreamWriter(memStream);
                    strWriter.Write(command.data);
                    strWriter.Flush();
                    memStream.Position = 0;

                    Type t = typeof(PosSocket);
                    int index = command.type.IndexOf(".");
                    MethodInfo method = t.GetMethod("on" + command.type.Remove(index, 1), BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    method.Invoke(this, new object[] { memStream });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}", ex.Message);
                    // server.UpdateMsg("程序发生异常,异常信息:" + ex.Message);
                }
                Thread.Sleep(200);
            }

        }

        private object BytesToStruct(byte[] bytes, Type type)
        {
            int size = Marshal.SizeOf(type);
            if(size > bytes.Length)
            {
                return null;
            }
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, structPtr, size);
            object obj = Marshal.PtrToStructure(structPtr, type);
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }

        //回发消息给客户端
        private void SendCmdToClient(Socket client, ProtoBuf.IExtensible msg)
        {
            // Byte[] message = System.Text.Encoding.Default.GetBytes(msg.ToCharArray());
            // client.Send(message, message.Length, 0);
        }

        public void OnMessageLogin(MemoryStream memStream)
        {
            message.Login login = ProtoBuf.Serializer.Deserialize<message.Login>(memStream);
        }
    }
}
