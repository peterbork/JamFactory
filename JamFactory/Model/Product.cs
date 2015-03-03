using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    class Product {
        public string Variant { get; set; }
        public int Size { get; set; }
        public int FruitContent { get; set; }
        public double Price { get; set; }

        public Product(string variant, int size, int fruitContent, double price) {
            Variant = variant;
            Size = size;
            FruitContent = fruitContent;
            Price = price;
        }
    }
}
