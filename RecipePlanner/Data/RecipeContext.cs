using Microsoft.Extensions.Configuration;
using RecipePlanner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipePlanner.Data
{
    public class RecipeContext : IRecipeContext
    {
        private string _path;

        private async Task ReadData()
        {
            using var fs = new FileStream(_path, FileMode.OpenOrCreate);
            Recipes = await JsonSerializer.DeserializeAsync<List<Recipe>>(fs);
        }

        public RecipeContext(IConfiguration configuration)
        {
            _path = configuration.GetSection("PathToRecipesJson").Value;
            ReadData().GetAwaiter().GetResult();
        }

        public List<Recipe> Recipes { get; set; } = new();

        public async Task SaveChanges()
        {
            using var fs = new FileStream(_path, FileMode.Create);
            await JsonSerializer.SerializeAsync(fs, Recipes, new JsonSerializerOptions() { WriteIndented = true });
        }
    }
}
