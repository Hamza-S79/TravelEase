using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TravelEaseVS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();




        }
        private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }




        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear the text when user clicks on the textbox
            if (SearchBox.Text == "Search...")
            {
                SearchBox.Text = string.Empty;
                SearchBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black); // Change text color to black when typing
            }
        }

        // Event handler for LostFocus
        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Revert to placeholder if the textbox is empty
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                SearchBox.Text = "Search...";
                SearchBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray); // Placeholder color
            }
        }

    }
}