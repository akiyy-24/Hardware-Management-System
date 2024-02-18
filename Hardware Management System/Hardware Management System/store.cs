using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_Management_System
{

    public partial class store : Form
    {
     
        public store()
        {
            InitializeComponent();
            dataGridView1.DataSource = new ItemDB().Store_SelectAll();
          
        }

        private void store_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new Dbconnection().ConnectDB();
            con.Open();
            string query = "select * from store where Item_ID=@Item_ID";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Item_ID", guna2TextBox2.Text);
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            customer customerForm = new customer();
            customerForm.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            dealer dealerForm= new dealer();
            dealerForm.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            @return rtn=new @return();
            rtn.Show();
            this.Hide();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
