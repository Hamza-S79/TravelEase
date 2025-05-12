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
using TravelEaseVS.MVVM.ViewModel;
namespace TravelEaseVS.MVVM.View
{
    /// <summary>
    /// Interaction logic for Bookings.xaml
    /// </summary>
    /// 



    public partial class Bookings : UserControl
    {   //public BookingsModel bm { get; set; }
        public Bookings()
        {
            //bm = new BookingsModel(id);
            InitializeComponent();
            //DataContext = bm;
            Bookings_.Navigate(new Bookings_Pages.Bookings_List(Bookings_));
        }
    }
}
