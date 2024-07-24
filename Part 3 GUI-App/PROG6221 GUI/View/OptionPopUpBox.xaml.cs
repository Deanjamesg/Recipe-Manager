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
    /// Interaction logic for OptionPopUpBox.xaml
    /// </summary>
    public partial class OptionPopUpBox : Window
    {
        public OptionPopUpBox(string _Task)
        {
            InitializeComponent();
            OptionDialog.Text = "Are you sure you want to " + @_Task;
        }
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
