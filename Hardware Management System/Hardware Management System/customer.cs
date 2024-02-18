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
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
            dataGridView1.DataSource = new ItemDB().Customer_SelectAll();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginForm = new login();
            loginForm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            store storeForm = new store();
            storeForm.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            dealer dealerForm = new dealer();
            dealerForm.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtid.Text);
                int qty = Convert.ToInt32(txtqty.Text);
                double dis_I = Convert.ToDouble(txtdis_I.Text);
                double dis = Convert.ToDouble(txtdis.Text);

                calculation cal = new calculation();
                double Tot_Each = cal.Customer_Total(id, qty, dis_I, dis);

                // Retrieve name from store table
                string name = RetrieveNameFromStore(id);

                // Check if the name is valid
                if (!string.IsNullOrEmpty(name))
                {
                    new ItemDB().Customer_Insert(name, id, qty, dis_I, dis, Tot_Each);

                    txtname.Clear();
                    txtid.Clear();
                    txtqty.Clear();
                    txtdis_I.Clear();
                    txtdis.Clear();

                 
                }
                else
                {
                    MessageBox.Show($"Item with Item_ID {id} not found in the store.");
                }
                //refresh database
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = new ItemDB().Customer_SelectAll();
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nPlease enter valid numeric values for ID, Quantity, Discount_I");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private string RetrieveNameFromStore(int id)
        {
            MySqlConnection con = new Dbconnection().ConnectDB();
            string query = "SELECT Name_I FROM store WHERE Item_ID = @id";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            object result = cmd.ExecuteScalar();
            con.Close();

            // Check if the result is not null and return the name as string
            return result != null ? result.ToString() : null;
        }



        private void customer_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int RItem_ID = Convert.ToInt32(txtid.Text);
                new ItemDB().Customer_Delete(RItem_ID);
                MessageBox.Show("deleted");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = new ItemDB().Customer_SelectAll();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txttot_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncalculate_Click(object sender, EventArgs e)
        {
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdis_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
