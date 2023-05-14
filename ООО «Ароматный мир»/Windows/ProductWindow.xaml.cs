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
using ООО__Ароматный_мир_.Windows;

namespace ООО__Ароматный_мир_.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();
        }

        int Count = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();

            Count = listProduct.Items.Count;
            CountListText.Text = listProduct.Items.Count.ToString() + " из " + Count.ToString();

            if(!string.IsNullOrEmpty(GlobalClass.Name))
            {
                ClietnText.Text = GlobalClass.Name + " " + GlobalClass.SurName+" "+GlobalClass.Patronomyc;
                if(GlobalClass.RoleId!=1)
                {
                    AddBtn.Visibility = Visibility;
                    contextMenu.Visibility = Visibility;
                }
            }
        }

        public void RefreshList()
        {
            var list = user_7_20P3Context.Context.Products.ToList();

            user_7_20P3Context.Context.Products.ToList().ForEach(x => user_7_20P3Context.Context.Entry(x).Reload());

            if(FiltrCombo.SelectedValue!=null)
            {
                switch(FiltrCombo.SelectedIndex)
                {
                    case 1:
                        list = list.Where(x=>x.ProductDiscountAmount>0 && x.ProductDiscountAmount<=2).ToList();
                        break;
                    case 2:
                        list = list.Where(x => x.ProductDiscountAmount > 2 && x.ProductDiscountAmount <= 4).ToList();
                        break;
                    case 3:
                        list = list.Where(x => x.ProductDiscountAmount > 4).ToList();
                        break;
                }
            }

            if (SortCombo.SelectedValue != null)
            {
                switch (SortCombo.SelectedIndex)
                {
                    case 0:
                        list = list.OrderBy(x=>x.ProductCost).ToList();
                        break;
                    case 1:
                        list = list.OrderByDescending(x => x.ProductCost).ToList();
                        break;
                
                }
            }

            if(!string.IsNullOrEmpty(SearchText.Text))
            {
                list = list.Where(x =>x.ProductName.ToLower().Contains(SearchText.Text.ToLower()) ).ToList();
            }

            listProduct.ItemsSource = list;
            CountList();
        }

        public void CountList()
        {
            if(listProduct.Items.Count==0)
            {
                CountListText.Text = "Нет записей";
            }
            else
            {
                CountListText.Text = listProduct.Items.Count.ToString() + " из " + Count.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutorisationWindow autorisationWindow = new AutorisationWindow();
            GlobalClass.Name = null;
            GlobalClass.SurName = null;
            GlobalClass.Patronomyc = null;
            GlobalClass.RoleId = null;
            autorisationWindow.Show();
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshList();
        }

        private void FiltrCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }

        private void SortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if(listProduct.SelectedValue!=null)
            {
                var items = (dynamic)listProduct.SelectedItem;
                string Article = items.ProductArticleNumber;

                if (user_7_20P3Context.Context.Orderproducts.Where(x => x.ProductArticleNumber == Article).ToList().Count == 0)
                {
                    if (MessageBox.Show("Вы точно хотите удалить продукт", "Удаление продукта", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var itemsDelet = user_7_20P3Context.Context.Products.FirstOrDefault(x => x.ProductArticleNumber == Article);
                        user_7_20P3Context.Context.Products.Remove(itemsDelet);
                        user_7_20P3Context.Context.SaveChanges();
                        MessageBox.Show("Продукт удалён");
                    }
                }
                else MessageBox.Show("Этот продукт уже заказан");
            }
           
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            EditAndAddWindow editAndAddWindow = new EditAndAddWindow();
            editAndAddWindow.Show();
            this.Close();
        }
    }
}
