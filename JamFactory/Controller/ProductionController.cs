﻿using System;
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
        public void GetTask(int Week) { 

        }
    }
}
