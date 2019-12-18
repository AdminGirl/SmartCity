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
    public partial class Form14 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");

        public Form14()
        {
            InitializeComponent();
            Showparlour();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Showparlour();
        }

        public void Showparlour()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            if (textBox1.Text != "")
            {
                asd.CommandText = "select  City_Area,Parlour_Name,Hair_Cut, Bridal_Makeover,Skin_Care_Package,Saree_Setup from [Parlour]  where City_Area like '" + textBox1.Text + "%'; ";
            }
            else
            {
                asd.CommandText = "select  City_Area,Parlour_Name,Hair_Cut, Bridal_Makeover,Skin_Care_Package,Saree_Setup from [Parlour] ";
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
