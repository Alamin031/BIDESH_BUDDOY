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
    public partial class Form24 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public Form24()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from u_d_info";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 50;
            con.Open();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Form9 f9 = new Form9();
                f9.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form24_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
