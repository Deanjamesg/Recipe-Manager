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
    /// Interaction logic for SearchRecipePage.xaml
    /// </summary>
    public partial class SearchRecipePage : Page
    {
        public RecipeManager recipeManager;

        private MainWindow mainWindow;

        public SearchRecipePage(RecipeManager _recipeManager)
        {
            InitializeComponent();

            recipeManager = _recipeManager;

            mainWindow = (MainWindow)Application.Current.MainWindow;

            string[] calorieOptions = { "", "100", "200", "300", "400", "500", "750", "1000", "1250", "1500", "1750", "2000" };
            
            cmbSelectFoodGroup.ItemsSource = Enum.GetValues(typeof(FoodGroup));

            cmbSelectCalories.ItemsSource = calorieOptions;

            cmbSelectCalories.SelectedIndex = 0;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private void btnSubmitSearch_Click(object sender, RoutedEventArgs e)
        {
            string foodGroup = cmbSelectFoodGroup.SelectedValue.ToString();

            string ingredient = txtSearchIngredient.Text;

            double maxCalories = -1;

            if (!cmbSelectCalories.SelectedValue.Equals(""))
            {
                maxCalories = double.Parse(cmbSelectCalories.SelectedValue.ToString());
            }

            List<Recipe> filteredRecipes = recipeManager.FilteredRecipeSearch(foodGroup, ingredient, maxCalories);

            if (filteredRecipes == null || filteredRecipes.Count() == 0)
            {
                PopUpBox popUpBox = new PopUpBox("No recipes could be found!");

                popUpBox.ShowDialog();
            }
            else
            {
                lstFilteredRecipes.ItemsSource = filteredRecipes;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private void btnShowRecipe_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null)
            {
                Recipe recipe = button.DataContext as Recipe;

                if (recipe != null)
                {
                    ViewRecipePage viewRecipePage = new ViewRecipePage(recipeManager);

                    viewRecipePage.cmbSelectRecipe.SelectedItem = recipe;

                    mainWindow.MainFrame.Content = viewRecipePage;
                }
            }
        }

    }
    //END OF CLASS
    //-------------------------------------------------------------------------------------------------------------------------------------
}
