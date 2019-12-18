using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCity
{
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");


        public Form6()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm3 = new Form1();
            frm3.Show();
            this.Hide();
        }

        public void DBconnection()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            asd.CommandText = "select * from [USER] ";

            asd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(asd);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            asd.CommandText = "select * from [USER]  where Id ='" + textBox1.Text + "' ; ";

            asd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(asd);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        public void Delete()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            asd.CommandText = "delete from [USER]  where Id ='" + textBox1.Text + "' ; ";

            asd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Delete();
            DBconnection();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form8 frm6 = new Form8();
            frm6.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form9 frm6 = new Form9();
            frm6.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form10 frm6 = new Form10();
            frm6.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form11 frm6 = new Form11();
            frm6.Show();
            this.Hide();
        }

        public void fBack()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            asd.CommandText = "select * from [FeedBack] ";

            asd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(asd);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fBack();
        }
    }
}
