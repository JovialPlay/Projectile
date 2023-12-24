using Projectile.MVVM;
using Projectile.Navigation;
using Projectile.View;
using Projectile.View.Pages;
using Projectile.View.UserControls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projectile
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel mainWindowViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            mainWindowViewModel = new MainWindowViewModel(MainFrame);
            DataContext = mainWindowViewModel;
        }
    }
}
