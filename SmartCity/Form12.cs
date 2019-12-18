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
    public partial class Form12 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");

        public Form12()
        {
            InitializeComponent();
            ShowHotel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowHotel();

        }

        public void ShowHotel()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            if (textBox1.Text != "")
            {
                asd.CommandText = "select City_Area,Hotel_NAme, Single_Room,Couple_Room, Luxury_Room,Suite_Room from [Hotel] where City_Area like '" + textBox1.Text + "%' ; ";
            }
            else
            {
                asd.CommandText = "select City_Area,Hotel_NAme, Single_Room,Couple_Room, Luxury_Room,Suite_Room from [Hotel] ";
            }
            asd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(asd);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            textBox1.Text = "";

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm3 = new Form5();
            frm3.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
