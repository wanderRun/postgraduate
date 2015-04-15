using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;

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
        // 端口号
        private const int PORT_NUMBER = 1234;

        // 最大数据量
        private const int MAX_BUFFER_SIZE = 1024;

        private Socket server;

        private Socket acceptClient;

        public int StartServer(int port)
        {
            // 初始化服务器端
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 绑定本地终结点
            IPEndPoint myLocal = new IPEndPoint(IPAddress.Any, port);
            server.Bind(myLocal);
            // 开始监听
            server.Listen(100);
            // 开始异步接受客户端连接
            server.BeginAccept(new AsyncCallback(this.StartListen), null);
            return 0;
        }

        private void StartListen(IAsyncResult iar)
        {
            try
            {
                acceptClient = server.EndAccept(iar);
                SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
                saea.SetBuffer(new byte[MAX_BUFFER_SIZE], 0, MAX_BUFFER_SIZE);
                saea.Completed += (s, e) =>
                {
                    if (e.SocketError == SocketError.Success)
                    {
                        try
                        {
                            Command command = new Command();
                            command = (Command)this.BytesToStruct(e.Buffer, command.GetType());
                            // object obj = Activator.CreateInstance(t);
                            MemoryStream memStream = new MemoryStream();
                            StreamWriter strWriter = new StreamWriter(memStream);
                            strWriter.Write(command.data);
                            strWriter.Flush();
                            memStream.Position = 0;

                            Type t = typeof(PosSocket);
                            int index = command.type.IndexOf(".");
                            MethodInfo method = t.GetMethod("on" + command.type.Remove(index, 1), BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                            method.Invoke(this, new object[] { memStream, acceptClient });
                            e.SetBuffer(new byte[MAX_BUFFER_SIZE], 0, MAX_BUFFER_SIZE);
                            acceptClient.ReceiveAsync(e);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("{0}", ex.Message);
                        }
                    }
                };
                acceptClient.ReceiveAsync(saea);
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
            server.BeginAccept(new AsyncCallback(this.StartListen), null);
        }

        private object BytesToStruct(byte[] bytes, Type type)
        {
            int size = Marshal.SizeOf(type);
            if (size > bytes.Length)
            {
                return null;
            }
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, structPtr, size);
            object obj = Marshal.PtrToStructure(structPtr, type);
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }

        public void sendProtoMsg(Socket client, object obj, string type)
        {
            string str;
            MemoryStream memStream = new MemoryStream();
            ProtoBuf.Serializer.Serialize<object>(memStream, obj);
            StreamReader strReader = new StreamReader(memStream);
            memStream.Position = 0;
            str = strReader.ReadToEnd();

            Command command;
            command.data = str;
            command.type = type;
            command.size = str.Length;

            int length = Marshal.SizeOf(command.GetType());
            byte[] msg = new byte[length];
            IntPtr structPtr = Marshal.AllocHGlobal(length);
            Marshal.StructureToPtr(command, structPtr, false);
            Marshal.Copy(structPtr, msg, 0, length);
            Marshal.FreeHGlobal(structPtr);
            client.Send(msg, length, 0);
        }

        public void OnMessageLogin(MemoryStream memStream, Socket socket)
        {
            message.Login login = ProtoBuf.Serializer.Deserialize<message.Login>(memStream);
            this.sendProtoMsg(socket, login, login.GetType().ToString());
        }
    }
}
