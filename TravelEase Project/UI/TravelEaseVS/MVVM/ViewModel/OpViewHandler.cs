using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelEaseVS.Core;
using TravelEaseVS.MVVM.View;
namespace TravelEaseVS.MVVM.ViewModel
{
    public class OpViewHandler : INotifyPropertyChanged
    {
        public string _id;
        public string id { get { return _id; } set { _id = value; } }
        public RelayCommand go_to_login { get; set; }
        public RelayCommand OHMVcommand { get; set; }
        public RelayCommand OATMcommand { get; set; }

        public OpAnnouncedTripsView oatv { get; set; }
        public OpHomeViewModel OHMV { get; set; }
        public OpAnnouncedTripsModel OATM { get; set; }

        private object curr_view;

        public object MyView
        {
            get { return curr_view; }
            set
            {
                curr_view = value;
                OnPropertyChanged(nameof(curr_view));
            }
        }


        public OpViewHandler()
        {
            OHMV = new OpHomeViewModel();
            //OATM = new OpAnnouncedTripsModel(int.Parse(id));
            
            //OpAnnouncedTripsView oatv = new OpAnnouncedTripsView(id);

            curr_view = OHMV;

            OHMVcommand = new RelayCommand( o =>
            {
                MyView = OHMV;
            });


            OATMcommand = new RelayCommand(o =>
            {
                MyView = oatv;
            });


        }

        public void reset()
        {   oatv = new OpAnnouncedTripsView(id);


        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
