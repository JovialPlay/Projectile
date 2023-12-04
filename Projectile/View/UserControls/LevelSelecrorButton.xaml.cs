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

namespace Projectile.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для LevelSelecrorButton.xaml
    /// </summary>
    public partial class LevelSelecrorButton : UserControl
    {
        public LevelSelecrorButton()
        {
            InitializeComponent();
        }

        private string textname;

        private int gridNumber;

        public Color textcolor = Color.FromRgb(255, 218, 168); //FFD5A8

        public Color changecolor = Color.FromRgb(255, 255, 255);

        public int GridNumber
        {
            get { return gridNumber; }
            set
            {
                gridNumber = value;
            }
        }
        public string Textname
        {
            get { return textname; }
            set 
            { 
                textname = value; 
                WrittenText.Content = textname;
            }
        }

        public void EnterColor()
        {
            this.WrittenText.Foreground = new  SolidColorBrush (changecolor);
        }

        public void OutColor()
        {
            this.WrittenText.Foreground = new SolidColorBrush(textcolor);
        }
    }
}
