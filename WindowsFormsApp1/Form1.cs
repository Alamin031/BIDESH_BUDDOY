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
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from s_r_info where email=@email or Name=@Name and Password=@Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    Form7 f7 = new Form7();
                    f7.Show();
                    this.Hide();
                    MessageBox.Show("login successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("login Faild", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            else
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 f4 = new Form4();
                f4.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 f2 = new Form2();
                f2.Show();
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
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.error;
                errorProvider1.SetError(this.textBox1, "Fill the box");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.check;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox2, "Fill the box");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.check;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
