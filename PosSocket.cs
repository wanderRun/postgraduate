using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Client
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
        private TcpClient tcpClient;
        private NetworkStream nsStream;
        private bool stopFlag;

        public int StartServer()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse("192.168.124.120"), Int32.Parse("1234"));
                nsStream = tcpClient.GetStream();
                Thread newThread = new Thread(new ThreadStart(ServerResponse));
                newThread.Start();

                message.Login login = new message.Login();
                login.name = "wang";
                login.password = "bin";
                this.sendProtoMsg(login, login.GetType().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
            return 1;
        }

        private void ServerResponse()
        {
            //ListBox.CheckForIllegalCrossThreadCalls = false;
            // 定义一个byte数组，用于接收从服务器端发送来的数据，
            // 每次所能接收的数据包的最大长度为1024个字节
            byte[] buff = new byte[1024];
            int length = 0;
            try
            {
                if (!nsStream.CanRead)
                {
                    return;
                }

                stopFlag = false;
                while (!stopFlag)
                {
                    // 从流中得到数据，并存入buff字符数组中
                    length = nsStream.Read(buff, 0, buff.Length);
                    if (length < 1)
                    {
                        Thread.Sleep(200);
                        continue;
                    }
                    Command command = new Command();
                    command = (Command)this.BytesToStruct(buff, command.GetType());
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
                tcpClient.Close();
            }
            catch
            {
            }
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
        
        public void sendProtoMsg(object obj, string type)
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
            nsStream.Write(msg, 0, msg.Length);
        }

        public void OnMessageLogin(MemoryStream memStream)
        {
            message.Login login = ProtoBuf.Serializer.Deserialize<message.Login>(memStream);
        }
    }
}
