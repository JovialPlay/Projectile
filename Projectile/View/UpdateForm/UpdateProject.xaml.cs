using Projectile.View.Pages;
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

namespace Projectile.View.UpdateForm
{
    /// <summary>
    /// Логика взаимодействия для UpdateProject.xaml
    /// </summary>
    public partial class UpdateProject : Window
    {
        BoardPageViewModel bpvm {  get; set; }
        public UpdateProject(BoardPageViewModel boardPageViewModel)
        {
            InitializeComponent();
            bpvm = boardPageViewModel;
            DataContext = bpvm;
            access.ItemsSource = bpvm.ProjectsAccess;

        }

    }
}
