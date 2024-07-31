using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using PROG6221_GUI.Model;
using PROG6221_GUI.View;
using PROG6221_GUI;
using PROG6221_GUI.Pages;

namespace PROG6221_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RecipeManager recipeManager;

        public MainWindow()
        {
            InitializeComponent();

            recipeManager = new RecipeManager();

            recipeManager.StartRecipeProgram();

            HomePage homePage = new HomePage(recipeManager);
            MainFrame.Content = homePage;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            //RecipeView recipeView = new RecipeView(recipeManager);
            //recipeView.Show();
            //this.Close();

            ViewRecipePage viewRecipePage = new ViewRecipePage(recipeManager);
            MainFrame.Content = viewRecipePage;

        }

        private void btnCreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            //CreateRecipeView createRecipeView = new CreateRecipeView(recipeManager);
            //createRecipeView.Show();
            //this.Close();
            CreateRecipePage createRecipePage = new CreateRecipePage(recipeManager);
            MainFrame.Content = createRecipePage;
        }

        private void btnEditScale_Click(object sender, RoutedEventArgs e)
        {
            //EditScaleView editScaleView = new EditScaleView(recipeManager);
            //editScaleView.Show();
            //this.Close();
            ScaleRecipePage scaleRecipePage = new ScaleRecipePage(recipeManager);
            MainFrame.Content = scaleRecipePage;
        }

        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            //DeleteRecipeView deleteRecipeView = new DeleteRecipeView(recipeManager);
            //deleteRecipeView.Show();
            //this.Close();
            DeleteRecipePage deleteRecipePage = new DeleteRecipePage(recipeManager);
            MainFrame.Content = deleteRecipePage;
        }

        private void btnSearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            //SearchRecipeView searchRecipeView = new SearchRecipeView(recipeManager);
            //searchRecipeView.Show();
            //this.Close();
            SearchRecipePage searchRecipePage = new SearchRecipePage(recipeManager);
            MainFrame.Content = searchRecipePage;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            this.Close();
        }
    }
}
