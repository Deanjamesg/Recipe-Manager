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
using System.Windows.Shapes;

namespace PROG6221_GUI.View
{
    /// <summary>
    /// Interaction logic for SearchRecipeView.xaml
    /// </summary>
    public partial class SearchRecipeView : Window
    {
        public RecipeManager recipeManager;
        public SearchRecipeView(RecipeManager _recipeManager)
        {
            this.recipeManager = _recipeManager;
            string[] calorieOptions = { "", "100", "200", "300", "400", "500", "750", "1000", "1250", "1500", "1750", "2000" };
            InitializeComponent();
            cmbSelectFoodGroup.ItemsSource = Enum.GetValues(typeof(FoodGroup));
            cmbSelectCalories.ItemsSource = calorieOptions;
            cmbSelectCalories.SelectedIndex = 0;

        }

        private void btnViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            RecipeView recipeView = new RecipeView(recipeManager);
            recipeView.Show();
            this.Close();

        }

        private void btnCreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            CreateRecipeView createRecipeView = new CreateRecipeView(recipeManager);
            createRecipeView.Show();
            this.Close();
        }

        private void btnEditScale_Click(object sender, RoutedEventArgs e)
        {
            EditScaleView editScaleView = new EditScaleView(recipeManager);
            editScaleView.Show();
            this.Close();
        }

        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecipeView deleteRecipeView = new DeleteRecipeView(recipeManager);
            deleteRecipeView.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            this.Close();
        }

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

            if (filteredRecipes == null)
            {
                CancelView cancelView = new CancelView();
                cancelView.ShowDialog();
            }
            else
            {
                lstFilteredRecipes.ItemsSource = filteredRecipes;
            }
        }

        private void btnShowRecipe_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                Recipe recipe = button.DataContext as Recipe;
                if (recipe != null)
                {
                    RecipeView recipeView = new RecipeView(recipeManager);
                    recipeView.cmbSelectRecipe.SelectedItem = recipe;
                    recipeView.Show();
                    this.Close();
                }
            }
        }

        private void btnSearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            SearchRecipeView searchRecipeView = new SearchRecipeView(recipeManager);
            searchRecipeView.Show();
            this.Close();
        }

    }
}
