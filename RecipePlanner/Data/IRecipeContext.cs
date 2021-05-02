using RecipePlanner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipePlanner.Data
{
    public interface IRecipeContext
    {
        public List<Recipe> Recipes { get; set; }
        public Task SaveChanges();
    }
}
