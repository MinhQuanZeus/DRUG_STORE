using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project.DAL
{
    public class DAO
    {
        static string strConn = ConfigurationManager.ConnectionStrings["DRUG_STOREConnectionString"].ConnectionString;

        static public DataTable GetDataTable(string sqlSelect)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;

            }


        }
   
        static public bool UpdateTable(SqlCommand cmd)
        {
            SqlConnection conn=null;
            try
            {
                conn = new SqlConnection(strConn);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {

                conn.Close();
                MessageBox.Show(ex.Message);
                return false;

            }
        }
    }
}
