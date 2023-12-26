using BLL;
using DAL.Repository;
using DTO;
using Projectile.MVVM;
using Projectile.Navigation;
using Projectile.View;
using Projectile.View.Pages;
using Projectile.View.UpdateForm;
using System;
using System.Collections.Generic;
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

        readonly DbReposSQL db;

        private int userid;

        private ProjectService projectService;

        private UserService userService;
        private CreateProject createProject { get; set; }

        public List<string> ProjectsAccess = new List<string> { "Приватный", "Публинчый" };
        public RelayCommand GoToBoards => new RelayCommand(execute => ChangePage((TakeProject)execute));
        public RelayCommand CreateNewProject => new RelayCommand(execute => NewProject());
        public RelayCommand SaveProject => new RelayCommand(obj => Save_Project((string)obj));

        public RelayCommand Cancel => new RelayCommand(execute => DoNotSave());

        private List<TakeProject> projects;
        public List<TakeProject> Projects 
        { get { return projects; }
          set
            {
                projects = value;
                OnPropertyChanged(nameof(Projects));
            }
        }

        public ProjectPageViewModel(NavigationStore _navigationStore, DbReposSQL context, int id)
        {
            db = context;
            projectService = new ProjectService(db);
            Projects = projectService.GetAllUsersProjects(id);
            Store = _navigationStore;
            userid = id;
            userService = new UserService(db);
        }

        private TakeProject selectedProject;
        public TakeProject SelectedProject
        {
            get { return selectedProject; }
            set 
            { 
                selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }
        public void ChangePage(TakeProject project)
        {
            Store.CurrentPage = new BoardPage(Store,db,project,userid);
        }

        public void NewProject()
        {
            SelectedProject = new TakeProject();
            SelectedProject.Name = "Имя проекта";
            SelectedProject.Owner = userService.GetSingleUser(userid).Login;
            SelectedProject.Access = "Приватный";
            SelectedProject.Description = "Описание Проекта";
            createProject = new CreateProject(this);
            createProject.ShowDialog();

        }

        public void Save_Project(string access)
        {
            SelectedProject.Access = access;
            Projects.Add(SelectedProject);
            projectService.CreateProject(SelectedProject, userid);
            SelectedProject = null;
            createProject.Close();
            Projects=projectService.GetAllUsersProjects(userid);
        }

        public void DoNotSave()
        {
            SelectedProject = null;
            createProject.Close();
        }

    }
}
