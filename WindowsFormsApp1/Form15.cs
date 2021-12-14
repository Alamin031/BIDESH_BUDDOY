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
    public partial class Form15 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public Form15()
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

        private void Form15_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
                Form32 f32 = new Form32();
                f32.Show();
                this.Hide();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}