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
using System.Windows.Shapes;

namespace Ateler
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        private Order _currentOrder = new Order();
        public AddOrderWindow(Order selectedOrder)
        {
            InitializeComponent();

            if (selectedOrder != null)
                _currentOrder = selectedOrder;
            
            DataContext = _currentOrder;

            ComboServices.ItemsSource = AtelueEntities.GetContext().Services.ToList();
            ComboPeople.ItemsSource = AtelueEntities.GetContext().People.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentOrder.Description))
                errors.AppendLine("Укажите описание");

            _currentOrder.DateOrder = DOrder.SelectedDate;
            _currentOrder.DateFitting = DFitting.SelectedDate;
            _currentOrder.DateReady = DReady.SelectedDate;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentOrder.CodeOrder == 0)
                AtelueEntities.GetContext().Orders.Add(_currentOrder);

            try
            {
                AtelueEntities.GetContext().SaveChanges();
                MessageBox.Show("Заказ добавлен в базу!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
    

