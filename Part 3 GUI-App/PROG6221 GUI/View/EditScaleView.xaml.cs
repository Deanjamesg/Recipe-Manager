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
    /// Interaction logic for EditScaleView.xaml
    /// </summary>
    public partial class EditScaleView : Window
    {

        RecipeManager recipeManager;

        public EditScaleView(RecipeManager _recipeManager)
        {
            this.recipeManager = _recipeManager;
            string[] scaleOptions = { "", "0.5", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            InitializeComponent();
            cmbSelectScale.ItemsSource = scaleOptions;
            cmbSelectScale.SelectedIndex = 0;
            cmbSelectRecipe.ItemsSource = recipeManager.GetRecipeList();
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

        private void btnSubmitScale_Click(object sender, RoutedEventArgs e)
        {
            double scale = 1;
            int index = cmbSelectRecipe.SelectedIndex;

            if (!cmbSelectScale.SelectedValue.Equals(""))
            {
                scale = double.Parse(cmbSelectScale.SelectedValue.ToString());
                recipeManager.ScaleRecipe(index, scale);
                SuccessfulView successfulView = new SuccessfulView();
                successfulView.ShowDialog();
            }

            EditScaleView editScaleView = new EditScaleView(recipeManager);
            editScaleView.cmbSelectRecipe.SelectedIndex = index;
            editScaleView.Show();
            this.Close();

        }

        private void btnResetRecipe_Click(object sender, RoutedEventArgs e)
        {
            int index = cmbSelectRecipe.SelectedIndex;
            recipeManager.ResetRecipeScale(index);

            SuccessfulView successfulView = new SuccessfulView();
            successfulView.ShowDialog();

            EditScaleView editScaleView = new EditScaleView(recipeManager);
            editScaleView.cmbSelectRecipe.SelectedIndex = index;
            editScaleView.Show();
            this.Close();

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
    }
}
