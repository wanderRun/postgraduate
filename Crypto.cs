using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Crypto
    {
        private string key;
        private string iv;

        private Crypto()
        {
            try
            {
                Application excel = new Application();
                Workbook book = excel.Workbooks.Open(System.Environment.CurrentDirectory + "\\密钥.xls");
                Worksheet sheet = book.Worksheets.Item[1];
                int count = book.Worksheets.Count;
                sheet.Visible = XlSheetVisibility.xlSheetVisible;
                Range range = (Range)sheet.Cells[2, 1];
                key = (string)range.Text;
                range = (Range)sheet.Cells[2, 2];
                iv = (string)range.Text;
                book.Close();
                excel.Quit();
                Marshal.ReleaseComObject(sheet);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(excel);
                GC.Collect();
            }
            catch (Exception ex)
            {
                key = "computer";
                iv = "science1";
                Console.WriteLine("{0}", ex.Message);
            }
        }

        private static readonly Crypto instance = new Crypto();

        public static Crypto Instance
        {
            get { return instance; }
        }

        // Encrypt the string.
        public byte[] Encrypt(string PlainText)
        {
            // Create a memory stream.
            MemoryStream ms = new MemoryStream();

            DESCryptoServiceProvider keys = new DESCryptoServiceProvider();
            keys.Key = System.Text.Encoding.ASCII.GetBytes(key);
            keys.IV = System.Text.Encoding.ASCII.GetBytes(iv);

            // Create a CryptoStream using the memory stream and the 
            // CSP DES key.  
            CryptoStream encStream = new CryptoStream(ms, keys.CreateEncryptor(), CryptoStreamMode.Write);

            // Create a StreamWriter to write a string
            // to the stream.
            StreamWriter sw = new StreamWriter(encStream);

            // Write the plaintext to the stream.
            sw.WriteLine(PlainText);

            // Close the StreamWriter and CryptoStream.
            sw.Close();
            encStream.Close();

            // Get an array of bytes that represents
            // the memory stream.
            byte[] buffer = ms.ToArray();

            // Close the memory stream.
            ms.Close();

            // Return the encrypted byte array.
            return buffer;
        }

        // Decrypt the byte array.
        public string Decrypt(byte[] CypherText)
        {
            // Create a memory stream to the passed buffer.
            MemoryStream ms = new MemoryStream(CypherText);

            DESCryptoServiceProvider keys = new DESCryptoServiceProvider();
            keys.Key = System.Text.Encoding.ASCII.GetBytes(key);
            keys.IV = System.Text.Encoding.ASCII.GetBytes(iv);

            // Create a CryptoStream using the memory stream and the 
            // CSP DES key. 
            CryptoStream encStream = new CryptoStream(ms, keys.CreateDecryptor(), CryptoStreamMode.Read);

            // Create a StreamReader for reading the stream.
            StreamReader sr = new StreamReader(encStream);

            // Read the stream as a string.
            string val = sr.ReadLine();

            // Close the streams.
            sr.Close();
            encStream.Close();
            ms.Close();

            return val;
        }
    }
}
