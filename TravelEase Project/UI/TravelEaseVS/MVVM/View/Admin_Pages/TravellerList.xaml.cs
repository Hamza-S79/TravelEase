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

namespace TravelEaseVS.MVVM.View.Admin_Pages
{
    /// <summary>
    /// Interaction logic for TravellerList.xaml
    /// </summary>
    public partial class TravellerList : Page
    {
        Frame pf;
        public TravellerList(Frame parentFrame)
        {
            InitializeComponent();
            pf = parentFrame;
        }

        public void NavToTravInfo(object sender, RoutedEventArgs e)
        {
            int t_id = 0;
            pf.Navigate(new TravellerInfo(pf, t_id));
        }



    }
}
