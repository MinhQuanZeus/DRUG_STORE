using Project.DTL;
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
    public partial class Sales : Form
    {
        Staff staff;
        public Sales(Staff staff)
        {
            InitializeComponent();
            this.staff = staff;
            DateTime dt = DateTime.Now;
            label2.Text = String.Format("Time:" + "{0:dd/MM/yyyy hh:MM}", dt);
            label5.Text = "Information Month: " + dateTimePicker3.Value.Month + " of StaffID: " + comboBox1.SelectedValue;
            label9.Visible = false;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "MM/yyyy";

            if (staff.IsManager==false)
            {
                comboBox1.DataSource = DAL.DAO.GetDataTable("select * from Staffs where storeID = '"+staff.StoreID+"'");
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "StaffID";
            }else
            {
                comboBox1.DataSource = DAL.DAO.GetDataTable("select * from Staffs where StaffID = '"+staff.Id+"'");
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "StaffID";
            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }


        private void rdProfit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdStaff.Checked)
            {
                groupBox3.Visible = true;
                btnSearch.Visible = false;
                Search.Visible = true;
                label9.Visible = true;
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DAL.DAO.GetDataTable("select s.StaffID,s.Name,s.Address,s.Phone,SUM ((bd.SellPrice - bd.Price)*bd.Quantity) as 'Income Total' from Staffs s join Bills b  on s.StaffID = b.StaffID join BillDetails bd on b.BillID = bd.BillID where MONTH(b.CreateDate) = '"+dateTimePicker3.Value.Month+"' and s.StaffID like '%"+comboBox1.SelectedValue+ "%' group by s.StaffID, s.Name,s.Address,s.Phone");
            label5.Text = "Information Month: " + dateTimePicker3.Value.Month + " of StaffID: " + comboBox1.SelectedValue;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                label9.Text = "Sorry! This Staff has no billorders or StaffID does not exist!";
            }else
            {
                label9.Text = "";
            }
        }
    }
}
