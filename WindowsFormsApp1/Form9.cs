using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form10 f10 = new Form10();
                f10.Show();
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
                Form24 f24 = new Form24();
                f24.Show();
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
                Form7 f7 = new Form7();
                f7.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Form20 f20 = new Form20();
                f20.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                Form25 f25 = new Form25();
                f25.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
