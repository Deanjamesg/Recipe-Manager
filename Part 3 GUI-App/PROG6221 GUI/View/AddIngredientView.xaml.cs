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
    /// Interaction logic for AddIngredientView.xaml
    /// </summary>
    public partial class AddIngredientView : Window
    {
        public RecipeManager recipeManager;
        public Recipe recipe { get; set; }
        public AddIngredientView(RecipeManager _recipeManager, Recipe _recipe, int numberOfIngredients, int numberOfSteps)
        {
            this.recipeManager = _recipeManager;
            this.recipe = _recipe;
            InitializeComponent();

            cmbFoodGroup.ItemsSource = Enum.GetValues(typeof(FoodGroup));
            cmbFoodGroup.SelectedIndex = 0;
            cmbUnitOM.ItemsSource = Enum.GetValues(typeof(UnitOM));
            cmbUnitOM.SelectedIndex = 0;
        }

        private void btnViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            RecipeView recipeView = new RecipeView(recipeManager);
            recipeView.Show();
            this.Close();

        }
        private void btnSearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            SearchRecipeView searchRecipeView = new SearchRecipeView(recipeManager);
            searchRecipeView.Show();
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
    }
}
