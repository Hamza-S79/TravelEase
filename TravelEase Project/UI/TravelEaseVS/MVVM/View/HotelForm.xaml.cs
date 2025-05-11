using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TravelEaseVS.MVVM.View
{
    public partial class HotelForm : UserControl
    {
        public HotelForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string hotelName = HotelNameTextBox.Text;
            string email = EmailTextBox.Text;
            string contact = ContactTextBox.Text;
            string location = LocationTextBox.Text;
            string govRegistration = GovernmentRegistrationTextBox.Text;
            string password = ComputeSha256Hash(passwordTextBox.Text);
            
            // Basic validation
            if (string.IsNullOrWhiteSpace(hotelName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(contact) ||
                string.IsNullOrWhiteSpace(location) ||
                string.IsNullOrWhiteSpace(govRegistration) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int newHotelId;

            // Connect to SQL
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OPQ91FU\\SQLEXPRESS; Initial Catalog = TravelEase; Integrated Security=True");

            using (conn)
            {
                try
                {
                    conn.Open();

                    // Get next hotel ID
                    SqlCommand getMaxIdCmd = new SqlCommand("SELECT ISNULL(MAX(hotel_id), 0) + 1 FROM Hotel_Provider", conn);
                    newHotelId = (int)getMaxIdCmd.ExecuteScalar();

                    // Insert into Hotel_Provider
                    SqlCommand insertHotelCmd = new SqlCommand(
                        "INSERT INTO Hotel_Provider (hotel_id,password ,name, email, contact_no, location, gov_registration, rating) " +
                        "VALUES (@hotel_id,@pass, @name, @email, @contact_no, @location, @gov_registration, 0)", conn); // Start with 0 rating

                    insertHotelCmd.Parameters.AddWithValue("@hotel_id", newHotelId);
                    insertHotelCmd.Parameters.AddWithValue("@pass", password);
                    insertHotelCmd.Parameters.AddWithValue("@name", hotelName);
                    insertHotelCmd.Parameters.AddWithValue("@email", email);
                    insertHotelCmd.Parameters.AddWithValue("@contact_no", contact);
                    insertHotelCmd.Parameters.AddWithValue("@location", location);
                    insertHotelCmd.Parameters.AddWithValue("@gov_registration", govRegistration);

                    int rowsAffected = insertHotelCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Hotel registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Open login window
                        TravelEaseVS.OtherWindows.login loginWindow = new TravelEaseVS.OtherWindows.login();
                        loginWindow.Show();

                        // Close current window
                        Window.GetWindow(this)?.Close();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    conn.Close();
                }
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
            // Not used in hotel form, but kept for consistency
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
    }
}