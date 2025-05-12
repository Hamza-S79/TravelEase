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
    /// Interaction logic for ProviderInfo.xaml
    /// </summary>
    public partial class ProviderInfo : Page
    {
        Frame _pf;
        public ProviderInfo(Frame pf, int P_id)
        {
            InitializeComponent();
            _pf = pf;
        }

        public void NavToProvList(object sender, RoutedEventArgs e)
        {
            _pf.GoBack();
        }


    }
}
