using Microsoft.AspNetCore.Mvc;
using RecipePlanner.Data;
using RecipePlanner.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RecipePlanner.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IRecipeContext _context;

        public IngredientController(IRecipeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(Guid recipeId, string name, decimal quantity, string measurementValue)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            var ingredient = recipe.Ingredients.FirstOrDefault(i => i.Name == name && i.MeasurementValue == measurementValue);

            if (ingredient != null)
            {
                ingredient.Quantity += quantity;
            }
            else
            {
                recipe.Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, MeasurementValue = measurementValue});
            }

            await _context.SaveChanges();

            return RedirectToAction("Personal", "Recipe", new { id = recipeId });
        }

        public async Task<IActionResult> Update(Guid recipeId, string name, decimal quantity, string measurementValue)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            var ingredient = recipe.Ingredients.FirstOrDefault(i => i.Name == name && i.MeasurementValue == measurementValue);

            if (ingredient == null)
            {
                return NotFound();
            }

            ingredient.Quantity = quantity;

            await _context.SaveChanges();

            return RedirectToAction("Personal", "Recipe", new { id = recipeId });
        }

        public async Task<IActionResult> Delete(Guid recipeId, string name, string measurementValue)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            var ingredient = recipe.Ingredients.FirstOrDefault(i => i.Name == name && i.MeasurementValue == measurementValue);

            if (ingredient == null)
            {
                return NotFound();
            }

            recipe.Ingredients.Remove(ingredient);

            await _context.SaveChanges();

            return RedirectToAction("Personal", "Recipe", new { id = recipeId });
        }
    }
}
