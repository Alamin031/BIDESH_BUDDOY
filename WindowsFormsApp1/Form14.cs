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
    public partial class Form14 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public static string Form_No;
        public Form14()
        {
            InitializeComponent();
            ResetControl();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_No = textBox16.Text;

            SqlConnection con = new SqlConnection(cs);
            string query = "insert into A_From values (@Name,@Marital_Status,@Nationality,@Email,@DOB,@University_Name,@University_Id,@Department,@Course,@Father_Name,@Mother_Name,@Address,@Mobile_No,@Photo,@Year_Of_Passing_HSC,@CGPA_HSC,@gender,@Form_No)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Marital_Status", textBox2.Text);
            cmd.Parameters.AddWithValue("@Nationality", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@DOB", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@University_Name", textBox5.Text);
            cmd.Parameters.AddWithValue("@University_Id", textBox6.Text);
            cmd.Parameters.AddWithValue("@Department", textBox7.Text);
            cmd.Parameters.AddWithValue("@Course", textBox8.Text);
            cmd.Parameters.AddWithValue("@Father_Name", textBox9.Text);
            cmd.Parameters.AddWithValue("@Mother_Name", textBox10.Text);
            cmd.Parameters.AddWithValue("@Address", textBox11.Text);
            cmd.Parameters.AddWithValue("@Mobile_No", textBox12.Text);
            cmd.Parameters.AddWithValue("@Photo", SavePhoto());
            cmd.Parameters.AddWithValue("@Year_Of_Passing_HSC", textBox13.Text);
            cmd.Parameters.AddWithValue("@CGPA_HSC", textBox14.Text);
            cmd.Parameters.AddWithValue("@Gender", textBox15.Text);
            cmd.Parameters.AddWithValue("@Form_No", textBox16.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Form30 f30 = new Form30();
                f30.Show();
                this.Hide();
                MessageBox.Show("Data Submit Successfully Please Submit EDUCATIONAL BACKGROUND");
                ResetControl();


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

        private void button4_Click(object sender, EventArgs e)
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

        private void Form14_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox15.Clear();
            pictureBox1.Image = Properties.Resources.no_image_avaiable;
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form23 f23 = new Form23();
                f23.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
