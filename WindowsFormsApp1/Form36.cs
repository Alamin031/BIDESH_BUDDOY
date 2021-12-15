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
    public partial class Form36 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;

        public Form36()
        {
            InitializeComponent();
            BindGridView();
            ResetControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            //ofd.Filter = "PNG FILE (*.PNG) | *.PNG";
            ofd.Filter = "ALL IMAGE FILE (*.*) | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into RUSSIA_UNIVERSITY_INFORMATION_PORTAL values (@University_Name,@University_Rank,@University_Address,@Department,@Course,@Course_Fees,@Course_Credit,@CGPA_Discount,@IELTS_Discount,@Photo)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@University_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@University_Rank", textBox2.Text);
            cmd.Parameters.AddWithValue("@University_Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Department", textBox4.Text);
            cmd.Parameters.AddWithValue("@Course", textBox5.Text);
            cmd.Parameters.AddWithValue("@Course_Fees", textBox6.Text);
            cmd.Parameters.AddWithValue("@Course_Credit", textBox7.Text);
            cmd.Parameters.AddWithValue("@CGPA_Discount", textBox8.Text);
            cmd.Parameters.AddWithValue("@IELTS_Discount", textBox9.Text);
            cmd.Parameters.AddWithValue("@Photo", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfully");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data Not Inserted");
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from RUSSIA_UNIVERSITY_INFORMATION_PORTAL";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[9];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 80;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update RUSSIA_UNIVERSITY_INFORMATION_PORTAL set University_Name=@University_Name,University_Rank=@University_Rank,University_Address=@University_Address,Department=@Department,Course=@Course,Course_Fees=@Course_Fees,Course_Credit=@Course_Credit,CGPA_Discount=@CGPA_Discount,IELTS_Discount=@IELTS_Discount,Photo=@Photo where University_Rank=@University_Rank";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@University_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@University_Rank", textBox2.Text);
            cmd.Parameters.AddWithValue("@University_Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Department", textBox4.Text);
            cmd.Parameters.AddWithValue("@Course", textBox5.Text);
            cmd.Parameters.AddWithValue("@Course_Fees", textBox6.Text);
            cmd.Parameters.AddWithValue("@Course_Credit", textBox7.Text);
            cmd.Parameters.AddWithValue("@CGPA_Discount", textBox8.Text);
            cmd.Parameters.AddWithValue("@IELTS_Discount", textBox9.Text);
            cmd.Parameters.AddWithValue("@Photo", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Update Successfully");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data Not Update");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from RUSSIA_UNIVERSITY_INFORMATION_PORTAL where University_Rank=@University_Rank";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@University_Rank", textBox2.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Deleted Successfully");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data Not Deleted");
            }
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            pictureBox1.Image = Properties.Resources.no_image_avaiable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[9].Value);
        }

        private Image GetPhoto(byte[] Photo)
        {
            MemoryStream ms = new MemoryStream(Photo);
            return Image.FromStream(ms);
        }

        private void Form36_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Form33 f33 = new Form33();
                f33.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
