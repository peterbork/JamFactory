using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    class Activity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TimeCheck { get; set; }
        public List<Measurement> Measurements { get; set; }
        //public Employee { get; set;}

        public Activity(string name, string description, string timeCheck)
        {
            this.Name = name;
            this.Description = description;
            this.TimeCheck = timeCheck;
            Measurements = new List<Measurement>();
        }
    }
}
