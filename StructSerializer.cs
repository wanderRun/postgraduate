using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    /// <summary>
    /// 结构序列化工具
    /// 可以将结构、类转换为字节流，支持Windows Phone 7
    /// 仅使用静态成员函数即可，按提示操作
    /// 转换过程请截获异常
    /// </summary>
    public class StructSerializer
    {
        class pair
        {
            public bool isarray;
            public byte[] data;
            public pair(bool v, byte[] p)
            {
                isarray = v;
                data = p;
            }
        }

        //delegate pair GetBytes(FieldInfo fi, object o);// 也可以使用委托

        static Dictionary<Type, Func<FieldInfo, object, pair>> tg =
            new Dictionary<Type, Func<FieldInfo, object, pair>>{
            {typeof(Int16), GetInt16Bytes},
            {typeof(Int32), GetInt32Bytes},
            {typeof(Int64), GetInt64Bytes},
            {typeof(UInt16), GetUInt16Bytes},
            {typeof(UInt32), GetUInt32Bytes},
            {typeof(UInt64), GetUInt64Bytes},
            {typeof(char), GetCharBytes},
            {typeof(byte), GetInt8Bytes},
            {typeof(byte[]), GetByteArrayBytes},
            {typeof(string), GetStringBytes}
            };

        static Dictionary<Type, Func<FieldInfo, object, byte[], int, int>> ts =
            new Dictionary<Type, Func<FieldInfo, object, byte[], int, int>>{
            {typeof(Int16), SetInt16Bytes},
            {typeof(Int32), SetInt32Bytes},
            {typeof(Int64), SetInt64Bytes},
            {typeof(UInt16), SetUInt16Bytes},
            {typeof(UInt32), SetUInt32Bytes},
            {typeof(UInt64), SetUInt64Bytes},
            {typeof(char), SetCharBytes},
            {typeof(byte), SetInt8Bytes},
            {typeof(byte[]), SetByteArrayBytes},
            {typeof(string), SetStringBytes}
            };



        static pair GetInt8Bytes(FieldInfo fi, object o)
        {
            return new pair(false, new byte[1] { (byte)fi.GetValue(o) });
        }

        static int SetInt8Bytes(FieldInfo fi, object o, byte[] data, int offset)
        {
            fi.SetValue(o, data[offset]);
            return sizeof(byte);
        }

        static pair GetCharBytes(FieldInfo fi, object o)
        {
            return new pair(false, BitConverter.GetBytes((Char)fi.GetValue(o)));
        }

        static int SetCharBytes(FieldInfo fi, object o, byte[] data, int offset)
        {
            fi.SetValue(o, BitConverter.ToChar(data, offset));
            return sizeof(char);
        }

        static pair GetInt16Bytes(FieldInfo fi, object o)
        {
            return new pair(false, BitConverter.GetBytes((Int16)fi.GetValue(o)));
        }

        static int SetInt16Bytes(FieldInfo fi, object o, byte[] data, int offset)
        {
            fi.SetValue(o, BitConverter.ToInt16(data, offset));
            return sizeof(Int16);
        }

        static pair GetInt32Bytes(FieldInfo fi, object o)
        {
            return new pair(false, BitConverter.GetBytes((Int32)fi.GetValue(o)));
        }

        static int SetInt32Bytes(FieldInfo fi, object o, byte[] data, int offset)
        {
            fi.SetValue(o, BitConverter.ToInt32(data, offset));
            return sizeof(Int32);
        }

        static pair GetInt64Bytes(FieldInfo fi, object o)
        {
            return new pair(false, BitConverter.GetBytes((Int64)fi.GetValue(o)));
        }

        static int SetInt64Bytes(FieldInfo fi, object o, byte[] data, int offset)
        {
            fi.SetValue(o, BitConverter.ToInt64(data, offset));
            return sizeof(Int64);
        }

        static pair GetUInt16Bytes(FieldInfo fi, object o)
        {
            return new pair(false, BitConverter.GetBytes((UInt16)fi.GetValue(o)));
        }

        static int SetUInt16Bytes(FieldInfo fi, object o, byte[] data, int offset)
        {
            fi.SetValue(o, BitConverter.ToUInt16(data, offset));
            return sizeof(UInt16);
        }

        static pair GetUInt32Bytes(FieldInfo fi, object o)
        {
            return new pair(false, BitConverter.GetBytes((UInt32)fi.GetValue(o)));
        }

        static int SetUInt32Bytes(FieldInfo fi, object o, byte[] data, int offset)
        {
            fi.SetValue(o, BitConverter.ToUInt32(data, offset));
            return sizeof(UInt32);
        }

        static pair GetUInt64Bytes(FieldInfo fi, object o)
        {
            return new pair(false, BitConverter.GetBytes((UInt64)fi.GetValue(o)));
        }

        static int SetUInt64Bytes(FieldInfo fi, object o, byte[] data, int offset)
        {
            fi.SetValue(o, BitConverter.ToUInt64(data, offset));
            return sizeof(UInt64);
        }

        static pair GetByteArrayBytes(FieldInfo fi, object o)
        {
            return new pair(true, (byte[])fi.GetValue(o));
        }

        static int SetByteArrayBytes(FieldInfo fi, object o, byte[] data, int offset)
        {
            UInt16 len = BitConverter.ToUInt16(data, offset);
            byte[] result = new byte[len];
            Array.Copy(data, offset + 2, result, 0, len);
            fi.SetValue(o, result);
            return sizeof(Int16) + len;
        }

        static pair GetStringBytes(FieldInfo fi, object o)
        {
            return new pair(true, System.Text.UnicodeEncoding.Unicode.GetBytes((string)fi.GetValue(o)));
        }

        static int SetStringBytes(FieldInfo fi, object o, byte[] data, int offset)
        {
            UInt16 len = BitConverter.ToUInt16(data, offset);
            fi.SetValue(o, System.Text.UnicodeEncoding.Unicode.GetString(data, offset + 2, len));
            return sizeof(UInt16) + len;
        }

        /// <summary>
        /// 结构实例转换为字节流
        /// obj最大支持65535个字符的字符串或字节流成员变量，请自行校验
        /// </summary>
        /// <param name="obj">预转换的对象</param>
        /// <returns>字节流</returns>
        static public Byte[] StructToBytes(Object obj)
        {
            List<pair> hs = new List<pair>();
            int count = 0;

            foreach (FieldInfo fi in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (ts.Keys.Contains(fi.FieldType))
                {
                    pair temp = tg[fi.FieldType](fi, obj);
                    if (temp.isarray)
                    {
                        count += 2;
                    }
                    count += temp.data.Length;
                    hs.Add(temp);
                }
            }

            byte[] result = new byte[count];
            int offset = 0;

            foreach (pair pr in hs)
            {
                if (pr.isarray)
                {
                    BitConverter.GetBytes((ushort)pr.data.Length).CopyTo(result, offset);
                    offset += 2;
                }
                pr.data.CopyTo(result, offset);
                offset += pr.data.Length;
            }

            return result;
        }

        /// <summary>
        /// 字节流传递到目标对象
        /// </summary>
        /// <param name="src">源数据流</param>
        /// <param name="obj">预转换的对象</param>
        static public void BytesToStruct(Byte[] src, Object obj)
        {
            int offset = 0;

            foreach (FieldInfo fi in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (ts.Keys.Contains(fi.FieldType))
                {
                    offset += ts[fi.FieldType](fi, obj, src, offset);
                }
            }
        }
    }
}