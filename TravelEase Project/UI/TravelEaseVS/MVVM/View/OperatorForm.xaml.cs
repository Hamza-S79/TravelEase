using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TravelEaseVS.MVVM.View
{
    public partial class OperatorForm : UserControl
    {
        public OperatorForm()
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
            string companyName = CompanyNameTextBox.Text;
            string contact = ContactTextBox.Text;
            int age = 0;

            // Try to parse age if it's not empty
            if (!string.IsNullOrWhiteSpace(AgeTextBox.Text))
            {
                if (!int.TryParse(AgeTextBox.Text, out age))
                {
                    MessageBox.Show("Please enter a valid age.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            int newOperatorId;

            // Validation for personal account
            if (PersonalAccountRadioButton.IsChecked == true &&
                (string.IsNullOrWhiteSpace(firstName) ||
                 string.IsNullOrWhiteSpace(lastName) ||
                 string.IsNullOrWhiteSpace(email) ||
                 string.IsNullOrWhiteSpace(password) ||
                 age == 0 ||
                 string.IsNullOrWhiteSpace(contact)))
            {
                MessageBox.Show("Please fill in all fields for personal account.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validation for corporate account
            if (CorporateAccountRadioButton.IsChecked == true &&
                (string.IsNullOrWhiteSpace(companyName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password)))
            {
                MessageBox.Show("Please fill in all fields for corporate account.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            password = ComputeSha256Hash(password); // Hash the password

            // Connect to SQL
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OPQ91FU\\SQLEXPRESS; Initial Catalog = TravelEase; Integrated Security=True");

            using (conn)
            {
                try
                {
                    conn.Open();

                    // Get next operator ID
                    SqlCommand getMaxIdCmd = new SqlCommand("SELECT ISNULL(MAX(operator_id), 0) + 1 FROM Trip_Operator", conn);
                    newOperatorId = (int)getMaxIdCmd.ExecuteScalar();

                    // Insert into Trip_Operator
                    SqlCommand insertOperatorCmd = new SqlCommand(
                        "INSERT INTO Trip_Operator (operator_id, password, email, joined_date, rating) " +
                        "VALUES (@operator_id, @password, @email, GETDATE(), 0)", conn); // Start with 0 rating
                    insertOperatorCmd.Parameters.AddWithValue("@operator_id", newOperatorId);
                    insertOperatorCmd.Parameters.AddWithValue("@email", email);
                    insertOperatorCmd.Parameters.AddWithValue("@password", password);
                    insertOperatorCmd.ExecuteNonQuery();

                    // Insert into either Operator_Person or Operator_Corporate
                    if (PersonalAccountRadioButton.IsChecked == true)
                    {
                        SqlCommand insertPersonCmd = new SqlCommand(
                            "INSERT INTO Operator_Person (operator_id, first_name, last_name, age, contact) " +
                            "VALUES (@operator_id, @first_name, @last_name, @age, @contact)", conn);
                        insertPersonCmd.Parameters.AddWithValue("@operator_id", newOperatorId);
                        insertPersonCmd.Parameters.AddWithValue("@first_name", firstName);
                        insertPersonCmd.Parameters.AddWithValue("@last_name", lastName);
                        insertPersonCmd.Parameters.AddWithValue("@age", age);
                        insertPersonCmd.Parameters.AddWithValue("@contact", contact);
                        insertPersonCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand insertCorpCmd = new SqlCommand(
                            "INSERT INTO Operator_Corporate (operator_id, company_name) " +
                            "VALUES (@operator_id, @company_name)", conn);
                        insertCorpCmd.Parameters.AddWithValue("@operator_id", newOperatorId);
                        insertCorpCmd.Parameters.AddWithValue("@company_name", companyName);
                        insertCorpCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Registration successful! You can now log in as an operator.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                finally
                {
                    conn.Close();
                }
            }

            // Open login window
            TravelEaseVS.OtherWindows.login loginWindow = new TravelEaseVS.OtherWindows.login();
            loginWindow.Show();

            // Close current window
            Window.GetWindow(this)?.Close();
        }

        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void loginLink_Click(object sender, MouseButtonEventArgs e)
        {
            TravelEaseVS.OtherWindows.login loginWindow = new TravelEaseVS.OtherWindows.login();
            loginWindow.Show();
            Window.GetWindow(this)?.Close();
        }

        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Optional: Add age validation logic if needed
        }

        private void CorporateAccountRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            FirstNameTextBox.IsEnabled = false;
            LastNameTextBox.IsEnabled = false;
            AgeTextBox.IsEnabled = false;
            CompanyNameTextBox.IsEnabled = true;
        }

        private void PersonalAccountRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            AgeTextBox.IsEnabled = true;
            CompanyNameTextBox.IsEnabled = false;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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