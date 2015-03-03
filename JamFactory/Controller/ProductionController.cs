using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Controller for group B
namespace JamFactory.Controller {
    class ProductionController {
        public static void CheckLogin(int personID, string password)
        {
            Database.ProductionDB.CheckLogin(5, "sssgs");
        }
        public void GetTasks(int Week) { 
        
        }
    }
}
