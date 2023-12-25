using Projectile.ViewModel;
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

namespace Projectile.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        public UserRegistrationFormViewModel ViewModel { get; set; }
        public UserRegistration()
        {
            InitializeComponent();
            ViewModel=new UserRegistrationFormViewModel(this);
            DataContext = ViewModel;
            PasswordBox.Password = "Password";
        }
    }
}
