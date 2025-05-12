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
using TravelEaseVS.MVVM.View.Admin_Pages;
namespace TravelEaseVS.MVVM.View
{
    /// <summary>
    /// Interaction logic for AdminTravellerView.xaml
    /// </summary>
    public partial class AdminTravellerView : UserControl
    {
        public AdminTravellerView()
        {
            InitializeComponent();
            Travellers.Navigate(new TravellerList(Travellers));
        }
    }
}
