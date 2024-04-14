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

        public Recipe(string recipeName, string[] recipeSteps, string[,] recipeIngredients)
        {
            scaleFactor = 1;
            name = recipeName;
            steps = recipeSteps;
            ingredients = recipeIngredients;
        }

        public void ScaleRecipe()
        {

        }

        public void ResetScale()
        {

        }

        public void DisplayRecipe()
        {

        }

        public void DeleteRecipe()
        {

        }

        public void AddNewRecipe()
        {

        }

        public void IngredientPrompt()
        { 

        }

        public void StepsPrompt()
        {

        }

    }
}
