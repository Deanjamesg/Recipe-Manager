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
    /// Interaction logic for DeleteRecipePage.xaml
    /// </summary>
    public partial class DeleteRecipePage : Page
    {
        public RecipeManager recipeManager;

        private MainWindow mainWindow;
        public DeleteRecipePage(RecipeManager _recipeManager)
        {
            InitializeComponent();

            recipeManager = _recipeManager;

            mainWindow = (MainWindow)Application.Current.MainWindow;

            cmbSelectRecipe.ItemsSource = recipeManager.GetRecipeList();

            if (recipeManager.RecipeList.Count == 0)
            {
                btnDeleteSelectedRecipe.IsHitTestVisible = false;
            }

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

        private void btnDeleteSelectedRecipe_Click(object sender, RoutedEventArgs e)
        {
            int index = cmbSelectRecipe.SelectedIndex;

            OptionPopUpBox optionPopUpBox = new OptionPopUpBox("Are you sure you want to delete this recipe?");

            var result = optionPopUpBox.ShowDialog();

            if (result.HasValue && result.Value)
            {
                recipeManager.DeleteRecipe(index);

                PopUpBox popUpBox = new PopUpBox("Recipe was successfully deleted!");

                popUpBox.ShowDialog();

                DeleteRecipePage deleteRecipePage = new DeleteRecipePage(recipeManager);

                mainWindow.MainFrame.Content = deleteRecipePage;
            }
            else
            {
                PopUpBox popUpBox = new PopUpBox("Deleting of recipe was cancelled!");

                popUpBox.ShowDialog();
            }
        }

    }
}
