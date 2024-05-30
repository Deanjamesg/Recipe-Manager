using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG6221_POE
{
    class Recipe
    {
        public double ScaleFactor { get; set; }
        public string RecipeName { get; set; }
        public List <string> Steps { get; set; }
        public List <Ingredient> Ingredients { get; set; }
        public double TotalCalories { get; set; }

        /* CreateNewRecipe()
         * Creates a new recipe by collecting details such as name, number of ingredients, quantity, and unit of measurement for each ingredient, 
         * as well as a description for each step. Validates user input and ensures that the recipe is unique before creation.
         */
        public Recipe()
        {
            Steps = new List<string>();
            Ingredients = new List<Ingredient>();
        }

        /* ScaleRecipe()
         * Scales the existing recipe by a specified factor.
         * Validates user input and ensures that a recipe exists before scaling.
         */
        //public void ScaleRecipe()
        //{
        //    // Check if a recipe exists.
        //    if (!exists)
        //    {
        //        Console.WriteLine("There is currently no recipe that exists!");
        //        Console.WriteLine("\nPress any key to continue...");
        //        Console.ReadKey();
        //        Console.Clear();
        //        return;
        //    }
        //    // Prompt to user to enter scaling factor.
        //    Console.Clear();
        //    Console.WriteLine(
        //        "Please note: \nIf you have not reset the recipe to its original quantities after scaling it, " +
        //        "\nplease do so before scaling it again!" +
        //        "\n\nHow much would you like to scale the recipe by? " +
        //        "\nPlease enter one of the following options: (0,5 / 2 / 3) " +               
        //        "\n\nEnter '1' to cancel the scaling and go reset the recipe to its original quantities.");

        //    double tempFactor;

        //    // Taking scaling factor from user.
        //    while (!double.TryParse(Console.ReadLine(), out tempFactor) && tempFactor <= 0)
        //    {
        //        Console.Write("Please enter a number that is greater than 0.");
        //    }

        //    // Cancel scaling if user enters '1'.
        //    if (tempFactor == 1) { return; }

        //    // Setting scaling factor.
        //    scaleFactor = tempFactor;

        //    // Scale each ingredient in the recipe, in the Ingredients array.
        //    foreach (Ingredient item in ingredients)
        //    {
        //        item.Quantity *= scaleFactor;
        //        ValidateUnitOfMeasurement(item);
        //        NormalizeQuantities(item);
        //    }

        //    // Display the scaled recipe.
        //    DisplayRecipe();
        //}


        ///* NormalizeQuantities()
        // * This method uses the object "Ingredient", and normalizes the quantities of ingredients by converting them to a more appropriate unit of measurement.
        // * An equivalent unit of measurement.
        // * For example, 3 Teaspoons = 1 Tablespoon, 8 Tablespoons = 0.5 Cups, 16 Tablespoons = 1 Cup.
        // */
        //public void NormalizeQuantities(Ingredient _ingredient)
        //{
        //    // Switch statement to handle different units of measurements.
        //    switch (_ingredient.UnitOfMeasurement)
        //    {
        //        // If the measurement is teaspoons.
        //        case "tsp":
        //            // If the quantity is 3 or more teaspoons, convert to tablespoons.
        //            if (_ingredient.Quantity >= 3)
        //            {
        //                _ingredient.Quantity /= 3;
        //                _ingredient.UnitOfMeasurement = "tbsp";
        //            }
        //            break;

        //        // If the measurement is tablespoons.
        //        case "tbsp":
        //            // If the quantity is 4 or more tablespoons, convert to cups.
        //            if (_ingredient.Quantity >= 4)
        //            {
        //                _ingredient.Quantity /= 16;
        //                _ingredient.UnitOfMeasurement = "cups";
        //            }
        //            // If the quantity is less than 1 tablespoon, convert to teaspoons.
        //            else if (_ingredient.Quantity < 1)
        //            {
        //                _ingredient.Quantity *= 3;
        //                _ingredient.UnitOfMeasurement = "tsp";
        //            }
        //            break;

        //        // If the measurement is cups.
        //        case "cups":
        //            // If the quantity is less than 0.25 cups, convert to tablespoons.
        //            if (_ingredient.Quantity < 0.25)
        //            {
        //                _ingredient.Quantity *= 16;
        //                _ingredient.UnitOfMeasurement = "tbsp";
        //            }
        //            break;

        //        // Default case for other measurements.
        //        default:
        //            break;
        //    }
        //}

        ///* ValidateUnitOfMeasurement()
        // * This method uses the object "Ingredient" after the user has inputed their desired values for the properties of the ingredient, 
        // * and ensures that the unit of measurement that the user has inputed, is an appropriate type of measurement.
        // * Appropriate units of measurements are: Tablespoons (tbsp), Teaspoons (tsp), Cups (c), Grams (g).
        // * If the unit of measurement is NOT one of the appropriate types, the user is prompted to re-enter the unit of measurement, and then the
        // * method calls itself to validate it once again, until the statement is true.
        // * If the unit of measurement IS one of the appropriate types, the unit of measurement is formated into a shorter form.
        // * For example, tablespoons will become tbsp.
        //*/
        //public void ValidateUnitOfMeasurement(Ingredient _ingredient)
        //{
        //    string unitMeasurement = _ingredient.UnitOfMeasurement.ToLower();
        //    char[] tablespoon = { 't', 'b', 's', 'p' };
        //    char[] teaspoon = { 't', 's', 'p' };
        //    char[] cups = { 'c' };
        //    char[] grams = { 'g' };

        //    /*
        //     * Order of check list: 
        //     * 1) Tablespoons
        //     * 2) Teaspoons
        //     * 3) Cups
        //     * 4) Grams
        //     */

        //    // Check if the unit of measurement contains characters representing tablespoons.
        //    if (tablespoon.All(c => unitMeasurement.Contains(c)))
        //    {
        //        _ingredient.UnitOfMeasurement = "tbsp";
        //        return;
        //    }
        //    // Check if the unit of measurement contains characters representing teaspoons.
        //    else if (teaspoon.All(c => unitMeasurement.Contains(c)))
        //    {
        //        _ingredient.UnitOfMeasurement = "tsp";
        //        return;
        //    }
        //    // Check if the unit of measurement contains characters representing cups.
        //    else if (cups.All(c => unitMeasurement.Contains(c)))
        //    {
        //        _ingredient.UnitOfMeasurement = "cups";
        //        return;
        //    }
        //    // Check if the unit of measurement contains characters representing grams.
        //    else if (grams.All(c => unitMeasurement.Contains(c)))
        //    {
        //        _ingredient.UnitOfMeasurement = "g";
        //        return;
        //    }
        //    // If none of the predefined units are found, prompt the user to enter a valid unit of measurement.
        //    else
        //    {
        //        Console.Write("Please enter one of following units of measurements: tablespoon / teaspoon / cups / grams \nfor the ingredient: (" + _ingredient.Name + ") ");
        //        _ingredient.UnitOfMeasurement = Console.ReadLine();
        //        // Recursively call the method to validate the entered unit of measurement.
        //        ValidateUnitOfMeasurement(_ingredient);
        //    }
        //}
        ///* ResetScale()
        // * Resets the scale of the recipe, reverting ingredient quantities to their original values.
        // */
        //public void ResetScale()
        //{
        //    // Check if a recipe exists.
        //    Console.Clear();
        //    if (!exists)
        //    {
        //        // If no recipe exists, inform the user and return.
        //        Console.WriteLine("There is currently no recipe that exists!");
        //        Console.WriteLine("\nPress any key to continue...");
        //        Console.ReadKey();
        //        Console.Clear();
        //        return;
        //    }

        //    // Iterate through each ingredient in the recipe.
        //    foreach (Ingredient item in ingredients)
        //    {
        //        // Reset the quantity of the ingredient by dividing it by the scale factor.
        //        item.Quantity /= scaleFactor;
        //        // Validate the unit of measurement for the ingredient.
        //        ValidateUnitOfMeasurement(item);
        //        // Normalize the quantities of the ingredient.
        //        NormalizeQuantities(item);
        //    }
        //    // Reset the scale factor to 1
        //    scaleFactor = 1;
        //    // Inform the user that the recipe's quantities have been successfully reset.
        //    Console.WriteLine("Successfully reset the recipe's quantities to their original values! \nPress any key to continue...");
        //    Console.ReadKey();
        //    Console.Clear();

        //}
        ///* DeleteRecipe()
        // * Deletes the current recipe if it exists.
        // * Returns true if the recipe was successfully deleted, otherwise false.
        // */
        //public bool DeleteRecipe()
        //{
        //    //Initialize a variable to hold the result of the deletion operation.
        //    bool result;

        //    // Check if a recipe exists.
        //    if (!exists)
        //    {
        //        // If no recipe exists, inform the user and return false.
        //        Console.WriteLine("There is currently no recipe that exists!");
        //        Console.WriteLine("\nPress any key to continue...");
        //        Console.ReadKey();
        //        Console.Clear();
        //        return false;
        //    }

        //    // Prompt the user to confirm the deletion.
        //    Console.WriteLine("Are you sure you want to delete this recipe? Yes / No");
        //    string confirm = Console.ReadLine().ToUpper();

        //    // Check if the user confirmed the deletion.
        //    if (confirm.Equals("YES"))
        //    {
        //        // Set the result to true.
        //        result = true;
        //    }
        //    else
        //    {
        //        // Set the result to false.
        //        result = false;
        //    }

        //    // Return the result of the deletion operation.
        //    return result;
        //}
    }
}
