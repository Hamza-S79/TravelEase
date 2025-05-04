using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;

namespace TravelEaseVS.MVVM.ViewModel
{

    public class Booking
    {
        private string _name, _stdate, _eddate, _status, _payment, _img;
        private string[] group;
        private int _price, _tid, _bid;

        public string Name { get { return _name; } set { _name = value; } }
        public string Start_date { get { return _stdate; } set { _stdate = value; } }
        public string End_date { get { return _eddate; } set { _eddate = value; } }
        public string Booking_status { get { return _status; } set { _status = value; } }
        public string Payment_status { get { return _payment; } set { _payment = value; } }
        public string Image_path { get { return _img; } set { _img = value; } }

        public int Price { get { return _price; } set { _price = value; } }
        public int Trip_id { get { return _tid; } set { _tid = value; } }
        public int Booking_id { get { return _bid; } set { _bid = value; } }

        //public string[] Group { get { } set { } }

        public Booking()
        {

        }

    }
    class Bookings : ObserveObj
    {
        int num_of_bookings = 17;

        private ObservableCollection<Booking> _List_Bookings;
        public ObservableCollection<Booking> List_Bookings { get { return _List_Bookings; } set { _List_Bookings = value; OnPropertyChanged(); }}

        public string name = "Nawaz Sharif", stdate = "12-07-2025", eddate ="17-07-2025", status = "Confirmed", payment = "Confirmed", img = "Images/Bali.jpeg";
        public string[] group;
        public int price = 15000, tid = 0, bid = 0;

        public Bookings()
        {
            List_Bookings = new ObservableCollection<Booking>();
            for (int i = 0; i < num_of_bookings; i++)
            {
                List_Bookings.Add(new Booking { Start_date = stdate, End_date = eddate, Booking_status = status, Payment_status = payment, Name = name, Trip_id = tid, Booking_id=i, Price = price, Image_path = img}) ;
            }

            OnPropertyChanged();
        }


    }
}
