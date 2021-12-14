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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form22 f22 = new Form22();
                f22.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form21_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
