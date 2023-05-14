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
using System.Windows.Shapes;
using ООО__Ароматный_мир_.Model;

namespace ООО__Ароматный_мир_.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditAndAddWindow.xaml
    /// </summary>
    public partial class EditAndAddWindow : Window
    {
        public EditAndAddWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CategoryCombo.ItemsSource = user_7_20P3Context.Context.Categories.Select(x=>x.NameCategory).ToList();
            ManufactureCombo.ItemsSource = user_7_20P3Context.Context.Manufactures.Select(x => x.NameManufacture).ToList();
            Supplier.ItemsSource = user_7_20P3Context.Context.Suppliers.Select(x => x.NameSupplier).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(ArticleText.Text) && !string.IsNullOrEmpty(NameProductText.Text) && !string.IsNullOrEmpty(DescriptionText.Text) 
                && !string.IsNullOrEmpty(CostText.Text) && !string.IsNullOrEmpty(DiscountText.Text) &&
                CategoryCombo.SelectedItem!=null && !string.IsNullOrEmpty(CountInStockText.Text) && ManufactureCombo.SelectedItem!=null && Supplier.SelectedItem!=null)
            {
                Product product = new Product
                {
                    ProductArticleNumber = ArticleText.Text,
                    ProductName = NameProductText.Text,
                    ProductDescription = DescriptionText.Text,
                    ProductCost = Convert.ToDecimal(CostText.Text),
                    ProductDiscountAmount = Convert.ToDecimal(DiscountText.Text),
                    MaxDiscount = Convert.ToDecimal(MaxDiscountText.Text),
                    ProductManufacturer = ManufactureCombo.SelectedIndex+1,
                    Supplier = Supplier.SelectedIndex + 1,
                    ProductCategory = CategoryCombo.SelectedIndex + 1,
                };

                user_7_20P3Context.Context.Products.Add(product);
                user_7_20P3Context.Context.SaveChanges();
                MessageBox.Show("Добавлено");
            } 
        }
    }
}
