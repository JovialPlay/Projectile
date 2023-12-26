using BLL;
using DAL.Repository;
using DTO;
using Projectile.MVVM;
using Projectile.Navigation;
using Projectile.View.Pages;
using Projectile.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Projectile.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public NavigationStore NavigationStore { get; set; }
        public DbReposSQL db { get; set; }
        public Frame MainFrame { get; set; }
        public UserForm userForm { get; set; }

        public TakeUser User { get; set; }
        private UserService userService { get; set; }

        public RelayCommand Home => new RelayCommand(execute => HomeClick());
        public RelayCommand OpenHelp => new RelayCommand(execute => HelpClick());
        public RelayCommand GoToJobs => new RelayCommand(execute => JobsClick());
        public RelayCommand ShowUser => new RelayCommand(execute => UserClick());
        public RelayCommand Out => new RelayCommand(execute => OutClick((Window)execute));
        public RelayCommand ShowStat => new RelayCommand(execute => ShowStatClick());

        public Page CurrentPage => NavigationStore._currentPage;
        public MainWindowViewModel (Frame mainFrame, int id)
        {
            db = new DbReposSQL ();
            NavigationStore = new NavigationStore();
            NavigationStore.CurrentPageChanged += OnCurrentPageChanged;
            MainFrame = mainFrame;
            userService=new UserService(db);
            User = userService.GetSingleUser(id);
            NavigationStore.CurrentPage = new ProjectPage(NavigationStore,db, User.Id);
        }

        private void OnCurrentPageChanged()
        {
            OnPropertyChanged(nameof(CurrentPage));
            MainFrame.Navigate(CurrentPage);
        }

        public void HomeClick()
        {
           NavigationService navigation = MainFrame.NavigationService;
           while (navigation.CanGoBack)
           {
               navigation.RemoveBackEntry();
           }
            NavigationStore.ChangePage(new ProjectPage(NavigationStore, db,User.Id));
        }

        public void HelpClick()
        {
            Help h=new Help();
            h.ShowDialog();
        }

        public void JobsClick()
        {
            NavigationStore.ChangePage(new UserJobPage(NavigationStore,db, User.Id));
        }

        public void UserClick()
        {
            userForm=new UserForm(this);
            userForm.ShowDialog();
        }
        public void OutClick(Window window)
        {
            UserRegistration userRegistration = new UserRegistration();
            userRegistration.Show();
            Application.Current.Shutdown();
        }

        public void ShowStatClick()
        {
            NavigationStore.ChangePage(new StatPage(NavigationStore, db, User.Id));
        }
    }
}
