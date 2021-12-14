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
    public partial class Form4 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public static string username;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into s_r_info values (@email,@Password,@ID,@Name,@Address,@Age,@Gender,@photo)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
            cmd.Parameters.AddWithValue("@ID", textBox3.Text);
            cmd.Parameters.AddWithValue("@Name", textBox4.Text);
            cmd.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd.Parameters.AddWithValue("Age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("Gender", textBox6.Text);
            cmd.Parameters.AddWithValue("@photo", SavePhoto());
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
                MessageBox.Show("Data submit Successfully");
            }
            else
            {
                MessageBox.Show("Data Not submit");
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
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
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

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
