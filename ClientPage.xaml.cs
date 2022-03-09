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
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridClient.ItemsSource = UkraineEntities.GetContext().Clients.ToList();
            BtnDel.Visibility = Data.isAdmin() ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnEd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditClientPage((sender as Button).DataContext as Client));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditClientPage());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var clientForRemoving = DGridClient.SelectedItems.Cast<Client>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие { clientForRemoving.Count() } элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    UkraineEntities.GetContext().Clients.RemoveRange(clientForRemoving);
                    UkraineEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены.");
                    DGridClient.ItemsSource = UkraineEntities.GetContext().Clients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + ex.StackTrace.ToString());
                }
        }
    }
}
