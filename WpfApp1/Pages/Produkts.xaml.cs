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
using static System.Data.Entity.Infrastructure.Design.Executor;

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
            
            discauntcombo.Items.Add("Время");
            discauntcombo.Items.Add("по возрастанию");
            discauntcombo.Items.Add("по убыванию");
            //discauntcombo.SelectedIndex = 0;

            catecoriacombo.SelectedIndex = 0;
            var category = AppConnect.model1.kategory;
            catecoriacombo.Items.Add("Категория");
            foreach (var item in category)
            {
                catecoriacombo.Items.Add(item.name);
            }
            

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

        private void discauntcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void catecoriacombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void textsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }
        private void UpdateProducts()
        {
            var products = FindProduct();
            listprodukts.ItemsSource = products;
        }
        public Лист3_[] FindProduct()
        {
            // В переменную product записываем список из таблицы Product
            var product = AppConnect.model1.Лист3_.ToList();
            var productall = product;

            // Поиск по названию ProductName1
            if (textsearch != null && !string.IsNullOrEmpty(textsearch.Text))
            {
                product = product.Where(x => x.discription.ToLower().Contains(textsearch.Text.ToLower())).ToList();
            }

            // Фильтрация по скидке
            if (discauntcombo.SelectedIndex > 0)
            {
                switch (discauntcombo.SelectedIndex)
                {
                    case 1:
                        product = product.OrderBy(x => x.discount).ToList(); break;
                    case 2:
                        product = product.OrderByDescending(x => x.discount).ToList();
                        break;

                }
            }

            //// Сортировка по возрастанию и убыванию цены
            //if (ComboSort.SelectedIndex > 0)
            //{
            //    switch (ComboSort.SelectedIndex)
            //    {
            //        case 1:
            //            product = product.OrderBy(x => x.ProductCost).ToList();
            //            break;
            //        case 2:
            //            product = product.OrderByDescending(x => x.ProductCost).ToList();
            //            break;
            //    }
            //}
            if (catecoriacombo.SelectedIndex > 0)
            {
                // Предположим, что в ComboCategory загружены объекты Category, и мы хотим выбрать продукты с id_category равным выбранной категории
                var selectedCategory = catecoriacombo.SelectedIndex;
                product = product.Where(x => x.id_catekoria == selectedCategory).ToList();
            }

            // Количество элементов найденных
            //if (product.Count > 0)
            //{
            //    LabelCount.Content = "Найдено " + product.Count + " из " + productall.Count;
            //}
            //else
            //{
            //    LabelCount.Content = "Ничего не найдено";
            //}

            return product.ToArray();
        }
    }
}
