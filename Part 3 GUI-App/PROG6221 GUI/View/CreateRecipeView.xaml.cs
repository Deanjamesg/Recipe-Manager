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
using PROG6221_GUI.Model;

namespace PROG6221_GUI.View
{
    /// <summary>
    /// Interaction logic for CreateRecipeView.xaml
    /// </summary>
    public partial class CreateRecipeView : Window
    {
        RecipeManager recipeManager;
        public Recipe recipe { get; set; }

        public CreateRecipeView(RecipeManager _recipeManager)
        {
            this.recipeManager = _recipeManager;
            InitializeComponent();
            string[] ingredientOptions = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            string[] stepOptions = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            cmbNumberOfIngredients.ItemsSource = ingredientOptions;
            cmbNumberOfSteps.ItemsSource = stepOptions;
            recipe = new Recipe();
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

        private void btnSearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            SearchRecipeView searchRecipeView = new SearchRecipeView(recipeManager);
            searchRecipeView.Show();
            this.Close();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            //recipe.RecipeName = txtRecipeNameField.Text;
            //int numberOfIngredients = int.Parse(cmbNumberOfIngredients.SelectedValue.ToString());
            //int numberOfSteps = int.Parse(cmbNumberOfSteps.SelectedValue.ToString());

            //AddIngredientView addIngredientView = new AddIngredientView(recipeManager, recipe, numberOfIngredients, numberOfSteps);
            //addIngredientView.Show();
            //this.Close();

            Recipe selectedRecipe = recipeManager.GetRecipe(1);
            
            txtRecipeName.Text = selectedRecipe.RecipeName;
            lstIngredients.ItemsSource = recipeManager.IngredientCheckBoxFormat(selectedRecipe);
            lstSteps.ItemsSource = selectedRecipe.Steps;

            cmbNumberOfIngredients.Visibility = Visibility.Collapsed;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelView cancelView = new CancelView();
            cancelView.ShowDialog();
            recipe = new Recipe();

            RecipeView recipeView = new RecipeView(recipeManager);
            recipeView.Show();
            this.Close();

        }

    }
}
