using Projectile.View.UserControls;
using Projectile.View.UserLayouts;
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

namespace Projectile
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Today_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ProjectsBar.Visibility = Visibility.Collapsed;
            TasksBar.Visibility = Visibility.Collapsed;
            TodayBar.Visibility = Visibility.Visible;
            BoardBar.Visibility = Visibility.Collapsed;
        }

        private void Projects_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProjectsBar.Visibility = Visibility.Visible;
            TasksBar.Visibility = Visibility.Collapsed;
            TodayBar.Visibility = Visibility.Collapsed;
            BoardBar.Visibility = Visibility.Collapsed;
        }

        private void Boards_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProjectsBar.Visibility = Visibility.Collapsed;
            TasksBar.Visibility = Visibility.Collapsed;
            TodayBar.Visibility = Visibility.Collapsed;
            BoardBar.Visibility = Visibility.Visible;
        }

        private void Cards_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProjectsBar.Visibility = Visibility.Collapsed;
            TasksBar.Visibility = Visibility.Visible;
            TodayBar.Visibility = Visibility.Collapsed;
            BoardBar.Visibility = Visibility.Collapsed;
        }

        private void Today_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Today_Loaded_1()
        {

        }

        private void PanelMouseEnter(object sender, MouseEventArgs e)
        {
            LevelSelecrorButton obj = (LevelSelecrorButton)sender;
            obj.EnterColor();
        }
        private void PanelMouseOut(object sender, MouseEventArgs e)
        {
            LevelSelecrorButton obj = (LevelSelecrorButton)sender;
            obj.OutColor();
        }

        public void Menu_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (!UpMenu.SendNavi())
            {
                Navigation.Visibility = Visibility.Collapsed;
            }
            else
            {
                Navigation.Visibility = Visibility.Visible;
            }
        }
    }
}
