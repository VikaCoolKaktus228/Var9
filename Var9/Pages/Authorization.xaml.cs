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
using Var9.ApplicationData;

namespace Var9.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            var userobj = AppConnect.ModelFish.User.FirstOrDefault(x => x.UserLogin == LoginTb.Text && x.UserPassword == PasswordPb.Password);
            if (userobj != null)
            {
                try
                {
                    var password = AppConnect.ModelFish.User.FirstOrDefault(x => x.UserPassword == PasswordPb.Password);
                    if (password == null)
                    {
                        MessageBox.Show("неверный пароль",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                        switch (userobj.UserRole)
                        {
                            case 1:
                                MessageBox.Show("здраствйте администратор " + userobj.UserLogin,
                        "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                AppFrame.MainFrame.Navigate(new AdmininstratorPage(/*(sender as Button).DataContext as User)*/));
                                break;
                            case 2:
                                MessageBox.Show("здраствйте пользователь " + userobj.UserLogin,
                        "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                AppFrame.MainFrame.Navigate(new ClientPage());
                                break;
                            case 3:
                                MessageBox.Show("здраствйте менеджер " + userobj.UserLogin,
                        "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                AppFrame.MainFrame.Navigate(new ManagerPage());
                                break;

                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + ex.Message.ToString(),
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
            }
        }
    }
}
