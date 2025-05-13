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
    /// Interaction logic for OpAnnouncedTripsView.xaml
    /// </summary>
    public partial class OpAnnouncedTripsView : UserControl
    {
        private string _O_id;
        public string O_id { get { return _O_id; } set { _O_id = value; } }
        public OpAnnouncedTripsView(string id)
        {
            O_id = id;
            InitializeComponent();
            if (DataContext is OpAnnouncedTripsModel am)
            {
                am.THE_id = O_id;
                am.generateList();
            }

        }

        private void load(object sender, RoutedEventArgs e)
        {
            if (DataContext is OpAnnouncedTripsModel am)
            {
                am.THE_id = O_id;
                am.generateList();
            }
        }
    }
}
