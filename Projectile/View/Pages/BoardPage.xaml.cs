using DAL.Repository;
using DTO;
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
    /// Логика взаимодействия для BoardPage.xaml
    /// </summary>
    public partial class BoardPage : Page
    {
        public BoardPage(NavigationStore ns, DbReposSQL db, TakeProject project, int userid)
        {
            InitializeComponent();
            BoardPageViewModel boardPageViewModel = new BoardPageViewModel(ns,db,project,userid);
            DataContext = boardPageViewModel;
        }
    }
}
