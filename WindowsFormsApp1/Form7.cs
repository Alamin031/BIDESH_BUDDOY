using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form13 f13 = new Form13();
                f13.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Form14 f14 = new Form14();
                f14.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Form9 f9 = new Form9();
                f9.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
