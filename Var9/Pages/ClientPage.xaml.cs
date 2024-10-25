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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            List<Product> productlist = AppConnect.ModelFish.Product.ToList();
                quantity.Content = productlist.Count + " из " + productlist.Count;
            ListProduct.ItemsSource = productlist;

            ComboSort.Items.Add("по возрастанию стоимости");
            ComboSort.Items.Add("по убыванию стоимости");
            ComboFilter.Items.Add("все диапазоны");
            ComboFilter.Items.Add("скидка 0-9,99%");
            ComboFilter.Items.Add("скидка 10-14,99%");
            ComboFilter.Items.Add("скидка > 15%");
        }
        Product[] FindProduct()
        {
            List<Product> product = AppConnect.ModelFish.Product.ToList();
            var AllProduct = product;
            if (SearchTb != null)
            {
                product = product.Where(x => x.ProductDescription.ToLower().Contains(SearchTb.Text.ToLower())).ToList();
                quantity.Content = product.Count + " из " + AllProduct.Count;
            }

            if (ComboFilter.SelectedIndex >= 0)
            {
                switch (ComboFilter.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        product = product.Where(x => x.ProductDiscountAmount >= 0 && x.ProductDiscountAmount < 10).ToList();
                        quantity.Content = product.Count + " из " + AllProduct.Count;
                        break;
                    case 2:
                        product = product.Where(x => x.ProductDiscountAmount >= 10 && x.ProductDiscountAmount < 15).ToList();
                        quantity.Content = product.Count + " из " + AllProduct.Count;
                        break;
                    case 3:
                        product = product.Where(x => x.ProductDiscountAmount >= 15).ToList();
                        quantity.Content = product.Count + " из " + AllProduct.Count;
                        break;
                }
            }
            if (ComboSort.SelectedIndex >= 0)
            {
                switch (ComboSort.SelectedIndex)
                {
                    case 0:
                        product = product.OrderBy(x => x.ProductCost).ToList();
                        quantity.Content = product.Count + " из " + AllProduct.Count;
                        break;
                    case 1:
                        product = product.OrderByDescending(x => x.ProductCost).ToList<Product>();
                        quantity.Content = product.Count + " из " + AllProduct.Count;
                        break;
                }
            }
            ListProduct.ItemsSource = product;
            return product.ToArray();

        }

        private void SearchTb_KeyDown(object sender, KeyEventArgs e)
        {
            FindProduct();
        }

        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindProduct();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindProduct();
        }

        private void ExitBtton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new Authorization());
        }
    }
}
