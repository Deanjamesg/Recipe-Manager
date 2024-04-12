using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE
{
    class Recipe
    {
        public int scaleFactor { get; set; }
        public string name { get; set; }
        public string[] steps { get; set; }
        public string[,] ingredients { get; set; }

        public Recipe() { 
        }

        public Recipe(string _name, string[] _steps, string[,] _ingredients)
        {
            name = _name;
            steps = _steps;
            ingredients = _ingredients;
        }

        public string Scale()
        {
            return "";
        }

        public string DisplayRecipe()
        {
            return "";
        }

        public void IngredientPrompt()
        {

        }

        public void StepsPrompt()
        {

        }

    }
}
