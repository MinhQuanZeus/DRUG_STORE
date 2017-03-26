using Project.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.GUI
{
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
            DataTable dt = DAO.GetDataTable("select Customers.CustomerID,Customers.Name,Customers.Address,sum(Bills.BillID) as TotalBill,sum(BillDetails.SellPrice) as Buy,sum(BillDetails.SellPrice)-sum(BillDetails.Price) as Benefit , Bills.isDebt from Customers,Bills,BillDetails  where Customers.CustomerID = Bills.CustomerID and Bills.BillID = BillDetails.BillID group by Customers.CustomerID, Customers.Name, Customers.Address, Bills.isDebt");
            dataGridView1.DataSource = dt;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt1 = DAO.GetDataTable("select Customers.CustomerID,Customers.Name,Customers.Address,sum(Bills.BillID) as TotalBill,sum(BillDetails.SellPrice) as Buy,sum(BillDetails.SellPrice)-sum(BillDetails.Price) as Benefit , Bills.isDebt from Customers,Bills,BillDetails  where Customers.CustomerID = Bills.CustomerID and Bills.BillID = BillDetails.BillID group by Customers.CustomerID, Customers.Name, Customers.Address, Bills.isDebt");
            dataGridView1.DataSource = dt1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt2 = DAO.GetDataTable("select Customers.CustomerID,Customers.Name,Customers.Address,Products.Name as ProductName, sum(BillDetails.Quantity) as Quantity from Customers,Bills,BillDetails,Products where Customers.CustomerID = Bills.CustomerID and Bills.BillID = BillDetails.BillID and BillDetails.ProductID = Products.ProductID group by Customers.CustomerID, Customers.Name, Products.Name, Customers.Address order by Customers.CustomerID");
            dataGridView1.DataSource = dt2;
        }
    }
}
