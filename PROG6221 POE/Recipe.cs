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

        public void ScaleRecipe()
        {
            if (!exists)
            {
                Console.WriteLine("There is currently no recipe that exists!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.Clear();
            Console.WriteLine(
                "\nPlease note: \nIf you have not reset the recipe to its original quantities after scaling it, " +
                "\nplease do so before scaling it again!" +
                "\n\nHow much would you like to scale the recipe by? " +
                "\nPlease enter one of the following options: (0,5 / 2 / 3) " +               
                "\n\nEnter '1' to cancel the scaling and go reset the recipe to its original quantities.");

            double tempFactor;

            while (!double.TryParse(Console.ReadLine(), out tempFactor) && tempFactor <= 0)
            {
                Console.Write("Please enter a number that is greater than 0.");
            }

            if (tempFactor == 1) { return; }

            scaleFactor = tempFactor;

            foreach (Ingredients item in ingredients)
            {
                item.quantity *= scaleFactor;
                ValidateUnitOfMeasurement(item);
                NormalizeQuantities(item);
            }

            DisplayRecipe();

 
        }
        public void ResetScale()
        {  
            Console.Clear();
            if (!exists)
            {
                Console.WriteLine("There is currently no recipe that exists!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            foreach (Ingredients item in ingredients)
            {
                item.quantity /= scaleFactor;
                ValidateUnitOfMeasurement(item);
                NormalizeQuantities(item);
            }
            scaleFactor = 1;
            Console.WriteLine("Successfully reset the recipe's quantities to their original values! \nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }
        /*
         * This method uses the object "Ingredient", and re-formats the quantities of their unit of measurement accordingly.
         * For example:
         * 3 Teaspoons = 1 Tablespoon
         * 8 Tablespoons = 0.5 Cups
         * 16 Tablespoons = 1 Cups
         */
        public void NormalizeQuantities(Ingredients _ingredient)
        {

            switch (_ingredient.measurement)
            {
                case "tsp":
                    if (_ingredient.quantity >= 3)
                    {
                        _ingredient.quantity /= 3;
                        _ingredient.measurement = "tbsp";
                    }
                    break;

                case "tbsp":
                    if (_ingredient.quantity >= 4)
                    {
                        _ingredient.quantity /= 16;
                        _ingredient.measurement = "cups";
                    } 
                    else if (_ingredient.quantity < 1)
                    {
                        _ingredient.quantity *= 3;
                        _ingredient.measurement = "tsp";
                    }
                    break;

                case "cups":
                    if (_ingredient.quantity < 0.25)
                    {
                        _ingredient.quantity *= 16;
                        _ingredient.measurement = "tbsp";
                    }
                    break;

                default:
                    break;

            }

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
                _ingredient.measurement = "tbsp";
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
                Console.Write("Please enter one of following units of measurements: tablespoon / teaspoon / cups / grams \nfor the ingredient: (" + _ingredient.name + ") ");
                _ingredient.measurement = Console.ReadLine();
                ValidateUnitOfMeasurement(_ingredient);
            }

        }

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

            Console.Clear();
            Console.WriteLine(recipeName);
            Console.WriteLine("-----------------------------------\nIngredients: \n-----------------------------------");

            for (int i = 0; i < ingredients.Length; i++)
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

        public bool DeleteRecipe()
        {
            bool result;

            if (!exists)
            {
                Console.WriteLine("There is currently no recipe that exists!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return false;
            }

            Console.WriteLine("Are you sure you want to delete this recipe? Yes / No");
            string confirm = Console.ReadLine().ToUpper();
            
            if (confirm.Equals("YES"))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

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

            Console.Clear();
            Console.WriteLine("Please enter the following requirements: ");

            Console.Write("\nName of the recipe: ");
            recipeName = Console.ReadLine();

            Console.Write("\nNumber of ingredients required: ");

            while (!int.TryParse(Console.ReadLine(), out ingredientsCount) && ingredientsCount <= 0)
            {
                Console.WriteLine("Please enter a number that is greater than 0.");
            }

            Console.Write("\nNumber of steps to be done: ");
            while (!int.TryParse(Console.ReadLine(), out stepsCount) && stepsCount <= 0)
            {
                Console.WriteLine("Please enter a number that is greater than 0.");
            }

            ingredients = new Ingredients[ingredientsCount];
            steps = new string[stepsCount];

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

                ingredients[i] = new Ingredients
                {
                    name = _name,
                    quantity = _quantity,
                    measurement = _measurement
                };

                ValidateUnitOfMeasurement(ingredients[i]);
                NormalizeQuantities(ingredients[i]);

            }
            Console.Clear();
            Console.WriteLine("\nPlease enter a description for each step: (" + stepsCount + " steps)");

            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine("\nSTEP NUMBER: " + (i + 1));
                steps[i] = Console.ReadLine();
            }
            exists = true;
            Console.Clear();

            DisplayRecipe();

        }

    }
}
