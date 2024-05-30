using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PROG6221_POE.Classes;
using PROG6221_POE;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        RecipeManager recipeManager1 = new RecipeManager();

        [TestMethod]
        public void CalculateTotalCalories_ShouldReturnCorrectTotal()
        {
            // Arrange
            Recipe recipe = new Recipe
            {
                RecipeName = "Scrambled Eggs",
                ScaleFactor = 1,
                Ingredients = new List<Ingredient>
                {
                     new Ingredient { Quantity = 2, Calories = 136 },
                     new Ingredient { Quantity = 1,  Calories = 102 }
                },
                Steps = new List<Step>
                {
                     new Step { Description = "Beat eggs" },
                     new Step { Description = "Cook in butter on low heat" }
                }
            };
            RecipeManager recipeManager = new RecipeManager();

            // Act
            double totalCalories = recipeManager.CalculateTotalCalories(recipe);

            // Assert
            Assert.AreEqual(238, totalCalories);
        }
    }
}
