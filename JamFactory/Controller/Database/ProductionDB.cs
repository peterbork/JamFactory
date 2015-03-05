using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamFactory.Model;

namespace JamFactory.Controller.Database
{
    public class ProductionDB
    {
        static string ConnectionString = "Server=ealdb1.eal.local;" + "Database=ejl20_db;" + "User Id=ejl20_usr;" + "Password=Baz1nga20;";

        public static bool CheckLogin(int PersonID, string Password)
        {
            bool LogIn = false;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("2_CheckLogin", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PersonID", PersonID));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    //cmd.ExecuteNonQuery(); // ExecuteNonQuery is intended for UPDATE, INSERT and DELETE queries

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LogIn = true;
                        }
                        else
                        {
                            LogIn = false;
                        }
                    }
                }
                catch (SqlException E)
                {
                    System.Windows.MessageBox.Show(E.Message);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return LogIn;
        }

        public static List<Model.Task> GetTask(int personid, DateTime starttime, DateTime endtime)
        {
            List<Model.Task> _Tasks = new List<Model.Task>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("2_GetTask", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PersonID", personid));
                    cmd.Parameters.Add(new SqlParameter("@StartTime", starttime));
                    cmd.Parameters.Add(new SqlParameter("@EndTime", endtime));
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        _Tasks.Add(new Model.Task(reader["Description"].ToString(), Convert.ToDateTime(reader["StartTime"].ToString()), Convert.ToDateTime(reader["EndTime"].ToString()), new Model.Employee(int.Parse(reader["ID"].ToString()), Convert.ToString(reader["Password"]), Convert.ToDateTime(reader["Hired"].ToString()), reader["Name"].ToString()), new Model.Machine(reader["Name"].ToString(), int.Parse(reader["Capacity"].ToString()), int.Parse(reader["ScrapValue"].ToString()), double.Parse(reader["AcquisitionValue"].ToString()), int.Parse(reader["LifeTime"].ToString()))));
                    }
                }
                catch (SqlException E)
                {
                    System.Windows.MessageBox.Show(E.Message);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();

                }
                return _Tasks;

            }

        }
    }
}