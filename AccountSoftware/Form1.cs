using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AccountSoftware
{
    public partial class Tejas : Form
    {
        public Tejas()
        {
            InitializeComponent();
        }

        public string Conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TejasDatabase.mdf;Integrated Security=True";

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertRecords();
            //label10.Text = "Records Inserted Sucessfully....!!!";
            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            MessageBox.Show("Records Inserted Sucessfully....!!!");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CostumerDetails cd = new CostumerDetails();
            
            cd.Show();

        }

        void InsertRecords()
        {
            string TejasDb = "insert into TejasAccount values('"+comboBox1.Text.ToString()+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox5.Text+"','"+dateTimePicker1.Text.ToString()+"','"+textBox4.Text+"')";
            SqlConnection con = new SqlConnection(Conn);
            SqlCommand cmd = new SqlCommand(TejasDb,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
