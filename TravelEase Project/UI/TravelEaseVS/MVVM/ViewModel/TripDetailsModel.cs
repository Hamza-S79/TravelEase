using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;
using TravelEaseVS.MVVM.View.Announced_Trip_Pages;

namespace TravelEaseVS.MVVM.ViewModel
{
    class TripDetailsModel:ObserveObj
    {

        public int ann_tripId { get { return _tripId; } set { _tripId = value; } }
        private int _tripId;

        private string _Op_Id ="", _Op_Name ="";
        public string Op_Id { get { return _Op_Id; } set { _Op_Id = value; } }
        public string Op_Name { get { return _Op_Name; } set { _Op_Name = value; } }

        private List<string> _itineraries; //number of itineraries will help determine the size of this, the backend generation will be much like the Listbox but horizontal/Vertical(and may need a stack panel to fit everything??)
        private List<string> _imagePaths; //we will create each image path by concatenatiing the root and the itinerary name
        private string[] _routes;// we will organize these against the stops using indexing, these may also show the bus that takes the route


        private string _bg_date, _ed_date, _cancellation_dd, _acc_tags;
        private int _price, _groupsize;

        public string bg_date { get { return _bg_date; } set { _bg_date = value; } }
        public string ed_date { get { return _ed_date; } set { _ed_date = value; } }
        public string cancellation_dd { get { return _cancellation_dd; } set { _cancellation_dd = value; } }
        public string acc_tags { get { return _acc_tags; } set { _acc_tags = value; } }

        public int price { get { return _price; } set { _price = value; } }
        public int groupsize { get { return _groupsize; } set { _groupsize= value; } }


        public List<string> itineraries
        {
            get { return _itineraries; }
            set
            {

                if (_itineraries != value) { _itineraries = value; OnPropertyChanged(); }
            }
        }
        public List<string> imagePaths { get { return _imagePaths; } set { _imagePaths = value; OnPropertyChanged(); } }
        public string[] routes { get { return _routes; } set { _routes = value; } }

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
        private void getItineraries()
        {
            itineraries = new List<string>();
            SqlConnection con = new SqlConnection("Data Source=HP\\SQLEXPRESS01;Initial Catalog=TravelEase;Integrated Security=True;");
            con.Open();

            SqlCommand com = new SqlCommand("exec TripItineraries " + ann_tripId.ToString(), con);

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read()) 
            {
                itineraries.Add(reader[2].ToString());
            }
            con.Close();
        }

        private void getTripInfo()
        {
            SqlConnection con = new SqlConnection("Data Source=HP\\SQLEXPRESS01;Initial Catalog=TravelEase;Integrated Security=True;");
            con.Open();

            SqlCommand com = new SqlCommand("exec TripDetails " + ann_tripId, con);

            SqlDataReader reader = com.ExecuteReader();

            reader.Read();
            Op_Id = "NOTYET";
            Op_Name = "Mustafa Saleem";
            groupsize = Convert.ToInt32(reader["max_group_size"]);
            price = Convert.ToInt32(reader[4]);
            bg_date = justDate(reader["begin_date"].ToString());
            ed_date = justDate(reader["end_date"].ToString());
            cancellation_dd = reader["cancellation_deadline"].ToString();
            acc_tags = reader["accessibility_tags"].ToString();


            con.Close();
        }

        public TripDetailsModel(int id)
        {
            ann_tripId = id;
            getItineraries();
            getTripInfo();
            OnPropertyChanged();

        }



    }
}
