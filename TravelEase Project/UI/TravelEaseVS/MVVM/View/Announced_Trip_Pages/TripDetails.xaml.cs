using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using TravelEaseVS.Core;
using TravelEaseVS.MVVM.ViewModel;
namespace TravelEaseVS.MVVM.View.Announced_Trip_Pages
{
    /// <summary>
    /// Interaction logic for TripDetails.xaml
    /// </summary>
    /// 




    public partial class TripDetails : Page
    {
        public Frame parentFrame;



        public TripDetails(Frame pf, int tid)
        {
            InitializeComponent();
            DataContext = new TripDetailsModel(tid);
            parentFrame = pf;
            
        }
        public TripDetails()
        {
            InitializeComponent();
            //DataContext = new TripDetailsModel(tid);


        }


        public void NavToList(object sender, RoutedEventArgs e)
        {
            parentFrame.GoBack();
        }
    }
}
