using Project.DAL;
using Project.DTL;
using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Project.GUI
{
    public partial class AddProductGUI : Form
    {
        int count;
        Staff staff;
        public AddProductGUI(Staff staff)
        {
            InitializeComponent();
            this.staff = staff;
            lblUnit.Visible = false;
            lblConvertValue.Visible = false;
            lblSellPrice.Visible = false;
            cbbCategory.DataSource = ProductypeDAO.getAllProductType();
            cbbCategory.DisplayMember = "ProductTypeName";
            cbbCategory.ValueMember = "ProductTypeID";
        }

        private void btnAddUmit_Click(object sender, EventArgs e)
        {
            lblUnit.Visible = true;
            lblConvertValue.Visible = true;
            lblSellPrice.Visible = true;            
            TextBox textbox = new TextBox();
            count = (panel1.Controls.OfType<TextBox>().ToList().Count)/3;
            textbox.Location = new Point(10, 28 * count);
            textbox.Size = new Size(150, 20);
            textbox.Name = "txtUnit" + (count + 1);
            panel1.Controls.Add(textbox);

           textbox = new TextBox();
            count = (panel1.Controls.OfType<TextBox>().ToList().Count)/3;
            textbox.Location = new Point(163, 28 * count);
            textbox.Size = new Size(150, 20);
            textbox.Name = "txtConvertValue" + (count + 1);
            textbox.KeyPress += this.txtPrice_KeyPress;
            panel1.Controls.Add(textbox);

            textbox = new TextBox();
            count = (panel1.Controls.OfType<TextBox>().ToList().Count)/3;
            textbox.Location = new Point(315, 28 * count);
            textbox.Size = new Size(150, 20);
            textbox.Name = "txtSellPrice" + (count + 1);
            textbox.KeyPress += this.txtPrice_KeyPress;
            panel1.Controls.Add(textbox);
        }

        private void lblUnit_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            String text = ((TextBox)sender).Text;
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text;
            int category = int.Parse(cbbCategory.SelectedValue.ToString());
            string description = txtDescription.Text;
            string guide = txtGuide.Text;
            double price = 0;
            double sellPrice = 0;
                if (!txtPrice.Text.Equals(""))
                {
                    price = double.Parse(txtPrice.Text);
                }

                if (!txtSellPrice.Text.Equals(""))
                {
                    sellPrice = double.Parse(txtSellPrice.Text);
                }                
            string basicUnit = txtUnit.Text;

            if (productName.Equals(""))
            {
                MessageBox.Show("Product Name Required","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (basicUnit.Equals(""))
            {
                MessageBox.Show("Basic Unit Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Product product = new Product(category,productName, description, guide, staff.StoreID, basicUnit, 0, price, sellPrice);
            ArrayList productUnits = new ArrayList();        
            int productID = ProductDAO.GetMaxID();
            string unitName = "";
            int ConversionValue = 1;
            double sellPriceUnit = 0;
            for (int i = 0; i < panel1.Controls.OfType<TextBox>().ToList().Count; i++)
            {
                TextBox textBox = panel1.Controls.OfType<TextBox>().ToList()[i];
                if (i % 3 == 0)
                {
                    unitName = textBox.Text;
                    if (unitName.Trim().Equals(""))
                    {
                        MessageBox.Show("Unit name Required");
                        textBox.Focus();
                        return;
                    }
                }

                if (i % 3 == 1)
                {
                    if (textBox.Text.Equals("") || textBox.Text.Equals("0"))
                    {
                        MessageBox.Show("ConversionValue Required and greater than 0");
                        textBox.Focus();
                        return;
                    }
                    ConversionValue = int.Parse(textBox.Text);
                }

                if(i%3 == 2)
                {
                    if (!textBox.Text.Trim().Equals(""))
                    {
                        sellPriceUnit = double.Parse(textBox.Text.Trim());
                    }

                    ProductUnit productUnit = new ProductUnit(productID,unitName,ConversionValue,sellPriceUnit);
                    productUnits.Add(productUnit);
                }
                
            }
            bool check = ProductDAO.insertProduct(product, productUnits);
            if (check)
            {
                MessageBox.Show("Insert Successfully: " + productName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Insert Fail: " + productName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
