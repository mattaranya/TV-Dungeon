using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public class Connect
    {
        public static string Connecting = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True";
        public static DataTable ExecuteDataTable(string sql)//creates DataTable visible
        {
            SqlConnection conn = new SqlConnection(Connecting);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter tableAdapter = new SqlDataAdapter(sql,conn);
            tableAdapter.Fill(dt);
            return dt;
        }

        public static void DoQuery(string sql)//Executes Query
        {
            SqlConnection conn = new SqlConnection(Connecting);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            com.CommandText = String.Format(sql);
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}