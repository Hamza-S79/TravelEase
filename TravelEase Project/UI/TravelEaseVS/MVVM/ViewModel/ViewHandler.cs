using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TravelEaseVS.Core;
using TravelEaseVS.MVVM.View;
using TravelEaseVS.MVVM.ViewModel;
namespace TravelEaseVS.MVVM.ViewModel
{
    class ViewHandler : ObserveObj
    {

        public RelayCommand go_to_login { get; set; }
        public RelayCommand HMVCommand { get; set; }
        public RelayCommand ATVCommand { get; set; }
        public RelayCommand BKSCommand { get; set; }

        //public Bookings bks { get; set; }
        public HomeViewModel hmv { get; set; }
        public AnnouncedTripsModel ATV { get; set; }
        public BookingsModel BKS { get; set; }

        private int _U_id;
        public int U_id{get{ return _U_id; } set { _U_id = value; } }

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
            //U_id = id;
            hmv = new HomeViewModel();
            ATV = new AnnouncedTripsModel();
            BKS = new BookingsModel();
            //bks = new Bookings(U_id);
            MyView = hmv;


            HMVCommand = new RelayCommand(o =>
            {
                MyView = hmv;
            });


            ATVCommand = new RelayCommand(o =>
             {
                 MyView = ATV;
             });

            BKSCommand = new RelayCommand(o=>{
                MyView = BKS;
            });



            OnPropertyChanged();
        }


        //public void func()
        //{
        //    MyView = bks.
        //}


        //public event PropertyChangedEventHandler PropertyChanged;


        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

    }




}
