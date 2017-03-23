using Project.DAL;
using Project.DTL;
using System;
using System.Collections;
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
    public partial class WareHouseImport : Form
    {
        ArrayList listProduct;
        ArrayList listWareHouse;
        int productIDTemp = -1;
        string productNameTemp = "";
        public WareHouseImport()
        {
            InitializeComponent();
            listWareHouse = new ArrayList();
            listProduct = new ArrayList();
            listProduct = ProductDAO.getListProduct();
            LoadListBox(listProduct);
            setUpDataGidView();
        }

        private void setUpDataGidView()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Product ID";
            dataGridView1.Columns[1].Name = "Register Number";
            dataGridView1.Columns[2].Name = "Expiry Date";
            dataGridView1.Columns[3].Name = "Quantity";
            dataGridView1.Columns[4].Name = "Import Date";
        }

        private void LoadListBox(ArrayList listProduct)
        {
          //  listProduct = ProductDAO.getListProduct();
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn("ProductID", typeof(int));
            dt.Columns.Add(c);
            c = new DataColumn("ProductName", typeof(string));
            dt.Columns.Add(c);
            foreach (Product product in listProduct)
            {
                DataRow r = dt.NewRow();
                r["ProductID"] = product.Id;
                r["ProductName"] = product.Name;
                dt.Rows.Add(r);

            }
            lbProduct.DataSource = dt;
            lbProduct.DisplayMember = "ProductName";
            lbProduct.ValueMember = "ProductID";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ArrayList listProductSearch = new ArrayList();
            String nameProduct = txtSearch.Text;
            if (nameProduct.Equals(""))
            {
                LoadListBox(listProduct);

            }
            else
            {
                foreach (Product product in listProduct)
                {
                    if (product.Name.Contains(nameProduct))
                    {
                        listProductSearch.Add(product);
                    }
                }   
            LoadListBox(listProductSearch);
                

            }
        }

        private void lbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)lbProduct.SelectedItem;
            productIDTemp = int.Parse(drv["ProductID"].ToString());
            productNameTemp = drv["ProductName"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkInfomation();
            if(checkInfomation() != "")
            {
                Warehouse wh = new Warehouse(productIDTemp, txtRegister.Text.Trim(), dtpExpirydate.Value, int.Parse(txtQuantity.Text), dtpImportDate.Value);
                listWareHouse.Add(wh);
                loadDatagidView(listWareHouse);
            } else
            {
                MessageBox.Show(checkInfomation(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadDatagidView(ArrayList listWareHouse)
        {
            foreach(Warehouse wh in listWareHouse)
            {
                string[] row = new string[] { ProductDAO.getNameProductByID(wh.ProductID), wh.RegisteredNumber.ToString() , wh.ExpiryDate.ToString(), wh.Quantity.ToString(), wh.ImportDate.ToString() };
                dataGridView1.Rows.Add(row);
            }
        }

        

        private string checkInfomation()
        {
            String check = "";
            if(productIDTemp == -1)
            {
                check += "You dont choose any Product !!! /n";
            } else if(txtRegister.Text == "" || txtRegister.Text == null)
            {
                check += "You dont enter registerNumber  !!! /n";
            }
            else if (txtQuantity.Text == "" || txtQuantity.Text == null)
            {
                check += "You dont enter registerNumber  !!! /n";
            } else if(dtpExpirydate.Value <= DateTime.Now)
            {
                check += "Expriry Date is not <= DateNow  !!! /n";
            }

            try
            {
                int.Parse(txtQuantity.Text);
            }
            catch (Exception)
            {
                check += "Quantity is not valid";
            }
            return check;
        }
    }
}
