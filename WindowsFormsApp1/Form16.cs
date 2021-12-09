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
    public partial class Form16 : Form
    {
        public Form16()
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
                Form15 f15 = new Form15();
                f15.Show();
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
                Form17 f17 = new Form17();
                f17.Show();
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
                Form18 f18 = new Form18();
                f18.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Form19 f19 = new Form19();
                f19.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form16_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }
    }
}
