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
    /// Interaction logic for AdminProviderView.xaml
    /// </summary>
    public partial class AdminProviderView : UserControl
    {
        public AdminProviderView()
        {
            InitializeComponent();
            Providers.Navigate(new ProviderList(Providers));
        }
    }
}
