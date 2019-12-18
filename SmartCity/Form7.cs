using MySql.Data.MySqlClient;
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
    public partial class Form7 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");
        public Form7()
        {
            InitializeComponent();
            Showtable();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ADD();
            Showtable();

        }




        private void button2_Click(object sender, EventArgs e)
        {
            Updatetable();
            Showtable();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
            Showtable();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void ADD()
        {
            try
            {

                con.Open();
                SqlCommand asd = con.CreateCommand();
                asd.CommandType = CommandType.Text;
                asd.CommandText = "insert into [Hotel]  values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'); ";

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
            asd.CommandText = "select * from [Hotel]  where hId ='" + textBox8.Text + "'; ";

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
            asd.CommandText = "delete from [Hotel]  where hId ='" + textBox8.Text + "'; ";

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
                asd.CommandText = "update [Hotel] set hId ='" + textBox1.Text + "',City_Area='" + textBox2.Text + "',Hotel_NAme='" + textBox3.Text + "',Single_Room='" + textBox4.Text + "',Couple_Room='" + textBox5.Text + "',Luxury_Room='" + textBox6.Text + "',Suite_Room='" + textBox7.Text + "' where hId = '" + textBox8.Text + "' ; ";
                                                                                                                                                                                                                                                 
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
            try
            {
                con.Open();
                SqlCommand asd = con.CreateCommand();
                asd.CommandType = CommandType.Text;
                asd.CommandText = "select * from [Hotel] ";

                asd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sd = new SqlDataAdapter(asd);
                sd.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Showtable();
        }
    }
}
