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
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRegg(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Login.Text) && !UkraineEntities.GetContext().Users.Where(x => x.u_login == Login.Text).Any())
            {
                User user = new User();
                user.u_login = Login.Text;
                user.u_password = Password.Password;
                UkraineEntities.GetContext().Users.Add(user);
                UkraineEntities.GetContext().SaveChanges();
                MessageBox.Show("Вы успешно зарегестрировались.");
                Manager.MainFrame.GoBack();
            }
            else
            {
                MessageBox.Show("Такой пользователь уже существует.");
            }
        }
    }
}
