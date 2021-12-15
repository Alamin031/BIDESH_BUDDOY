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
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            int a = comboBox1.SelectedIndex;

            if (a == 0)
            {
                string query = "select * from USA_UNIVERSITY_INFORMATION_PORTAL";
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
            else if(a == 1)
            {
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
            else if(a == 2)
            {
                string query = "select * from EUROPE_UNIVERSITY_INFORMATION_PORTAL";
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
           
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form7 f7 = new Form7();
                f7 .Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
