using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_Management_System
{
    public class Dbconnection
    {
        private MySqlConnection connection;
        public MySqlConnection ConnectDB()
        {
            string con_string = "server=127.0.0.1;uid=root;psw=;database=hardware management system";
            connection = new MySqlConnection(con_string);
            

            try { connection.Open(); } 
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
            return connection;
        }
    }
}
