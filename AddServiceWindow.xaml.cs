using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ateler
{
    /// <summary>
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        private Service _currentService = new Service();
        public AddServiceWindow(Service selectedService)
        {
            InitializeComponent();

            if (selectedService != null)
                _currentService = selectedService;

            DataContext = _currentService;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var inputPrice = Price.Text;
            var number = new Regex(@"[0-9]+");
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentService.ServiceName))
                errors.AppendLine("Укажите название услуги");
            if (!number.IsMatch(inputPrice))
                errors.AppendLine("Укажите цену услуги");           

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentService.CodeService == 0)
                AtelueEntities.GetContext().Services.Add(_currentService);

            try
            {
                _currentService.Price = Int32.Parse(inputPrice);
                AtelueEntities.GetContext().SaveChanges();
                MessageBox.Show("Услуга добавлена в базу!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
    

