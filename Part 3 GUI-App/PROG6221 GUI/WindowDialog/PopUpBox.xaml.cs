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
    /// Interaction logic for PopUpBox.xaml
    /// </summary>
    public partial class PopUpBox : Window
    {
        public PopUpBox(string message)
        {
            InitializeComponent();
            AlertString.Text = message;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
