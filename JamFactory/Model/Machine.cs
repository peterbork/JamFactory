using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    public class Machine {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double ScrapValue { get; set; }
        public double AuquistionValue { get; set; }
        public int LifeTime { get; set; }
        public Machine(string name, int capacity, double scrapvalue, double auquistionvalue, int lifetime) {
            this.Name = name;
            this.Capacity = capacity;
            this.ScrapValue = scrapvalue;
            this.AuquistionValue = auquistionvalue;
            this.LifeTime = lifetime;
        }
    }
}
