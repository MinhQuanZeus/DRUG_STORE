using Project.DTL;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace Project.GUI
{
    public partial class DayEndGUI : Form
    {
        Staff staff;
        static string strConn = ConfigurationManager.ConnectionStrings["DRUG_STOREConnectionString"].ConnectionString;
        public DayEndGUI(Staff staff)
        {
            InitializeComponent();
            this.staff = staff;
            DateTime dt = DateTime.Now;
            label4.Text = String.Format("Time:" + "{0:dd/MM/yyyy hh:MM}", dt);
            label2.Text = "Day Search:" + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");
            dataGridView1.DataSource = DAL.DAO.GetDataTable("select b.BillID as N'Voucher code',b.CreateDate as N'Create Date',bd.Quantity,p.Name as N'Product Name',p.Price,p.SellPrice as N'Sell Price',(p.SellPrice-p.Price)*bd.Quantity as N'Revenue' from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID");
            comboBox1.DataSource = DAL.DAO.GetDataTable("select * from Staffs");
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "StoreID";
            if (staff.IsManager == false)
            {
                comboBox2.DataSource = DAL.DAO.GetDataTable("select s.Name,s.StoreID from Stores s join Staffs st on s.StoreID = st.StoreID where st.StaffID = '"+staff.Id+"' group by s.Name, s.StoreID ");
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "StoreID";
            }
            comboBox3.DataSource= DAL.DAO.GetDataTable("select * from Products");
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "ProductID";

            label6.Text = "Total Money: " + DAL.BillDAO.GetTotalPrice();
            groupBox4.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = "Day Search:" + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");
            double price=0;
            if (rdBanHang.Checked)
            {
                dataGridView1.DataSource = DAL.DAO.GetDataTable("select b.BillID as N'Voucher code',b.CreateDate as N'Create Date',bd.Quantity,p.Name as N'Product Name',p.Price,p.SellPrice as N'Sell Price',(p.SellPrice-p.Price)*bd.Quantity as N'Income' from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID where b.CreateDate = '" + dateTimePicker1.Value.Date + "'");
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("select 'TA' = sum((p.SellPrice-p.Price)*bd.Quantity) from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID where b.StaffID ='" + dateTimePicker1.Value.Date + "'", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["TA"].ToString() == "")
                    {
                        price = 0;
                    }
                    else
                    {
                        price = double.Parse(dr["TA"].ToString());
                    }
                    dr.Close();
                }
                conn.Close();
                label6.Text = "Total Money: " + price ;
            }
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            label5.Text = "Total number of orders: " + dataGridView1.RowCount;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DAL.DAO.GetDataTable(" select b.BillID as N'Voucher code',b.CreateDate as N'Create Date',bd.Quantity,p.Name as N'Product Name',p.Price,p.SellPrice as N'Sell Price',(p.SellPrice-p.Price)*bd.Quantity as N'Revenue' from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID where b.StaffID = '" +comboBox1.SelectedValue+"'");
            label6.Text = "Total Money: " + DAL.BillDAO.GetTotalPriceByID(int.Parse(comboBox1.SelectedValue.ToString()));
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
            }
            else
            {
                groupBox4.Visible = false;
                groupBox1.Visible = true;
                groupBox3.Visible = true;
                label6.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= DAL.DAO.GetDataTable("select p.ProductID,p.Name,p.Description,p.StoreID,p.Unit,pu.UnitName,p.Status from Products p join ProductUnit pu on p.ProductID =pu.ProductID where p.ProductID like'%"+comboBox3.SelectedValue+ "%' and p.StoreID like '%"+comboBox2.SelectedValue+"%' ");
        }
    }
}
