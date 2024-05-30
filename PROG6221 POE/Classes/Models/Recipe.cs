using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG6221_POE
{
    class Recipe
    {
        public double ScaleFactor { get; set; }
        public string RecipeName { get; set; }
        public List <Step> Steps { get; set; }
        public List <Ingredient> Ingredients { get; set; }
        public double TotalCalories { get; set; }

        public Recipe()
        {
            Steps = new List<Step>();
            Ingredients = new List<Ingredient>();
        }

    }
}
