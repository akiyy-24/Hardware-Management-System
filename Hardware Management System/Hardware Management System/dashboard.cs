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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
          

           
           
            
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Console.WriteLine($"Width: {this.Width}, Height: {this.Height}");
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void return_Click(object sender, EventArgs e)
        {
            loadform(new @return());
        }

        private void dealer_Click(object sender, EventArgs e)
        {
            loadform(new dealer());
        }

        private void customer_Click(object sender, EventArgs e)
        {
            loadform(new customer());
        }

        public void loadform(object form)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form f = (form as Form);
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();


            

          
        }

        private void store_Click(object sender, EventArgs e)
        {
            loadform(new store());
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();
            //open login
            login loginForm = new login();
            loginForm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            // Minimize the current form
            this.WindowState = FormWindowState.Minimized;

            // Open a new instance of the login form
            login loginForm = new login();
            loginForm.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // If the form is maximized, restore it to normal size
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                // If the form is not maximized, maximize it
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
