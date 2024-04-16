# PROG6221-POE
Programming Project 1st Semester 2nd Year (Varsity College) - ST10378305

Student number: ST10378305
Student name: Dean James Greeff

Overview
This repository contains a recipe application implemented in C#. The application allows users to create, scale, display, reset, and delete recipes.

Classes:
- Program.cs
The Program class is the entry point of the application. It contains the main method Main() which presents a menu to the user and handles user interactions. It provides options to create a new recipe, scale a recipe, reset scale to original, display recipe, delete recipe, and exit the application.

- Recipe.cs
The Recipe class represents a recipe. It contains properties for scaleFactor, recipeName, steps, ingredients, and exists. This class encapsulates methods for creating a new recipe, scaling a recipe, displaying a recipe, normalizing quantities of ingredients, validating units of measurement, resetting scale to original, and deleting a recipe.

- Ingredients.cs
The Ingredients class represents an ingredient of a recipe. It contains properties for name, quantity, and measurement.

Methods:
- CreateNewRecipe():
Creates a new recipe by collecting details such as name, ingredients, and steps.

- ScaleRecipe():
Scales the existing recipe by a specified factor.

- DisplayRecipe():
Displays the current recipe, including its name, ingredients, and steps.

- NormalizeQuantities(Ingredients _ingredient):
Normalizes the quantities of ingredients by converting them to a more appropriate unit of measurement.

- ValidateUnitOfMeasurement(Ingredients _ingredient):
Validates the unit of measurement entered by the user for an ingredient.

- ResetScale():
Resets the scale of the recipe, reverting ingredient quantities to their original values.

- DeleteRecipe():
Deletes the current recipe if it exists.
