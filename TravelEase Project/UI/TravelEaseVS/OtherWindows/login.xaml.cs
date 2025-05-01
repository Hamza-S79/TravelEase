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

namespace TravelEaseVS.OtherWindows
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void SignUpLink_Click(object sender, MouseButtonEventArgs e)
        {
            signup signUpWindow = new signup();
            signUpWindow.Show();

            // Optional: Close or hide current window if needed
            Window.GetWindow(this)?.Close();
        }



        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordPlaceholder.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = IdTextBox.Text;
            string password = PasswordBox.Password;

            if (id == "admin" && password == "123")
            {

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();

            }
            else
            {
                // Login failed, show error text
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private string _selectedUserRole; // To store the selected role

        private void UserTypeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.IsChecked == true)
            {
                _selectedUserRole = radioButton.Tag.ToString();
                Console.WriteLine($"Selected Role: {_selectedUserRole}");
                // Now you can use the '_selectedUserRole' variable
                // to adjust your login form or logic as needed.
            }
        }
    }
}
