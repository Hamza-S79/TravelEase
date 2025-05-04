using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;


namespace TravelEaseVS.MVVM.ViewModel
{
    class ViewHandler : ObserveObj
    {
        public RelayCommand HMVCommand { get; set; }
        public RelayCommand ATVCommand { get; set; }
        public RelayCommand BKSCommand { get; set; }


        public HomeViewModel hmv { get; set; }
        public AnnouncedTripsModel ATV { get; set; }
        public Bookings BKS { get; set; }

        private object curr_view;

        public object MyView
        {
            get { return curr_view; }
            set
            {
                curr_view = value;
                OnPropertyChanged();
            }
        }



        public ViewHandler()
        {
            hmv = new HomeViewModel();
            ATV = new AnnouncedTripsModel();
            BKS = new Bookings();
            curr_view = hmv;


            HMVCommand = new RelayCommand(o =>
            {
                MyView = hmv;
            });


            ATVCommand = new RelayCommand(o =>
             {
                 MyView = ATV;
             });

            BKSCommand = new RelayCommand( o =>
            {
                MyView = BKS;
            
            });

        }
    }




}
