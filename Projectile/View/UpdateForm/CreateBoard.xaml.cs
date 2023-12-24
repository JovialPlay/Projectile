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
    /// Логика взаимодействия для CreateBoard.xaml
    /// </summary>
    public partial class CreateBoard : Window
    {
        public CreateBoard(BoardPageViewModel bpvm)
        {
            InitializeComponent();
            DataContext = bpvm;
        }
    }
}
