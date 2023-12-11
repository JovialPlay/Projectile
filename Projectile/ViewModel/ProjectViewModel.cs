using Projectile.MVVM;
using Projectile.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projectile.ViewModel
{
    public class ProjectViewModel : ViewModelBase
    {
        private Frame frame {  get; set; }
        public RelayCommand ChangeViewToBoards => new RelayCommand(execute => frame.Navigate(new BoardPage()));
    }
}
