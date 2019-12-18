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
    public partial class Form10 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");

        public Form10()
        {
            InitializeComponent();
            Showtable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
            this.Hide();
        }

        public void ADD()
        {
            try
            {

                con.Open();
                SqlCommand asd = con.CreateCommand();
                asd.CommandType = CommandType.Text;
                asd.CommandText = "insert into [Parlour]  values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'); ";

                asd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("saved");

               
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                con.Close();
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

        }

        public void DBconnection()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            asd.CommandText = "select * from [Parlour]  where pId ='" + textBox8.Text + "'; ";

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
            asd.CommandText = "delete from [Parlour]  where pId ='" + textBox8.Text + "'; ";

            asd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Deleted");
        }

        public void Updatetable()
        {
            try
            {

                con.Open();
                SqlCommand asd = con.CreateCommand();
                asd.CommandType = CommandType.Text;
                asd.CommandText = "update [Parlour] set pId ='" + textBox1.Text + "',City_Area='" + textBox2.Text + "',Parlour_Name='" + textBox3.Text + "',Hair_Cut='" + textBox4.Text + "',Bridal_Makeover='" + textBox5.Text + "',Skin_Care_Package='" + textBox6.Text + "',Saree_Setup='" + textBox7.Text + "' where pId = '" + textBox8.Text + "' ; ";

                asd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Updated");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                con.Close();
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

        }

        public void Showtable()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            asd.CommandText = "select * from [Parlour] ";

            asd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(asd);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADD();
            Showtable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBconnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Updatetable();
            Showtable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete();
            Showtable();
        }
    }
}
