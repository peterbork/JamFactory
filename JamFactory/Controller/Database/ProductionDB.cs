using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Controller.Database
{
    public class ProductionDB
    {
        static string ConnectionString = "Server=ealdb1.eal.local;" + "Database=ejl20_db;" + "User Id=ejl20_usr;" + "Password=Baz1nga20;";

        public static void CheckLogin(int PersonID, string Password)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("2_CheckLogin", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PersonID", PersonID));
                cmd.Parameters.Add(new SqlParameter("@Password", Password));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
