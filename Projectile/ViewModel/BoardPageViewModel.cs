using BLL;
using BLL.Services;
using DAL.Repository;
using DTO;
using Interfaces.Services;
using Projectile.MVVM;
using Projectile.Navigation;
using Projectile.View.Pages;
using Projectile.View.UpdateForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectile.ViewModel
{
    public class BoardPageViewModel : ViewModelBase
    {
        readonly NavigationStore Store;

        readonly DbReposSQL db;

        private UpdateProject updateProject;

        private ProjectService projectService;

        public RelayCommand GoToTasks => new RelayCommand(execute => ChangePage((TakeBoard)execute));

        public List<string> ProjectsAccess = new List<string> { "Приватный", "Публичный" };
        public RelayCommand ChangeProject => new RelayCommand(execute => ChangeProjectSettings());
        public RelayCommand DeleteCurrentProject => new RelayCommand(execute => DeleteProject());
        public RelayCommand UpdateCurrentProject => new RelayCommand(execute => UpdateProject());
        public RelayCommand Cancel => new RelayCommand(execute => DoNotSaveProject());

        public UserService userService;
        public TakeProject OwnerProject { get; set; }

        private CreateBoard createBoard;

        public string userstring { get; set;  }
        public RelayCommand CreateBoardClick => new RelayCommand(execute => NewBoard());
        public RelayCommand CancelBoard => new RelayCommand(execute => DoNotSaveBoard());
        public RelayCommand CreateBoard => new RelayCommand(execute => BoardToDb(userstring));
        public BoardService boardService {  get; set; }
        public List<TakeBoard> Boards { get; set; }

        public BoardPageViewModel(NavigationStore _navigationStore, DbReposSQL context, TakeProject ownerProject)
        {
            Store = _navigationStore;
            db = context;
            boardService = new BoardService(db);
            projectService = new ProjectService(db);
            userService = new UserService(db);
            Store = _navigationStore;
            OwnerProject = ownerProject;
            Boards = boardService.GetProjectBoards(ownerProject.Id);
        }
        public void ChangePage(TakeBoard board)
        {
            Store.CurrentPage = new TaskPage(Store, db, board);
        }
        public void ChangeProjectSettings()
        {
            updateProject = new UpdateProject(this);
            updateProject.ShowDialog();
        }

        public void UpdateProject()
        {
            projectService.UpdateProject(OwnerProject, 1);
            updateProject.Close();
        }
        public void DeleteProject()
        {
            projectService.DeleteProject(OwnerProject.Id);
            Store.ChangePage(new ProjectPage(Store,db));
        }
        public void DoNotSaveProject()
        {
            updateProject.Close();
        }

        private TakeBoard selectedBoard;
        public TakeBoard SelectedBoard
        {
            get { return selectedBoard; }
            set
            {
                selectedBoard = value;
                OnPropertyChanged(nameof(SelectedBoard));
            }
        }

        public void NewBoard()
        {
            selectedBoard = new TakeBoard();
            selectedBoard.Name = "Имя доски";
            selectedBoard.Project = OwnerProject.Id;
            selectedBoard.Description = "Описание Доски";
            selectedBoard.Users = new List<int>();
            userstring = "Пользователь1;Пользователь2;Пользователь3;";
            createBoard =new CreateBoard(this);
            createBoard.ShowDialog();         
        }

        public void DoNotSaveBoard()
        {
            selectedBoard=null;
            createBoard.Close();
        }

        public void BoardToDb(string users)
        {
            string one=null;
            List<TakeUser> list = new List<TakeUser>();
            int border = 0;
            for (int i=0;i<users.Length; i++)
            { 
                if (users[i] ==';')
                {
                    one=users.Substring(border,i-border);
                    foreach(var j in userService.GetAllUsers()) 
                    { 
                        if (j.Login==one)
                        {
                            SelectedBoard.Users.Add(j.Id);
                        }
                    }
                    border=i+1;
                }
            }
            if (one==null)
            {
                foreach (var j in userService.GetAllUsers())
                {
                    if (j.Login == users)
                    {
                        SelectedBoard.Users.Add(j.Id);
                    }
                }
            }
            boardService.CreateBoard(SelectedBoard, 1);
            createBoard.Close();
        }
    }
}
