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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox2.PasswordChar = '*';
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sign_btn_Click(object sender, EventArgs e)
        {
            string enteredUsername = guna2TextBox1.Text;
            string enteredPassword = guna2TextBox2.Text;

            if (enteredUsername.Equals("123") && enteredPassword.Equals("123"))
            {

                Dashboard dashboardForm = new Dashboard();

                // Show the CustomerForm
                dashboardForm.Show();

                // Optionally, you can hide the login form if needed
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }

        }

        private void reset_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
