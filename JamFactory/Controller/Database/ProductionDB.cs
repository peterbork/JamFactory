using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamFactory.Model;

namespace JamFactory.Controller.Database {
    public class ProductionDB {
        static string ConnectionString = "Server=ealdb1.eal.local;" + "Database=ejl20_db;" + "User Id=ejl20_usr;" + "Password=Baz1nga20;";

        public static void CheckLogin(int PersonID, string Password) {
            try {
                using (SqlConnection conn = new SqlConnection(ConnectionString)) {
                    SqlCommand cmd = new SqlCommand("2_CheckLogin", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PersonID", PersonID));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception E) {
                throw E;
            }
            finally {

            }
        }
        public static List<Model.Task> GetTask(Model.Employee employee, DateTime starttime, DateTime endtime) {
            List<Model.Task> _Tasks = new List<Model.Task>();
            using (SqlConnection conn = new SqlConnection(ConnectionString)) {
                try {
                    
                    SqlCommand cmd = new SqlCommand("2_CheckLogin", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PersonID", employee.ID));
                    cmd.Parameters.Add(new SqlParameter("@StartTime", starttime));
                    cmd.Parameters.Add(new SqlParameter("@EndTime", endtime));
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        _Tasks.Add(new Model.Task(reader["Description"].ToString(), Convert.ToDateTime(reader["StartTime"].ToString()), Convert.ToDateTime(reader["EndTime"].ToString()), employee, new Model.Machine(reader["Name"].ToString(), int.Parse(reader["Capacity"].ToString()), int.Parse(reader["ScrapValue"].ToString()), double.Parse(reader["AcquisitionValue"].ToString()), Convert.ToDateTime(reader["LifeTime"].ToString()))));
                    }
                    
                }

                catch (SqlException e) {
                    System.Windows.MessageBox.Show(e.Message);
                }
                finally {

                    conn.Close();
                    conn.Dispose();
                }
                return _Tasks;
            }
        }

    }
}
