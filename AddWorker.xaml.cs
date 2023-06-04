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
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Page
    {
        public AddWorker()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AtelueEntities userContext = new AtelueEntities();

            if (userContext.Users.Count(x => x.LoginUser == Login.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                User userObj = new User()
                {
                    LoginUser = Login.Text,
                    //Name =;
                    Paassword =tPass.Text,
                    CodeRole = 2
                };
                AtelueEntities.GetContext().Users.Add(userObj);

                //userContext.Users.Add(userObj);
                

                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pass.Password!=tPass.Text)
            {
                Add.IsEnabled = false;
                pass.Background = Brushes.LightCoral;
                pass.BorderBrush = Brushes.Red;
            }
            else
            {
                Add.IsEnabled = true;
                pass.Background = Brushes.LightGreen;
                pass.BorderBrush = Brushes.Green;
            }
        }
    }
}
