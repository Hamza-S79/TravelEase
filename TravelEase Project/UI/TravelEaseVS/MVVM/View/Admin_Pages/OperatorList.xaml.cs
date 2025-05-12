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
    /// Interaction logic for OperatorList.xaml
    /// </summary>
    public partial class OperatorList : Page
    {
        Frame _pf;//Parent Frame
        public OperatorList(Frame pf)
        {
            InitializeComponent();
            _pf = pf;
        }

        public void NavToOperInfo(object sender, RoutedEventArgs e)
        {
            int O_id = 0;
            _pf.Navigate(new OperatorInfo(_pf, O_id));
        }
    }
}
