using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG6221_POE.Classes
{
    class UI
    {
        //-------------------------------------------------------------------------------------------------------------------------------------

        // Define the method to handle the event
        private void NotifyCaloriesExceeded(string recipeName, double calories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Warning: The recipe '{recipeName}' exceeds 300 calories with its total of {calories} calories.\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // Define the delegate
        public delegate void CaloriesExceededNotification(string recipeName, double calories);

        // Declare an event based on the delegate
        public event CaloriesExceededNotification OnCaloriesExceeded;

        //-------------------------------------------------------------------------------------------------------------------------------------

        public UI()
        {
            // Subscribe to the OnCaloriesExceeded event in the UI constructor
            this.OnCaloriesExceeded += NotifyCaloriesExceeded;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void WelcomeMessage()
        {
            Console.Title = "Recipe Application";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Recipe Application!\n");
            NextPrompt();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void GoodbyeMessage()
        {
            Console.Title = "Closing Application";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thank you for using the Recipe Application!");
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void NextPrompt()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------

        // DisplayMenu() displays a menu to the user, prompting them to select an option.
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Application Menu: \n\n1) Create a new recipe \n2) Scale a recipe \n3) Reset the scale of a recipe to its original \n4) Display a recipe \n5) Delete a recipe \n6) View a list of all recipes \n7) Exit \n");
            
        }
        //-------------------------------------------------------------------------------------------------------------------------------------

        // GetMenuChoice() gets the user's choice from the menu and returns it as an integer.
        public int GetMenuChoice(int maxChoice)
        {
            int menuChoice;
            do
            {
                Console.Write("Please select one of the following options: ");
            } while (!int.TryParse(Console.ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > maxChoice);
            Console.Clear();
            return menuChoice;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public double GetScaleFactor()
        {
            Console.Clear();
            Console.WriteLine("Scale a Recipe\n");
            double scaleFactor = GetPositiveDouble("Please enter a number that you would like to scale the recipe by: ");
            return scaleFactor;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // DisplayRecipe() displays the recipe to the user, in a neat and readable format.
        // This display will include the recipe name, ingredients, and steps.
        public void DisplayRecipe(Recipe recipe)
        {
            // Display recipe's details for ingredients.
            Console.Clear();
            Console.WriteLine(recipe.RecipeName);
            Console.WriteLine("-----------------------------------\nIngredients: \n-----------------------------------");
            int i = 1;
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                Console.WriteLine(i + ") " + (ingredient.Quantity < 1 ? ingredient.Quantity.ToString("0.00") : ingredient.Quantity.ToString("0")) + " " + ingredient.UnitOfMeasurement + " of " + ingredient.Name + " (" + ingredient.FoodGroup + ") " + ingredient.Calories.ToString("0") + " calories");
                i++;
            } 
            
            // Display recipe's description for each step.
            Console.WriteLine("-----------------------------------\nSteps: \n-----------------------------------");
            i = 1;
            foreach (Step step in recipe.Steps)
            {
                Console.WriteLine(i + ") " + step.Description);
                i++;
            }
            Console.WriteLine("-----------------------------------\nTotal Calories: " + recipe.TotalCalories.ToString("0") + " calories\n");
            RecipeCalorieStatus(recipe);

            //Check if the total calories exceed 300 and if the event has subscribers
            if (recipe.TotalCalories > 300 && OnCaloriesExceeded != null)
            {
                OnCaloriesExceeded(recipe.RecipeName, recipe.TotalCalories);
            }

        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public bool ConfirmDeleteRecipe()
        {

            bool confirmation = false;
            Console.Write("Are you sure you want to delete this recipe? (Yes / No): ");
            string response = Console.ReadLine().ToUpper();

            if (response.Equals("YES"))
            {
                confirmation = true;
                Console.WriteLine("Recipe deleted successfully.");
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }

            return confirmation;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // DisplayRecipeList() displays a list of all the recipes to the user in alphabetical order by name.
        public void DisplayRecipeList(List<Recipe> recipeList)
        {
            Console.Clear();
            Console.Write("List of Recipes: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Low / ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Moderate / ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("High");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" (Calories)\n");

            int i = 1;
            foreach (Recipe recipe in recipeList)
            {
                Console.Write(i + ") "); RecipeTitleStatus(recipe);
                Console.WriteLine();
                i++;
            }
            Console.WriteLine();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // CreateNewRecipe() prompts the user to enter the details for a new recipe.
        public Recipe CreateNewRecipe()
        {
            Recipe recipe = new Recipe();

            // Prompt user to enter recipe details.
            Console.Clear();
            Console.WriteLine("Please enter the details for the recipe:");

            // Gather recipe name.
            Console.Write("\nRecipe Name: ");
            recipe.RecipeName = Console.ReadLine();

            // Gather ingredient details.
            int ingredientsCount = GetPositiveInteger("\nNumber of ingredients: ");
            Console.Clear();
            for (int i = 0; i < ingredientsCount; i++)
            {
                Console.Clear();
                recipe.Ingredients.Add(GetIngredientDetail(i));
            }

            Console.Clear();

            // Gather descriptions for each step 
            int stepsCount = GetPositiveInteger("Number of steps: ");
            for (int i = 0; i < stepsCount; i++)
            {
                Console.Clear();
                recipe.Steps.Add(GetStepDescription(i));
            }

            recipe.ScaleFactor = 1;

            return recipe;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // GetPositiveInteger() prompts the user to enter a positive integer and returns it.
        private int GetPositiveInteger(string prompt)
        {
            //https://www.w3schools.com/cs/cs_while_loop.php
            int number;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out number) || number <= 0);
            return number;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // GetPositiveDouble() prompts the user to enter a positive double and returns it.
        private double GetPositiveDouble(string prompt)
        {
            double number;
            do
            {
                Console.Write(prompt);
            } while (!double.TryParse(Console.ReadLine(), out number) || number <= 0);
            return number;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // GetIngredientDetail() prompts the user to enter the details for an ingredient and returns it.
        private Ingredient GetIngredientDetail(int ingredientNumber)
        {
            // Create a new ingredient object.
            Ingredient ingredient = new Ingredient();

            Console.WriteLine("Ingredient Number: " + (ingredientNumber + 1));

            //Set the name of the ingredient
            Console.Write("\nName: ");
            ingredient.Name = Console.ReadLine();

            //https://learn.microsoft.com/en-us/dotnet/api/system.enum.getvalues?view=net-8.0
            // Display available units of measurement and prompt user to select one
            Console.WriteLine("\nUnit of Measurement: \n");
            int i = 1;
            foreach (var unit in Enum.GetValues(typeof(UnitOM)))
            {
                Console.WriteLine(i + ") " + unit);
                i++;
            }

            int unitChoice;
            do
            {
                unitChoice = GetPositiveInteger("\nSelect one of the options: ");
            } while (unitChoice < 1 || unitChoice > Enum.GetNames(typeof(UnitOM)).Length);
            ingredient.UnitOfMeasurement = (UnitOM)unitChoice;

            ingredient.Quantity = GetPositiveDouble("\nQuantity: ");

            // Display available food groups and prompt user to select one
            Console.WriteLine("\nFood Group: \n");
            i = 1;
            foreach (var group in Enum.GetValues(typeof(FoodGroup)))
            {
                Console.WriteLine(i + ") " + group);
                i++;
            }
            int groupChoice;
            do
            {
                groupChoice = GetPositiveInteger("\nSelect one of the options: ");
            } while (groupChoice < 1 || groupChoice > Enum.GetNames(typeof(FoodGroup)).Length);
            ingredient.FoodGroup = (FoodGroup)groupChoice;

            ingredient.Calories = GetPositiveDouble("\nTotal Number of Calories for this ingredient: ");

            ingredient.SetOriginalValues();

            return ingredient;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        // GetStepDescription() prompts the user to enter the description for a step and returns it.
        private Step GetStepDescription(int stepNumber)
        {
            Step step = new Step();
            Console.WriteLine("Step Number: " + (stepNumber + 1));
            step.Description = Console.ReadLine();

            return step;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private void RecipeCalorieStatus(Recipe recipe)
        {
            if (recipe.TotalCalories < 200)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("This recipe is low in calories, suitable for a snack.\n");
            } 
            else if (recipe.TotalCalories >= 200 && recipe.TotalCalories < 500)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This recipe is moderate in calories, suitable for a balanced meal.\n");
            } 
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("This recipe is high in calories, and should be consumed sparingly.\n");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private void RecipeTitleStatus (Recipe recipe)
        {
            if (recipe.TotalCalories < 200)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(recipe.RecipeName);
            }
            else if (recipe.TotalCalories >= 200 && recipe.TotalCalories < 500)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(recipe.RecipeName);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(recipe.RecipeName);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        //END OF UI CLASS
        //-------------------------------------------------------------------------------------------------------------------------------------

    }
}
