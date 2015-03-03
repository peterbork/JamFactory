using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    class Machine {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double ScrapValue { get; set; }
        public double AuquistionValue { get; set; }
        public DateTime LifeTime { get; set; }
        public Machine(string name, int capacity, double scrapvalue, double auquistionvalue, DateTime lifetime) {
            this.Name = name;
            this.Capacity = capacity;
            this.ScrapValue = scrapvalue;
            this.AuquistionValue = auquistionvalue;
            this.LifeTime = lifetime;
        }
    }
}
