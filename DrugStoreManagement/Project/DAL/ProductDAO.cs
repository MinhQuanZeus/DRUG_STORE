using Project.DTL;
using System;
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
            SqlCommand cmd = new SqlCommand("Insert into Products(ProductTypeID, Name, Description, Guide, StoreID,Unit,Quantity,Price,SellPrice)" 
                +"Values(@ProductTypeID, @Name, @Description,@Guide, @StoreID,@Unit,@Quantity,@Price,@SellPrice)");
            cmd.Parameters.AddWithValue("@ProductTypeID", product.ProductypeID);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Guide", product.Guide);
            cmd.Parameters.AddWithValue("@StoreID", product.StoreId);
            cmd.Parameters.AddWithValue("@Unit", product.Unit);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
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
    }
}
