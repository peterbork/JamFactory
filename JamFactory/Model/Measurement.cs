using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    class Measurement
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ExpectedResult { get; set; }
        public string ActualResult { get; set; }

        public Measurement(string name, string expectedResult, string actualResult)
        {
            this.Name = name;
            this.ExpectedResult = expectedResult;
            this.ActualResult = actualResult;
        }
    }
}
