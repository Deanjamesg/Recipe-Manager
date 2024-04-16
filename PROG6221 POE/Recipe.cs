using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace PROG6221_POE
{
    class Recipe
    {
        public double scaleFactor { get; set; }
        public string recipeName { get; set; }
        public string[] steps { get; set; }
        public Ingredients[] ingredients { get; set; }
        public bool exists { get; set; }

        public Recipe() { 
        }

        /* CreateNewRecipe()
         * Creates a new recipe by collecting details such as name, number of ingredients, quantity, and unit of measurement for each ingredient, 
         * as well as a description for each step. Validates user input and ensures that the recipe is unique before creation.
         */
        public void CreateNewRecipe()
        {
            if (exists)
            {
                Console.Clear();
                Console.WriteLine("There is currently a recipe that exists! \nPlease go delete the current recipe before creating a new one!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            int ingredientsCount, stepsCount;
            scaleFactor = 1;

            // Prompt user to enter recipe details.
            Console.Clear();
            Console.WriteLine("Please enter the following requirements: ");

            // Gather recipe name.
            Console.Write("\nName of the recipe: ");
            recipeName = Console.ReadLine();

            // Gather number of ingredients required.
            Console.Write("\nNumber of ingredients required: ");

            while (!int.TryParse(Console.ReadLine(), out ingredientsCount) && ingredientsCount <= 0)
            {
                Console.WriteLine("Please enter a number that is greater than 0.");
            }

            // Gather number of steps.
            Console.Write("\nNumber of steps to be done: ");
            while (!int.TryParse(Console.ReadLine(), out stepsCount) && stepsCount <= 0)
            {
                Console.WriteLine("Please enter a number that is greater than 0.");
            }

            // Initialize arrays for ingredients and steps.
            ingredients = new Ingredients[ingredientsCount];
            steps = new string[stepsCount];

            // Gather ingredient details.
            Console.Clear();
            Console.WriteLine("Please enter the ingredients(" + ingredientsCount + ") used, the quantity and unit of measurement:\nNOTE: Use a ',' not a '.' when entering a decimal value.");

            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine("\nINGREDIENT NUMBER: " + (i + 1));
                Console.Write("Ingredient: ");
                string _name = Console.ReadLine();
                Console.Write("Quantity: ");

                double _quantity;
                while (!double.TryParse(Console.ReadLine(), out _quantity) || _quantity <= 0)
                {
                    Console.Write("Please enter a number that is greater than 0 for quantity: ");
                }
                Console.Write("Unit of measurement: ");
                string _measurement = Console.ReadLine();

                // Create new Ingredients objects and validate unit of measurement and normalize their quantities.
                ingredients[i] = new Ingredients
                {
                    name = _name,
                    quantity = _quantity,
                    measurement = _measurement
                };

                ValidateUnitOfMeasurement(ingredients[i]);
                NormalizeQuantities(ingredients[i]);

            }
            // Gather descriptions for each step and storing it in a string array. 
            Console.Clear();
            Console.WriteLine("Please enter a description for each step: (" + stepsCount + " steps)");

            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine("\nSTEP NUMBER: " + (i + 1));
                steps[i] = Console.ReadLine();
            }
            // Set exists bool to true indicating recipe creation / that a recipe exists.
            exists = true;
            Console.Clear();

            // Calling DisplayRecipe() to display the created recipe.
            DisplayRecipe();

        }

        /* ScaleRecipe()
         * Scales the existing recipe by a specified factor.
         * Validates user input and ensures that a recipe exists before scaling.
         */
        public void ScaleRecipe()
        {
            // Check if a recipe exists.
            if (!exists)
            {
                Console.WriteLine("There is currently no recipe that exists!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            // Prompt to user to enter scaling factor.
            Console.Clear();
            Console.WriteLine(
                "Please note: \nIf you have not reset the recipe to its original quantities after scaling it, " +
                "\nplease do so before scaling it again!" +
                "\n\nHow much would you like to scale the recipe by? " +
                "\nPlease enter one of the following options: (0,5 / 2 / 3) " +               
                "\n\nEnter '1' to cancel the scaling and go reset the recipe to its original quantities.");

            double tempFactor;

            // Taking scaling factor from user.
            while (!double.TryParse(Console.ReadLine(), out tempFactor) && tempFactor <= 0)
            {
                Console.Write("Please enter a number that is greater than 0.");
            }

            // Cancel scaling if user enters '1'.
            if (tempFactor == 1) { return; }

            // Setting scaling factor.
            scaleFactor = tempFactor;

            // Scale each ingredient in the recipe, in the Ingredients array.
            foreach (Ingredients item in ingredients)
            {
                item.quantity *= scaleFactor;
                ValidateUnitOfMeasurement(item);
                NormalizeQuantities(item);
            }

            // Display the scaled recipe.
            DisplayRecipe();
        }

        /* DisplayRecipe()
         * Displays the current recipe, including its name, ingredients, and steps.
         * Validates if a recipe exists before displaying.
         */
        public void DisplayRecipe()
        {
            if (!exists)
            {
                Console.WriteLine("There is currently no recipe that exists!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            // Display recipe's details for ingredients.
            Console.Clear();
            Console.WriteLine(recipeName);
            Console.WriteLine("-----------------------------------\nIngredients: \n-----------------------------------");

            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine(ingredients[i].quantity + " " + ingredients[i].measurement + " of " + ingredients[i].name);
            }

            // Display recipe's description for each step.
            Console.WriteLine("-----------------------------------\nSteps: \n-----------------------------------");

            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine((i + 1) + ") " + steps[i]);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }

        /* NormalizeQuantities()
         * This method uses the object "Ingredient", and normalizes the quantities of ingredients by converting them to a more appropriate unit of measurement.
         * An equivalent unit of measurement.
         * For example, 3 Teaspoons = 1 Tablespoon, 8 Tablespoons = 0.5 Cups, 16 Tablespoons = 1 Cup.
         */
        public void NormalizeQuantities(Ingredients _ingredient)
        {
            // Switch statement to handle different units of measurements.
            switch (_ingredient.measurement)
            {
                // If the measurement is teaspoons.
                case "tsp":
                    // If the quantity is 3 or more teaspoons, convert to tablespoons.
                    if (_ingredient.quantity >= 3)
                    {
                        _ingredient.quantity /= 3;
                        _ingredient.measurement = "tbsp";
                    }
                    break;

                // If the measurement is tablespoons.
                case "tbsp":
                    // If the quantity is 4 or more tablespoons, convert to cups.
                    if (_ingredient.quantity >= 4)
                    {
                        _ingredient.quantity /= 16;
                        _ingredient.measurement = "cups";
                    }
                    // If the quantity is less than 1 tablespoon, convert to teaspoons.
                    else if (_ingredient.quantity < 1)
                    {
                        _ingredient.quantity *= 3;
                        _ingredient.measurement = "tsp";
                    }
                    break;

                // If the measurement is cups.
                case "cups":
                    // If the quantity is less than 0.25 cups, convert to tablespoons.
                    if (_ingredient.quantity < 0.25)
                    {
                        _ingredient.quantity *= 16;
                        _ingredient.measurement = "tbsp";
                    }
                    break;

                // Default case for other measurements.
                default:
                    break;
            }
        }

        /* ValidateUnitOfMeasurement()
         * This method uses the object "Ingredient" after the user has inputed their desired values for the properties of the ingredient, 
         * and ensures that the unit of measurement that the user has inputed, is an appropriate type of measurement.
         * Appropriate units of measurements are: Tablespoons (tbsp), Teaspoons (tsp), Cups (c), Grams (g).
         * If the unit of measurement is NOT one of the appropriate types, the user is prompted to re-enter the unit of measurement, and then the
         * method calls itself to validate it once again, until the statement is true.
         * If the unit of measurement IS one of the appropriate types, the unit of measurement is formated into a shorter form.
         * For example, tablespoons will become tbsp.
        */
        public void ValidateUnitOfMeasurement(Ingredients _ingredient)
        {
            string unitMeasurement = _ingredient.measurement.ToLower();
            char[] tablespoon = { 't', 'b', 's', 'p' };
            char[] teaspoon = { 't', 's', 'p' };
            char[] cups = { 'c' };
            char[] grams = { 'g' };

            /*
             * Order of check list: 
             * 1) Tablespoons
             * 2) Teaspoons
             * 3) Cups
             * 4) Grams
             */

            // Check if the unit of measurement contains characters representing tablespoons.
            if (tablespoon.All(c => unitMeasurement.Contains(c)))
            {
                _ingredient.measurement = "tbsp";
                return;
            }
            // Check if the unit of measurement contains characters representing teaspoons.
            else if (teaspoon.All(c => unitMeasurement.Contains(c)))
            {
                _ingredient.measurement = "tsp";
                return;
            }
            // Check if the unit of measurement contains characters representing cups.
            else if (cups.All(c => unitMeasurement.Contains(c)))
            {
                _ingredient.measurement = "cups";
                return;
            }
            // Check if the unit of measurement contains characters representing grams.
            else if (grams.All(c => unitMeasurement.Contains(c)))
            {
                _ingredient.measurement = "g";
                return;
            }
            // If none of the predefined units are found, prompt the user to enter a valid unit of measurement.
            else
            {
                Console.Write("Please enter one of following units of measurements: tablespoon / teaspoon / cups / grams \nfor the ingredient: (" + _ingredient.name + ") ");
                _ingredient.measurement = Console.ReadLine();
                // Recursively call the method to validate the entered unit of measurement.
                ValidateUnitOfMeasurement(_ingredient);
            }
        }
        /* ResetScale()
         * Resets the scale of the recipe, reverting ingredient quantities to their original values.
         */
        public void ResetScale()
        {
            // Check if a recipe exists.
            Console.Clear();
            if (!exists)
            {
                // If no recipe exists, inform the user and return.
                Console.WriteLine("There is currently no recipe that exists!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            // Iterate through each ingredient in the recipe.
            foreach (Ingredients item in ingredients)
            {
                // Reset the quantity of the ingredient by dividing it by the scale factor.
                item.quantity /= scaleFactor;
                // Validate the unit of measurement for the ingredient.
                ValidateUnitOfMeasurement(item);
                // Normalize the quantities of the ingredient.
                NormalizeQuantities(item);
            }
            // Reset the scale factor to 1
            scaleFactor = 1;
            // Inform the user that the recipe's quantities have been successfully reset.
            Console.WriteLine("Successfully reset the recipe's quantities to their original values! \nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }
        /* DeleteRecipe()
         * Deletes the current recipe if it exists.
         * Returns true if the recipe was successfully deleted, otherwise false.
         */
        public bool DeleteRecipe()
        {
            //Initialize a variable to hold the result of the deletion operation.
            bool result;

            // Check if a recipe exists.
            if (!exists)
            {
                // If no recipe exists, inform the user and return false.
                Console.WriteLine("There is currently no recipe that exists!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return false;
            }

            // Prompt the user to confirm the deletion.
            Console.WriteLine("Are you sure you want to delete this recipe? Yes / No");
            string confirm = Console.ReadLine().ToUpper();

            // Check if the user confirmed the deletion.
            if (confirm.Equals("YES"))
            {
                // Set the result to true.
                result = true;
            }
            else
            {
                // Set the result to false.
                result = false;
            }

            // Return the result of the deletion operation.
            return result;
        }
    }
}
