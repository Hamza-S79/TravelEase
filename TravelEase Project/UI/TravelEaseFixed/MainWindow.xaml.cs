using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelEaseFixed.MVVM.View.TravellerPages;
namespace TravelEaseFixed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int id;
        public MainWindow(int _id)
        {
            id = _id;
            InitializeComponent();
            TravellerMainFrame.Navigate(new TravHome());
        }

        private void NavToAnnTrips(object s, RoutedEventArgs e) { TravellerMainFrame.Navigate(new AnnouncedTrips(TravellerMainFrame)); }
        private void NavToBookings(object s, RoutedEventArgs e) { TravellerMainFrame.Navigate(new TravBookings(TravellerMainFrame, id));}
        private void NavToActTrips(object s, RoutedEventArgs e) { TravellerMainFrame.Navigate(new ActiveTrips(TravellerMainFrame, id)); }
        private void NavToHome(object s, RoutedEventArgs e) { TravellerMainFrame.Navigate(new TravHome()); }
    }
}