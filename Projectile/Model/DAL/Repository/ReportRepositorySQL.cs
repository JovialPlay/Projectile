using DomainModel;
using DTO;
using Interfaces.DTO;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReportRepositorySQL : IReportsRepository
    {
        private DataContext db;
        public ReportRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        //выполнить ХП
        public List<TakeTask> GetAllTasksInProject(string projectname)
        {
            var data = db.tasks.Include("statuses").Include("users").Include("cards").Include("priorities").Include("tags").Include("todolists").Where(i => i.cards.boards.projects.projectname == projectname);
            List<TakeTask> result = new List<TakeTask>();
            foreach (var task in data)
            {
                result.Add(new TakeTask(task));
            }
            return result;
        }
        public List<TakeTask> WhatIsDoneBy(string username)
        {
            var data = db.tasks.Include("statuses").Include("users").Include("cards").Include("priorities").Include("tags").Include("todolists")
                .Where(i => (((i.users1.userlogin == username) && (i.statuses.statusname=="Сделано"))));
            List<TakeTask> result = new List<TakeTask>();
            foreach (var task in data)
            {
                result.Add(new TakeTask(task));
            }
            return result;
        }
        public List<TakeTask> GetAllUsersTasks(string username)
        {
            var data = db.tasks.Include("statuses").Include("users").Include("cards").Include("priorities").Include("tags").Include("todolists")
                .Where(i => (i.users1.userlogin == username)).ToList();
            List<TakeTask> result = new List<TakeTask>();
            foreach (var task in data)
            {
                result.Add(new TakeTask(task));
            }
            return result;
        }
        public UserEficiency GetUserEficiency(string username)
        {
            UserEficiency result = new UserEficiency();
            result.User = username;
            result.TasksNotDone = 0;
            result.TasksDone = 0;
            var UsersTasks = GetAllUsersTasks(username);
            foreach (var item in UsersTasks)
            {
                if (item.Status == "Сделано")
                    result.TasksDone++;
                else
                    result.TasksNotDone++;
            }
            result.EfficiencyInPersentage = (int)((double)result.TasksDone / (double)(result.TasksNotDone + result.TasksDone) * 100);
            return result;
        }
    }
}
