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
    public partial class Form11 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");

        public Form11()
        {
            InitializeComponent();
            Showtable();
        }

        private void button7_Click(object sender, EventArgs e)
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
                asd.CommandText = "insert into [vPlace]  values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'); ";

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

        }

        public void DBconnection()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            asd.CommandText = "select * from [vPlace]  where vId ='" + textBox8.Text + "'; ";

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
            asd.CommandText = "delete from [vPlace]  where vId ='" + textBox8.Text + "'; ";

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
                asd.CommandText = "update [vPlace] set vId ='" + textBox1.Text + "',City_Area='" + textBox2.Text + "',Visiting_Place='" + textBox3.Text + "',Narrest_Hotel='" + textBox4.Text + "',Average_Cost='" + textBox5.Text + "' where vId = '" + textBox8.Text + "' ; ";

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
            textBox8.Text = "";

        }

        public void Showtable()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            asd.CommandText = "select * from [vPlace] ";

            asd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(asd);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADD();
            Showtable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBconnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Updatetable();
            Showtable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Delete();
            Showtable();
        }
    }
}
