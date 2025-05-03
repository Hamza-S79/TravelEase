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
    /// Interaction logic for OperatorForm.xaml
    /// </summary>
    public partial class OperatorForm : UserControl
    {
        public OperatorForm()
        {
            InitializeComponent();
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


        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CorporateAccountRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Disable First Name, Last Name, and Age Textboxes
            FirstNameTextBox.IsEnabled = false;
            LastNameTextBox.IsEnabled = false;
            AgeTextBox.IsEnabled = false;


            // Enable Company Name TextBox
            CompanyNameTextBox.IsEnabled = true;
        }

        private void PersonalAccountRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Enable First Name, Last Name, and Age Textboxes
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            AgeTextBox.IsEnabled = true;

            // Disable Company Name TextBox
            CompanyNameTextBox.IsEnabled = false;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Ensure that the correct textboxes are disabled/enabled based on the selected radio button
            if (CorporateAccountRadioButton.IsChecked == true)
            {
                CorporateAccountRadioButton_Checked(null, null);
            }
            else if (PersonalAccountRadioButton.IsChecked == true)
            {
                PersonalAccountRadioButton_Checked(null, null);
            }
        }


    }
}
