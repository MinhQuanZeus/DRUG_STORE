using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
