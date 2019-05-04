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
    public partial class CostumerDetails : Form
    {

        public CostumerDetails()
        {
            InitializeComponent();
        }

        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TejasDatabase.mdf;Integrated Security=True";

        private void CostumerDetails_Load(object sender, EventArgs e)
        {
            LoadTejasCostumers();
            TotalCount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void LoadTejasCostumers()
        {
            
            string sql = "SELECT * FROM TejasAccount";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            SDataSet ds = new SDataSet();
            connection.Open();
            dataadapter.Fill(ds, "TejasAccount");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TejasAccount";
        }

        void TotalCount()
        {
            string TejasDb = "SELECT COUNT(*) Sno FROM TejasAccount";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(TejasDb, con);
            con.Open();
            label2.Text = cmd.ExecuteScalar().ToString();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ClientInvoice ci = new ClientInvoice(textBox1.Text);

            ci.Show();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            
            ClientInvoice ci = new ClientInvoice(selectedRow.Cells[0].Value.ToString());

            ci.Show();

        }
    }
}

