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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;

            AtelueEntities userContext = new AtelueEntities();
            

            MainFrame.Navigate(new AuthorizationPage());
            

                
        }

        private void MainframeContentRendered(object sender, EventArgs e)
        {
            if(Manager.MainFrame.NavigationService.CanGoBack==true)
            {
                back.Visibility = Visibility.Visible;
            }
            else
            {
                back.Visibility = Visibility.Collapsed;
            }
        }
        //возврат на предыдущую страницу
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
