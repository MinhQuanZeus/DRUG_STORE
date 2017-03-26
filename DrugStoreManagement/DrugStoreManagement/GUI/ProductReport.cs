using Project.DAL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project.GUI
{
    public partial class ProductReport : Form
    {
        string maxDate;
        public ProductReport()
        {
            InitializeComponent();
           
            string ConnectionString = ConfigurationManager.ConnectionStrings["DRUG_STOREConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string sql = "select max(CreateDate) from Bills";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                maxDate = dr[0].ToString();
            }
           
            DataTable dt = DAO.GetDataTable("select Products.ProductID, Products.Name,sum(BillDetails.Quantity) as Quantity,BillDetails.Unit, sum(BillDetails.Price) as Capital , sum(BillDetails.SellPrice) as Revenue, sum(BillDetails.SellPrice)-sum(BillDetails.Price) as Benefit, Bills.CreateDate from Products, BillDetails, Bills where Products.ProductID = BillDetails.ProductID and Bills.BillID = BillDetails.BillID group by Products.ProductID, Products.Name, BillDetails.Unit, Bills.CreateDate");
            dataGridView1.DataSource = dt;
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            if (!maxDate.Equals(""))
            {
                d = DateTime.Parse(maxDate);
            }

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            if (startDate > d)
            {
                MessageBox.Show("Start date must be less " + d + "", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DataTable dt1 = DAO.GetDataTable("select Products.ProductID, Products.Name,sum(BillDetails.Quantity) as Quantity,BillDetails.Unit, sum(BillDetails.Price) as Capital , sum(BillDetails.SellPrice) as Revenue, sum(BillDetails.SellPrice)-sum(BillDetails.Price) as Benefit, Bills.CreateDate from Products, BillDetails, Bills where Products.ProductID = BillDetails.ProductID and Bills.BillID = BillDetails.BillID and Bills.CreateDate < '" + endDate + "' and Bills.CreateDate > '" + startDate + "' group by Products.ProductID, Products.Name, BillDetails.Unit, Bills.CreateDate order by Bills.CreateDate");
                dataGridView1.DataSource = dt1;
            }
           
        }
    }
}
