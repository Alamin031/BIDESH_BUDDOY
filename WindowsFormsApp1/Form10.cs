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
    public partial class Form10 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;

        public Form10()
        {
            InitializeComponent();
           // BindGridView();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
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
            con.Open();

        }
      // private void BindGridView()
       // {
           // SqlConnection con = new SqlConnection(cs);
           // string query = "select * from u_i_portal";
           // SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //DataTable data = new DataTable();
          //  sda.Fill(data);
           // dataGridView1.DataSource = data;

           // DataGridViewImageColumn dgv = new DataGridViewImageColumn();
           // dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
           // dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

           // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

           // dataGridView1.RowTemplate.Height = 50;
            //con.Open();

        }
    }

