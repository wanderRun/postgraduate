using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Server
{
    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    //struct Command
    //{
    //    public int size;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //    public string type;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    //    public string data;
    //}

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
                            message.Command command = new message.Command();
                            StructSerializer.BytesToStruct(e.Buffer, command);
                            // command = (Command)this.BytesToStruct(e.Buffer, command.GetType());
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

        public void SendProtoMsg(Socket client, object obj, string type)
        {
            string str;
            MemoryStream memStream = new MemoryStream();
            ProtoBuf.Serializer.Serialize<object>(memStream, obj);
            StreamReader strReader = new StreamReader(memStream);
            memStream.Position = 0;
            str = strReader.ReadToEnd();

            message.Command command = new message.Command();
            command.data = str;
            command.type = type;
            command.size = (UInt32)str.Length;

            //int length = Marshal.SizeOf(command.GetType());
            //byte[] msg = new byte[length];
            //IntPtr structPtr = Marshal.AllocHGlobal(length);
            //Marshal.StructureToPtr(command, structPtr, false);
            //Marshal.Copy(structPtr, msg, 0, length);
            //Marshal.FreeHGlobal(structPtr);
            byte[] msg = StructSerializer.StructToBytes(command);
            SocketAsyncEventArgs asyArg = new SocketAsyncEventArgs();
            asyArg.SetBuffer(msg, 0, msg.Length);
            client.SendAsync(asyArg);
        }

        public void OnMessageLogin(MemoryStream memStream, Socket socket)
        {
            message.ResponseLogin send = new message.ResponseLogin();
            message.Login rec = ProtoBuf.Serializer.Deserialize<message.Login>(memStream);
            int index = DataManager.Teachers.teacher.FindIndex(t => t.id == rec.name);
            if(index == -1)
            {
                send.ret = 2;
                SendProtoMsg(socket, send, send.GetType().ToString());
                return;
            }
            if(DataManager.Teachers.teacher[index].password != rec.password)
            {
                send.ret = 3;
                SendProtoMsg(socket, send, send.GetType().ToString());
                return;
            }
            send.ret = 1;
            SendProtoMsg(socket, send, send.GetType().ToString());
        }
        public void OnMessageReqStudentInfo(MemoryStream memStream, Socket socket)
        {
            message.ReqStudentInfo rec = ProtoBuf.Serializer.Deserialize<message.ReqStudentInfo>(memStream);
            message.ResStudentInfo students = new message.ResStudentInfo();
            SendProtoMsg(socket, students, students.GetType().ToString());
        }

        public void OnMessageReqTeacherScore(MemoryStream memStream, Socket socket)
        {
            message.ReqTeacherScore rec = ProtoBuf.Serializer.Deserialize<message.ReqTeacherScore>(memStream);
            message.ResTeacherScore send = new message.ResTeacherScore();
            send.result = true;
            SendProtoMsg(socket, send, send.GetType().ToString());
        }

        public void OnMessageReqChangePassword(MemoryStream memStream, Socket socket)
        {
            message.ReqChangePassword rec = ProtoBuf.Serializer.Deserialize<message.ReqChangePassword>(memStream);
            message.ResChangePassword send = new message.ResChangePassword();
            send.ret = (UInt32)DataManager.ChangeTeacherPassword(rec.id, rec.old_password, rec.new_password);
            SendProtoMsg(socket, send, send.GetType().ToString());
        }
    }
}
