using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipePlanner.Models
{
    public class ShoppingCartViewModel
    {
        public List<Recipe> Recipes { get; set; } = new();
        public List<Ingredient> ShoppingCartItems { get; set; } = new();
    }
}
