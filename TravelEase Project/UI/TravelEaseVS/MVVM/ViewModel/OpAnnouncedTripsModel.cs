using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelEaseVS.MVVM.ViewModel
{

    public class OppCard
    {
        private string _s = "", _e = "", _bd = "", _ed = "", _img1 = "", _img2 = "", _type = ""; //start location, end location, begin date, end date
        private int _id, _gs, _pr; //trip is, group size, package price
        public string Start_loc { get { return _s; } set { _s = value; } }
        public string End_loc { get { return _e; } set { _e = value; } }
        public string Beginning_Date { get { return _bd; } set { _bd = value; } }
        public string End_date { get { return _ed; } set { _ed = value; } }
        public int Trip_ID { get { return _id; } set { _id = value; } }
        public int Group_size { get { return _gs; } set { _gs = value; } }
        public int Price { get { return _pr; } set { _pr = value; } }

        public string type { get { return _type; } set { _type = value; } }

        public string Image_path1 { get { return _img1; } set { _img1 = value; } }
        public string Image_path2 { get { return _img2; } set { _img2 = value; } }

    };

    public class OpAnnouncedTripsModel : INotifyPropertyChanged
    {

        int num_of_trips = 20;
        string s = "Nara", e = "Osaka", bd = "01-07-2025", ed = "04-07-2025", img1 = "../../../Images/Nara.jpeg", img2 = "../../../Images/Osaka.jpeg";
        public string search_st ="";
        string type = "";
        int id = 13,gs = 4, pr = 5000;


        private ObservableCollection<OppCard> _List_Cards;
        public ObservableCollection<OppCard> List_Cards { get { return _List_Cards; } set { _List_Cards = value; OnPropertyChanged(nameof(_List_Cards)); } }

        private string _THE_id;
        public string THE_id { get { return _THE_id; } set { _THE_id = value; } }

        private void FirstLast()
        {
            SqlConnection con = new SqlConnection("Data Source = HP\\SQLEXPRESS01; Initial Catalog = TravelEase; Integrated Security = True;");
            con.Open();
            string k = "exec FirstLast " + id.ToString();
            SqlCommand co = new SqlCommand(k, con);
            SqlDataReader reader = co.ExecuteReader();
            reader.Read();
            e = reader[0].ToString();
            reader.Read();
            s = reader[0].ToString();
            con.Close();

            con = new SqlConnection("Data Source = HP\\SQLEXPRESS01; Initial Catalog = TravelEase; Integrated Security = True;");
            con.Open();
            co = new SqlCommand("exec TripType " + id.ToString(), con);
            reader = co.ExecuteReader();
            reader.Read();
            type = reader[0].ToString();
            con.Close();
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
        public void generateList(string search = "")
        {
            int id;
            List_Cards = new ObservableCollection<OppCard>();
            SqlConnection conn = new SqlConnection("Data Source = HP\\SQLEXPRESS01; Initial Catalog = TravelEase; Integrated Security = True;");
            conn.Open();
            string q = "";
            if (search == "")
            {
                q = "Select * from Announced_Trip a join Trip_Design t on t.trip_design_id =a.trip_design_id join Trip_Operator o on o.operator_id = t.operator_id where t.operator_id = ";
                q += THE_id;
            }
            else
            {
                q = "exec searchResult \'%" + search + "%\'";
            }
            //q = "Select * from announced_trip where announced_trip_id = 52";
            SqlCommand com = new SqlCommand(q, conn);


            SqlDataReader read = com.ExecuteReader();


            while (read.Read())
            {
                id = Convert.ToInt32(read["announced_trip_id"]);

                //conn.Close();
                FirstLast();
                //conn.Open();
                OppCard t = new OppCard
                {
                    Trip_ID = id,
                    Start_loc = s,
                    End_loc = e,
                    Beginning_Date = justDate(read["begin_date"].ToString()),
                    End_date = justDate(read["end_date"].ToString()),
                    Price = Convert.ToInt32(read["package_price"]),
                    Image_path1 = "../../Images/" + s + ".jpeg",
                    Image_path2 = "../../Images/" + e + ".jpeg"
                };
                List_Cards.Add(t);
            OnPropertyChanged(nameof(_List_Cards));
            }

            conn.Close();
        }


        public OpAnnouncedTripsModel()
        {
            
            //generateList();
            OnPropertyChanged(nameof(_List_Cards));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
