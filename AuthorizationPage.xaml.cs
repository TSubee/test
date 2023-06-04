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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            
        }
        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            AtelueEntities userContext = new AtelueEntities();
            try
            {

                var userObj = userContext.Users.Where(top => top.Paassword ==
              PasswordBox.Password && top.LoginUser ==
              LoginBox.Text).FirstOrDefault();

                if (userObj==null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.CodeRole)
                    {
                        case 1:MessageBox.Show("Здравствуйте, Администратор " + userObj.LoginUser + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 2: MessageBox.Show("Здравствуйте, Мастер " + userObj.LoginUser + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        default: MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }                      
            userContext.Dispose();
            Clean();
        }
        private void Clean()//Очищение полей авторизации
        {
            LoginBox.Text = "";
            PasswordBox.Password = "";
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
