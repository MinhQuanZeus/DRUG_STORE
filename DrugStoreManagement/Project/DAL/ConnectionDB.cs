using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTL
{
    class ConnectionDB
    {
        public static SqlConnection getConnection()
        {
            string strConn =
                ConfigurationManager.ConnectionStrings["DRUG_STOREConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }
    }
}
