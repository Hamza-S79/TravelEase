﻿using System;
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
using TravelEaseVS.MVVM;
using TravelEaseVS.MVVM.ViewModel;
using TravelEaseVS.OtherWindows;
namespace TravelEaseVS
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        private void Go_to_login(object sender, RoutedEventArgs e)
        {
            login lw = new login();
            lw.Show();

            // Optional: Close or hide current window if needed
            Window.GetWindow(this)?.Close();
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

