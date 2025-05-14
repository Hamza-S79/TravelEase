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
using TravelEaseFixed.MVVM.ViewModel;
namespace TravelEaseFixed.MVVM.View.TravellerPages
{
    /// <summary>
    /// Interaction logic for AnnouncedTrips.xaml
    /// </summary>
    public partial class AnnouncedTrips : Page
    {
        Frame pf;
        public AnnouncedTrips(Frame _pf, int _id)
        {
            InitializeComponent();
            pf = _pf;
            DataContext = new TravellerBackend(_id);
        }

        private void NavToTripInfo(object s, RoutedEventArgs e)
        {
            pf.Navigate(new TripInfo(pf,1));
        }


    }
}
