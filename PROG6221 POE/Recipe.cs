using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE
{
    class Recipe
    {
        public int scaleFactor { get; set; }
        public string name { get; set; }
        public string[] steps { get; set; }
        public string[,] ingredients { get; set; }

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
            Console.WriteLine(name);
            Console.WriteLine("-----------------------------------\nIngredients: \n-----------------------------------");

            for (int i = 0; i < ingredients.GetLength(0); i++)
            {
                Console.WriteLine(ingredients[i, 1] + " " + ingredients[i, 2] + " of " + ingredients[i, 0]);

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
            name = Console.ReadLine();

            Console.Write("\nNumber of ingredients required: ");
            int ingredientsCount = int.Parse(Console.ReadLine());

            Console.Write("\nNumber of steps to be done: ");
            int stepsCount = int.Parse(Console.ReadLine());

            scaleFactor = 1;
            ingredients = new string[ingredientsCount, 3];
            steps = new string[stepsCount];

            string[] Prompt = { "Ingredient: ", "Quantity: ", "Unit of measurement: " };

            Console.WriteLine("\nPlease enter the ingredients used, the quantity and unit of measurement: ");

            for (int i = 0; i < ingredients.GetLength(0); i++)
            {
                Console.WriteLine("\nINGREDIENT NUMBER: " + (i + 1));

                for (int j = 0; j < ingredients.GetLength(1); j++)
                {
                    Console.Write(Prompt[j]);
                    ingredients[i, j] = Console.ReadLine();
                }
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
