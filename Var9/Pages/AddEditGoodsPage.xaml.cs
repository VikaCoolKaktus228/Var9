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
    /// Логика взаимодействия для AddEditGoodsPage.xaml
    /// </summary>
    public partial class AddEditGoodsPage : Page
    {
        private Product thisProduct = new Product();
            
        public AddEditGoodsPage(Product selectedproduct)
        {
            InitializeComponent();
            if (selectedproduct != null)
            {
                thisProduct = selectedproduct;
            }
            if (thisProduct.IdProduct > 0)
            {
                ArticleTb.Visibility = Visibility.Hidden;
            }
            else
            {
                DeleteButton.Visibility = Visibility.Hidden;
            }

                ComboCategory.ItemsSource = Entities2.GetContext().Category.ToList();
            ManufacturerCombo.ItemsSource = Entities2.GetContext().Manufacturer.ToList();
            UnitCombo.ItemsSource = Entities2.GetContext().Unit.ToList();
            ProductNameCombo.ItemsSource = Entities2.GetContext().ProductName.ToList();

            DataContext = thisProduct;
        }
        private void AddProduct()
        {
            try
            {
                thisProduct = new Product()
                {
                    ProductArticleNumber = ArticleTb.Text,
                    ProductNameId = ProductNameCombo.SelectedIndex + 1,
                    ProductCategory = ComboCategory.SelectedIndex + 1,
                    ProductDescription = DescriptionTb.Text,
                    ProductManufacturer = ManufacturerCombo.SelectedIndex + 1,
                    ProductCost = Convert.ToDecimal(CostTb.Text),
                    ProductDiscountAmount = Convert.ToByte(ActDiscTb.Text),
                    ProductQuantityInStock = Convert.ToInt32(OnStockTb.Text),
                    ProductStatus = 1,
                    ProductPhoto = null,
                    MaxDiscountAmount = Convert.ToByte(MaxDiscTb.Text),
                    UnitId = UnitCombo.SelectedIndex + 1,
                    Suplier = ManufacturerCombo.SelectedIndex + 1
                };
                AppConnect.ModelFish.Product.Add(thisProduct);
                AppConnect.ModelFish.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void UpdateProduct()
        {
            if (thisProduct.IdProduct > 0)
            {
                try
                {
                    thisProduct.ProductArticleNumber = thisProduct.ProductArticleNumber;
                    thisProduct.ProductNameId = ProductNameCombo.SelectedIndex + 1;
                    thisProduct.ProductCategory = ComboCategory.SelectedIndex + 1;
                    thisProduct.ProductDescription = DescriptionTb.Text;
                    thisProduct.ProductManufacturer = ManufacturerCombo.SelectedIndex + 1;
                    thisProduct.ProductCost = Convert.ToDecimal(CostTb.Text);
                    thisProduct.ProductDiscountAmount = Convert.ToByte(ActDiscTb.Text);
                    thisProduct.ProductQuantityInStock = Convert.ToInt32(OnStockTb.Text);
                    thisProduct.ProductStatus = 1;
                    thisProduct.ProductPhoto = thisProduct.ProductPhoto;
                    thisProduct.MaxDiscountAmount = Convert.ToByte(MaxDiscTb.Text);
                    thisProduct.UnitId = UnitCombo.SelectedIndex + 1;
                    thisProduct.Suplier = ManufacturerCombo.SelectedIndex + 1;
                    AppConnect.ModelFish.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new AdmininstratorPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new Authorization());
        }

        private void AddChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if(thisProduct.IdProduct == 0)
            {
                AddProduct();
                AppFrame.MainFrame.Navigate(new AdmininstratorPage());

            }
            else
            {
                UpdateProduct();
                AppFrame.MainFrame.Navigate(new AdmininstratorPage());
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Entities2.GetContext().Product.Remove(thisProduct);
                Entities2.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
