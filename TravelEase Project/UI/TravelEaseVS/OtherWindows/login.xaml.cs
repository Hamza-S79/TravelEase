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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace TravelEaseVS.OtherWindows
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        private int _usertype = 1; //1 for Traveler, 2 for Admin,  3 for Operator, 4 for Provider
        public int userType { get { return _usertype; } set { _usertype = value; } }
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
            string email = IdTextBox.Text;
            string password = PasswordBox.Password;

            SqlConnection conn = new SqlConnection("Data Source=HP\\SQLEXPRESS01;Initial Catalog=TravelEase;Integrated Security=True;");
            conn.Open();
            SqlCommand com;
            SqlDataReader reader;
            switch (userType)
            {
                case 1:
                    com = new SqlCommand("exec UserAuth \'" + email + "\',\'" + password + "\'", conn);
                    reader = com.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        MainWindow mainWindow = new MainWindow(Convert.ToInt32(reader[0]));
                        //MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();

                    }
                    else
                    {
                        // Login failed, show error text
                        ErrorTextBlock.Visibility = Visibility.Visible;
                    }

                    break;

                case 2:
                    if (email == "admin" && password == "123")
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        // Login failed, show error text
                        ErrorTextBlock.Visibility = Visibility.Visible;
                    }
                break;                
                case 3:
                    if (email == "saleem" && password == "123")
                    {
                        OpMainWindow OpWindow = new OpMainWindow(3);
                        OpWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        // Login failed, show error text
                        ErrorTextBlock.Visibility = Visibility.Visible;
                    }
                break;                
                case 4:
                    if (email == "nasir" && password == "123")
                    {
                        ProviderMainWindow pw = new ProviderMainWindow();
                        pw.Show();
                        this.Close();
                    }
                    else
                    {
                        // Login failed, show error text
                        ErrorTextBlock.Visibility = Visibility.Visible;
                    }
                break;

            }

            conn.Close();
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

                userType = _selectedUserRole[0] - 48;
                // Now you can use the '_selectedUserRole' variable
                // to adjust your login form or logic as needed.
            }
        }
    }
}
