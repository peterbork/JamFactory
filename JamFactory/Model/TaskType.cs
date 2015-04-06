using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    public class TaskType
    {
        public string Description { get; set; }
        public int ID { get; set; }

        public TaskType(string desc, int id)
        {
            this.Description = desc;
            this.ID = id;
        }

        public TaskType()
        { }
    }
}
