# PROG6221-POE
Programming Project 1st Semester 2nd Year (Varsity College) - ST10378305

Student number: ST10378305
Student name: Dean James Greeff

Recipe Application

This is a console-based Recipe Application written in C#. The application allows users to create, display, scale, reset the scale of, and delete recipes. Each recipe consists of a name, a list of ingredients, and a list of steps. Each ingredient has a name, quantity, unit of measurement, food group, and calorie count.

Lecturer Feedback Fixes:
- Added references
- Fixed error handling
- Units of measurements change accordingly, accurately
- Split classes into seperate files
- Added end-of-file in classes

Classes:

Program.cs
- This is the entry point of the application. It contains the Main method which controls the flow of the application. It uses a while loop to continuously display a menu to the user until they choose to exit. The menu options are handled using a switch statement.

Ingredient.cs
- This class represents an ingredient in a recipe. It has properties for the name, quantity, unit of measurement, food group, and calories of the ingredient. It also includes methods to set and reset the original values of these properties.

Step.cs
- This class represents a step in a recipe. It has a single property (string) for the description of the step.

Recipe.cs
- This class represents a recipe. It has properties for the scale factor, recipe name, list of <steps>, list of <ingredients>, and total calories of the recipe.

RecipeManager.cs
- This class manages a list of recipes. It includes methods to add a new recipe, delete a recipe, scale a recipe, reset the scale of a recipe, get a recipe, get the list of recipes, calculate the total calories of a recipe, and normalize the quantities of the ingredients in a recipe.

UI.cs
- This class handles all user interaction. It includes methods to display messages and prompts to the user, get input from the user, and display recipes and lists of recipes.

Flow of Logic
- The application starts in the Main method of the Program class. It creates a RecipeManager object to manage the recipes and a UI object to handle user interaction.
- The application then enters a while loop which continues until the user chooses to exit. In each iteration of the loop, the application displays a menu to the user and gets their choice. Depending on the user's choice, the application may prompt the user for more information, perform an action (such as creating or scaling a recipe), and display the result to the user.
- The RecipeManager class is responsible for managing the list of recipes. It includes methods to add, delete, scale, and reset recipes, as well as to calculate the total calories of a recipe and normalize the quantities of its ingredients.
- The UI class is responsible for all user interaction. It includes methods to display messages and prompts to the user, get input from the user, and display recipes and lists of recipes.
- The Ingredient, Step, and Recipe classes represent the ingredients, steps, and recipes in the application. Each of these classes includes properties for its data and methods to manipulate this data.

##References:
1. https://www.w3schools.com/cs/cs_enums.php
2. https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
3. https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in
4. https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removeat?view=net-6.0
5. https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-8.0
6. https://www.w3schools.com/cs/cs_while_loop.php
7. https://learn.microsoft.com/en-us/dotnet/api/system.enum.getvalues?view=net-8.0
