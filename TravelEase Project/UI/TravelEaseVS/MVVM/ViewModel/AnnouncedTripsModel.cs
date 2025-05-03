using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;


namespace TravelEaseVS.MVVM.ViewModel
{
    class AnnouncedTripsModel:ObserveObj
    {
        public RelayCommand TICommand { get; set; }
        public TripInfo Trio { get; set; }

        


        

        public AnnouncedTripsModel()
        {

           

        }

        



    }
}
