using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamFactory.Model;

// Controller for group B
namespace JamFactory.Controller {
    public class ProductionController {
        public static void CheckLogin(int personID, string password)
        {
            Database.ProductionDB.CheckLogin(personID, password);
        }
        Employee _employee = new Employee(2, "sad", Convert.ToDateTime("2002-09-24 08:00:00.000"), "Peter");
        public void GetTask(Model.Employee employee, DateTime starttime, DateTime endtime) {
            Database.ProductionDB.GetTask(_employee, starttime, endtime);
        }
    }
}
