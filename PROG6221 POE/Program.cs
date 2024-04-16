using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE
{
    class Program
    {
        public static void Main(string[] args)
        {

            string option;
            Boolean application;

            Recipe recipe = new Recipe();

            application = true;

            Console.Title = "RECIPE APPLICATION";
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Welcome to the Recipe Application!\n");

            while (application)
            {
                Console.WriteLine("Please select one of the following options: \n\n1) Create a new recipe \n2) Scale a recipe \n3) Reset scale to original \n4) Display recipe \n5) Delete recipe \n6) Exit");
                option = Console.ReadLine();

                switch (option)
                {
                    //Create a New Recipe
                    case "1": 

                        recipe.CreateNewRecipe();
                        break;

                    //Scale a Recipe.
                    case "2": 

                        recipe.ScaleRecipe();
                        break;

                    //Reset recipe scale factor to original.
                    case "3": 

                        recipe.ResetScale();
                        break;

                    //Display Recipe
                    case "4": 

                        recipe.DisplayRecipe();
                        break;

                    //Delete Recipe
                    case "5": 

                        if (recipe.DeleteRecipe())
                        {
                            recipe = new Recipe();
                            Console.WriteLine("You have successfully cleared all the data from this recipe!");
                        }
                        else
                        {
                            Console.WriteLine("Cancelled!");
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Exit Application
                    case "6": 

                        application = false;
                        break;

                    default:
                        Console.WriteLine("Please select one of the available options.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

        }
    }
}
