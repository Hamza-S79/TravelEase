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

    public class OpCard
    {
        private string _name = "", _age = "", _email = "", _contact = "", _joinDate = "", _profileImage = "";

        public string Name { get => _name; set => _name = value; }

        public string Age { get => _age; set => _age = value; }
        public string Email { get => _email; set => _email = value; }
        public string Contact { get => _contact; set => _contact = value; }
        public string JoinDate { get => _joinDate; set => _joinDate = value; }
        public string ProfileImage { get => _profileImage; set => _profileImage = value; }

    }

    class AdminOperatorModel :ObserveObj
     {
        int num_of_op = 20;
        string name = "Muhammad Hamza", age = "Age: 22", email = "hamza@example.com", contact = "0300-1234567", joinDate = "01-01-2023", profileImage = "../../../Images/pf.jpg";

        private ObservableCollection<OpCard> _List_OpCards;
        public ObservableCollection<OpCard> List_OpCards
        {
            get { return _List_OpCards; }
            set { _List_OpCards = value; OnPropertyChanged(); }
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
        public AdminOperatorModel()
        {
            con = new SqlConnection("Data Source=HP\\SQLEXPRESS01;Initial Catalog=TravelEase;Integrated Security=True;");
            _List_OpCards = new ObservableCollection<OpCard>();
            con.Open();
            SqlCommand com = new SqlCommand("exec O_PersonInfo", con);

            SqlDataReader read = com.ExecuteReader();

            while (read.Read()) 
            {
                List_OpCards.Add(new OpCard
                {
                    Name = read[1].ToString() +" "+read[2].ToString(),
                    Age = read[3].ToString(),
                    Email = read[7].ToString(),
                    Contact = read[4].ToString(),
                    JoinDate = justDate(read[9].ToString()),
                    ProfileImage = profileImage
                });
            }
            con.Close();
            OnPropertyChanged();
        }
    }
}
