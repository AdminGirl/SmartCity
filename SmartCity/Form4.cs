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
    public partial class Form4 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnection();

        }

        public void DBconnection()
        {
            string gen = string.Empty;
            if (radioButton1.Checked)
            {
                gen = "Male";
            }
            else if (radioButton2.Checked)
            {
                gen = "Female";
            }
            try
            {

                con.Open();
                SqlCommand asd = con.CreateCommand();
                asd.CommandType = CommandType.Text;
                asd.CommandText = "insert into [USER] (id,uName,uAddress,uAge,uEmail,uPassword,uGander) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + gen + "'); ";

                asd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("saved");

                Form5 frm3 = new Form5();
                frm3.Show();
                this.Hide();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
