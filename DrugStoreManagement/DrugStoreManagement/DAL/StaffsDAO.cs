using Project.DTL;
using System;
using System.Data;

namespace Project.DAL
{
    public class StaffsDAO
    {
        public static Staff checkLogin(String username, String password)
        {
            Staff staff = null;
            String sql = "Select * from Staffs where Username = '" + username + "' and Password = '" + password + "'";
            DataTable dt = DAO.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                int staffId = int.Parse(dt.Rows[0]["StaffID"].ToString());
                string name = dt.Rows[0]["Name"].ToString();
                string usname = dt.Rows[0]["Username"].ToString();
                string address = dt.Rows[0]["Address"].ToString();
                string phone = dt.Rows[0]["Phone"].ToString();
                bool isManager = dt.Rows[0]["IsManager"].ToString() == "1" ? true : false;
                int storeId = int.Parse(dt.Rows[0]["StoreID"].ToString());

                staff = new Staff(staffId, name, username, "", address, phone, isManager, storeId);

            }
            return staff;
        }
    }
}
