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
using System.Runtime.InteropServices.WindowsRuntime;
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
        public TakeBoard OwnerBoard {  get; set; }


        CreateTask createTask { get; set; }
        CreateTag createTag { get; set; }
        UpdateBoard updateBoard { get; set; }
        UpdateTask updateTask { get; set; }
        public string OwnerBoardString { get; set; }
        public TakeTag newTag { get; set; }

        public TakeTask BackupTask { get; set; }

        public UserService userService { get; set; }
        public ProjectService projectService { get; set; }
        public BoardService boardService { get; set; }
        PriorityService priorityService { get; set; }
        public StatusService statusService { get; set; }
        public TaskService taskService { get; set; }
        public TagService tagService { get; set; }
        public CardService cardService { get; set; }

        public List<int> Priorities { get; set; }

        private List<TakeCard> cards { get; set; }
        public List<TakeCard> Cards 
        { 
            get { return cards; }
            set 
            { 
                cards = value; 
                OnPropertyChanged(nameof(Cards));
            }
        }
        public List<TakeTask> Tasks { get; set; }

        private List<string> boardUsers;
        public List<string> BoardUsers 
        {
            get { return boardUsers; }
            set
            {
                boardUsers = value;
                OnPropertyChanged(nameof(BoardUsers));
            }
        }

        public List<string> Statuses { get; set; }
        public List<TakeTag> Tags { get; set; }

        public List<TakeTag> takeTags
        {
            get 
            {
                return Tags;
            }
            set 
            { 
                Tags= value;
                OnPropertyChanged(nameof(takeTags));
            }
        }

        public RelayCommand DeleteCard => new RelayCommand(execute => DeleteCardFromDb((TakeCard)execute));
        public RelayCommand SaveTaskClick => new RelayCommand(execute => SaveTask());
        public RelayCommand CancelTaskClick => new RelayCommand(execute => DoNotSaveTask());
        public RelayCommand SaveChanges => new RelayCommand(execute => SendCardsToDB());
        public RelayCommand ChangeBoard => new RelayCommand(execute => ChangeBoardSettings());
        public RelayCommand ChangeBoardInDB => new RelayCommand(execute => UpdateBoard());
        public RelayCommand DeleteBoardFromDB => new RelayCommand(execute => DeleteBoard());
        public RelayCommand CancelBoard => new RelayCommand(execute => DoNotSave());
        public RelayCommand CreateCardClick => new RelayCommand(execute => CreateCard());
        public RelayCommand AddTask => new RelayCommand(execute => CreateTask((TakeCard)execute));
        public RelayCommand AddTag => new RelayCommand(execute => NewTag());
        public RelayCommand SaveTag => new RelayCommand(execute => SendTagToDb());
        public RelayCommand CancelTag => new RelayCommand(execute => DoNotSaveTag());
        public RelayCommand DeleteTag => new RelayCommand(execute => RemoveTagFromDb((TakeTag)execute));
        public RelayCommand ChangeTask => new RelayCommand(execute => ChangeTaskSettings((TakeTask)execute));

        public RelayCommand CancelUpdateTaskClick => new RelayCommand(execute => DoNotSaveUpdateTask());
        public RelayCommand UpdateTaskClick => new RelayCommand(execute => UpdateTask());
        public RelayCommand DeleteTaskClick => new RelayCommand(execute => DeleteTask());

        public TakeTask selectedTask { get; set; }
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
            takeTags = tagService.GetAllTags();
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
            BoardUsers= new List<string>();
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
            OwnerBoard = boardService.GetSingleBoard(OwnerBoard.Id);
            OwnerBoardString = null;
            foreach (int j in OwnerBoard.Users)
            {
                string s = userService.GetSingleUser(j).Login;
                BoardUsers.Add(s);
                s += ";";
                OwnerBoardString += s;
            }
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
            card.Name = "Карточка";  
            card.Board = OwnerBoard;
            cardService.CreateCard(card, userid);
            card=cardService.GetSingleCardByName(card.Name);
            card.Name="Карточка #"+card.Id.ToString();
            cardService.UpdateCard(card, userid);
            Cards = cardService.GetBoardsCards(OwnerBoard.Id);
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
            SendCardsToDB();
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
            Cards = cardService.GetBoardsCards(OwnerBoard.Id);
        }
        public void DoNotSaveTask()
        {
            SelectedTask = null;
            createTask.Close();
        }

        public void DeleteCardFromDb(TakeCard card)
        {
            cardService.DeleteCard(card.Id);
            Cards=cardService.GetBoardsCards(OwnerBoard.Id);


        }

        public void NewTag()
        {
            newTag = new TakeTag();
            newTag.Name = "Имя тега";
            createTag= new CreateTag(this);
            createTag.ShowDialog();
        }

        public void SendTagToDb()
        {
            tagService.CreateTag(newTag);
            newTag = null;
            createTag.Close();
            takeTags=tagService.GetAllTags();
        }

        public void DoNotSaveTag()
        {
            newTag = null;
            createTag.Close();
        }

        public void RemoveTagFromDb(TakeTag tag)
        {
            tagService.DeleteTag(tag.Id);
            takeTags=tagService.GetAllTags();
        }

        public void ChangeTaskSettings(TakeTask task)
        {
            SendCardsToDB();
            BackupTask = task;
            SelectedTask =task;
            foreach (var t in takeTags)
            {
                foreach (var tasktag in SelectedTask.Tags)
                {
                    if (t.Name==tasktag)
                    {
                        t.IsIncluded = true;
                    }
                }
            }
            updateTask = new UpdateTask(this); 
            updateTask.ShowDialog();
        }

        public void UpdateTask()
        {
            foreach(var t in takeTags)
            {
                if (t.IsIncluded)
                    SelectedTask.Tags.Add(t.Name);
            }
            taskService.UpdateTask(SelectedTask);
            SelectedTask = null;
            Cards = cardService.GetBoardsCards(OwnerBoard.Id);
            updateTask.Close();
        }

        public void DeleteTask()
        {
            taskService.DeleteTask(SelectedTask.Id);
            SelectedTask = null;
            Cards = cardService.GetBoardsCards(OwnerBoard.Id);
            updateTask.Close();
        }

        public void DoNotSaveUpdateTask()
        {
            updateTask.Close();
            Cards = cardService.GetBoardsCards(OwnerBoard.Id);
        }
    }
}
