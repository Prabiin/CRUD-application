using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace MovieProject
{
    class DB
    {
        private static readonly string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\MovieProject\MovieDB.mdf;Integrated Security=True";
        static SqlConnection conn;
        public static void OpenConnection()
        {
            conn = new SqlConnection(connStr);
            conn.Open();
        }
        public static void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public static int ExecuteQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            int ctr = cmd.ExecuteNonQuery();
            return ctr;
        }
        public static SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
