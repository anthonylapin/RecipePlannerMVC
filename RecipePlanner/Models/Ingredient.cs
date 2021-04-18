using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipePlanner.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string MeasurementValue { get; set; }
        public decimal Quantity { get; set; }
    }
}
