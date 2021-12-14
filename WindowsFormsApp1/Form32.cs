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
    public partial class Form32 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public Form32()
        {
            InitializeComponent();
            BindGridView();
        }

        private void Form32_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * From Educational_Background";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 80;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form15 f15 = new Form15();
                f15.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
