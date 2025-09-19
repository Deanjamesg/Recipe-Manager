# C# Programming Project - Recipe Manager 

PROG6221 - Portfolio of Evidence  
Programming 2A  
ST10378305    
Dean James Greeff  

## Recipe Manager Application

This is a Recipe Manager Application written in C#. This application allows users to create, display, scale, reset the scale of, and delete recipes. Each recipe consists of a name, a list of ingredients, and a list of steps. Each ingredient has a name, quantity, unit of measurement, food group, and calorie count.

## Project's Classes & Custom Types

**Program**
- This is the entry point of the application. It contains the Main method which controls the flow of the application. It uses a while loop to continuously display a menu to the user until they choose to exit. The menu options are handled using a switch statement.

**Ingredient**
- This class represents an ingredient in a recipe. It has properties for the name, quantity, unit of measurement, food group, and calories of the ingredient. It also includes methods to set and reset the original values of these properties.

**Step**
- This class represents a step in a recipe. It has a single property (string) for the description of the step.

**Recipe**
- This class represents a recipe. It has properties for the scale factor, recipe name, list of <steps>, list of <ingredients>, and total calories of the recipe.

**RecipeManager**
- This class manages a list of recipes. It includes methods to add a new recipe, delete a recipe, scale a recipe, reset the scale of a recipe, get a recipe, get the list of recipes, calculate the total calories of a recipe, and normalize the quantities of the ingredients in a recipe.

**UI**
- This class handles all user interaction. It includes methods to display messages and prompts to the user, get input from the user, and display recipes and lists of recipes.  

## Project Logic
- The application starts in the Main method of the Program class. It creates a RecipeManager object to manage the recipes and a UI object to handle user interaction.  
- The application then enters a while loop which continues until the user chooses to exit. In each iteration of the loop, the application displays a menu to the user and gets their choice. Depending on the user's choice, the application may prompt the user for more information, perform an action (such as creating or scaling a recipe), and display the result to the user.  
- The RecipeManager class is responsible for managing the list of recipes. It includes methods to add, delete, scale, and reset recipes, as well as to calculate the total calories of a recipe and normalize the quantities of its ingredients.  
- The UI class is responsible for all user interaction. It includes methods to display messages and prompts to the user, get input from the user, and display recipes and lists of recipes.  
- The Ingredient, Step, and Recipe classes represent the ingredients, steps, and recipes in the application. Each of these classes includes properties for its data and methods to manipulate this data.  
