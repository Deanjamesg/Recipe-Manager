using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE.Classes
{
    class RecipeManager
    {
        public List<Recipe> RecipeList { get; set; }

        public RecipeManager()
        {
            RecipeList = new List<Recipe>();

            // Sample Recipe 1
            Recipe recipe1 = new Recipe
            {
                RecipeName = "Pancakes",
                ScaleFactor = 1,
                Ingredients = new List<Ingredient>
        {
            new Ingredient { Name = "Flour", Quantity = 1, UnitOfMeasurement = "cup", FoodGroup = "Grains", Calories = 455 },
            new Ingredient { Name = "Egg", Quantity = 1, UnitOfMeasurement = "whole", FoodGroup = "Protein", Calories = 68 },
            new Ingredient { Name = "Milk", Quantity = 0.5, UnitOfMeasurement = "cup", FoodGroup = "Dairy", Calories = 56 }
        },
                Steps = new List<string> { "Mix all ingredients", "Cook on a hot griddle" }
            };
            recipe1.TotalCalories = CalculateTotalCalories(recipe1);
            RecipeList.Add(recipe1);

            // Sample Recipe 2
            Recipe recipe2 = new Recipe
            {
                RecipeName = "Scrambled Eggs",
                ScaleFactor = 1,
                Ingredients = new List<Ingredient>
        {
            new Ingredient { Name = "Egg", Quantity = 2, UnitOfMeasurement = "whole", FoodGroup = "Protein", Calories = 136 },
            new Ingredient { Name = "Butter", Quantity = 1, UnitOfMeasurement = "tbsp", FoodGroup = "Dairy", Calories = 102 }
        },
                Steps = new List<string> { "Beat eggs", "Cook in butter on low heat" }
            };
            recipe2.TotalCalories = CalculateTotalCalories(recipe2);
            RecipeList.Add(recipe2);

            // Sample Recipe 3
            Recipe recipe3 = new Recipe
            {
                RecipeName = "Grilled Cheese",
                ScaleFactor = 1,
                Ingredients = new List<Ingredient>
        {
            new Ingredient { Name = "Bread", Quantity = 2, UnitOfMeasurement = "slice", FoodGroup = "Grains", Calories = 200 },
            new Ingredient { Name = "Cheese", Quantity = 1, UnitOfMeasurement = "slice", FoodGroup = "Dairy", Calories = 113 },
            new Ingredient { Name = "Butter", Quantity = 1, UnitOfMeasurement = "tbsp", FoodGroup = "Dairy", Calories = 102 }
        },
                Steps = new List<string> { "Butter one side of each slice of bread", "Place cheese between bread slices", "Cook on a hot griddle until cheese is melted" }
            };
            recipe3.TotalCalories = CalculateTotalCalories(recipe3);
            RecipeList.Add(recipe3);

            SortRecipesAlphabetically();
        }

        public void AddNewRecipe(Recipe recipe)
        {
            recipe.TotalCalories = CalculateTotalCalories(recipe);
            RecipeList.Add(recipe);
            SortRecipesAlphabetically();
        }
        public void DeleteRecipe(int index)
        {
            RecipeList.RemoveAt(index);
            SortRecipesAlphabetically();
        }
        public void ScaleRecipe(int index, double scaleFactor)
        {
            Recipe recipe = GetRecipe(index);
            recipe.ScaleFactor = scaleFactor;
            recipe.TotalCalories = CalculateTotalCalories(recipe);
        }
        public void ResetRecipeScale(int index)
        {
            Recipe recipe = GetRecipe(index);
            recipe.ScaleFactor = 1;
        }
        public void NormalizeQuantities()
        {

        }
        public void ValidateUnitOfMeasurement()
        {

        }
        public void SortRecipesAlphabetically()
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-8.0
            RecipeList.Sort((recipe1, recipe2) => recipe1.RecipeName.CompareTo(recipe2.RecipeName));
        }
        public List <Recipe> GetRecipeList()
        {
            return RecipeList;
        }

        public Recipe GetRecipe(int index)
        {
            return RecipeList[index];
        }

        private double CalculateTotalCalories(Recipe recipe)
        {
            double result = 0; 

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                result += (ingredient.Calories * recipe.ScaleFactor);
            }

            return result;
        }
    }
}
