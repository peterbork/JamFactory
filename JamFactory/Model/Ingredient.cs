using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public Ingredient(string name, double price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }
    }
}
