using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    public class Machine {
        public int MachineID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double ScrapValue { get; set; }
        public double AcquisitionValue { get; set; }
        public int LifeTime { get; set; }
        public Machine(int ID, string name, int capacity, double scrapvalue, double acquisitionValue, int lifetime)
        {
            this.MachineID = ID;
            this.Name = name;
            this.Capacity = capacity;
            this.ScrapValue = scrapvalue;
            this.AcquisitionValue = acquisitionValue;
            this.LifeTime = lifetime;
        }
    }
}
