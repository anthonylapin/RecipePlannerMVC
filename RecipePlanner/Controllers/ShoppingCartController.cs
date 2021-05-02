using RecipePlanner.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using RecipePlanner.Data;
using RecipePlanner.Models;

namespace RecipePlanner.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IRecipeContext _context;
        private readonly ISession _session;

        public ShoppingCartController(IRecipeContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;

            if (!_session.Keys.Contains("shoppingCartItems"))
            {
                SetShoppingCartItems(new List<Ingredient>());
            }
        }

        public IActionResult Index()
        {
            var viewModel = new ShoppingCartViewModel() 
            {
                Recipes = _context.Recipes,
                ShoppingCartItems = GetShoppingCartItems()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(Guid recipeId, uint quantity)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            var shoppingCartItems = GetShoppingCartItems();

            
            foreach (var ingredient in recipe.Ingredients)
            {
                // ingredient quantity in shopping cart item = recipeQuantity * ingredientQuantityInRecipe
                var ingredientQuantity = quantity * ingredient.Quantity;

                var existingItem = shoppingCartItems.FirstOrDefault(i => 
                    i.Name == ingredient.Name && i.MeasurementValue == ingredient.MeasurementValue);

                if (existingItem != null)
                {
                    existingItem.Quantity += ingredientQuantity;
                }
                else
                {
                    shoppingCartItems.Add(new Ingredient {
                        Name = ingredient.Name, Quantity = ingredientQuantity, MeasurementValue = ingredient.MeasurementValue 
                    });
                }
            }

            SetShoppingCartItems(shoppingCartItems);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ClearShoppingCart()
        {
            SetShoppingCartItems(new List<Ingredient>());
            return RedirectToAction(nameof(Index));
        }

        private List<Ingredient> GetShoppingCartItems() => _session.Get<List<Ingredient>>("shoppingCartItems");
        private void SetShoppingCartItems(List<Ingredient> items) =>
            _session.Set("shoppingCartItems", items);
    }
}
