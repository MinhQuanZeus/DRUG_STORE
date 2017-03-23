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
            label4.Text = String.Format("Thời Gian:" + "{0:dd/MM/yyyy}", dt);
            label2.Text = "Ngày Bán:" + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");
            dataGridView1.DataSource = DAL.DAO.GetDataTable("select b.BillID as N'Mã chứng từ',b.CreateDate as N'Thời gian',bd.Quantity as N'SL Sản phẩm',p.Name as N'Tên Sản Phẩm',p.Price as N'Giá Nhập',p.SellPrice as N'Giá Bán',(p.SellPrice-p.Price)*bd.Quantity as N'Doanh Thu' from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID");
            label6.Text = "Tổng Tiền: " + DAL.BillDAO.GetTotalPrice();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = "Ngày Bán:" + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");
            if (cbBanHang.Checked)
            {
                dataGridView1.DataSource = DAL.DAO.GetDataTable("select b.BillID as N'Mã chứng từ',b.CreateDate as N'Thời gian',bd.Quantity as N'SL Sản phẩm',(p.SellPrice-p.Price)*bd.Quantity as N'Doanh Thu' from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID");
                label6.Text= "Tổng Tiền: " + DAL.BillDAO.GetTotalPrice();
            }
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            label5.Text = "Tổng Số Đơn Hàng: " + dataGridView1.RowCount;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (DAL.BillDAO.GetTotalPriceByID(int.Parse(textBox1.Text)) == 0)
            {
                label8.Text = "Xin Lỗi! ID Nhân Viên này không có mặt hàng nào đã bán hoặc ID Nhân Viên đó không tồn tại!";
            }else
            {
                label8.Text = "";
            }
            dataGridView1.DataSource = DAL.DAO.GetDataTable(" select b.BillID as N'Mã chứng từ',b.CreateDate as N'Thời gian',bd.Quantity as N'SL Sản phẩm', p.Name as N'Tên Sản Phẩm', p.Price as N'Giá Nhập', p.SellPrice as N'Giá Bán', (p.SellPrice - p.Price) * bd.Quantity as N'Doanh Thu' from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID where b.StaffID = '"+int.Parse(textBox1.Text)+"'");
            label6.Text = "Tổng Tiền: " + DAL.BillDAO.GetTotalPriceByID(int.Parse(textBox1.Text));
        }

        private void DayEndGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
