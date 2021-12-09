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
    public partial class Form6 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public Form6()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
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
                Form8 f8 = new Form8();
                f8.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form11 f11 = new Form11();
                f11.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Form12 f12 = new Form12();
                f12.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Form15 f15 = new Form15();
                f15.Show();
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
                Form27 f27 = new Form27();
                f27.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
