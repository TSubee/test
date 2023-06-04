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
    /// Логика взаимодействия для ServiceForClientPage.xaml
    /// </summary>
    public partial class ServiceForClientPage : Page
    {
        public ServiceForClientPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AtelueEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridServiceClient.ItemsSource = AtelueEntities.GetContext().Services.ToList();
            }
        }
    }
}
