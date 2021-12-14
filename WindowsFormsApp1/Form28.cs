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
    public partial class Form28 : Form
    {
        public Form28()
        {
            InitializeComponent();
        }

        private void Form28_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form28_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form26 f26 = new Form26();
                f26.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
