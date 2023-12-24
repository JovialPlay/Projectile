using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private DataContext db;
        private ProjectRepositorySQL projectRepository;
        private BoardRepositorySQL boardRepository;
        private CardRepositorySQL cardRepository;
        private TaskRepositorySQL taskRepository;
        private PriorityRepositorySQL priorityRepository;
        private TagRepositorySQL tagRepository;
        private TodoRepositorySQL todoRepository;
        private ToDoListRepositorySQL toDoListRepository;
        private StatusRepositorySQL statusRepository;
        private ReportRepositorySQL reportRepository;
        private UserRepositorySQL userRepository;

        public DbReposSQL()
        {
            db = new DataContext();
        }

        public IRepository<projects> Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepositorySQL(db);
                return projectRepository;
            }
        }
        public IRepository<boards> Boards 
        {
            get
            {
                if (boardRepository == null)
                    boardRepository = new BoardRepositorySQL(db);
                return boardRepository;
            }
        }
        public IRepository<cards> Cards
        {
            get
            {
                if (cardRepository == null)
                    cardRepository = new CardRepositorySQL(db);
                return cardRepository;
            }
        }
        public IRepository<tasks> Tasks
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepositorySQL(db);
                return taskRepository;
            }
        }
        public IRepository<priorities> Priorities
        {
            get
            {
                if (priorityRepository == null)
                    priorityRepository = new PriorityRepositorySQL(db);
                return priorityRepository;
            }
        }
        public IRepository<tags> Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepositorySQL(db);
                return tagRepository;
            }
        }
        public IRepository<todos> ToDos
        {
            get
            {
                if (todoRepository == null)
                    todoRepository = new TodoRepositorySQL(db);
                return todoRepository;
            }
        }
        public IRepository<todolists> ToDolists
        {
            get
            {
                if (toDoListRepository == null)
                    toDoListRepository = new ToDoListRepositorySQL(db);
                return toDoListRepository;
            }
        }
        public IRepository<statuses> Statuses
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepositorySQL(db);
                return statusRepository;
            }
        }
        public IRepository<users> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepositorySQL(db);
                return userRepository;
            }
        }
        public IReportsRepository Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepositorySQL(db);
                return reportRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
