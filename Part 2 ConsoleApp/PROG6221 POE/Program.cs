using PROG6221_POE.Classes;
using System;

// Student Name: Dean James Greeff
// Student Number: ST10378305
// Date: 30/05/2024
// Assignment: PROG6221 - POE Part 2
// Link to GitHub Account
// https://github.com/Deanjamesg/PROG6221-POE

namespace PROG6221_POE
{
    class Program
    {
        //https://www.w3schools.com/cs/cs_enums.php
        public enum MenuOptions
        {
            CreateNewRecipe = 1,
            ScaleRecipe,
            ResetRecipeScale,
            DisplayRecipe,
            DeleteRecipe,
            DisplayRecipeList,
            Exit
        }
        public static void Main(string[] args)
        {

            Boolean isApplicationRunning = true;
            RecipeManager recipeManager = new RecipeManager();
            UI UI = new UI();
            
            int recipeChoice;

            UI.WelcomeMessage();

            while (isApplicationRunning)
            {
                UI.DisplayMenu();

                //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
                switch ((MenuOptions)UI.GetMenuChoice(7))
                {
                    //Create a New Recipe
                    case MenuOptions.CreateNewRecipe:

                        Recipe recipe = UI.CreateNewRecipe();
                        recipeManager.AddNewRecipe(recipe);
                        UI.DisplayRecipe(recipe);
                        UI.NextPrompt();

                        break;

                    //Scale a Recipe.
                    case MenuOptions.ScaleRecipe:

                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        recipeChoice = UI.GetMenuChoice(recipeManager.GetRecipeList().Count);
                        double scaleFactor = UI.GetScaleFactor();
                        recipeManager.ScaleRecipe(recipeChoice - 1, scaleFactor);
                        UI.DisplayRecipe(recipeManager.GetRecipe(recipeChoice - 1));
                        UI.NextPrompt();

                        break;

                    //Reset recipe scale factor to original.
                    case MenuOptions.ResetRecipeScale:

                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        recipeChoice = UI.GetMenuChoice(recipeManager.GetRecipeList().Count);
                        recipeManager.ResetRecipeScale(recipeChoice - 1);
                        UI.DisplayRecipe(recipeManager.GetRecipe(recipeChoice - 1));
                        UI.NextPrompt();

                        break;

                    //Display a Recipe
                    case MenuOptions.DisplayRecipe:

                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        recipeChoice = UI.GetMenuChoice(recipeManager.GetRecipeList().Count);
                        UI.DisplayRecipe(recipeManager.GetRecipe(recipeChoice - 1));
                        UI.NextPrompt();

                        break;

                    //Delete Recipe
                    case MenuOptions.DeleteRecipe:

                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        recipeChoice = UI.GetMenuChoice(recipeManager.GetRecipeList().Count);

                        if (UI.ConfirmDeleteRecipe())
                        {
                            recipeManager.DeleteRecipe(recipeChoice - 1);
                            UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        }

                        UI.NextPrompt();

                        break;

                    //Display Recipe List
                    case MenuOptions.DisplayRecipeList: 

                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        UI.NextPrompt();

                        break;

                    //Exit Application
                    case MenuOptions.Exit: 

                        isApplicationRunning = false;
                        UI.GoodbyeMessage();

                        break;

                    //Default response to any key pressed, that is not a menu option.
                    default:

                        UI.DisplayMenu();

                        break;
                }
                
            }

        }

        //END OF PROGRAM CLASS
        //-------------------------------------------------------------------------------------------------------------------------------------
    }
}
