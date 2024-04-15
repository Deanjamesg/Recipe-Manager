using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine(ingredients[i].quantity * scaleFactor + " " + ingredients[i].measurement + " of " + ingredients[i].name);
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

        }

        public void CreateNewRecipe()
        {
            Console.Clear();
            Console.WriteLine("Please enter the following requirements: ");

            Console.Write("\nName of the recipe: ");
            recipeName = Console.ReadLine();

            Console.Write("\nNumber of ingredients required: ");

            int ingredientsCount, stepsCount;

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

            scaleFactor = 1;
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
