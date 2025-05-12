using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelEaseVS.MVVM.View.Announced_Trip_Pages;
using TravelEaseVS.MVVM.ViewModel;

namespace TravelEaseVS.MVVM.View
{
    /// <summary>
    /// Interaction logic for AnnouncedTripsView.xaml
    /// </summary>
    public partial class AnnouncedTripsView : UserControl
    {
        
        public AnnouncedTripsView()
        {
            InitializeComponent();
            Announced_Trips.Navigate(new TripsList(this.Announced_Trips));
                

        }


    }
}
