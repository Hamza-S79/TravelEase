using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TravelEaseVS.MVVM.ViewModel;
using TravelEaseVS.Core;
namespace TravelEaseVS.MVVM.View.Announced_Trip_Pages
{
    /// <summary>
    /// Interaction logic for TripsList.xaml
    /// </summary>
    /// 


    public partial class TripsList : Page 
    {
        public Frame parentFrame;
        int selected_id = 0;
        string search_st = "";
        RelayCommand nav;
        
        public TripsList(Frame pF)
        {
            InitializeComponent();
            parentFrame = pF;
        }


        public void NavToTripDetail(object sender, RoutedEventArgs e)
        {
            Button sen = sender as Button;

            
            selected_id = (int)sen.Tag;

            parentFrame.Navigate(new TripDetails(parentFrame,selected_id));
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

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
