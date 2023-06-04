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
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        public WorkersPage()
        {
            InitializeComponent();
        }

        private void SearchTbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtelueEntities userContext = new AtelueEntities();

            try
            {
                UsersListView.ItemsSource = userContext.Users.Where(Item => Item.LoginUser == SearchTbox.Text || Item.LoginUser.Contains(SearchTbox.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }
    }
}
