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
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            OrFilter.ItemsSource = UkraineEntities.GetContext().AdvertTypes.GroupBy(x => x.a_type).Select(x => x.Key).ToList();
            OrSorting.ItemsSource = new List<string>
            {
                "Клиент", "Тип", "Менеджер", "Длительность", "Стоимость", "Дата"
            };
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridOrder.ItemsSource = UkraineEntities.GetContext().Orders.ToList();
        }

        private void BtnEd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditOrderPage((sender as Button).DataContext as Order));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditOrderPage());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var orderForRemoving = DGridOrder.SelectedItems.Cast<Order>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие { orderForRemoving.Count() } элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    UkraineEntities.GetContext().Orders.RemoveRange(orderForRemoving);
                    UkraineEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены.");
                    DGridOrder.ItemsSource = UkraineEntities.GetContext().Orders.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + ex.StackTrace.ToString());
                }
        }

        private void OrFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DGridOrder.ItemsSource = UkraineEntities.GetContext().Orders.Where(x => x.AdvertType.a_type == OrFilter.SelectedItem.ToString()).ToList();
        }

        private void OrSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = DGridOrder.ItemsSource.Cast<Order>().ToList();
            switch (OrSorting.SelectedItem.ToString())
            {
                case "Клиент":
                    DGridOrder.ItemsSource = list.OrderBy(x => x.Client.c_name);
                    break;
                case "Тип":
                    DGridOrder.ItemsSource = list.OrderBy(x => x.AdvertType.a_type);
                    break;
                case "Менеджер":
                    DGridOrder.ItemsSource = list.OrderBy(x => x.User.u_ID);
                    break;
                case "Длительность":
                    DGridOrder.ItemsSource = list.OrderBy(x => x.o_durationInSecond);
                    break;
                case "Стоимость":
                    DGridOrder.ItemsSource = list.OrderBy(x => x.o_cost);
                    break;
                case "Дата":
                    DGridOrder.ItemsSource = list.OrderBy(x => x.o_date);
                    break;
            }
        }

        private void OrFind_SelectionChanged(object sender, RoutedEventArgs e)
        {
            DGridOrder.ItemsSource = UkraineEntities.GetContext().Orders.Where(x => x.Client.c_name.ToLower().Contains(OrFind.Text.ToLower())).ToList();
        }
    }
}
