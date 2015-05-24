using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Server
{
    class MysqlManager
    {
        private static MySqlConnection conn;
        private static MySqlDataAdapter da;
        private static MySqlCommandBuilder cb;

        public static DataTable SelectData(string database)
        {
            DataTable data = new DataTable();
            if(conn != null)
            {
                conn.Close();
            }
            string connStr = String.Format("server=localhost;user id=root; password=''; database=postgraduate; pooling=false; charset=utf8");
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                da = new MySqlDataAdapter("SELECT * FROM " + database, conn);
                cb = new MySqlCommandBuilder(da);
                da.Fill(data);
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
            return data;
        }

        public static void InsertData(string database, List<KeyValuePair<string, string>> data)
        {
            if (conn != null)
            {
                conn.Close();
            }
            string connStr = String.Format("server=localhost;user id=root; password=''; database=postgraduate; pooling=false; charset=utf8");
            try
            {
                string key = "";
                string value = "";
                int count = 0;
                foreach(KeyValuePair<string, string> kvp in data)
                {
                    if(count++ != 0)
                    {
                        key += ", ";
                        value += ", ";
                    }
                    key += kvp.Key;
                    value += "'" + kvp.Value + "'";
                }
                conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = "INSERT INTO " + database + " (" + key + ") VALUES (" + value + ")";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);
                mySqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }

        public static void UpdateData(string database)
        {
            if (conn != null)
            {
                conn.Close();
            }
            string connStr = String.Format("server=localhost;user id=root; password=''; database=postgraduate; pooling=false; charset=utf8");
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("UPDATE", conn);
                mySqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }

        public static void DeleteData(string database)
        {
            if (conn != null)
            {
                conn.Close();
            }
            string connStr = String.Format("server=localhost;user id=root; password=''; database=postgraduate; pooling=false; charset=utf8");
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("DELETE", conn);
                mySqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }
    }
}
