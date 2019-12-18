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
    public partial class Form8 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A5U3RHS\SAIDASQL;Initial Catalog=ProductDB;Integrated Security=True");
        public Form8()
        {
            InitializeComponent();
            Showtable();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public void ADD()
        {
            try
            {

                con.Open();
                SqlCommand asd = con.CreateCommand();
                asd.CommandType = CommandType.Text;
                asd.CommandText = "insert into [Admin]  values ('" + textBox1.Text + "','" + textBox2.Text + "'); ";

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



        }

        public void Showtable()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            asd.CommandText = "select * from [Admin] ";

            asd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(asd);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        public void Updatetable()
        {
            try
            {

                con.Open();
                SqlCommand asd = con.CreateCommand();
                asd.CommandType = CommandType.Text;
                asd.CommandText = "update [Admin] set Email ='" + textBox1.Text + "',Passwoed='" + textBox2.Text + "' where Email ='" + textBox3.Text + "' ; ";

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

        }

        public void Delete()
        {
            con.Open();
            SqlCommand asd = con.CreateCommand();
            asd.CommandType = CommandType.Text;
            asd.CommandText = "delete from [Admin]  where Email ='" + textBox3.Text + "' ; ";

            asd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Deleted");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete();
            Showtable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Updatetable();
            Showtable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADD();
            Showtable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
            this.Hide();
        }
    }
}
