using Project.DTL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    class ProductUnitDAO
    {
        public static bool insertProductUnit(ProductUnit productUnit)
        {
            SqlCommand cmd = new SqlCommand("Insert into ProductUnit values(@productID, @unitName, @ConversionValue, @SellPrice)");
            cmd.Parameters.AddWithValue("@productID", productUnit.ProductID);
            cmd.Parameters.AddWithValue("@unitName", productUnit.UnitName);
            cmd.Parameters.AddWithValue("@ConversionValue", productUnit.ConversionValue);
            cmd.Parameters.AddWithValue("@SellPrice", productUnit.SellPrice);
            return DAO.UpdateTable(cmd);
        }
    }
}
