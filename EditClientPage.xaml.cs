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
    public partial class EditClientPage : Page
    {
        private Client _currentClient = new Client();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public EditClientPage()
        {
            InitializeComponent();
            _currentClient = new Client();
            DataContext = _currentClient;
        }

        public EditClientPage(Client cl)
        {
            InitializeComponent();
            _currentClient = cl;
            DataContext = _currentClient;
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text))
                MessageBox.Show("Заполните пожалуйста все поля", "", MessageBoxButton.OK);
            else
            {
                if (_currentClient.c_ID == 0)
                    UkraineEntities.GetContext().Clients.Add(_currentClient);
                try
                {
                    UkraineEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.ToString()); }
                MessageBox.Show("Вы успешно добавили/изменили клиента");
                Manager.MainFrame.GoBack();
            }
        }
    }
}
