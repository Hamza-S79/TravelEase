using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseFixed.Core;

namespace TravelEaseFixed.MVVM.ViewModel
{
    public class ActiveTripsModel : ObserveObj
    {
        int u_id;
        int temp;
        string e, s, type;
        Info info;


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
                q = "exec ActiveTrips "+ u_id;
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





        private ObservableCollection<TripCard> _List_TripCards;
        public ObservableCollection<TripCard> List_TripCards { get { return _List_TripCards; } set { _List_TripCards = value; OnPropertyChanged(); } }

        public ActiveTripsModel(int _id) 
        { 
            u_id = _id;
            generateList();
        }
    }
}
