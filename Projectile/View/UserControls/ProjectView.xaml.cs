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
    /// Логика взаимодействия для ProjectView.xaml
    /// </summary>
    public partial class ProjectView : UserControl
    {
        public ProjectView()
        {
            InitializeComponent();
        }

        private string projectname;
        private string projectdescription;
        
        public string Projectname
        { 
            get { return projectname; }
            set 
            { 
                projectname = value; 
                ProjectLabel.Content = projectname;
            }
        }
        public string Projectdescription
        { get { return projectdescription; } 
            set 
            { 
            projectdescription = value;
            ProjectDescriptionl.Content = projectdescription;
            }
        }

        private void ProjectLabel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ProjectLabel.FontSize = e.NewSize.Height-e.NewSize.Width/17-2;
        }
    }
}
