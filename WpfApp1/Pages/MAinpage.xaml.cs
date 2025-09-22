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
using WpfApp1.ApplicationData;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для MAinpage.xaml
    /// </summary>

    
    public partial class MAinpage : Page
    {
        public MAinpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.model1.users.FirstOrDefault(x =>
                    x.Login == login.Text &&
                    x.Password == password.Password);

                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.Role)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, Администратор " + userObj.name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Produkts ffsfff = new Produkts();
                            NavigationService.Navigate(ffsfff);
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, Менеджер " + userObj.name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Produkts ffsf = new Produkts();
                            NavigationService.Navigate(ffsf);
                            break;
                        case 3:
                            MessageBox.Show("Здравствуйте, пользователь " + userObj.name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                             Produkts ffsff = new Produkts();
                            NavigationService.Navigate(ffsff);
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message + ". Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
