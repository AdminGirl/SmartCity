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
using MySql.Data.MySqlClient;

namespace SmartCity
{
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public void LogIn()
        {
            try
            {
                con.Open();
                SqlCommand asd = con.CreateCommand();
                asd.CommandType = CommandType.Text;
                asd.CommandText = "select * from [Admin]  where Email ='" + textBox1.Text.Trim() + "' and Passwoed ='" + textBox2.Text.Trim() + "' ; ";

                asd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sd = new SqlDataAdapter(asd);
                sd.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show(" You are logged in successfully.");
                    Form6 frm6 = new Form6();
                    frm6.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Possword or Email");
                }

                con.Close();

            }

            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }


    }
}
