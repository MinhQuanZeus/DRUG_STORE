using System.Data;

namespace Project.DAL
{
    class ProductypeDAO
    {
        public static DataTable getAllProductType()
        {
            return DAO.GetDataTable("Select * from ProductTypes");
        }
    }
}
