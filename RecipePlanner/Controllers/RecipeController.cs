using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipePlanner.Data;
using RecipePlanner.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecipePlanner.Controllers
{
    public class RecipeController : Controller
    {
        private IRecipeContext _context;

        public RecipeController(IRecipeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Recipes);
        }

        public IActionResult Create()
        {
            return View("CreateEdit", new Recipe());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            recipe.Id = Guid.NewGuid();
            _context.Recipes.Add(recipe);
            await _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(Guid id)
        {
            var recipe = _context.Recipes.Find(r => r.Id == id);
            
            if (recipe == null)
            {
                return NotFound();
            }

            return View("CreateEdit", recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Recipe recipe)
        {
            var existingRecipe = _context.Recipes.Find(r => r.Id == recipe.Id);

            if (existingRecipe == null)
            {
                return BadRequest();
            }

            existingRecipe.Name = recipe.Name;
            existingRecipe.Instruction = recipe.Instruction;

            await _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
