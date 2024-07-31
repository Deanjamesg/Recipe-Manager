using PROG6221_GUI.Model;
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
    /// Interaction logic for ViewRecipePage.xaml
    /// </summary>
    public partial class ViewRecipePage : Page
    {
        public RecipeManager recipeManager;
        public ViewRecipePage(RecipeManager _recipeManager)
        {
            InitializeComponent();

            recipeManager = _recipeManager;

            cmbSelectRecipe.ItemsSource = recipeManager.GetRecipeList();
        }
        private void cmbRecipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)cmbSelectRecipe.SelectedItem;
            if (selectedRecipe != null)
            {
                txtRecipeName.Text = selectedRecipe.RecipeName;
                lstIngredients.ItemsSource = recipeManager.IngredientCheckBoxFormat(selectedRecipe);
                lstSteps.ItemsSource = selectedRecipe.Steps;
                lblTotalCalories.Content = "Total Calories: " + recipeManager.CalculateTotalCalories(selectedRecipe).ToString();
            }
        }

        private void btnSearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            SearchRecipePage searchRecipePage = new SearchRecipePage(recipeManager);
            NavigationService.Navigate(searchRecipePage);
        }
    }
}
