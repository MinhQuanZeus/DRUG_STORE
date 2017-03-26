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
    public partial class MainGUI : Form
    {
        private Staff staff;
        public MainGUI(Staff staff)
        {            
            InitializeComponent();
            this.staff = staff;
            tsbWarehouse.ToolTipText = "Warehouse";
        }

        private void tsbWarehouse_Click(object sender, EventArgs e)
        {
            ProductsGUI rs = new ProductsGUI(staff);
            rs.FormBorderStyle = FormBorderStyle.None;
            rs.TopLevel = false;
            rs.Show();
            this.toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(rs);
        }

        private void dayEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DayEndGUI rs = new DayEndGUI(staff);
            rs.FormBorderStyle = FormBorderStyle.None;
            rs.TopLevel = false;
            rs.Show();
            this.toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(rs);
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales rs = new Sales(staff);
            rs.FormBorderStyle = FormBorderStyle.None;
            rs.TopLevel = false;
            rs.Show();
            this.toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(rs);
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductReport pr = new ProductReport();
            pr.FormBorderStyle = FormBorderStyle.None;
            pr.TopLevel = false;
            pr.Show();
            this.toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(pr);
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerReport cr = new CustomerReport();
            cr.FormBorderStyle = FormBorderStyle.None;
            cr.TopLevel = false;
            cr.Show();
            this.toolStripContainer1.ContentPanel.Controls.Clear();
            toolStripContainer1.ContentPanel.Controls.Add(cr);
        }
    }
}
