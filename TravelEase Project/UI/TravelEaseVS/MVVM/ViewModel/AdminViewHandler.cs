using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;
namespace TravelEaseVS.MVVM.ViewModel
{
    class AdminViewHandler: ObserveObj
    {


        public RelayCommand go_to_login { get; set; }
        public RelayCommand AHMVcommand { get; set; }
        public RelayCommand ATcommand { get; set; }
        public RelayCommand AOcommand { get; set; }
        public RelayCommand APcommand { get; set; }


        public AdminHomeViewModel AHMV { get; set; }
        public AdminOperatorModel AOVM { get; set; }
        public AdminProviderModel APVM { get; set; }

        public AdminTravellerModel ATVM { get; set; }

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



        public AdminViewHandler()
        {

            ATVM = new AdminTravellerModel();
            AOVM = new AdminOperatorModel();
            APVM = new AdminProviderModel();
            AHMV = new AdminHomeViewModel();

            curr_view = AHMV;

            AHMVcommand = new RelayCommand(o => { MyView = AHMV; });
            ATcommand = new RelayCommand(o => { MyView = ATVM; });
            AOcommand = new RelayCommand(o => { MyView = AOVM; });
            APcommand = new RelayCommand(o => { MyView = APVM; });
        }
    }
}

