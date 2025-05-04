using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;
using TravelEaseVS.MVVM.View.Announced_Trip_Pages;


namespace TravelEaseVS.MVVM.ViewModel
{
    public class TripCard
    {
        private string _s ="", _e ="", _bd = "", _ed = "", _img1 = "", _img2 =""; //start location, end location, begin date, end date
        private int _id, _gs, _pr; //trip is, group size, package price
        public string Start_loc { get { return _s; } set { _s = value; } }
        public string End_loc { get { return _e; } set { _e = value; } }
        public string Beginning_Date { get { return _bd; } set { _bd = value; } }
        public string End_date { get { return _ed; } set { _ed = value; } }
        public int Trip_ID { get { return _id; } set { _id = value; } }
        public int Group_size { get { return _gs; } set { _gs = value; } }
        public int Price { get { return _pr; } set { _pr = value; } }

        public string Image_path1 { get { return _img1; } set { _img1 = value;  } }
        public string Image_path2 { get { return _img2; } set { _img2 = value; } }

    }
    class AnnouncedTripsModel: ObserveObj
    {
        int num_of_trips = 20;
        string s = "Nara", e ="Osaka", bd = "01-07-2025", ed  ="04-07-2025", img1 = "../../../Images/Nara.jpeg", img2 = "../../../Images/Osaka.jpeg";
        int id = 13, gs = 4, pr = 5000;
        private ObservableCollection<TripCard> _List_TripCards;
        public ObservableCollection<TripCard> List_TripCards { get { return _List_TripCards; } set { _List_TripCards = value; OnPropertyChanged(); } }
        public AnnouncedTripsModel()
        {
            _List_TripCards = new ObservableCollection<TripCard>();

            

            //OnPropertyChanged();

            for (int i = 0; i < num_of_trips; i++)
            {
                
                List_TripCards.Add(new TripCard { Start_loc = s, End_loc = e, Beginning_Date = bd, End_date = ed, Group_size = gs, Price = pr, Trip_ID = i, Image_path1=img1, Image_path2= img2});
                //OnPropertyChanged();
            }
                OnPropertyChanged();

           
        }

    }
}
