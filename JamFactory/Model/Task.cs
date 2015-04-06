using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    public class Task {
        public Model.TaskType WorkTask;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Model.Employee Employee;
        public Model.Machine Machine;

        public Task(Model.TaskType workTask, DateTime starttime, DateTime endtime, Model.Employee employee)
        {
            this.WorkTask = workTask;
            this.StartTime = starttime;
            this.EndTime = endtime;
            this.Employee = employee;

        }
    }
}
