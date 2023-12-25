using BLL;
using BLL.Services;
using DAL.Repository;
using DTO;
using Interfaces.DTO;
using Interfaces.Services;
using NpgsqlTypes;
using Projectile.MVVM;
using Projectile.Navigation;
using Projectile.View.Pages;
using Projectile.View.UpdateForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projectile.ViewModel
{
    public class TaskPageViewModel:ViewModelBase
    {
        readonly NavigationStore Store;

        readonly DbReposSQL db;

        private int userid;
        public TakeBoard OwnerBoard { get; set; }
        public UserService userService { get; set; }
        public RelayCommand SaveTaskClick => new RelayCommand(execute => SaveTask());
        public RelayCommand CancelTaskClick => new RelayCommand(execute => DoNotSaveTask());
        public ProjectService projectService { get; set; }
        public BoardService boardService { get; set; }
        PriorityService priorityService { get; set; }
        public StatusService statusService { get; set; }
        public TaskService taskService { get; set; }
        public TagService tagService { get; set; }
        public string OwnerBoardString { get; set; }
        public UpdateBoard updateBoard { get; set; }
        public List<TakeCard> Cards { get; set; }
        public List<TakeTask> Tasks { get; set; }
        public List<string> BoardUsers { get; set; }
        public List<string> Statuses { get; set; }
        public List<TakeTag> Tags { get; set; }
        public List<int> Priorities { get; set; }
        CreateTask createTask { get; set; }
        public RelayCommand SaveChanges => new RelayCommand(execute => SendCardsToDB());
        public RelayCommand ChangeBoard => new RelayCommand(execute => ChangeBoardSettings());
        public RelayCommand ChangeBoardInDB => new RelayCommand(execute => UpdateBoard());
        public RelayCommand DeleteBoardFromDB => new RelayCommand(execute => DeleteBoard());
        public RelayCommand Cancel => new RelayCommand(execute => DoNotSave());
        public RelayCommand CreateCardClick => new RelayCommand(execute => CreateCard());
        CardService cardService { get; set; }

        public RelayCommand AddTask => new RelayCommand(execute => CreateTask((TakeCard)execute));

        private TakeTask selectedTask;
        public TakeTask SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }
        public TaskPageViewModel(NavigationStore store, DbReposSQL db, TakeBoard ownerBoard,int id)
        {
            userid = id;
            Store = store;
            this.db = db;
            OwnerBoard = ownerBoard;
            taskService = new TaskService(db);
            userService = new UserService(db);
            boardService = new BoardService(db);
            projectService = new ProjectService(db);
            statusService = new StatusService(db);
            tagService = new TagService(db);
            priorityService = new PriorityService(db);
            BoardUsers = new List<string>();
            Statuses = new List<string>();
            Tags = new List<TakeTag>();
            Priorities = new List<int>();
            foreach (int j in OwnerBoard.Users) 
            {
                string s = userService.GetSingleUser(j).Login;
                BoardUsers.Add(s);
                s+=";";
                OwnerBoardString += s;
            }
            cardService = new CardService(db);
            Cards = cardService.GetBoardsCards(OwnerBoard.Id);
            Statuses=statusService.GetAllNames();
            Tags = tagService.GetAllTags();
            Priorities=priorityService.GetAllNames();
        }

        public void ChangeBoardSettings()
        {
            updateBoard=new UpdateBoard(this);
            updateBoard.ShowDialog();
        }


        public void UpdateBoard()
        {
            int border = 0;
            string one;
            OwnerBoard.Users = new List<int>();
            if (OwnerBoardString != null)
            {
                for (int i = 0; i < OwnerBoardString.Length; i++)
                {
                    if (OwnerBoardString[i] == ';')
                    {
                        one = OwnerBoardString.Substring(border, i - border);
                        foreach (var j in userService.GetAllUsers())
                        {
                            if (j.Login == one)
                            {
                                OwnerBoard.Users.Add(j.Id);
                            }
                        }
                        border = i + 1;
                    }
                }
            }
            boardService.UpdateBoard(OwnerBoard, userid);
            updateBoard.Close();
        }
        public void DeleteBoard()
        {
            boardService.DeleteBoard(OwnerBoard.Id);
            Store.ChangePage(new BoardPage(Store, db,projectService.GetSingleProject((int)OwnerBoard.Project), userid));
            updateBoard.Close();
        }
        public void DoNotSave()
        {
            updateBoard.Close();
        }
        public void CreateCard()
        {
            TakeCard card = new TakeCard();
            card.Name = "Новая Карточка";
            card.Board = OwnerBoard;
            cardService.CreateCard(card, userid);
            Cards = cardService.GetBoardsCards(OwnerBoard.Id);
            Store.CurrentPage = new TaskPage(Store, db, OwnerBoard, userid);
        }

        public void SendCardsToDB()
        {
            foreach (var card in Cards) 
            { 
                cardService.UpdateCard(card, userid);
            }
        }

        public void CreateTask(TakeCard card)
        {
            SelectedTask = new TakeTask
            {
                Card = card.Name,
                Status = statusService.GetSingleStatus(userid).Name,
                Deadline = DateTime.Today,
                Workers = userService.GetSingleUser(userid).Login,
                Checker = userService.GetSingleUser(userid).Login,
                Description = "Описание задачи",
                Name = "Имя Задачи",
                Priority = Priorities.First(),
                Tags = new List<string>()
            };
            createTask = new CreateTask(this);
            createTask.ShowDialog();
        }
        public void SaveTask()
        {
            foreach(var t in Tags)
            {
                if (t.IsIncluded)
                    SelectedTask.Tags.Add(t.Name);
            }
            taskService.CreateTask(SelectedTask);
            SelectedTask = null;
            createTask.Close();
            Store.ChangePage(new TaskPage(Store, db, OwnerBoard, userid));
        }
        public void DoNotSaveTask()
        {
            SelectedTask = null;
            createTask.Close();
        }
    }
}
