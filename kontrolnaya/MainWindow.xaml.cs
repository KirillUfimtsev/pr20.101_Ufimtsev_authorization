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

namespace kontrolnaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            { 
                MessageBox.Show("Введите все поля");

                return;
            }

            var db = kontrolnayaEntities.GetContext();
            User user;

            try
            {
                  user = db.User.First(p => p.login == login);
            }
            catch
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }

            Role role = db.Role.First(p => p.idRole == user.idRole);
            
            if(user.password == password)
            {
                MessageBox.Show($"Вы авторизировались, ваша роль: {role.Name}");
                return;
            }

            else
            {
                MessageBox.Show("Неверный пароль");
                return;
            }
            

            
            

        }
    }
}
