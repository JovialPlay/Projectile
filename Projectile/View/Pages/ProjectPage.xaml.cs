﻿using Projectile.Navigation;
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
    /// Логика взаимодействия для ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        ProjectPageViewModel ppvm {  get; set; }
        public ProjectPage(NavigationStore navigationStore)
        {
            InitializeComponent();
            ppvm = new ProjectPageViewModel(navigationStore);
            ProjectTemplate.ItemsSource = ppvm.FakeProjects;
            ProjectTemplate.DataContext = ppvm;
            DataContext=ppvm;
        }
    }
}
