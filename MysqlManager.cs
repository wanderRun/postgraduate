using MySql.Data.MySqlClient;
using System;
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
            }
            catch (MySqlException ex)
            {
            }
            return data;
        }

        public static void InsertData(string database)
        {

        }
    }
}
