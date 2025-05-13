using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TravelEaseFixed.Core;
using TravelEaseVS.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TravelEaseFixed.MVVM.ViewModel
{

    public class BookingCard
    {
        private string _name, _tid, _stdate, _eddate, _status, _payment, _img;
        private List<string> group;
        private string _price,  _bid;

        public string Name { get { return _name; } set { _name = value; } }
        public string Start_date { get { return _stdate; } set { _stdate = value; } }
        public string End_date { get { return _eddate; } set { _eddate = value; } }
        public string Booking_status { get { return _status; } set { _status = value; } }
        public string Payment_status { get { return _payment; } set { _payment = value; } }
        public string Image_path { get { return _img; } set { _img = value; } }

        public string Price { get { return _price; } set { _price = value; } }
        public string Trip_id { get { return _tid; } set { _tid = value; } }
        public string Booking_id { get { return _bid; } set { _bid = value; } }

        //public string[] Group { get { } set { } }


    }


    public class TripCard
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

    public class TravellerBackend : ObserveObj
    {
        int id;
        int temp;
        string e, s, type;
        //Booking Variables
            private ObservableCollection<BookingCard> _List_Bookings;
            public ObservableCollection<BookingCard> List_Bookings { get { return _List_Bookings; } set { _List_Bookings = value; OnPropertyChanged(nameof(List_Bookings)); } }
        //=================


        //Trips Variables
            private ObservableCollection<TripCard> _List_TripCards;
            public ObservableCollection<TripCard> List_TripCards { get { return _List_TripCards; } set { _List_TripCards = value; OnPropertyChanged(); } }
            public RelayCommand search { get; set; }

            private string _search_st = "";
            public string search_st { get { return _search_st; } set { _search_st = value; } }
        //===============


        //Helping Functions
            string justDate(string st) //helping function to extract the date part out of the whole date which includes time as well
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
                string k = "exec FirstLast " + temp.ToString();
                SqlCommand co = new SqlCommand(k, con);
                SqlDataReader reader = co.ExecuteReader();
                reader.Read();
                e = reader[0].ToString();
                reader.Read();
                s = reader[0].ToString();
                con.Close();

                con = new SqlConnection("Data Source = HP\\SQLEXPRESS01; Initial Catalog = TravelEase; Integrated Security = True;");
                con.Open();
                co = new SqlCommand("exec TripType " + temp.ToString(), con);
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
                    temp = Convert.ToInt32(read["announced_trip_id"]);

                    //conn.Close();
                    FirstLast();
                    //conn.Open();
                    TripCard t = new TripCard
                    {
                        Trip_ID = temp,
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

            private void generateBookings()
            {
                List_Bookings = new ObservableCollection<BookingCard>();
                SqlConnection conn = new SqlConnection("Data Source = HP\\SQLEXPRESS01; Initial Catalog = TravelEase; Integrated Security = True;");
                conn.Open();
                string q = "Select * from Booking b join Announced_Trip a on a.announced_trip_id = b.announced_trip_id where b.user_id = " + id.ToString();
                SqlCommand co = new SqlCommand(q, conn);
                SqlDataReader reader = co.ExecuteReader();
                while (reader.Read()) 
                {
                    List_Bookings.Add(new BookingCard { 
                        Start_date = reader["begin_date"].ToString(),
                        End_date = reader["end_date"].ToString(),
                        Booking_status = reader["status"].ToString(),
                        Payment_status = reader["payment_status"].ToString(),
                        Trip_id = reader["announced_trip_id"].ToString(),
                        Booking_id = reader["booking_id"].ToString(),
                        Price = reader["package_price"].ToString(),
                        });
                    OnPropertyChanged();
            }

        }
        //=================

        public TravellerBackend(int _id)
        {
            id = _id;
            generateList();
            generateBookings();
            search = new RelayCommand(o => {

                generateList(search_st);
            });

        }




    }
}
