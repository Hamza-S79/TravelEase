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

namespace TravelEaseVS.MVVM.View
{
    /// <summary>
    /// Interaction logic for HotelForm.xaml
    /// </summary>
    public partial class HotelForm : UserControl
    {
        public HotelForm()
        {
            InitializeComponent();
        }

        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TravelEaseVS.OtherWindows.login loginWindow = new TravelEaseVS.OtherWindows.login();
            loginWindow.Show();

            // Optional: Close or hide current window if needed
            Window.GetWindow(this)?.Close();
        }


        private void loginLink_Click(object sender, MouseButtonEventArgs e)
        {
            TravelEaseVS.OtherWindows.login loginWindow = new TravelEaseVS.OtherWindows.login();
            loginWindow.Show();

            // Optional: Close or hide current window if needed
            Window.GetWindow(this)?.Close();
        }
    }
}
