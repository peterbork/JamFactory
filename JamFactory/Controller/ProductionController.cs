using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamFactory.Model;

// Controller for group B
namespace JamFactory.Controller
{
    public class ProductionController
    {
        public static void CheckLogin(int personID, string password)
        {    
            bool LogIn = Database.ProductionDB.CheckLogin(personID, password);

            if (LogIn == true)
            {
                View.Group_B.Start logInView = new View.Group_B.Start();
                logInView.Close();

                View.Group_B.ScheduleView scheduleView = new View.Group_B.ScheduleView();
                scheduleView.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("nej du");
            }
        }

        //public static void GetTask(int personid, DateTime starttime, DateTime endtime) {
        //    Database.ProductionDB.GetTask(personid, starttime, endtime);
        //}
    }
}
