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
    /// Interaction logic for TripInfo.xaml
    /// </summary>
    public partial class TripInfo : Page
    {
        Frame pf;
        
        public TripInfo(Frame _pf,int _id)
        {
            InitializeComponent();
            pf = _pf;
            DataContext = new TripInfoModel(_id);
        }


        private void Back(object s, RoutedEventArgs e)
        {
            pf.GoBack();
        }

        public void selectItinerary(object sender, RoutedEventArgs e)
        {
            Button itinerary = sender as Button;
            string tag = itinerary.Tag as String;
            if (DataContext is TripInfoModel)
            {
                ((TripInfoModel)DataContext).setImage(tag);
            }
        }
    }
}
