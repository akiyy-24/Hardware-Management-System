using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hardware_Management_System
{
    public partial class dealer : Form
    {
        public dealer()
        {
            InitializeComponent();
            dataGridView2.DataSource = new ItemDB().Dealer_SelectAll();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            store storeForm = new store();
            storeForm.Show();
            storeForm.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            customer customerForm = new customer();
            customerForm.Show();
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            @return retunForm=new @return();
            retunForm.Show();
            this.Close();
        }

        private void dealer_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int D_ID = Convert.ToInt32(txtdid.Text);
                int Item_ID = Convert.ToInt32(txtitemid.Text);
                String Com_Name = txtdcom.Text;
                String D_Name = txtdname.Text;
                int D_qty = Convert.ToInt32(txtdqty.Text);
                int D_Price = Convert.ToInt32(txtdprice.Text);

                new ItemDB().Dealer_Insert(D_ID, Item_ID, Com_Name, D_Name, D_qty, D_Price);

                //Clear text boxes
                txtdid.Clear();txtitemid.Clear();txtdcom.Clear();txtdname.Clear();txtdqty.Clear();txtdprice.Clear();

                // Refresh the DataGridView
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridView()
        {
            try
            {
                // Assuming dataGridView1 is the name of your DataGridView control
                // Set the DataGridView data source to null and then reassign it
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = new ItemDB().Dealer_SelectAll(); // Replace GetData() with your method to fetch data
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("Error refreshing DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
               // int D_ID = Convert.ToInt32(txtdid.Text);
                int Item_ID = Convert.ToInt32(txtitemid.Text);
                new ItemDB().Dealer_Delete(Item_ID);
                MessageBox.Show("deleted");
                RefreshDataGridView();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
