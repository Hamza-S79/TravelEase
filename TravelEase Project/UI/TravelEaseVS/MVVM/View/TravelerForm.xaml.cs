using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Security.Cryptography;

namespace TravelEaseVS.MVVM.View
{
    /// <summary>
    /// Interaction logic for TravelerForm.xaml
    /// </summary>
    public partial class TravelerForm : UserControl
    {
        public TravelerForm()
        {
            InitializeComponent();

            CorporateAccountRadioButton.Checked += CorporateAccountRadioButton_Checked;
            PersonalAccountRadioButton.Checked += PersonalAccountRadioButton_Checked;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            string nationality = NationalityTextBox.Text;
            int age = int.Parse(AgeTextBox.Text);
            string companyName = CompanyNameTextBox.Text;
            string contact = ContactTextBox.Text;

            int newUserId;

            // if any field is empty
            
            if (CorporateAccountRadioButton.IsChecked == false && string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
              string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
              string.IsNullOrWhiteSpace(nationality) || age == 0 ||
              string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (PersonalAccountRadioButton.IsChecked == false &&
                string.IsNullOrWhiteSpace(companyName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || 
                string.IsNullOrWhiteSpace(nationality))
            {
                
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
                
            }

            password = ComputeSha256Hash(password); //adding the hash

            //connect to sql                      
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OPQ91FU\\SQLEXPRESS; Initial Catalog = TravelEase; Integrated Security=True");
                                                    
            using (conn)
            {
                conn.Open();

                //get next id
                SqlCommand getMaxIdCmd = new SqlCommand("SELECT ISNULL(MAX(user_id),0) + 1 FROM App_User", conn);
                newUserId = (int)getMaxIdCmd.ExecuteScalar();
                
                // 2. Insert into App_User
                SqlCommand insertUserCmd = new SqlCommand(
                    "INSERT INTO App_User (user_id, email, joined_date, password, nationality) " +
                    "VALUES (@user_id, @email, GETDATE(), @password, @nationality)", conn);
                insertUserCmd.Parameters.AddWithValue("@user_id", newUserId);
                insertUserCmd.Parameters.AddWithValue("@email", email);
                insertUserCmd.Parameters.AddWithValue("@password", password);
                insertUserCmd.Parameters.AddWithValue("@nationality", nationality);
                insertUserCmd.ExecuteNonQuery();

                // 3. Insert into either User_Person or User_Corporate
                if (string.IsNullOrWhiteSpace(companyName))
                {
                    SqlCommand insertPersonCmd = new SqlCommand(
                        "INSERT INTO User_Person (user_id, first_name, last_name, age, contact) " +
                        "VALUES (@user_id, @first_name, @last_name, @age, @contact)", conn);
                    insertPersonCmd.Parameters.AddWithValue("@user_id", newUserId);
                    insertPersonCmd.Parameters.AddWithValue("@first_name", firstName);
                    insertPersonCmd.Parameters.AddWithValue("@last_name", lastName);
                    insertPersonCmd.Parameters.AddWithValue("@age", age);
                    insertPersonCmd.Parameters.AddWithValue("@contact", contact);
                    insertPersonCmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand insertCorpCmd = new SqlCommand(
                        "INSERT INTO User_Corporate (user_id, company_name) " +
                        "VALUES (@user_id, @company_name)", conn);
                    insertCorpCmd.Parameters.AddWithValue("@user_id", newUserId);
                    insertCorpCmd.Parameters.AddWithValue("@company_name", companyName);
                    insertCorpCmd.ExecuteNonQuery();
                }

                conn.Close();

            }

            TravelEaseVS.OtherWindows.login loginWindow = new TravelEaseVS.OtherWindows.login();
            loginWindow.Show();

            // Optional: Close or hide current window if needed
            Window.GetWindow(this)?.Close();
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
