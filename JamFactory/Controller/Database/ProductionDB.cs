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

        public static List<Model.Task> GetTasks(int personid, DateTime starttime, DateTime endtime)
        {
            // Gets all tasks within the parameters
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
                        _Tasks.Add(new Model.Task(new Model.TaskType(reader["Description"].ToString(),
                                                                     Convert.ToInt32(reader["TaskTypeID"])), 
                                                  Convert.ToDateTime(reader["StartTime"].ToString()), 
                                                  Convert.ToDateTime(reader["EndTime"].ToString()), 
                                                  new Model.Employee(int.Parse(reader["ID"].ToString()), 
                                                                     Convert.ToString(reader["Password"]), 
                                                                     Convert.ToDateTime(reader["Hired"].ToString()), 
                                                                     reader["Name"].ToString()) ));
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
        public static void AddTask(List<Model.Task> schedule)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    foreach (Model.Task task in schedule)
                    {
                        SqlCommand cmd = new SqlCommand("2_AddTask", conn);
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@EmployeeID", task.Employee.ID));
                        cmd.Parameters.Add(new SqlParameter("@StartTime", task.StartTime));
                        cmd.Parameters.Add(new SqlParameter("@EndTime", task.EndTime));
                        cmd.Parameters.Add(new SqlParameter("@TaskTypeID", task.WorkTask.ID));
                        cmd.ExecuteNonQuery();
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
        }
    }
}