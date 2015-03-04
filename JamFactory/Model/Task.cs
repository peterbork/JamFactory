using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    public class Task {
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        Model.Employee Employee;
        Model.Machine Machine;

        public Task(string description, DateTime starttime, DateTime endtime, Model.Employee employee, Model.Machine machine) {
            this.Description = description;
            this.StartTime = starttime;
            this.EndTime = endtime;
            this.Employee = employee;
            this.Machine = machine;
        }
    }
}
