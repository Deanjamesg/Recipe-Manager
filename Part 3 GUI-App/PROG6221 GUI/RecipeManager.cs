using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROG6221_GUI.Model;
using Newtonsoft.Json;
using System.IO;

namespace PROG6221_GUI
{
    public class RecipeManager
    {
        public List<Recipe> RecipeList { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public RecipeManager()
        {
            RecipeList = new List<Recipe>();
        }

        public void StartRecipeProgram()
        {
            CreateSampleRecipes();

            // Create a prompt that allows the user to choose between loading recipes from a file or only store recipes while app is running.

            //recipeManager.SaveRecipesToFile();
            //recipeManager.LoadRecipesFromFile();
        }

        public void SaveRecipesToFile()
        {
            string json = JsonConvert.SerializeObject(RecipeList, Formatting.Indented);

            File.WriteAllText("Recipes\\SavedRecipes", json);
        }

        public void LoadRecipesFromFile()
        {
            if (File.Exists("Recipes\\SavedRecipes"))
            {
                string json = File.ReadAllText("Recipes\\SavedRecipes");
                RecipeList = JsonConvert.DeserializeObject<List<Recipe>>(json);
                if (RecipeList == null)
                {
                    RecipeList = new List<Recipe>();
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public List<Recipe> FilteredRecipeSearch(string _foodGroup, string _ingredientName, double _maxCalories)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();

            foreach (Recipe recipe in RecipeList)
            {
                // Checks to see if there is a max calorie filter, if there is, it will check if the recipe is within the calorie range.
                if (checkMaxCaloriesFilter(recipe, _maxCalories) && checkFoodGroupFilter(recipe, _foodGroup) && checkIngredientFilter(recipe, _ingredientName)) 
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public bool checkMaxCaloriesFilter(Recipe recipe, double _maxCalories)
        {
            return (_maxCalories == -1 || recipe.TotalCalories <= _maxCalories);
        }

        public bool checkFoodGroupFilter(Recipe recipe, string _foodGroup)
        {
            return (_foodGroup == "Any" || recipe.Ingredients.Any(ingredient => ingredient.FoodGroup.ToString() == _foodGroup));
        }

        public bool checkIngredientFilter(Recipe recipe, string _ingredientName)
        {
            return (_ingredientName == "" || recipe.Ingredients.Any(ingredient => ingredient.Name.ToUpper() == _ingredientName.ToUpper()));
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void CreateSampleRecipes()
        {
            //Creating sample recipes to make for easier testing
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

            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in

            foreach (Ingredient ingredient in recipe1.Ingredients)
            {
                ingredient.SetOriginalValues();
            }

            recipe1.TotalCalories = CalculateTotalCalories(recipe1);
            recipe1 = NormalizeQuantities(recipe1);
            RecipeList.Add(recipe1);

            //Sample Recipe 2
            Recipe recipe2 = new Recipe
            {
                RecipeName = "Scrambled Eggs",
                ScaleFactor = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Egg", Quantity = 2, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Poultry, Calories = 100 },
                    new Ingredient { Name = "Butter", Quantity = 1, UnitOfMeasurement = UnitOM.Tablespoon, FoodGroup = FoodGroup.Dairy, Calories = 50 }
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
            recipe2 = NormalizeQuantities(recipe2);
            RecipeList.Add(recipe2);

            // Sample Recipe 3
            Recipe recipe3 = new Recipe
            {
                RecipeName = "Grilled Cheese",
                ScaleFactor = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Bread Slices", Quantity = 2, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Starch, Calories = 200 },
                    new Ingredient { Name = "Cheese Slices", Quantity = 1, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Dairy, Calories = 113 },
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
            recipe3 = NormalizeQuantities(recipe3);
            RecipeList.Add(recipe3);

            // Sample Recipe 4
            Recipe recipe4 = new Recipe
            {
                RecipeName = "Pasta Primavera",
                ScaleFactor = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Pasta", Quantity = 250, UnitOfMeasurement = UnitOM.Gram, FoodGroup = FoodGroup.Starch, Calories = 300 },
                    new Ingredient { Name = "Olive Oil", Quantity = 2, UnitOfMeasurement = UnitOM.Tablespoon, FoodGroup = FoodGroup.Fats, Calories = 240 },
                    new Ingredient { Name = "Garlic Cloves", Quantity = 2, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Vegetable, Calories = 8 },
                    new Ingredient { Name = "Broccoli Florets", Quantity = 1, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Vegetable, Calories = 55 },
                    new Ingredient { Name = "Carrot", Quantity = 1, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Vegetable, Calories = 25 },
                    new Ingredient { Name = "Bell Pepper", Quantity = 1, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Vegetable, Calories = 24 },
                    new Ingredient { Name = "Peas", Quantity = 0.5, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Vegetable, Calories = 62 },
                    new Ingredient { Name = "Parmesan Cheese", Quantity = 0.25, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Dairy, Calories = 108 }
                },
                Steps = new List<Step> {
                    new Step { Description = "Cook pasta according to package instructions" },
                    new Step { Description = "Heat olive oil in a large pan and sauté garlic" },
                    new Step { Description = "Add broccoli, carrot, and bell pepper to the pan and cook until tender" },
                    new Step { Description = "Stir in peas and cooked pasta" },
                    new Step { Description = "Serve with grated Parmesan cheese on top" }
                }
            };

            foreach (Ingredient ingredient in recipe4.Ingredients)
            {
                ingredient.SetOriginalValues();
            }
            recipe4.TotalCalories = CalculateTotalCalories(recipe4);

            RecipeList.Add(recipe4);

            SortRecipesAlphabetically();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void AddNewRecipe(Recipe recipe)
        {

            recipe.TotalCalories = CalculateTotalCalories(recipe);
            recipe = NormalizeQuantities(recipe);
            RecipeList.Add(recipe);
            SortRecipesAlphabetically();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void DeleteRecipe(int index)
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removeat?view=net-6.0
            if (RecipeList.Count == 0)
            {
                return;
            }
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

            recipe = NormalizeQuantities(recipe);
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

            recipe = NormalizeQuantities(recipe);
            recipe.TotalCalories = CalculateTotalCalories(recipe);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private void SortRecipesAlphabetically()
        {

            //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-8.0
            RecipeList.Sort((recipe1, recipe2) => recipe1.RecipeName.CompareTo(recipe2.RecipeName));
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public List<Recipe> GetRecipeList()
        {

            return RecipeList;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public Recipe GetRecipe(int index)
        {

            return RecipeList[index];
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        //Calculate the total calories of a recipe, by summing the calories of each ingredient.
        public double CalculateTotalCalories(Recipe recipe)
        {

            double result = 0;

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                result += (ingredient.Calories * recipe.ScaleFactor);
            }

            return result;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        //Normalize the quantities of ingredients in a recipe, by passing each ingredient through a switch statements.
        //The switch statements convert the quantities of ingredients to a more appropriate unit of measurement.
        private Recipe NormalizeQuantities(Recipe recipe)
        {

            foreach (Ingredient ingredient in recipe.Ingredients)
            {

                //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
                switch (ingredient.UnitOfMeasurement)
                {

                    // If the measurement is teaspoons.
                    case UnitOM.Teaspoon:

                        // If the quantity is 3 or more teaspoons, convert to tablespoons.
                        if (ingredient.Quantity >= 3)
                        {
                            ingredient.Quantity /= 3;
                            ingredient.UnitOfMeasurement = UnitOM.Tablespoon;
                        }

                        break;

                    // If the measurement is tablespoons.
                    case UnitOM.Tablespoon:

                        // If the quantity is 8 or more tablespoons, convert to cups.
                        if (ingredient.Quantity >= 8)
                        {
                            ingredient.Quantity /= 16;
                            ingredient.UnitOfMeasurement = UnitOM.Cup;
                        }

                        // If the quantity is less than 1 tablespoon, convert to teaspoons.
                        else if (ingredient.Quantity < 1)
                        {
                            ingredient.Quantity *= 3;
                            ingredient.UnitOfMeasurement = UnitOM.Teaspoon;
                        }

                        break;

                    // If the measurement is cups.
                    case UnitOM.Cup:

                        // If the quantity is less than 0.25 cups, convert to tablespoons.
                        if (ingredient.Quantity < 0.25)
                        {
                            ingredient.Quantity *= 16;
                            ingredient.UnitOfMeasurement = UnitOM.Tablespoon;
                        }

                        break;

                    // If the measurement is grams.
                    case UnitOM.Gram:

                        // If the quantity is 1000 or more grams, convert to kilograms.
                        if (ingredient.Quantity >= 1000)
                        {
                            ingredient.Quantity /= 1000;
                            ingredient.UnitOfMeasurement = UnitOM.Kilogram;
                        }

                        break;

                    // If the measurement is kilograms.
                    case UnitOM.Kilogram:

                        // If the quantity is less than 1 kilograms, convert to grams.
                        if (ingredient.Quantity < 1)
                        {
                            ingredient.Quantity *= 1000;
                            ingredient.UnitOfMeasurement = UnitOM.Gram;
                        }

                        break;

                    // If the measurement is milliliters.
                    case UnitOM.Milliliter:

                        // If the quantity is 1000 or more milliliters, convert to liters.
                        if (ingredient.Quantity >= 1000)
                        {
                            ingredient.Quantity /= 1000;
                            ingredient.UnitOfMeasurement = UnitOM.Litre;
                        }
                        break;

                    // If the measurement is liters.
                    case UnitOM.Litre:

                        // If the quantity is less than 1 liters, convert to milliliters.
                        if (ingredient.Quantity < 1)
                        {
                            ingredient.Quantity *= 1000;
                            ingredient.UnitOfMeasurement = UnitOM.Milliliter;
                        }
                        break;

                    // Default case for other measurements.
                    default:
                        break;

                }
            }
            return recipe;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public List<string> IngredientCheckBoxFormat(Recipe recipe)
        {
            List<string> ingredientList = new List<string>();

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredientList.Add((ingredient.Quantity < 1 ? ingredient.Quantity.ToString("0.00") : ingredient.Quantity.ToString("0")) + " " + ingredient.UnitOfMeasurement + ", " + ingredient.Name + " (" + ingredient.Calories.ToString("0") + " kcal)");
            }

            return ingredientList;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // strRecipeDetails() creates a string of the recipe in a neat and readable format.
        // This method will return a string that consists of the recipe's name, ingredients, and steps.
        public string strRecipeDetails(Recipe recipe)
        {
            string recipeDetails = "";
            // String of recipe's details for ingredients.
            recipeDetails += recipe.RecipeName + "\n";
            recipeDetails += "\nIngredients: \n";
            int i = 1;
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                recipeDetails += i + ") " + (ingredient.Quantity < 1 ? ingredient.Quantity.ToString("0.00") : ingredient.Quantity.ToString("0")) + " " + ingredient.UnitOfMeasurement + ", " + ingredient.Name + " (" + ingredient.Calories.ToString("0") + " kcal)\n";
                i++;
            }

            // String of recipe's description for each step.
            recipeDetails += "\nSteps: \n";
            i = 1;
            foreach (Step step in recipe.Steps)
            {
                recipeDetails += i + ") " + step.Description + "\n";
                i++;
            }
            recipeDetails += "\nTotal Calories: " + recipe.TotalCalories.ToString("0") + " calories\n";

            return recipeDetails;

        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // strRecipeDetails() creates a string of the recipe in a neat and readable format.
        // This method will return a string that consists of the recipe's name, ingredients, and steps.
        public string strRecipeList(Recipe recipe)
        {
            string recipeDetails = "";
            // String of recipe's details for ingredients.
            recipeDetails += recipe.RecipeName + "\n";
            recipeDetails += "\nIngredients: \n";
            int i = 1;
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                recipeDetails += i + ") " + (ingredient.Quantity < 1 ? ingredient.Quantity.ToString("0.00") : ingredient.Quantity.ToString("0")) + " " + ingredient.UnitOfMeasurement + " of " + ingredient.Name + " (" + ingredient.FoodGroup + ") " + ingredient.Calories.ToString("0") + " calories\n";
                i++;
            }

            // String of recipe's description for each step.
            recipeDetails += "\nSteps: \n";
            i = 1;
            foreach (Step step in recipe.Steps)
            {
                recipeDetails += i + ") " + step.Description + "\n";
                i++;
            }
            recipeDetails += "\nTotal Calories: " + recipe.TotalCalories.ToString("0") + " calories\n";

            return recipeDetails;

        }

        //END OF RECIPE MANAGER CLASS
        //-------------------------------------------------------------------------------------------------------------------------------------
    }
}
