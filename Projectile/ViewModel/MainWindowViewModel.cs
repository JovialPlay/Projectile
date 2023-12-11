using Projectile.MVVM;
using Projectile.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Projectile.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        Frame frame {  get; set; }
        private ProjectPage projectPage { get; set; }

        private BoardPage boardPage { get; set; }

        private TodayPage todayPage { get; set; }
        public MainWindowViewModel(Frame f)
        {
            frame = f;
            projectPage=new ProjectPage(frame);
            boardPage=new BoardPage();
            todayPage=new TodayPage();
        }

        public RelayCommand ChangeViewToProjects => new RelayCommand(execute => ChangePage(projectPage));
        public RelayCommand ChangeViewToBoards => new RelayCommand(execute => ChangePage(boardPage));
        public RelayCommand ChangeViewToTodday => new RelayCommand(execute => ChangePage(todayPage));

        public void ChangePage(object Page)
        {
            frame.Navigate(Page);
        }
    }
}
