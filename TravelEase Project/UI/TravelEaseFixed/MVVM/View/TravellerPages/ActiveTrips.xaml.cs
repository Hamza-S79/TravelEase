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
    /// Interaction logic for ActiveTrips.xaml
    /// </summary>
    public partial class ActiveTrips : Page
    {
        Frame pf; int id;
        public ActiveTrips(Frame _pf, int _id)
        {
            InitializeComponent();
            pf = _pf;
            id = _id;
            DataContext = new ActiveTripsModel(_id);
        }

        private void Back(object s, RoutedEventArgs e)
        {
            pf.GoBack();
        }
    }
}
