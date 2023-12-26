using DAL.Repository;
using Interfaces.Repository;
using Projectile.Navigation;
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

namespace Projectile.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatPage.xaml
    /// </summary>
    public partial class StatPage : Page
    {
        public StatPageViewModel ViewModel { get; set; }
        public StatPage(NavigationStore Store, DbReposSQL db, int userid)
        {          
            InitializeComponent();
            ViewModel=new StatPageViewModel(Store,db,userid);
            DataContext = ViewModel;
        }
    }
}
