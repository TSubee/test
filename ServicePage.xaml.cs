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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            AddServiceWindow window = new AddServiceWindow((sender as Button).DataContext as Service);
            window.ShowDialog();
        }

        private void ServiceAdd_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow window = new AddServiceWindow(null);
            window.ShowDialog();
        }

        private void ServiceDelete_Click(object sender, RoutedEventArgs e)
        {
            var servicesForRemoving = DGridService.SelectedItems.Cast<Service>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие ", " элементов?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AtelueEntities.GetContext().Services.RemoveRange(servicesForRemoving);
                    AtelueEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridService.ItemsSource = AtelueEntities.GetContext().Services.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AtelueEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridService.ItemsSource = AtelueEntities.GetContext().Services.ToList();
            }
        }
    }
}
