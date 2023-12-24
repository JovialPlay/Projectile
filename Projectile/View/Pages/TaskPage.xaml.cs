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
    /// Логика взаимодействия для TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        TaskPageViewModel TPVM;
        public TaskPage(NavigationStore store, DbReposSQL db, TakeBoard ownerBoard)
        {
            InitializeComponent();
            TPVM = new TaskPageViewModel(store, db, ownerBoard);
            DataContext = TPVM;
            TasksBar.CardTemplate.ItemsSource = TPVM.Cards;
        }
    }
}
