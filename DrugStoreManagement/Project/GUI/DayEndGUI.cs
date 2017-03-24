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
    public partial class DayEndGUI : Form
    {
        public DayEndGUI()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            label4.Text = String.Format("Time:" + "{0:dd/MM/yyyy}", dt);
            label2.Text = "Day Search:" + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");
            dataGridView1.DataSource = DAL.DAO.GetDataTable("select b.BillID as N'Voucher code',b.CreateDate as N'Create Date',bd.Quantity,p.Name as N'Product Name',p.Price,p.SellPrice as N'Sell Price',(p.SellPrice-p.Price)*bd.Quantity as N'Revenue' from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID");
            label6.Text = "Total Money: " + DAL.BillDAO.GetTotalPrice();
            groupBox4.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = "Day Search:" + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");
            if (rdBanHang.Checked)
            {
                dataGridView1.DataSource = DAL.DAO.GetDataTable("select b.BillID as N'Voucher code',b.CreateDate as N'Create Date',bd.Quantity,p.Name as N'Product Name',p.Price,p.SellPrice as N'Sell Price',(p.SellPrice-p.Price)*bd.Quantity as N'Revenue' from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID where b.CreateDate = '"+dateTimePicker1.Value.Date+"'");
                label6.Text= "Total Money: " + DAL.BillDAO.GetTotalPrice();
            }
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            label5.Text = "Total number of orders: " + dataGridView1.RowCount;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (DAL.BillDAO.GetTotalPriceByID(int.Parse(textBox1.Text)) == 0)
            {
                label8.Text = "Sorry! This StaffID has no items sold or StaffID does not exist!";
            }else
            {
                label8.Text = "";
            }
            dataGridView1.DataSource = DAL.DAO.GetDataTable(" select b.BillID as N'Voucher code',b.CreateDate as N'Create Date',bd.Quantity,p.Name as N'Product Name',p.Price,p.SellPrice as N'Sell Price',(p.SellPrice-p.Price)*bd.Quantity as N'Revenue' from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID where b.StaffID = '" + int.Parse(textBox1.Text)+"'");
            label6.Text = "Total Money: " + DAL.BillDAO.GetTotalPriceByID(int.Parse(textBox1.Text));
        }

        private void DayEndGUI_Load(object sender, EventArgs e)
        {

        }

        private void rdBanHang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdHangHoa.Checked)
            {
                groupBox4.Visible = true;
                groupBox1.Visible = false;
                groupBox3.Visible = false;
                dataGridView1.DataSource = DAL.DAO.GetDataTable("select p.ProductID,p.Name,p.Description,p.StoreID,p.Unit,pu.UnitName,p.Status from Products p join ProductUnit pu on p.ProductID =pu.ProductID");
                label6.Visible = false;
            }else
            {
                groupBox4.Visible = false;
                groupBox1.Visible = true;
                groupBox3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productID = "";
            string storeID = "";
            if (txt3.Text != null)
            {
                 productID = txt3.Text;
            }
            if (txt2.Text != null)
            {
                storeID = txt2.Text;
            }
            dataGridView1.DataSource= DAL.DAO.GetDataTable("select p.ProductID,p.Name,p.Description,p.StoreID,p.Unit,pu.UnitName,p.Status from Products p join ProductUnit pu on p.ProductID =pu.ProductID where p.ProductID like'%"+productID+ "%' and p.StoreID like '%"+storeID+"%' ");
        }
    }
}
