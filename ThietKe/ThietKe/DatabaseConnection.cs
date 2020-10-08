using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ThietKe
{
    class DatabaseConnection
    {
        MySqlConnection db_con = new MySqlConnection("server=localhost;user id=root;database=dbtest");
        MySqlDataAdapter db_select;
        DataSet dbset;
        MySqlCommand sql_cmd;
        string query;

        public void OpenConnection()
        {
            db_con.Open();
        }
        public void CloseConnection()
        {
            db_con.Close();
        }
        public DataTable ReadValue()
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from san_pham",db_con);
            da.Fill(dt);
            return dt;
        }
    }
}
