using Projectile.Model;
using Projectile.MVVM;
using Projectile.Navigation;
using Projectile.View;
using Projectile.View.Pages;
using System.Collections.ObjectModel;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Projectile.ViewModel
{
    public class ProjectPageViewModel : ViewModelBase
    {
        readonly NavigationStore Store;
        public RelayCommand GoToBoards => new RelayCommand(execute => ChangePage());
        public ObservableCollection<FakeProject> FakeProjects { get; set; }
        public ProjectPageViewModel(NavigationStore _navigationStore)
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
            Store = _navigationStore;
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
        public void ChangePage()
        {
            Store.CurrentPage = new BoardPage();
        }
    }
}
