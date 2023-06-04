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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private User _currentUser = new User();
        private Person _currentPerson = new Person();
        public AddUserPage(User selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
                _currentUser = selectedUser;

            else
                _currentUser.Person = _currentPerson;

            DataContext = _currentUser;
            ComboRoles.ItemsSource = AtelueEntities.GetContext().Roles.ToList();

            //Patronimic = AtelueEntities.GetContext().People.ToList();

        }

        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //if (string.IsNullOrWhiteSpace(_currentUser.Person.LastName))
                //errors.AppendLine("Укажите фамилию");
            //if (string.IsNullOrWhiteSpace(_currentUser.Person.FirstName))
            //    errors.AppendLine("Укажите имя");
            //if (string.IsNullOrWhiteSpace(_currentUser.Person.Patronimic))
               //errors.AppendLine("Укажите Отчество");
            if (string.IsNullOrWhiteSpace(_currentUser.LoginUser))
                errors.AppendLine("Укажите логин 'Admin', 'Master' или 'Client'");
            if (string.IsNullOrWhiteSpace(_currentUser.Paassword))
                errors.AppendLine("Пароль!");
            

            if (errors.Length>0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUser.CodeUser == 0)
                AtelueEntities.GetContext().Users.Add(_currentUser);
            //AtelueEntities.GetContext().People.Add(_currentUser);
            

            try
            {
                AtelueEntities.GetContext().SaveChanges();
                MessageBox.Show("Пользователь добавлен в базу!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
