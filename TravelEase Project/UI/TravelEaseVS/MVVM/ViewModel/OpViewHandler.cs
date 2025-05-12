using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;
namespace TravelEaseVS.MVVM.ViewModel
{
    class OpViewHandler : ObserveObj
    {
        public RelayCommand go_to_login { get; set; }
        public RelayCommand OHMVcommand { get; set; }
        public RelayCommand OATMcommand { get; set; }


        public OpHomeViewModel OHMV { get; set; }
        public OpAnnouncedTripsModel OATM { get; set; }

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


        public OpViewHandler()
        {
            OHMV = new OpHomeViewModel();
            OATM = new OpAnnouncedTripsModel();
            curr_view = OHMV;


            OHMVcommand = new RelayCommand( o =>
            {
                MyView = OHMV;
            });



            OATMcommand = new RelayCommand(o =>
            {
                MyView = OATM;
            });

        }

    }
}
