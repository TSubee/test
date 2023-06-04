using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    { 
        public AdminPage()
        {
            InitializeComponent();
        }

        private void BEditClick(object sender, RoutedEventArgs e)
        {
            AddUserWindow window = new AddUserWindow((sender as Button).DataContext as User);
            window.ShowDialog();           
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow window = new AddUserWindow(null);
            window.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DGridAdmin.SelectedItems.Cast<User>().ToList();
        
            if(MessageBox.Show($"Вы точно хотите удалить следующие ", " элементов?",MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                try
                {
                    AtelueEntities.GetContext().Users.RemoveRange(usersForRemoving);
                    AtelueEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridAdmin.ItemsSource = AtelueEntities.GetContext().Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility==Visibility.Visible)
            {
                AtelueEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridAdmin.ItemsSource = AtelueEntities.GetContext().Users.ToList();
            }
        }
        private void service_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ServicePage());
        }  
    }
}
 