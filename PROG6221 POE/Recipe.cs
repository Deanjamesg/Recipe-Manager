using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE
{
    class Recipe
    {
        public double scaleFactor { get; set; }
        public string recipeName { get; set; }
        public string[] steps { get; set; }
        public Ingredients[] ingredients { get; set; }

        public Recipe() { 
        }

        public void ScaleRecipe()
        {
 
        }
        /*
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
            if (tablespoon.All(c => unitMeasurement.Contains(c)))
            {
                _ingredient.measurement = "Tbsp";
                return;
            } 
            else if (teaspoon.All(c => unitMeasurement.Contains(c)))
            {
                _ingredient.measurement = "tsp";
                return;
            } 
            else if (cups.All(c => unitMeasurement.Contains(c)))
            {
                _ingredient.measurement = "cups";
                return;
            } 
            else if (grams.All(c => unitMeasurement.Contains(c)))
            {
                _ingredient.measurement = "g";
                return;
            } 
            else
            {
                Console.WriteLine("Please enter one of following units of measurements: tablespoon, teaspoon, cups, or grams.");
                _ingredient.measurement = Console.ReadLine();
                ValidateUnitOfMeasurement(_ingredient);
            }

        }

        public void ResetScale()
        {
            scaleFactor = 1;
            Console.Clear();
            DisplayRecipe();

        }

        public void DisplayRecipe()
        {

            Console.Clear();
            Console.WriteLine(recipeName);
            Console.WriteLine("-----------------------------------\nIngredients: \n-----------------------------------");

            for (int i = 0; i < ingredients.GetLength(0); i++)
            {
                Console.WriteLine(ingredients[i].quantity + " " + ingredients[i].measurement + " of " + ingredients[i].name);
            }
            Console.WriteLine("-----------------------------------\nSteps: \n-----------------------------------");

            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine((i + 1) + ") " + steps[i]);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }

        public void DeleteRecipe()
        {
            scaleFactor = 1;
            recipeName = "";
            steps = null;
            ingredients = null;
            Console.WriteLine("You have successfully cleared all the data from this recipe!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void CreateNewRecipe()
        {
            Console.Clear();
            Console.WriteLine("Please enter the following requirements: ");

            Console.Write("\nName of the recipe: ");
            recipeName = Console.ReadLine();

            Console.Write("\nNumber of ingredients required: ");

            int ingredientsCount, stepsCount;
            scaleFactor = 1;

            while (!int.TryParse(Console.ReadLine(), out ingredientsCount) && ingredientsCount <= 0)
            {
                Console.WriteLine("Please enter a number that is greater than 0.");
            }

            Console.Write("\nNumber of steps to be done: ");
            while (!int.TryParse(Console.ReadLine(), out stepsCount) && stepsCount <= 0)
            {
                Console.WriteLine("Please enter a number that is greater than 0.");
            }
            steps = new string[stepsCount];
 
            Console.WriteLine("\nPlease enter the ingredients used, the quantity and unit of measurement: ");

            ingredients = new Ingredients[ingredientsCount];

            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine("\nINGREDIENT NUMBER: " + (i + 1));
                Console.Write("Ingredient: ");
                string _name = Console.ReadLine();
                Console.WriteLine("Quantity: ");
                //Validate this:
                double _quantity;
                while (!double.TryParse(Console.ReadLine(), out _quantity))
                {
                    Console.WriteLine("Please enter a number for quantity.");
                }
                Console.WriteLine("Unit of measurement: ");
                string _measurement = Console.ReadLine();

                ingredients[i] = new Ingredients
                {
                    name = _name,
                    quantity = _quantity,
                    measurement = _measurement
                };

            }
            Console.WriteLine("\nPlease enter a description for each step: ");

            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine("\nSTEP NUMBER: " + (i + 1));
                steps[i] = Console.ReadLine();
            }
            Console.Clear();

            DisplayRecipe();

        }

    }
}
