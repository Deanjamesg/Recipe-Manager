using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROG6221_GUI.Model;
using System.IO;
using System;

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
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public List<Recipe> FilteredRecipeSearch(string _foodGroup, string _ingredientName, double _maxCalories)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();

            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in
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

        private bool checkMaxCaloriesFilter(Recipe recipe, double _maxCalories)
        {
            return (_maxCalories == -1 || recipe.TotalCalories <= _maxCalories);
        }

        private bool checkFoodGroupFilter(Recipe recipe, string _foodGroup)
        {
            return (_foodGroup == "Any" || recipe.Ingredients.Any(ingredient => ingredient.FoodGroup.ToString() == _foodGroup));
        }

        private bool checkIngredientFilter(Recipe recipe, string _ingredientName)
        {
            return (_ingredientName == "" || recipe.Ingredients.Any(ingredient => ingredient.Name.ToUpper() == _ingredientName.ToUpper()));
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        //Creating sample recipes to make for easier testing
        public void CreateSampleRecipes()
        {
            //Sample Recipe 1
            Recipe recipe1 = new Recipe
            {
                RecipeName = "Pancakes",
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

            AddNewRecipe(recipe1);

            //Sample Recipe 2
            Recipe recipe2 = new Recipe
            {
                RecipeName = "Scrambled Eggs",
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

            AddNewRecipe(recipe2);

            // Sample Recipe 3
            Recipe recipe3 = new Recipe
            {
                RecipeName = "Grilled Cheese",
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

            AddNewRecipe(recipe3);

            // Sample Recipe 4
            Recipe recipe4 = new Recipe
            {
                RecipeName = "Pasta Primavera",
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

            AddNewRecipe(recipe4);

            // Sample Recipe 5
            Recipe recipe5 = new Recipe
            {
                RecipeName = "Chicken Salad",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Chicken Breast", Quantity = 200, UnitOfMeasurement = UnitOM.Gram, FoodGroup = FoodGroup.Poultry, Calories = 330 },
                    new Ingredient { Name = "Lettuce", Quantity = 2, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Vegetable, Calories = 10 },
                    new Ingredient { Name = "Tomato", Quantity = 1, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Vegetable, Calories = 22 },
                    new Ingredient { Name = "Cucumber", Quantity = 0.5, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Vegetable, Calories = 8 },
                    new Ingredient { Name = "Olive Oil", Quantity = 1, UnitOfMeasurement = UnitOM.Tablespoon, FoodGroup = FoodGroup.Fats, Calories = 120 }
                },
                Steps = new List<Step>
                {
                    new Step { Description = "Grill the chicken breast and slice it." },
                    new Step { Description = "Chop the lettuce, tomato, and cucumber." },
                    new Step { Description = "Mix all ingredients in a bowl and drizzle with olive oil." }
                }
            };

            AddNewRecipe(recipe5);

            // Sample Recipe 6
            Recipe recipe6 = new Recipe
            {
                RecipeName = "Fruit Smoothie",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Banana", Quantity = 1, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Fruit, Calories = 105 },
                    new Ingredient { Name = "Strawberries", Quantity = 1, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Fruit, Calories = 50 },
                    new Ingredient { Name = "Greek Yogurt", Quantity = 0.5, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Dairy, Calories = 100 },
                    new Ingredient { Name = "Honey", Quantity = 1, UnitOfMeasurement = UnitOM.Tablespoon, FoodGroup = FoodGroup.Sugar, Calories = 64 },
                    new Ingredient { Name = "Milk", Quantity = 1, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Dairy, Calories = 103 }
                },
                Steps = new List<Step>
                {
                    new Step { Description = "Combine all ingredients in a blender." },
                    new Step { Description = "Blend until smooth." },
                    new Step { Description = "Serve immediately." }
                }
            };

            AddNewRecipe(recipe6);

            // Sample Recipe 7
            Recipe recipe7 = new Recipe
            {
                RecipeName = "Beef Stir Fry",
                Ingredients = new List<Ingredient>
                {

                    new Ingredient { Name = "Beef Strips", Quantity = 200, UnitOfMeasurement = UnitOM.Gram, FoodGroup = FoodGroup.Meat, Calories = 250 },
                    new Ingredient { Name = "Bell Pepper", Quantity = 1, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Vegetable, Calories = 24 },
                    new Ingredient { Name = "Broccoli Florets", Quantity = 1, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Vegetable, Calories = 55 },
                    new Ingredient { Name = "Soy Sauce", Quantity = 2, UnitOfMeasurement = UnitOM.Tablespoon, FoodGroup = FoodGroup.Condiment, Calories = 20 },
                    new Ingredient { Name = "Olive Oil", Quantity = 1, UnitOfMeasurement = UnitOM.Tablespoon, FoodGroup = FoodGroup.Oils, Calories = 120 }
                },
                Steps = new List<Step>
                {
                    new Step { Description = "Heat olive oil in a pan." },
                    new Step { Description = "Add beef strips and cook until browned." },
                    new Step { Description = "Add bell pepper and broccoli, and stir fry until tender." },
                    new Step { Description = "Add soy sauce and mix well." },
                    new Step { Description = "Serve hot." }
                }
            };

            AddNewRecipe(recipe7);

            // Sample Recipe 8
            Recipe recipe8 = new Recipe
            {
                RecipeName = "Vegetable Soup",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Carrot", Quantity = 2, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Vegetable, Calories = 50 },
                    new Ingredient { Name = "Potato", Quantity = 1, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Starch, Calories = 110 },
                    new Ingredient { Name = "Onion", Quantity = 1, UnitOfMeasurement = UnitOM.Whole, FoodGroup = FoodGroup.Vegetable, Calories = 44 },
                    new Ingredient { Name = "Celery", Quantity = 2, UnitOfMeasurement = UnitOM.Stalk, FoodGroup = FoodGroup.Vegetable, Calories = 10 },
                    new Ingredient { Name = "Vegetable Broth", Quantity = 4, UnitOfMeasurement = UnitOM.Cup, FoodGroup = FoodGroup.Liquid, Calories = 40 }
                },
                Steps = new List<Step>
                {
                    new Step { Description = "Chop all vegetables." },
                    new Step { Description = "Heat vegetable broth in a pot." },
                    new Step { Description = "Add all vegetables to the pot and cook until tender." },
                    new Step { Description = "Serve hot." }
                }
            };

            AddNewRecipe(recipe8);

        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void AddNewRecipe(Recipe recipe)
        {
            // Setting the scale factor of the recipe to 1, as this is the original state of the recipe.
            recipe.ScaleFactor = 1;

            // Normalizing all the quantities of the ingredients in the recipe, to simplify the recipe.
            //recipe = NormalizeQuantities(recipe);
            NormalizeQuantities(recipe);

            // Setting the total calories of the recipe to the returned value of the method CalculateTotalCalories().
            recipe.TotalCalories = CalculateTotalCalories(recipe);

            // Foreach loop to set the original values of each ingredient in the recipe.
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredient.SetOriginalValues();
            }

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
            recipe.ScaleFactor = recipe.ScaleFactor * scaleFactor;

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredient.Quantity *= scaleFactor;
                ingredient.Calories *= scaleFactor;
            }

            //recipe = NormalizeQuantities(recipe);
            NormalizeQuantities(recipe);
            recipe.TotalCalories = CalculateTotalCalories(recipe);
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
                result += ingredient.Calories;
            }
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        //Normalize the quantities of ingredients in a recipe, by passing each ingredient through a switch statements.
        //The switch statements convert the quantities of ingredients to a more appropriate unit of measurement.
        private void NormalizeQuantities(Recipe recipe)
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
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public List<string> IngredientCheckBoxFormat(Recipe recipe)
        {
            List<string> ingredientList = new List<string>();

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredientList.Add((ingredient.Quantity % 1 != 0 ? ingredient.Quantity.ToString("0.00") : ingredient.Quantity.ToString("0")) + " " + ingredient.UnitOfMeasurement + ", " + ingredient.Name + " (" + ingredient.Calories.ToString("0") + " kcal)");
            }

            return ingredientList;
        }

        //END OF RECIPE MANAGER CLASS
        //-------------------------------------------------------------------------------------------------------------------------------------
    }
}
