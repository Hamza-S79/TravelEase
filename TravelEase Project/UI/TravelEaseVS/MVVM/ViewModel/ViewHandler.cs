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
        public RelayCommand HMVCommand {  get; set; }
        public RelayCommand ATVCommand { get; set; }

        public HomeViewModel hmv {get;set;}

        public AnnouncedTripsModel ATV { get; set; }

        private object curr_view;

        public object MyView
        {
            get { return curr_view; }
            set{
                curr_view = value; 
            OnPropertyChanged();
            }
        }



        public ViewHandler() 
        {
            hmv = new HomeViewModel();
            ATV = new AnnouncedTripsModel();
            curr_view = ATV;


            HMVCommand = new RelayCommand(o =>
            {
                MyView = hmv;
            });


           ATVCommand = new RelayCommand(o =>
            {
                MyView = ATV;
            });
        }
    }
    
}
