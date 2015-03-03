using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    class Recipe {
        public string Name { get; set; }
        public string Documentation { get; set; }
        public string Correspondence { get; set; }
        public List<Product> Products { get; set; }

        public Recipe(string name, string documentation, string correspondence) {
            Name = name;
            Documentation = documentation;
            Correspondence = correspondence;
            Products = new List<Product>();
        }
    }
}
