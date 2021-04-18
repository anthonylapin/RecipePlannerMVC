using Microsoft.AspNetCore.Mvc;
using RecipePlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipePlanner.Controllers
{
    public class IngredientController : Controller
    {
        public IActionResult Create(Recipe recipe, string name, decimal quantity, string measurementValue)
        {
            var ingredient = new Ingredient() { Name = name, Quantity = quantity, MeasurementValue = measurementValue };
            recipe.Ingredients.Add(ingredient);
            return RedirectToAction(nameof(Index));
        }
    }
}
