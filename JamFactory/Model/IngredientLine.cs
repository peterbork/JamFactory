using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    class IngredientLine {
        public int Amount { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }

        public IngredientLine(int amount, Recipe recipe, Ingredient ingredient) {
            Amount = amount;
            Recipe = recipe;
            Ingredient = ingredient;
        }
    }
}
