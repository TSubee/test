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
    /// Логика взаимодействия для MasterPage.xaml
    /// </summary>
    public partial class MasterPage : Page
    {
        public MasterPage()
        {
            InitializeComponent();
        }
        private void BEditClick(object sender, RoutedEventArgs e)
        {
            AddOrderWindow window = new AddOrderWindow((sender as Button).DataContext as Order);
            window.ShowDialog();           
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow window = new AddOrderWindow(null);
            window.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var ordersForRemoving = DGridOrder.SelectedItems.Cast<Order>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие ", " элементов?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AtelueEntities.GetContext().Orders.RemoveRange(ordersForRemoving);
                    AtelueEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridOrder.ItemsSource = AtelueEntities.GetContext().Orders.ToList();
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
                DGridOrder.ItemsSource = AtelueEntities.GetContext().Orders.ToList();
            }
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientListPage());
        }
    }
}
