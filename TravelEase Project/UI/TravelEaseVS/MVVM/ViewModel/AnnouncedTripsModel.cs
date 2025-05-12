using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;
using TravelEaseVS.MVVM.View.Announced_Trip_Pages;
using System.Windows.Media;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace TravelEaseVS.MVVM.ViewModel
{
    public class TripCard
    {
        private string _s ="", _e ="", _bd = "", _ed = "", _img1 = "", _img2 ="", _type = ""; //start location, end location, begin date, end date
        private int _id, _gs, _pr; //trip is, group size, package price
        public string Start_loc { get { return _s; } set { _s = value; } }
        public string End_loc { get { return _e; } set { _e = value; } }
        public string Beginning_Date { get { return _bd; } set { _bd = value; } }
        public string End_date { get { return _ed; } set { _ed = value; } }
        public int Trip_ID { get { return _id; } set { _id = value; } }
        public int Group_size { get { return _gs; } set { _gs = value; } }
        public int Price { get { return _pr; } set { _pr = value; } }

        public string type { get { return _type; } set { _type = value; } }

        public string Image_path1 { get { return _img1; } set { _img1 = value;  } }
        public string Image_path2 { get { return _img2; } set { _img2 = value; } }

    };






    class AnnouncedTripsModel : ObserveObj
    {
        int num_of_trips = 20;
        string s = "Nara", e = "Osaka", bd = "01-07-2025", ed = "04-07-2025", img1 = "../../../Images/Nara.jpeg", img2 = "../../../Images/Osaka.jpeg";
        string type = "";
        int id = 13, gs = 4, pr = 5000;
        private ObservableCollection<TripCard> _List_TripCards;
        public ObservableCollection<TripCard> List_TripCards { get { return _List_TripCards; } set { _List_TripCards = value; OnPropertyChanged(); } }
        private string _search_st = "";
        public string search_st { get { return _search_st; } set { _search_st = value; } }
        string full_search_st = "";

        public RelayCommand search { get; set; }


      
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

        private void generateList(string search = "")
        {
            List_TripCards = new ObservableCollection<TripCard>();
            SqlConnection conn = new SqlConnection("Data Source = HP\\SQLEXPRESS01; Initial Catalog = TravelEase; Integrated Security = True;");
            conn.Open();
            string q = "";
            if (search == "")
                q = "exec UpcomingTrips";
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
                TripCard t = new TripCard
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
                List_TripCards.Add(t);
            }

            OnPropertyChanged();
            conn.Close();
        }



        public AnnouncedTripsModel()
        {
            

            generateList();
            

            search = new RelayCommand(o => {
                
                generateList(search_st); //<< start here (connecting Model to View to Code-Behind)
            });

            //OnPropertyChanged();
            //for (int i = 0; i < num_of_trips; i++)
            //{
                
            //    List_TripCards.Add(new TripCard { Start_loc = s, End_loc = e, Beginning_Date = bd, End_date = ed, Group_size = gs, Price = pr, Trip_ID = i, Image_path1=img1, Image_path2= img2});
            //    //OnPropertyChanged();
            //}
                OnPropertyChanged();

           
        }

    }
}
