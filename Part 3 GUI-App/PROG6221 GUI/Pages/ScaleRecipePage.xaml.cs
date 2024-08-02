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
using System.Xml.Linq;

namespace PROG6221_GUI.Pages
{
    /// <summary>
    /// Interaction logic for ScaleRecipePage.xaml
    /// </summary>
    public partial class ScaleRecipePage : Page
    {
        public RecipeManager recipeManager;

        private MainWindow mainWindow;

        public ScaleRecipePage(RecipeManager _recipeManager)
        {
            InitializeComponent();

            recipeManager = _recipeManager;

            mainWindow = (MainWindow)Application.Current.MainWindow;

            string[] scaleOptions = { "", "0,5", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            cmbSelectScale.ItemsSource = scaleOptions;

            cmbSelectScale.SelectedIndex = 0;

            cmbSelectRecipe.ItemsSource = recipeManager.GetRecipeList();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

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

        //-------------------------------------------------------------------------------------------------------------------------------------

        private void btnSubmitScale_Click(object sender, RoutedEventArgs e)
        {
            //double scale = 1;

            int index = cmbSelectRecipe.SelectedIndex;

            if (!cmbSelectScale.SelectedValue.Equals(""))
            {
                double scale = double.Parse(cmbSelectScale.SelectedValue.ToString());

                recipeManager.ScaleRecipe(index, scale);

                PopUpBox popUpBox = new PopUpBox("Recipe was successfully scaled!");

                popUpBox.ShowDialog();

                ScaleRecipePage scaleRecipePage = new ScaleRecipePage(recipeManager);

                scaleRecipePage.cmbSelectRecipe.SelectedIndex = index;

                mainWindow.MainFrame.Content = scaleRecipePage;
            }
            else
            {
                PopUpBox popUpBox = new PopUpBox("Please select a scale value!");

                popUpBox.ShowDialog();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private void btnResetRecipe_Click(object sender, RoutedEventArgs e)
        {
            int index = cmbSelectRecipe.SelectedIndex;

            recipeManager.ResetRecipeScale(index);

            PopUpBox popUpBox = new PopUpBox("Recipe was reset to its original quantities!");

            popUpBox.ShowDialog();

            ScaleRecipePage scaleRecipePage = new ScaleRecipePage(recipeManager);

            scaleRecipePage.cmbSelectRecipe.SelectedIndex = index;

            mainWindow.MainFrame.Content = scaleRecipePage;
        }
    }
    //END OF CLASS
    //-------------------------------------------------------------------------------------------------------------------------------------
}
