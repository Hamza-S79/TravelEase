using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TravelEaseVS.MVVM.ViewModel;
using TravelEaseVS.Core;
namespace TravelEaseVS.MVVM.View.Announced_Trip_Pages
{
    /// <summary>
    /// Interaction logic for TripsList.xaml
    /// </summary>
    /// 

    public partial class TripsList : Page 
    {
        public Frame parentFrame;
        

        
        public TripsList(Frame pF)
        {
            InitializeComponent();
            parentFrame = pF;
        }


        private void NavToTripDetail(object sender, RoutedEventArgs e)
        {
            parentFrame.Navigate(new TripDetails(parentFrame));
        }
    }
}
