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
    /// Логика взаимодействия для AutorisationWindow.xaml
    /// </summary>
    public partial class AutorisationWindow : Window
    {
        public AutorisationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(LoginText.Text) && !string.IsNullOrEmpty(PasswordText.Password))
            {
                var User = user_7_20P3Context.Context.Users.FirstOrDefault(x=>x.UserLogin==LoginText.Text && x.UserPassword==PasswordText.Password);
                if(User!=null)
                {
                    ProductWindow productWindow = new ProductWindow();
                    GlobalClass.Name = User.UserName;
                    GlobalClass.SurName = User.UserSurname;
                    GlobalClass.Patronomyc = User.UserPatronymic;
                    GlobalClass.RoleId = User.UserRole;
                    productWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не верные данные");
                }
            }
            else
            {
                MessageBox.Show("Пустые поля");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();
            productWindow.Show();
            this.Close();
        }
    }
}
