using PROG6221_GUI.Model;
using PROG6221_GUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6221_GUI.Pages
{
    /// <summary>
    /// Interaction logic for CreateRecipePage.xaml
    /// </summary>
    public partial class CreateRecipePage : Page
    {
        public RecipeManager recipeManager;

        private Recipe newRecipe = new Recipe();

        public CreateRecipePage(RecipeManager _recipeManager)
        {
            InitializeComponent();

            recipeManager = _recipeManager;

            string[] ingredientOptions = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            string[] stepOptions = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };

            cmbNumberOfIngredients.ItemsSource = ingredientOptions;
            cmbNumberOfSteps.ItemsSource = stepOptions;

            cmbFoodGroup.ItemsSource = Enum.GetValues(typeof(FoodGroup)).Cast<FoodGroup>().Skip(1).ToArray();
            cmbFoodGroup.SelectedIndex = 0;

            cmbUnitOM.ItemsSource = Enum.GetValues(typeof(UnitOM));
            cmbUnitOM.SelectedIndex = 0;

            newRecipe = new Recipe();
        }

        private void btnGoIngredientsPrompt_Click(object sender, RoutedEventArgs e)
        {
            newRecipe.RecipeName = txtRecipeNameField.Text;

            txtRecipeName.Text = newRecipe.RecipeName;

            panelRecipeDetails.Visibility = Visibility.Hidden;
            panelIngredientDetails.Visibility = Visibility.Visible;
            txtRecipeName.Visibility = Visibility.Visible;
            txtIngredients.Visibility = Visibility.Visible;
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Check if all fields are filled

            if (!CheckEmptyFields()) return;

            // Check if a number was entered in the quantity field

            if (!CheckQuantityField()) return;

            // Check if a number was entered in the calories field

            if (!CheckCalorieField()) return;

            Ingredient newIngredient = new Ingredient();
            newIngredient.FoodGroup = (FoodGroup)cmbFoodGroup.SelectedValue;
            newIngredient.Name = txtIngredientName.Text;
            newIngredient.Quantity = double.Parse(txtQuantity.Text);
            newIngredient.UnitOfMeasurement = (UnitOM)cmbUnitOM.SelectedValue;
            newIngredient.Calories = double.Parse(txtCalories.Text);

            newRecipe.Ingredients.Add(newIngredient);
            lstIngredients.ItemsSource = recipeManager.IngredientCheckBoxFormat(newRecipe);
            ClearUIFields();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            OptionPopUpBox optionPopUpBox = new OptionPopUpBox("STOP creating this recipe?");

            var result = optionPopUpBox.ShowDialog();

            if (result.HasValue && result.Value)
            {
                PopUpBox popUpBox = new PopUpBox("You have stopped creating this recipe!");
                popUpBox.ShowDialog();

                ViewRecipePage viewRecipePage = new ViewRecipePage(recipeManager);
                NavigationService.Navigate(viewRecipePage);
            }
            else
            {
                PopUpBox popUpBox = new PopUpBox("You may continue creating this recipe!");
                popUpBox.ShowDialog();
            }

        }

        private void btnGoStepsPrompt_Click(object sender, RoutedEventArgs e)
        {
            txtSteps.Visibility = Visibility.Visible;
            panelIngredientDetails.Visibility = Visibility.Hidden;
            panelStepDetails.Visibility = Visibility.Visible;
        }

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            Step newStep = new Step();
            newStep.Description = txtStepDescription.Text;
            newRecipe.Steps.Add(newStep);
            lstSteps.ItemsSource = null;
            lstSteps.ItemsSource = newRecipe.Steps;
            txtStepDescription.Clear();

        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            recipeManager.AddNewRecipe(newRecipe);

            PopUpBox popUpBox = new PopUpBox("You have successfully created a new recipe!");
            popUpBox.ShowDialog();

            ViewRecipePage viewRecipePage = new ViewRecipePage(recipeManager);
            NavigationService.Navigate(viewRecipePage);
            viewRecipePage.cmbSelectRecipe.SelectedItem = newRecipe;

        }

        private void ClearUIFields()
        {
            txtIngredientName.Clear();
            txtQuantity.Clear();
            cmbFoodGroup.SelectedIndex = 0;
            cmbUnitOM.SelectedIndex = 0;
            txtCalories.Clear();

        }

        private bool CheckEmptyFields()
        {
            if (txtIngredientName.Text == "" || txtQuantity.Text == "" || txtCalories.Text == "")
            {
                PopUpBox popUpBox = new PopUpBox("Please fill in all fields!");
                popUpBox.ShowDialog();
                return false;
            }
            return true;
        }

        private bool CheckQuantityField()
        {
            if (!double.TryParse(txtQuantity.Text, out double quantity))
            {
                PopUpBox popUpBox = new PopUpBox("Please enter a number in the quantity field!");
                popUpBox.ShowDialog();
                return false;
            }
            return true;
        }

        private bool CheckCalorieField()
        {
            if (!double.TryParse(txtCalories.Text, out double calories))
            {
                PopUpBox popUpBox = new PopUpBox("Please enter a number in the calories field!");
                popUpBox.ShowDialog();
                return false;
            }
            return true;
        }
    }
}
