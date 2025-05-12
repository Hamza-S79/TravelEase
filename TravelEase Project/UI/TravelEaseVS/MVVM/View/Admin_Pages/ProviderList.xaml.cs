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
    /// Interaction logic for ProviderList.xaml
    /// </summary>
    public partial class ProviderList : Page
    {
        Frame _pf;
        public ProviderList(Frame pf)
        {
            InitializeComponent();
            _pf = pf;
        }

        public void NavToProvInfo(object sender, RoutedEventArgs e)
        {
            int P_id = 0;
            _pf.Navigate(new ProviderInfo(_pf, P_id));
        }
    }
}
