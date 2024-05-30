using PROG6221_POE.Classes;
using System;
// Link to GitHub Account
// https://github.com/Deanjamesg/PROG6221-POE

namespace PROG6221_POE
{
    class Program
    {
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

                switch (UI.GetMenuChoice())
                {
                    //Create a New Recipe
                    case 1:

                        Recipe recipe = UI.CreateNewRecipe();
                        recipeManager.AddNewRecipe(recipe);
                        UI.DisplayRecipe(recipe);
                        UI.NextPrompt();

                        break;

                    //Scale a Recipe.
                    case 2:

                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        recipeChoice = UI.GetMenuChoice();
                        double scaleFactor = UI.GetScaleFactor();
                        recipeManager.ScaleRecipe(recipeChoice - 1, scaleFactor);
                        UI.DisplayRecipe(recipeManager.GetRecipe(recipeChoice - 1));
                        UI.NextPrompt();

                        break;

                    //Reset recipe scale factor to original.
                    case 3:

                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        recipeChoice = UI.GetMenuChoice();
                        recipeManager.ResetRecipeScale(recipeChoice - 1);
                        UI.DisplayRecipe(recipeManager.GetRecipe(recipeChoice - 1));
                        UI.NextPrompt();

                        break;

                    //Display a Recipe
                    case 4:

                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        recipeChoice = UI.GetMenuChoice();
                        UI.DisplayRecipe(recipeManager.GetRecipe(recipeChoice - 1));
                        UI.NextPrompt();

                        break;

                    //Delete Recipe
                    case 5:

                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        recipeChoice = UI.GetMenuChoice();
                        recipeManager.DeleteRecipe(recipeChoice - 1);
                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        UI.NextPrompt();

                        break;

                    //Display Recipe List
                    case 6: 

                        UI.DisplayRecipeList(recipeManager.GetRecipeList());
                        UI.NextPrompt();

                        break;

                    //Exit Application
                    case 7: 

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
    }
}
