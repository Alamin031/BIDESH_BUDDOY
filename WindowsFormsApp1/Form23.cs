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
    public partial class Form23 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public Form23()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from A_From";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[13];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 100;
        }

        private void Form23_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form14 f14 = new Form14();
                f14.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void Form23_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
