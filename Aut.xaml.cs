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
    public partial class Aut : Page
    {
        public Aut()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAut(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginBox.Text) && UkraineEntities.GetContext().Users.Where(x => x.u_login == LoginBox.Text).Any())
            {
                if (UkraineEntities.GetContext().Users.Where(x => x.u_login == LoginBox.Text && x.u_password == PasswordBox.Password).Any())
                {
                    var user = UkraineEntities.GetContext().Users.First(x => x.u_login == LoginBox.Text && x.u_password == PasswordBox.Password);
                    Data.Access = user.u_role;
                    Data.UserID = user.u_ID;
                    Manager.MainFrame.Navigate(new Menu());
                }
                else
                    MessageBox.Show("Пароль неправильный. Попробуйте еще раз.");
            }
            else
                MessageBox.Show("Такого пользователя не существует.");
        }

        private void BtnReg(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Reg());
        }
    }
}
