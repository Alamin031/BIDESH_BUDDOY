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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public static string username;
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into a_r_info values (@name,@phn_num,@email,@country,@n_p_number,@address,@pass,@photo)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@phn_num", textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);
            cmd.Parameters.AddWithValue("@country", textBox4.Text);
            cmd.Parameters.AddWithValue("@n_p_number", textBox5.Text);
            cmd.Parameters.AddWithValue("@address", textBox6.Text);
            cmd.Parameters.AddWithValue("@pass", textBox7.Text);
            cmd.Parameters.AddWithValue("@photo", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
                MessageBox.Show("Data Submit Successfully");
            }
            else
            {
                MessageBox.Show("Data Not Submit");
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.Icon = Properties.Resources.error;
                errorProvider3.SetError(this.textBox3, "Fill the box");
            }
            else
            {
                errorProvider3.Icon = Properties.Resources.check;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.Icon = Properties.Resources.error;
                errorProvider4.SetError(this.textBox4, "Fill the box");
            }
            else
            {
                errorProvider4.Icon = Properties.Resources.check;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider5.Icon = Properties.Resources.error;
                errorProvider5.SetError(this.textBox5, "Fill the box");
            }
            else
            {
                errorProvider5.Icon = Properties.Resources.check;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) == true)
            {
                textBox6.Focus();
                errorProvider6.Icon = Properties.Resources.error;
                errorProvider6.SetError(this.textBox6, "Fill the box");
            }
            else
            {
                errorProvider6.Icon = Properties.Resources.check;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) == true)
            {
                textBox7.Focus();
                errorProvider7.Icon = Properties.Resources.error;
                errorProvider7.SetError(this.textBox7, "Fill the box");
            }
            else
            {
                errorProvider7.Icon = Properties.Resources.check;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            //ofd.Filter = "PNG FILE (*.PNG) | *.PNG";
            ofd.Filter = "IMAGE FILE (*.*) | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }
    }
}
