using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using TravelEaseVS.Core;

namespace TravelEaseVS.MVVM.ViewModel
{
    class AdminTravellerModel:ObserveObj
    {

        public class ProfileCard
        {
            private string _name = "", _nationality = "", _age = "", _email = "", _contact = "", _joinDate = "", _profileImage = "";

            public string Name { get => _name; set => _name = value; }
            public string Nationality { get => _nationality; set => _nationality = value; }
            public string Age { get => _age; set => _age = value; }
            public string Email { get => _email; set => _email = value; }
            public string Contact { get => _contact; set => _contact = value; }
            public string JoinDate { get => _joinDate; set => _joinDate = value; }
            public string ProfileImage { get => _profileImage; set => _profileImage = value; }

        }
            int num_of_trips = 20;
            string name = "Muhammad Hamza", nationality = "Pakistani", age = "Age: 22", email = "hamza@example.com", contact = "0300-1234567", joinDate = "01-01-2023", profileImage = "../../../Images/pf.jpg";

            private ObservableCollection<ProfileCard> _List_Cards;
            public ObservableCollection<ProfileCard> List_Cards
            {
                get { return _List_Cards; }
                set { _List_Cards = value; OnPropertyChanged(); }
            }

        string justDate(string st)//helping function to extract the date part out of the whole date which includes time as well
        {
            string t = "";
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] == ' ') return t;
                t += st[i];
            }

            return t;
        }

        SqlConnection con;
        
        public AdminTravellerModel()
        {
            _List_Cards = new ObservableCollection<ProfileCard>();
            con = new SqlConnection("Data Source=HP\\SQLEXPRESS01;Initial Catalog=TravelEase;Integrated Security=True;");
            con.Open();
            SqlCommand com = new SqlCommand("exec T_PersonInfo", con);

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read()) 
            {
                List_Cards.Add(new ProfileCard
                {
                    Name = reader["first_Name"].ToString() +" "+ reader["last_Name"].ToString(),
                    Nationality = reader["nationality"].ToString(),
                    Age = reader["age"].ToString(),
                    Email = reader["email"].ToString(),
                    Contact = reader["contact"].ToString(),
                    JoinDate = justDate(reader["joined_date"].ToString()),
                    ProfileImage = profileImage
                });
            }

            con.Close();
            OnPropertyChanged();
        }

    }
}

