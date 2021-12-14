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
    public partial class Form30 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
        public Form30()
        {
            InitializeComponent();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            label14.Text = Form14.Form_No;
        }

        private void Form30_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            SqlConnection con = new SqlConnection(cs);
            string query = "insert into Educational_Background values (@Form_No,@SSC_Board,@SSC_group,@SSC_GPA,@HSC_Board,@HSC_group,@HSC_GPA,@Religion,@Economic_conditions,@Parents_occupation,@Proficiency_text,@IELTS_Band_score,@GRE_score)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Form_NO", textBox3.Text);
            cmd.Parameters.AddWithValue("@SSC_Board", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@SSC_group", comboBox5.SelectedItem);
            cmd.Parameters.AddWithValue("@SSC_GPA", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@HSC_Board", comboBox3.SelectedItem);
            cmd.Parameters.AddWithValue("@HSC_group", comboBox6.SelectedItem);
            cmd.Parameters.AddWithValue("@HSC_GPA", comboBox4.SelectedItem);
            cmd.Parameters.AddWithValue("@Religion", comboBox8.SelectedItem);
            cmd.Parameters.AddWithValue("@Economic_conditions", comboBox10.SelectedItem);
            cmd.Parameters.AddWithValue("@Parents_occupation", comboBox9.SelectedItem);
            cmd.Parameters.AddWithValue("@Proficiency_text", comboBox7.SelectedItem);
            cmd.Parameters.AddWithValue("@IELTS_Band_score", textBox1.Text);
            cmd.Parameters.AddWithValue("@GRE_score", textBox2.Text);




            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Form31 f31 = new Form31();
                f31.Show();
                this.Hide();
                MessageBox.Show("Data Submit Successfully");
                ResetControl();


            }
            else
            {
                MessageBox.Show("Data Not Submit");
            }
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            comboBox5.SelectedItem = null;
            comboBox6.SelectedItem = null;
            comboBox7.SelectedItem = null;
            comboBox8.SelectedItem = null;
            comboBox9.SelectedItem = null;
            comboBox10.SelectedItem = null;
            
        }

        private void Form30_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
