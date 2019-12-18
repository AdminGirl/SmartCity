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
    public partial class Form3 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            con.Open();
                SqlCommand asd = con.CreateCommand();
                asd.CommandType = CommandType.Text;
                asd.CommandText = "select * from [USER]  where uEmail ='" + textBox1.Text.Trim() + "' and uPassword ='" + textBox2.Text.Trim() + "' ; ";

                asd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sd = new SqlDataAdapter(asd);
                sd.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show(" You are logged in successfully.");
                    Form5 frm5 = new Form5();
                    frm5.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Possword or Email");
                }

                con.Close();

            }

            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
