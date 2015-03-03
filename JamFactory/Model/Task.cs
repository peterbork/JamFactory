using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    class Task {
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Task(string description, DateTime starttime, DateTime endtime) {
            this.Description = description;
            this.StartTime = starttime;
            this.EndTime = endtime;
        }
    }
}
