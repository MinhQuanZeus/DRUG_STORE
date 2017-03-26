using Project.DTL;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project.DAL
{
    class ProductDAO
    {
        static string strConn = ConfigurationManager.ConnectionStrings["DRUG_STOREConnectionString"].ConnectionString;
        public static bool insertProduct(Product product, ArrayList productUnits)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            SqlTransaction transaction;
            // Start a local transaction.
            transaction = conn.BeginTransaction("SampleTransaction");
            command.Connection = conn;
            command.Transaction = transaction;

            try
            {
                command.CommandText = "Insert into Products(ProductTypeID, Name, Description, Guide, StoreID,Unit,Price,SellPrice)"
                + "Values(@ProductTypeID, @Name, @Description,@Guide, @StoreID,@Unit,@Price,@SellPrice)";
                command.Parameters.AddWithValue("@ProductTypeID", product.ProductypeID);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Guide", product.Guide);
                command.Parameters.AddWithValue("@StoreID", product.StoreId);
                command.Parameters.AddWithValue("@Unit", product.Unit);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@SellPrice", product.SellPrice);
                command.ExecuteNonQuery();

                foreach(ProductUnit productUnit in productUnits)
                {
                    command.CommandText = "Insert into ProductUnit values(@productID, @unitName, @ConversionValue, @SellPriceunit)";
                    command.Parameters.AddWithValue("@productID", productUnit.ProductID);
                    command.Parameters.AddWithValue("@unitName", productUnit.UnitName);
                    command.Parameters.AddWithValue("@ConversionValue", productUnit.ConversionValue);
                    command.Parameters.AddWithValue("@SellPriceunit", productUnit.SellPrice);
                    command.ExecuteNonQuery();
                }
                // Attempt to commit the transaction.
                transaction.Commit();
                return true;

            }
            catch(Exception ex)
            {
                try
                {
                    transaction.Rollback();
                    MessageBox.Show("Faild insert" + ex.Message);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Faild"+ex.Message);
                    MessageBox.Show("Faild ex2" + ex2.Message);
                }
                conn.Close();
                return false;
            }          

        }

        static public int GetMaxID()
        {
            try
            {
                DataTable dt = DAO.GetDataTable("select MAX(ProductID) as MAX from Products");
                if (dt.Rows.Count == -1) return -1;
                return int.Parse(dt.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
             //   MessageBox.Show("Faild"+ex.Message);
                return -1;
            }
        }
    }
}
