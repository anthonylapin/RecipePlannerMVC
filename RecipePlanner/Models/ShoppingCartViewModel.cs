using System.Collections.Generic;

namespace RecipePlanner.Models
{
    public class ShoppingCartViewModel
    {
        public List<Recipe> Recipes { get; set; } = new();
        public List<Ingredient> ShoppingCartItems { get; set; } = new();
    }
}
