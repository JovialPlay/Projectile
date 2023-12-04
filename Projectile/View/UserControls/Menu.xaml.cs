using Projectile.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

namespace Projectile.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        bool Navi = true;
        public void OutColor(object sender, RoutedEventArgs e)
        {
            Image obj= (Image)sender;
            obj.Opacity = 1;
        }
        public void EnterColor(object sender, RoutedEventArgs e) 
        {
            Image obj = (Image)sender;
            obj.Opacity = 0.3;
        }
        public void ShowHideNavigation()
        {
            Navi=!Navi;
        }

        public bool SendNavi() 
        {
            return Navi;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }
    }

}
