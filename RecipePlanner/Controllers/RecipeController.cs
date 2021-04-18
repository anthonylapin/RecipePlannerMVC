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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
