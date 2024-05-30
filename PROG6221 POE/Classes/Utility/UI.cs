using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE.Classes
{
    class UI
    {
        public void WelcomeMessage()
        {
            Console.Title = "Recipe Application";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Recipe Application!");
            NextPrompt();
        }
        public void GoodbyeMessage()
        {
            Console.Title = "Closing Application";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thank you for using the Recipe Application!");
        }
        public void NextPrompt()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        // DisplayMenu() displays a menu to the user, prompting them to select an option.
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Application Menu: \n\n1) Create a new recipe \n2) Scale a recipe \n3) Reset the scale of a recipe to its original \n4) Display a recipe \n5) Delete a recipe \n6) View a list of all recipes \n7) Exit \n");
            
        }
        // GetMenuChoice() gets the user's choice from the menu and returns it as an integer.
        public int GetMenuChoice()
        {
            int menuChoice = GetPositiveInteger("Please select one of the following options: ");
            Console.Clear();
            return menuChoice;
        }
        public double GetScaleFactor()
        {
            Console.Clear();
            Console.WriteLine("Scale a Recipe\n");
            double scaleFactor = GetPositiveDouble("Please enter a number that you would like to scale the recipe by: ");
            return scaleFactor;
        }
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
                Console.WriteLine(i + ") " + ingredient.Quantity + " " + ingredient.UnitOfMeasurement + " of " + ingredient.Name + " (" + ingredient.FoodGroup + ") " + ingredient.Calories + " calories");
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
        }
    
        // DisplayRecipeList() displays a list of all the recipes to the user in alphabetical order by name.
        public void DisplayRecipeList(List<Recipe> recipeList)
        {
            Console.Clear();
            Console.WriteLine("List of Recipes: \n");
            int i = 1;
            foreach (Recipe recipe in recipeList.OrderBy(recipe => recipe.RecipeName))
            {
                Console.WriteLine(i + ") " + recipe.RecipeName);
                i++;
            }
            Console.WriteLine();
        }
        public Recipe CreateNewRecipe()
        {
            Recipe recipe = new Recipe();

            // Prompt user to enter recipe details.
            Console.Clear();
            Console.WriteLine("Please enter the details for the recipe:");

            // Gather recipe name.
            Console.Write("\nRecipe name: ");
            recipe.RecipeName = Console.ReadLine();

            // Gather ingredient details.
            int ingredientsCount = GetPositiveInteger("\nNumber of ingredients required: ");
            for (int i = 0; i < ingredientsCount; i++)
            {
                recipe.Ingredients.Add(GetIngredientDetail(i));
            }

            // Gather descriptions for each step 
            int stepsCount = GetPositiveInteger("\nNumber of steps required: ");
            for (int i = 0; i < stepsCount; i++)
            {
                recipe.Steps.Add(GetStepDescription(i));
            }

            return recipe;
        }
        private int GetPositiveInteger(string prompt)
        {
            int number;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out number) || number <= 0);
            return number;
        }

        private double GetPositiveDouble(string prompt)
        {
            double number;
            do
            {
                Console.Write(prompt);
            } while (!double.TryParse(Console.ReadLine(), out number) || number <= 0);
            return number;
        }

        private Ingredient GetIngredientDetail(int ingredientNumber)
        {

            Ingredient ingredient = new Ingredient();
            Console.WriteLine("Ingredient Number: " + (ingredientNumber + 1));
            Console.Write("Ingredient name: ");
            ingredient.Name = Console.ReadLine();
            ingredient.Quantity = GetPositiveInteger("Quantity: ");
            Console.Write("Unit of measurement: ");
            ingredient.UnitOfMeasurement = Console.ReadLine();
            Console.Write("Food Group: ");
            ingredient.FoodGroup = Console.ReadLine();
            ingredient.Calories = GetPositiveDouble("Calories: ");

            return ingredient;
        }

        private Step GetStepDescription(int stepNumber)
        {
            Step step = new Step();
            Console.WriteLine("Step Number: " + (stepNumber + 1));
            step.Description = Console.ReadLine();

            return step;
        }

    }
}
