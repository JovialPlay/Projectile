using BLL;
using BLL.Services;
using DAL.Repository;
using DTO;
using Interfaces.CombinedDataObjects;
using Projectile.MVVM;
using Projectile.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectile.ViewModel
{
    public class StatPageViewModel : ViewModelBase
    {
        readonly NavigationStore Store;

        readonly DbReposSQL db;

        private TakeUser User;

        private ProjectService projectService;

        private TaskService taskService;

        private UserService userService;
        public Statistic Statistic { get; set; }

        private ReportService reportService {  get; set; }
        public StatPageViewModel (NavigationStore store, DbReposSQL db, int id)
        {
            Store = store;
            this.db = db;
            projectService=new ProjectService (db);
            taskService = new TaskService (db);
            reportService = new ReportService (db);
            userService = new UserService (db);
            User = userService.GetSingleUser(id);
            Statistic = new Statistic ();
            Statistic.ProjectCount=projectService.GetAllUsersProjects(User.Id).Count();
            List<TakeTask> takeTasks = new List<TakeTask> ();
            takeTasks = taskService.GetAllUsersTasks(User.Id);
            foreach (TakeTask task in takeTasks) 
            { 
                if ((task.Status=="Сделано")&&(task.Workers==User.Login))
                {
                    Statistic.TasksDone++;
                }
                if ((task.Status!="Сделано")&&(task.Status!="На проверке")&&(task.Workers == User.Login))
                {
                    Statistic.TasksNotDone++;
                }
                if ((task.Deadline<DateTime.Now)&&(task.Status!= "Сделано"))
                {
                    Statistic.TasksOutdated++;
                }
                if ((task.Status=="На проверке")&&(task.Checker==User.Login))
                {
                    Statistic.TasksToChech++;
                }
                {
                    Statistic.UserEfiiciency =(double)Statistic.TasksDone / (double)(Statistic.TasksDone + Statistic.TasksNotDone);
                }
            }
        }

    }
}
