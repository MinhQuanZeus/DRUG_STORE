using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Project.DAL
{
    public class BillDAO
    {
        static string strConn = ConfigurationManager.ConnectionStrings["DRUG_STOREConnectionString"].ConnectionString;

        public static double GetTotalPrice()
        {
            double price = 0;
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("select 'TA' = sum((p.SellPrice-p.Price)*bd.Quantity) from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                price = double.Parse(dr["TA"].ToString());
                dr.Close();
            }

            conn.Close();
            return price;
        }
        public static double GetTotalPriceByID(int staffID)
        {
            double price = 0;
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("select 'TA' = sum((p.SellPrice-p.Price)*bd.Quantity) from Bills b join BillDetails bd on b.BillID = bd.BillID join Products p on p.ProductID = bd.ProductID where b.StaffID ='"+staffID+"'", conn);
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
            return price;
        }

    }
}
