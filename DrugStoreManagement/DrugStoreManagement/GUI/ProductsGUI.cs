using Project.DTL;
using System;
using System.Windows.Forms;

namespace Project.GUI
{
    public partial class ProductsGUI : Form
    {
        Staff staff;
        public ProductsGUI(Staff staff)
        {
            InitializeComponent();
            this.staff = staff;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductGUI addProduct = new AddProductGUI(staff);
            addProduct.ShowDialog();
        }
    }
}
