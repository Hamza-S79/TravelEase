using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;

namespace TravelEaseVS.MVVM.ViewModel
{
    public class ProvCard
    {
        private string _name = "", _email = "", _location = "", _contact = "", _govtReg = "", _profileImage = "", _rating ="";

        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string Location { get => _location; set => _location = value; }
        public string Contact { get => _contact; set => _contact = value; }
        public string GovernmentRegistration { get => _govtReg; set => _govtReg = value; }
        public string ProfileImage { get => _profileImage; set => _profileImage = value; }

        public string Rating { get => _rating; set => _rating = value; }
    }
    class AdminProviderModel:ObserveObj
    {
        private ObservableCollection<ProvCard> _List_PrCards;
        public ObservableCollection<ProvCard> List_PrCards
        {
            get { return _List_PrCards; }
            set { _List_PrCards = value; OnPropertyChanged(); }
        }

        SqlConnection con;

        public AdminProviderModel()
        {
            _List_PrCards = new ObservableCollection<ProvCard>();

            // Sample admin data
            string name = "Muhammad Nasir Bilal";
            string email = "nasir@example.com";
            string location = "Islamabad";
            string contact = "+92 312 1234567";
            string govtReg = "REG-PAK-2025-001";
            string profileImg = "../../../Images/hotel.jpg";

            con = new SqlConnection("Data Source=HP\\SQLEXPRESS01;Initial Catalog=TravelEase;Integrated Security=True;");
            con.Open();
            SqlCommand com = new SqlCommand("Select * from Hotel_Provider", con);

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read()) 
            {
                List_PrCards.Add(new ProvCard
                {
                    Name = reader[1].ToString(),
                    Email = reader[2].ToString(),
                    Location = reader[4].ToString(),
                    Contact = reader[3].ToString(),
                    Rating = reader[5].ToString(),
                    GovernmentRegistration = reader[6].ToString(),
                    ProfileImage = profileImg
                });
            }

            con.Close();
            OnPropertyChanged();


        }
    }
}
