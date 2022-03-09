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
    public partial class EditTypePage : Page
    {
        private AdvertType _currentType;

        public EditTypePage()
        {
            InitializeComponent();
            _currentType = new AdvertType();
            DataContext = _currentType;
        }

        public EditTypePage(AdvertType sv)
        {
            InitializeComponent();
            _currentType = sv;
            DataContext = _currentType;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(type.Text) || string.IsNullOrWhiteSpace(cost.Text))
                MessageBox.Show("Заполните пожалуйста все поля", "", MessageBoxButton.OK);
            else
            {
                if (_currentType.a_ID == 0)
                    UkraineEntities.GetContext().AdvertTypes.Add(_currentType);
                try
                {
                    UkraineEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.ToString()); }
                MessageBox.Show("Вы успешно добавили/изменили тип");
                Manager.MainFrame.GoBack();
            }
        }
    }
}
