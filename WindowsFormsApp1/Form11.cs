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
    public partial class Form11 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public Form11()
        {
            InitializeComponent();
            BindGridView();
            ResetControl();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into d_c_info values (@UNIVERSITY_ID,@Department,@Course)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UNIVERSITY_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Department", textBox2.Text);
            cmd.Parameters.AddWithValue("@Course", textBox3.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfully");
                BindGridView();
            }
            else
            {
                MessageBox.Show("Data Not Inserted");
            }
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from d_c_info";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 80;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update d_c_info set UNIVERSITY_ID=@UNIVERSITY_ID,Department=@Department,Course=@Course where UNIVERSITY_ID=@UNIVERSITY_ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UNIVERSITY_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Department", textBox2.Text);
            cmd.Parameters.AddWithValue("@Course", textBox3.Text);


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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from d_c_info where UNIVERSITY_ID=@UNIVERSITY_ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UNIVERSITY_ID", textBox1.Text);

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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
    }
}

