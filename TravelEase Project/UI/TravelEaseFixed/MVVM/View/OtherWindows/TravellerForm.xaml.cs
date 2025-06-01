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
using System.Data.SqlClient;
namespace TravelEaseFixed.MVVM.View.OtherWindows
{
    /// <summary>
    /// Interaction logic for TravellerForm.xaml
    /// </summary>
    public partial class TravellerForm : Page
    {
        public TravellerForm()
        {
            InitializeComponent();
        }

        public void signUp(object s, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=HP\\SQLEXPRESS01;Initial Catalog=TravelEase;Integrated Security=True;");
            conn.Open();
            SqlCommand comm = new SqlCommand("Select dbo.checkEmailTrav('"+ Email.Text+"')",conn);
            bool already = (bool)comm.ExecuteScalar();
            if (!already)
            {
                if (Email.Text == ""
                    || Password.Text == ""
                    || F_name.Text == ""
                    || L_name.Text == ""
                    || Nationality.Text == ""
                    || Age.Text == ""
                    || Contact.Text == "")
                { MessageBox.Show("All fields are neccessary"); }
                else
                {
                    comm = new SqlCommand(("exec BookUserPerson '" + Email.Text + "','" + Password.Text + "','" + Nationality.Text + "', '" + F_name.Text + "','" + L_name.Text + "' ," + Age.Text + ", '" + Contact.Text + "'"), conn);
                    comm.ExecuteNonQuery();
                }
                conn.Close();
            }
            else
            { MessageBox.Show("Email already in use!"); }

        }

    }
}
