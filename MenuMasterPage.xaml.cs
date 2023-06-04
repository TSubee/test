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

namespace Ateler
{
    /// <summary>
    /// Логика взаимодействия для MenuMasterPage.xaml
    /// </summary>
    public partial class MenuMasterPage : Page
    {
        public MenuMasterPage()
        {
            InitializeComponent();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow window = new AddOrderWindow(null);
            window.ShowDialog();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
