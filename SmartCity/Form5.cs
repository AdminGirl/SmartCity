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
    public partial class Form5 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm3 = new Form1();
            frm3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 frm3 = new Form12();
            frm3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form13 frm3 = new Form13();
            frm3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form14 frm3 = new Form14();
            frm3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form15 frm3 = new Form15();
            frm3.Show();
            this.Hide();
        }

        public void DBconnection()
        {
            string fb = string.Empty;
            if (radioButton1.Checked)
            {
                fb = "Excellent";
            }
            else if (radioButton2.Checked)
            {
                fb = "Good";
            }
            else if (radioButton3.Checked)
            {
                fb = "Average";
            }
            else if (radioButton4.Checked)
            {
                fb = "Bad";
            }
            try
            {

                con.Open();
                SqlCommand asd = con.CreateCommand();
                asd.CommandType = CommandType.Text;
                asd.CommandText = "insert into [FeedBack]  values ('" + fb + "'); ";

                asd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("saved");

            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DBconnection();
        }
    }
}
