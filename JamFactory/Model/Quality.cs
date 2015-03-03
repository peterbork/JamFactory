using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    class Quality
    {
        public string Type { get; set; }
        public int BerriePercent {get; set;}
        public Quality(string type, int berriepercent) {
            this.Type = type;
            this.BerriePercent = berriepercent;
        }
    }
}
