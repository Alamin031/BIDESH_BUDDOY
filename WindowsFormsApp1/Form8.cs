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
    public partial class Form8 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public Form8()
        {
            InitializeComponent();
            BindGridView();
            ResetControl();
           
        }
        private void button6_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into u_i_portal values (@u_id,@u_rank,@u_name,@u_address,@u_photo)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@u_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@u_rank", textBox2.Text);
            cmd.Parameters.AddWithValue("@u_name", textBox3.Text);
            cmd.Parameters.AddWithValue("@u_address", textBox4.Text);
            cmd.Parameters.AddWithValue("@u_photo", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a>0)
            {
                MessageBox.Show("Data Inserted Successfully");
                BindGridView();
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
            string query = "select * from u_i_portal";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data; 

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 50;
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }


        private void button7_Click(object sender, EventArgs e)
        {
          
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update u_i_portal set u_id=@u_id,u_rank=@u_rank,u_name=@u_name,u_address=@u_address,u_photo=@u_photo where u_id=@u_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@u_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@u_rank", textBox2.Text);
            cmd.Parameters.AddWithValue("@u_name", textBox3.Text);
            cmd.Parameters.AddWithValue("@u_address", textBox4.Text);
            cmd.Parameters.AddWithValue("@u_photo", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Update Successfully");
                BindGridView();
            }
            else
            {
                MessageBox.Show("Data Not Update");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[4].Value);
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from u_i_portal where u_id=@u_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@u_id", textBox1.Text);

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
            pictureBox1.Image = Properties.Resources.no_image_avaiable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
