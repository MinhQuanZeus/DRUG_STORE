using Project.DTL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.DAL
{
    class ProductDAO
    {
        public static bool insertProduct(Product product)
        {
            SqlCommand cmd = new SqlCommand("Insert into Products(ProductTypeID, Name, Description, Guide, StoreID,Unit,Price,SellPrice)" 
                +"Values(@ProductTypeID, @Name, @Description,@Guide, @StoreID,@Unit,@Price,@SellPrice)");
            cmd.Parameters.AddWithValue("@ProductTypeID", product.ProductypeID);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Guide", product.Guide);
            cmd.Parameters.AddWithValue("@StoreID", product.StoreId);
            cmd.Parameters.AddWithValue("@Unit", product.Unit);
            
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@SellPrice", product.SellPrice);
            return DAO.UpdateTable(cmd);
        }

        static public int GetMaxID()
        {
            try
            {
                DataTable dt = DAO.GetDataTable("select MAX(orderID) as MAX from Orders");
                if (dt.Rows.Count == 0) return 0;
                return int.Parse(dt.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        static public ArrayList getListProduct()
        {

            SqlConnection conn = ConnectionDB.getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
            ArrayList listProduct = new ArrayList();
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int productID = int.Parse(dr["ProductID"].ToString());
                int ProductTypeID = int.Parse(dr["ProductTypeID"].ToString());
                string Name = dr["Name"].ToString();
                string Description = dr["Description"].ToString();
                string Guide = dr["Guide"].ToString();
                int StoreID = int.Parse(dr["StoreID"].ToString());
                string Unit = dr["Unit"].ToString();
             
                double Price = double.Parse((dr["Price"].ToString()));
                double SellPrice = double.Parse((dr["SellPrice"].ToString()));
                int Status = int.Parse(dr["Status"].ToString());
                listProduct.Add(new Product(productID, ProductTypeID, Name, Description, Guide, StoreID, Unit, Price, SellPrice, Status));
            }
            dr.Close();
            return listProduct;

        }

        static public string getNameProductByID(int id)
        {
            ArrayList listProduct = getListProduct();
            foreach(Product p in listProduct)
            {
                if(p.Id == id)
                {
                    return p.Name;
                }
            }
            return "";

        }
    }
}
