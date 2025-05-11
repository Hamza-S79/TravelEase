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
using System.Security.Cryptography;
using System.Data.SqlClient;


namespace TravelEaseVS.OtherWindows
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        private string _selectedUserRole = ""; // To store the selected role
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
            password = ComputeSha256Hash(password);

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OPQ91FU\\SQLEXPRESS; Initial Catalog = TravelEase; Integrated Security=True");

                using (conn)
                {
                    conn.Open();
                    //Todo: Implement the interface logic for each case
                    SqlCommand verifycmd;
                    switch (_selectedUserRole)
                    {
                        case "Admin":
                            if (id == "admin" && password == ComputeSha256Hash("123"))
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

                            break;

                        case "Traveler":

                            verifycmd = new SqlCommand("SELECT count(user_id) FROM App_User WHERE user_id =  @USER AND password=@PASS", conn);
                            verifycmd.Parameters.AddWithValue("@USER", id);
                            verifycmd.Parameters.AddWithValue("@PASS", password);
                            if ((int)verifycmd.ExecuteScalar() == 1)
                            {
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                                this.Close();
                            }
                            else
                            {
                                ErrorTextBlock.Visibility = Visibility.Visible;
                            }

                            break;

                        case "Trip Operator":
                            verifycmd = new SqlCommand("SELECT count(operator_id) FROM Trip_Operator WHERE operator_id =  @OP AND password = @PASS", conn);
                            verifycmd.Parameters.AddWithValue("@OP", id);
                            verifycmd.Parameters.AddWithValue("@PASS", password);
                            if ((int)verifycmd.ExecuteScalar() == 1)
                            {
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                                this.Close();
                            }
                            else
                            {
                                ErrorTextBlock.Visibility = Visibility.Visible;
                            }
                            break;

                        case "Service Provider":
                            verifycmd = new SqlCommand("SELECT count(hotel_id) FROM Hotel_Provider WHERE hotel_id =  @USER AND password = @PASS", conn);
                            verifycmd.Parameters.AddWithValue("@USER", id);
                            verifycmd.Parameters.AddWithValue("@PASS", password);
                            if ((int)verifycmd.ExecuteScalar() == 1)
                            {
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                                this.Close();
                            }
                            else
                            {
                                ErrorTextBlock.Visibility = Visibility.Visible;
                            }
                           
                            break;
                        default:
                            break;
                    }
                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Database Error", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //calculating the hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // format as hex
                }
                return builder.ToString();
            }
        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


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
