using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    class Fruit:Ingredient
    {
        public double Gram { get; set; }
        public string Season { get; set; }
        public Fruit(string name, double price, int amount, double gram, string season) : base(name, price, amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
            Gram = gram;
            Season = season;
        }
    }
    
}
