using System;
using System.Collections.Generic;

namespace RecipePlanner.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Instruction { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new();
    }
}
