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
    public partial class Form27 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public Form27()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from a_r_info";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 50;
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from a_r_info where phn_num=@phn_num";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
                MessageBox.Show("Data Delete Successfully");
            }
            else
            {
                MessageBox.Show("Data Not Delete");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Form6 f6 = new Form6();
                f6.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form27_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[7].Value);
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * a_r_info";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 50;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update a_r_info set name=@name,phn_num=@phn_num,email=@email,country=@country,n_p_number=@n_p_number,address=@address,pass=@pass,photo=@photo where phn_num=@phn_num";
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
                MessageBox.Show("Data update Successfully");
            }
            else
            {
                MessageBox.Show("Data Not update");
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void Form27_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
