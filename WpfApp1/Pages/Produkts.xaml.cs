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
    /// Логика взаимодействия для Produkts.xaml
    /// </summary>
    public partial class Produkts : Page
    {
        public Produkts()
        {
            InitializeComponent();
            List<Лист3_> products = AppConnect.model1.Лист3_.ToList();

            listprodukts.ItemsSource = products;

            if (products.Count > 0)
            {
                tbCounter.Text = "Найдено " + products.Count + " товаров";
            }
            else
            {
                tbCounter.Text = "Не найдено";
            }
        }
    }
}
