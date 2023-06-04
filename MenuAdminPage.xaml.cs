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
    /// Логика взаимодействия для MenuAdminPage.xaml
    /// </summary>
    public partial class MenuAdminPage : Page
    {
        public MenuAdminPage()
        {
            InitializeComponent();
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            
            AddServiceWindow window = new AddServiceWindow(null);
            window.ShowDialog();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AtelueEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                //DGridOrder.ItemsSource = AtelueEntities.GetContext().Orders.ToList();
            }
        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Workers_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
