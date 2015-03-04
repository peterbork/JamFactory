using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    public class Employee : Person {
        public int ID { get; set; }
        public string Password { get; set; }
        public DateTime Hired { get; set; }

        public Employee(int id, string password, DateTime hired, string name) {
            this.ID = id;
            this.Password = password;
            this.Hired = hired;
            this.Name = name;
        }
    }
}
