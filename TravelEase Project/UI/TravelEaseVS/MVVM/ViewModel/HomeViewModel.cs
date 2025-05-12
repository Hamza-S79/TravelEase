using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;
using System.Data.SqlClient;

namespace TravelEaseVS.MVVM.ViewModel
{
    class HomeViewModel:ObserveObj
    {
        int num_of_trips = 5;
        string s = "Orlando", e = "Miami", bd = "05-09-2025", ed = "12-09-2025", img1 ="../../Images/Orlando.jpeg" , img2 = "../../Images/Miami Beach.jpeg";
        int id = 4, gs = 2, pr = 8000;
        private ObservableCollection<TripCard> _List_TripCards;
        public ObservableCollection<TripCard> List_TripCards { get { return _List_TripCards; } set { _List_TripCards = value; OnPropertyChanged(); } }
        public HomeViewModel()
        {
            _List_TripCards = new ObservableCollection<TripCard>();



            //OnPropertyChanged();

            for (int i = 0; i < num_of_trips; i++)
            {

                List_TripCards.Add(new TripCard { Start_loc = s, End_loc = e, Beginning_Date = bd, End_date = ed, Group_size = gs, Price = pr, Trip_ID = i, Image_path1 = img1, Image_path2 = img2 });
                //OnPropertyChanged();
            }
            OnPropertyChanged();


        }
    }
}
