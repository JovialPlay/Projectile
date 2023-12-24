﻿using DAL.Repository;
using Projectile.MVVM;
using Projectile.Navigation;
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
        public NavigationStore NavigationStore { get; set; }
        public RelayCommand Home => new RelayCommand(execute => HomeClick());
        public DbReposSQL db {  get; set; }
        public Frame MainFrame { get; set; }
        public Page CurrentPage => NavigationStore._currentPage;
        public MainWindowViewModel (Frame mainFrame)
        {
            db = new DbReposSQL ();
            NavigationStore = new NavigationStore();
            NavigationStore.CurrentPageChanged += OnCurrentPageChanged;
            MainFrame = mainFrame;
            NavigationStore.CurrentPage = new ProjectPage(NavigationStore,db);
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
            NavigationStore.ChangePage(new ProjectPage(NavigationStore, db));
        }

    }
}
