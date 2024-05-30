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

        //-------------------------------------------------------------------------------------------------------------------------------------
        public RecipeManager()
        {
            RecipeList = new List<Recipe>();

            //Sample Recipe 1
            Recipe recipe1 = new Recipe
            {
                RecipeName = "Pancakes",
                ScaleFactor = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Flour", Quantity = 1, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Grain, Calories = 455 },
                    new Ingredient { Name = "Egg", Quantity = 1, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Poultry, Calories = 68 },
                    new Ingredient { Name = "Milk", Quantity = 0.5, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Dairy, Calories = 56 }
                },
                Steps = new List<Step>
                {
                    new Step { Description = "Mix all ingredients" },
                    new Step { Description = "Cook on a hot griddle" }
                }
                
            };
            foreach (Ingredient ingredient in recipe1.Ingredients)
            {
                ingredient.SetOriginalValues();
            }
            recipe1.TotalCalories = CalculateTotalCalories(recipe1);
            RecipeList.Add(recipe1);

            //Sample Recipe 2
            Recipe recipe2 = new Recipe
            {
                RecipeName = "Scrambled Eggs",
                ScaleFactor = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Egg", Quantity = 2, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Poultry, Calories = 136 },
                    new Ingredient { Name = "Butter", Quantity = 1, UnitOfMeasurement = UnitOM.Tablespoon, FoodGroup = FoodGroup.Dairy, Calories = 102 }
                },
                Steps = new List<Step>
                {
                    new Step { Description = "Beat eggs" },
                    new Step { Description = "Cook in butter on low heat" }
                }
            };
            foreach (Ingredient ingredient in recipe2.Ingredients)
            {
                ingredient.SetOriginalValues();
            }
            recipe2.TotalCalories = CalculateTotalCalories(recipe2);
            RecipeList.Add(recipe2);

            // Sample Recipe 3
            Recipe recipe3 = new Recipe
            {
                RecipeName = "Grilled Cheese",
                ScaleFactor = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Bread", Quantity = 2, UnitOfMeasurement = UnitOM.Slice, FoodGroup = FoodGroup.Starch, Calories = 200 },
                    new Ingredient { Name = "Cheese", Quantity = 1, UnitOfMeasurement = UnitOM.Slice, FoodGroup = FoodGroup.Dairy, Calories = 113 },
                    new Ingredient { Name = "Butter", Quantity = 1, UnitOfMeasurement = UnitOM.Tablespoon, FoodGroup = FoodGroup.Dairy, Calories = 102 }
                },
                Steps = new List<Step> {
                    new Step { Description = "Butter one side of each slice of bread" },
                    new Step { Description = "Place cheese between bread slices" },
                    new Step { Description = "Cook on a hot griddle until cheese is melted" }
                }
            };
            foreach (Ingredient ingredient in recipe3.Ingredients)
            {
                ingredient.SetOriginalValues();
            }
            recipe3.TotalCalories = CalculateTotalCalories(recipe3);
            RecipeList.Add(recipe3);

            SortRecipesAlphabetically();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public void AddNewRecipe(Recipe recipe)
        {
            recipe.TotalCalories = CalculateTotalCalories(recipe);
            RecipeList.Add(recipe);
            SortRecipesAlphabetically();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public void DeleteRecipe(int index)
        {
            RecipeList.RemoveAt(index);
            SortRecipesAlphabetically();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public void ScaleRecipe(int index, double scaleFactor)
        {
            Recipe recipe = GetRecipe(index);
            recipe.ScaleFactor = scaleFactor;
            recipe.TotalCalories = CalculateTotalCalories(recipe);

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredient.Quantity *= scaleFactor;
                ingredient.Calories *= scaleFactor;
            }
            recipe.ScaleFactor = 1;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public void ResetRecipeScale(int index)
        {
            Recipe recipe = GetRecipe(index);
            recipe.ScaleFactor = 1;

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredient.ResetValues();
            }

            recipe.TotalCalories = CalculateTotalCalories(recipe);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public void NormalizeQuantities()
        {

        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public void ValidateUnitOfMeasurement()
        {

        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public void SortRecipesAlphabetically()
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-8.0
            RecipeList.Sort((recipe1, recipe2) => recipe1.RecipeName.CompareTo(recipe2.RecipeName));
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public List <Recipe> GetRecipeList()
        {
            return RecipeList;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        public Recipe GetRecipe(int index)
        {
            return RecipeList[index];
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
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
