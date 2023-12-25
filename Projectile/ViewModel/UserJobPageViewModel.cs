using BLL;
using BLL.Services;
using DAL.Repository;
using DTO;
using Interfaces.CombinedDataObjects;
using Interfaces.Services;
using Projectile.MVVM;
using Projectile.Navigation;
using Projectile.View.UpdateForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectile.ViewModel
{
    public class UserJobPageViewModel : ViewModelBase
    {
        readonly NavigationStore Store;

        readonly DbReposSQL db;

        private TakeUser user;
        private UpdateTask updateTask { get; set; }
        private CreateTag createTag { get; set; }

        private UserService userService { get; set; }
        private TaskService taskService { get; set; }
        private BoardService boardService { get; set; }
        private TagService tagService { get; set; }
        private StatusService statusService { get; set; }
        private PriorityService priorityService { get; set; }

        public List<string> Statuses { get; set; }
        public List<TakeTag> Tags { get; set; }
        public List<string> BoardUsers { get; set; }
        public List<int> Priorities { get; set; }
        public TakeTag newTag { get; set; }

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
        private List<Template> templates { get; set; }
        public List<Template> Templates
        {
            get { return templates; }
            set
            {
                templates = value;
                OnPropertyChanged(nameof(Templates));
            }
        }

        public List<TakeTag> takeTags
        {
            get
            {
                return Tags;
            }
            set
            {
                Tags = value;
                OnPropertyChanged(nameof(takeTags));
            }
        }
        public RelayCommand ChangeTask => new RelayCommand(execute => ChangeTaskSettings((TakeTask)execute));
        public RelayCommand CancelUpdateTaskClick => new RelayCommand(execute => DoNotSaveUpdateTask());
        public RelayCommand UpdateTaskClick => new RelayCommand(execute => UpdateTask());
        public RelayCommand DeleteTaskClick => new RelayCommand(execute => DeleteTask());
        public RelayCommand AddTag => new RelayCommand(execute => NewTag());
        public RelayCommand SaveTag => new RelayCommand(execute => SendTagToDb());
        public RelayCommand CancelTag => new RelayCommand(execute => DoNotSaveTag());
        public RelayCommand DeleteTag => new RelayCommand(execute => RemoveTagFromDb((TakeTag)execute));

        public UserJobPageViewModel(NavigationStore store, DbReposSQL db, int userid)
        {
            Store = store;
            this.db = db;

            userService = new UserService(db);
            taskService = new TaskService(db);
            boardService = new BoardService(db);
            priorityService = new PriorityService(db);
            statusService = new StatusService(db);
            tagService = new TagService(db);

            takeTags=tagService.GetAllTags();
            Statuses=statusService.GetAllNames();
            Priorities=priorityService.GetAllNames().ToList();
            BoardUsers = new List<string>();

            templates = new List<Template>();
            user = userService.GetSingleUser(userid);
            foreach (var board in boardService.GetUsersBoards(userid))
            {
                if (taskService.GetAllBoardsUsersTasks(board.Id, userid).Count!=0)
                {
                    Template template = new Template();
                    template.board = boardService.GetSingleBoard(board.Id);
                    template.tasks = taskService.GetAllBoardsUsersTasks(board.Id,userid);
                    templates.Add(template);
                }

            }
        }
        public void ChangeTaskSettings(TakeTask task)
        {
            SelectedTask = task;
            BoardUsers.Clear();
            BoardUsers.Add(SelectedTask.Checker);
            if (SelectedTask.Checker!=SelectedTask.Workers)
                BoardUsers.Add(SelectedTask.Workers);
            foreach (var t in takeTags)
            {
                foreach (var tasktag in SelectedTask.Tags)
                {
                    if (t.Name == tasktag)
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
            foreach (var t in takeTags)
            {
                if (t.IsIncluded)
                    SelectedTask.Tags.Add(t.Name);
            }
            taskService.UpdateTask(SelectedTask);
            SelectedTask = null;
            templates.Clear();
            foreach (var board in boardService.GetUsersBoards(user.Id))
            {
                if (taskService.GetAllBoardsTasks(board.Id).Count != 0)
                {
                    Template template = new Template();
                    template.board = boardService.GetSingleBoard(board.Id);
                    template.tasks = taskService.GetAllBoardsTasks(board.Id);
                    templates.Add(template);
                }

            }
            updateTask.Close();
        }

        public void DeleteTask()
        {
            taskService.DeleteTask(SelectedTask.Id);
            SelectedTask = null;
            templates.Clear();
            foreach (var board in boardService.GetUsersBoards(user.Id))
            {
                if (taskService.GetAllBoardsTasks(board.Id).Count != 0)
                {
                    Template template = new Template();
                    template.board = boardService.GetSingleBoard(board.Id);
                    template.tasks = taskService.GetAllBoardsTasks(board.Id);
                    templates.Add(template);
                }

            }
            updateTask.Close();
        }

        public void DoNotSaveUpdateTask()
        {
            SelectedTask = null;
            updateTask.Close();
        }

        public void NewTag()
        {
            newTag = new TakeTag();
            newTag.Name = "Имя тега";
            createTag = new CreateTag(this);
            createTag.ShowDialog();
        }

        public void SendTagToDb()
        {
            tagService.CreateTag(newTag);
            newTag = null;
            createTag.Close();
            takeTags = tagService.GetAllTags();
        }

        public void DoNotSaveTag()
        {
            newTag = null;
            createTag.Close();
        }

        public void RemoveTagFromDb(TakeTag tag)
        {
            tagService.DeleteTag(tag.Id);
            takeTags = tagService.GetAllTags();
        }
    }
}
