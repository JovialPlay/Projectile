using Projectile.Model;
using Projectile.MVVM;
using Projectile.View.Pages;
using System.Collections.ObjectModel;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Projectile.ViewModel
{
    public class ProjectPageViewModel : ViewModelBase
    {
        public ObservableCollection<FakeProject> FakeProjects { get; set; }
        public ProjectPageViewModel(Frame frame)
        {
            FakeProjects = new ObservableCollection<FakeProject>
            {
                new FakeProject("First","FirstDescription"),
                new FakeProject("Second","SecondDescription"),
                new FakeProject("Ten","TenDescription"),
                new FakeProject("First","FirstDescription"),
                new FakeProject("Second","SecondDescription"),
                new FakeProject("Ten","TenDescription")
            };
        }

        private FakeProject selectedProject;

        public FakeProject SelectedProject
        {
            get { return selectedProject; }
            set 
            { 
                selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }
    }
}
