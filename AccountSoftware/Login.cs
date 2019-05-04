using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountSoftware
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "tejas" && textBox2.Text == "Tejas@123")
            {
                Tejas ob2 = new Tejas();
                Login ob = new Login();
                this.Hide();
                ob2.Show();

            }
            else
            {
                //label4.Text = "Incorrect Password....!!!";
                MessageBox.Show("Incorrect Password....!!!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
