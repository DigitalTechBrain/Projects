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
    public partial class ClientInvoice : Form
    {
        public string Conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TejasDatabase.mdf;Integrated Security=True";

        public int StuffId { get; set; }

        public ClientInvoice(string str)
        {
            StuffId = Convert.ToInt16(str);
           

        InitializeComponent();

           
        }

        private void ClientInvoice_Load(object sender, EventArgs e)
        {
            

            ConnectionToDb();
        }

        void ConnectionToDb()
        {
            
            


            string str = "select * from TejasAccount where Sno = '" + StuffId + "'";

            SqlDataAdapter sda = new SqlDataAdapter(str, Conn);
            SDataSet  ds = new SDataSet();

            sda.Fill(ds,"TejasAccount");

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No data Found", "CrystalReportWithOracle");
                return;
            }

            var result = ds.TejasAccount.Select(c => new
            {
                
                ProductName = c.ProductName,
                Sno =   "A100" + c.Sno,
                ClientAddress = c.ClientAddress,
                ProductAmount = c.ProductAmount,
                ClientName = c.ClientName,
                ClientMail = c.ClientMail,
                Phone = c.Phone

            }).ToList();
            TejasCrystalReport crg = new TejasCrystalReport();
            crg.SetDataSource(result);
            this.crystalReportViewer1.ReportSource = crg;


            

        }

        private void TejasCrystalReport1_InitReport(object sender, EventArgs e)
        {

        }
    }
}
