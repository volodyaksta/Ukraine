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
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientPage());
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new OrderPage());
        }

        private void BtnType_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TypePage());
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BtnType.Visibility = Data.isAdmin() ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
