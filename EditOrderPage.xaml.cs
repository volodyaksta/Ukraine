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

namespace Ukraine
{
    public partial class EditOrderPage : Page
    {
        private Order _currentOrder;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public EditOrderPage()
        {
            InitializeComponent();
            _currentOrder = new Order();
            DataContext = _currentOrder;
            ComboClient.ItemsSource = UkraineEntities.GetContext().Clients.ToList();
            ComboType.ItemsSource = UkraineEntities.GetContext().AdvertTypes.ToList();
            ComboUser.ItemsSource = UkraineEntities.GetContext().Users.ToList();
        }

        public EditOrderPage(Order sv)
        {
            InitializeComponent();
            _currentOrder = sv;
            DataContext = _currentOrder;
            ComboClient.ItemsSource = UkraineEntities.GetContext().Clients.ToList();
            ComboType.ItemsSource = UkraineEntities.GetContext().AdvertTypes.ToList();
            ComboUser.ItemsSource = UkraineEntities.GetContext().Users.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ComboClient.Text) || string.IsNullOrWhiteSpace(ComboType.Text) || string.IsNullOrWhiteSpace(ComboUser.Text) || string.IsNullOrWhiteSpace(o_durationInSecond.Text) || string.IsNullOrWhiteSpace(o_cost.Text))
                MessageBox.Show("Заполните пожалуйста все поля", "", MessageBoxButton.OK);
            else
            {
                if (_currentOrder.o_ID == 0)
                    UkraineEntities.GetContext().Orders.Add(_currentOrder);
                try
                {
                    UkraineEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.ToString()); }
                MessageBox.Show("Вы успешно добавили/изменили заказ");
                Manager.MainFrame.GoBack();
            }
        }
    }
}
