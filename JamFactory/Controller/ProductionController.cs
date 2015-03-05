using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamFactory.Model;
using System.Globalization;

// Controller for group B
namespace JamFactory.Controller {

    public class ProductionController {
        static int EmployeeID;
        public static void CheckLogin(int personID, string password)
        {
            EmployeeID = personID;
            bool LogIn = Database.ProductionDB.CheckLogin(personID, password);

            if (LogIn == true) {
                View.Group_B.Start logInView = new View.Group_B.Start();
                logInView.Close();

                View.Group_B.ScheduleView scheduleView = new View.Group_B.ScheduleView();
                scheduleView.Show();
            }
            else {
                System.Windows.MessageBox.Show("PersonID og Password er forkert!");
            }
        }
        public static int GetEmployeeID() {
            return EmployeeID;
        }

        public static List<List<Model.Task>> GetTask(int EmployeeID, DateTime starttime, DateTime endtime, int WeekNumber) {
            List<Model.Task> _Task = Database.ProductionDB.GetTask(EmployeeID, starttime, endtime);
            DateTime StartOfWeekDate = Helper.Dates.FirstDateOfWeek(WeekNumber, CultureInfo.CurrentCulture);
            List<List<Model.Task>> ListOfTaskInList  = GetTaskForEachDay(_Task, StartOfWeekDate);
            return ListOfTaskInList;
        }

        public static List<List<Model.Task>> GetTaskForEachDay( List<Model.Task> _Tasks, DateTime StartOfWeekDate){
            List<List<Model.Task>> ListOfTaskInList = new List<List<Model.Task>>();
            
            DateTime MondayDate = StartOfWeekDate;
            for (int i = 1; i <= 7; i++)
			{
                List<Model.Task> ListOfTask = new List<Model.Task>();
                foreach (Model.Task t in _Tasks) 
                {
                    if (t.StartTime > MondayDate && t.EndTime < MondayDate.AddDays(1)) 
                    {
                        ListOfTask.Add(t);
                    }
                }
            ListOfTaskInList.Add(ListOfTask);
            MondayDate = StartOfWeekDate.AddDays(i);
			}
            return ListOfTaskInList;
        }
    }
}
