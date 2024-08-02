using PROG6221_GUI.Model;
using PROG6221_GUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private Recipe newRecipe;

        private MainWindow mainWindow;

        private string instructions;

        public CreateRecipePage(RecipeManager _recipeManager)
        {
            InitializeComponent();

            recipeManager = _recipeManager;

            mainWindow = (MainWindow)Application.Current.MainWindow;

            newRecipe = new Recipe();

            cmbFoodGroup.ItemsSource = Enum.GetValues(typeof(FoodGroup)).Cast<FoodGroup>().Skip(1).ToArray();

            cmbFoodGroup.SelectedIndex = 0;

            cmbUnitOM.ItemsSource = Enum.GetValues(typeof(UnitOM));

            cmbUnitOM.SelectedIndex = 0;

            instructions =
                "1) Enter a name for the recipe. " +
                "\n2) Click 'Next' to add ingredients. " +
                "\n3) Enter the ingredient details and click 'Add Ingredient'. " +
                "\n4) When you are done adding ingredients, click 'Next' to add steps. " +
                "\n5) Enter the step details and click 'Add Step'. " +
                "\n6) When you are happy with everything click 'Done' to save the recipe! " +
                "\n7) To cancel the recipe click 'Cancel' at anytime.";

            txtRecipeName.Text = "Instructions";

            txtIngredients.Text = instructions;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        private void btnGoIngredientsPrompt_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckRecipeNameField()) return;

            newRecipe.RecipeName = txtRecipeNameField.Text;

            txtRecipeName.Text = newRecipe.RecipeName;

            txtIngredients.Text = "Ingredients";

            panelRecipeDetails.Visibility = Visibility.Hidden;

            panelIngredientDetails.Visibility = Visibility.Visible;

            txtRecipeName.Visibility = Visibility.Visible;

            txtIngredients.Visibility = Visibility.Visible;

            lstIngredients.Visibility = Visibility.Visible;

            mainWindow.UnsavedData = true;

        }

        //-------------------------------------------------------------------------------------------------------------------------------------


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

            newIngredient.Quantity = NormalizeQuantityField(txtQuantity.Text);

            newIngredient.UnitOfMeasurement = (UnitOM)cmbUnitOM.SelectedValue;

            newIngredient.Calories = double.Parse(txtCalories.Text);

            newRecipe.Ingredients.Add(newIngredient);

            lstIngredients.ItemsSource = recipeManager.IngredientCheckBoxFormat(newRecipe);

            ClearUIFields();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            OptionPopUpBox optionPopUpBox = new OptionPopUpBox("Are you sure you want to cancel this recipe?");

            var result = optionPopUpBox.ShowDialog();

            if (result.HasValue && result.Value)
            {
                PopUpBox popUpBox = new PopUpBox("This recipe has been cancelled!");

                popUpBox.ShowDialog();

                ViewRecipePage viewRecipePage = new ViewRecipePage(recipeManager);

                mainWindow.MainFrame.Content = viewRecipePage;

                mainWindow.UnsavedData = false;
            }
            else
            {
                PopUpBox popUpBox = new PopUpBox("Continue with the recipe!");

                popUpBox.ShowDialog();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        private void btnGoStepsPrompt_Click(object sender, RoutedEventArgs e)
        {
            txtSteps.Visibility = Visibility.Visible;

            panelIngredientDetails.Visibility = Visibility.Hidden;

            panelStepDetails.Visibility = Visibility.Visible;

            lstSteps.Visibility = Visibility.Visible;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStepDescription.Text))
            {
                PopUpBox popUpBox = new PopUpBox("Please fill in all fields!");

                popUpBox.ShowDialog();

                return;
            }

            Step newStep = new Step();

            newStep.Description = txtStepDescription.Text;

            newRecipe.Steps.Add(newStep);

            lstSteps.ItemsSource = null;

            lstSteps.ItemsSource = newRecipe.Steps;

            txtStepDescription.Clear();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            recipeManager.AddNewRecipe(newRecipe);

            mainWindow.UnsavedData = false;

            PopUpBox popUpBox = new PopUpBox("You have successfully created a new recipe!");

            popUpBox.ShowDialog();

            ViewRecipePage viewRecipePage = new ViewRecipePage(recipeManager);
            
            viewRecipePage.cmbSelectRecipe.SelectedItem = newRecipe;

            mainWindow.MainFrame.Content = viewRecipePage;

        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        private void ClearUIFields()
        {
            txtIngredientName.Clear();

            txtQuantity.Clear();

            cmbFoodGroup.SelectedIndex = 0;

            cmbUnitOM.SelectedIndex = 0;

            txtCalories.Clear();

        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        private bool CheckEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(txtIngredientName.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtCalories.Text))
            {
                PopUpBox popUpBox = new PopUpBox("Please fill in all fields!");

                popUpBox.ShowDialog();

                return false;
            }
            return true;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        private bool CheckQuantityField()
        {
            string target = txtQuantity.Text;

            int count = 0;
 
            foreach (char c in target)
            {
                if (c == ',' || c == '.' || c == '/')
                {
                    count++;
                }
                if (!char.IsDigit(c) && c != ',' && c != '.' && c != '/' || count == 2)
                {
                    PopUpBox popUpBox = new PopUpBox("Please enter a valid Quantity! \nEg: 0.5 or 0,5 or 1/2");

                    popUpBox.ShowDialog();
                    return false;
                }
            }
            return true;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private bool CheckCalorieField()
        {
            string target = txtCalories.Text;

            foreach (char c in target)
            {
                if (!char.IsDigit(c) )
                {
                    PopUpBox popUpBox = new PopUpBox("Please enter a whole number for Calories!");

                    popUpBox.ShowDialog();
                    return false;
                }
            }
            return true;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        private bool CheckRecipeNameField()
        {
            if (string.IsNullOrWhiteSpace(txtRecipeNameField.Text))
            {
                PopUpBox popUpBox = new PopUpBox("Please enter a recipe name!");

                popUpBox.ShowDialog();

                return false;
            }
            return true;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private void btnBackToIngredientsPrompt_Click(object sender, RoutedEventArgs e)
        {
            panelStepDetails.Visibility = Visibility.Hidden;

            panelIngredientDetails.Visibility = Visibility.Visible;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private double NormalizeQuantityField(string number)
        {
            char[] charArr = { '/', '.' };

            string[] splitArr;

            double result = 0;

            if (number.Contains("."))
            {
                number = number.Replace(".", ",");

                result = double.Parse(number);
            }

            else if (number.Contains("/"))
            {
                splitArr = number.Split(charArr);

                result = double.Parse(splitArr[0]) / double.Parse(splitArr[1]);
            }
            else
            {
                result = double.Parse(number);
            }
            return result;
        }

    }
    //END OF CLASS
    //-------------------------------------------------------------------------------------------------------------------------------------
}
