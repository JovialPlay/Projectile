using Interfaces.DTO;
using DTO;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Interfaces.Repository;
using DAL.Repository;
using Interfaces.Services;

namespace BLL
{
    public class TaskService :ITaskService
    {
        private IDbRepos db;
        public TaskService(IDbRepos repos)
        {
            db = repos;
        }

        public List<TakeTask> GetAllCardsTasks(int id)
        {
            return db.Tasks.GetList().Select(i => new TakeTask(i)).Where(i =>i.Card==db.Cards.GetItem(id).cardname).ToList();
        }

        public TakeTask GetSingleTask(int Id)
        {
            return new TakeTask(db.Tasks.GetItem(Id));
        }

        public void CreateTask(TakeTask p)
        {
            db.Tasks.Create(new tasks()
            {
                taskname=p.Name,
                taskdescription=p.Description,
                taskdeadline=p.Deadline,
                taskisdone=p.isDone,
                taskcard=db.Cards.GetList().Where(i=>i.cardname==p.Card).First().id,
                taskchecker=db.Users.GetList().Where(i=>i.userlogin==p.Checker).First().id,
                taskpriority=p.Priority,
                taskstatus=db.Statuses.GetList().Where(i=>i.statusname==p.Status).First().id,
            });
            Save();
        }

        public void UpdateTask(TakeTask p)
        {
            tasks u = db.Tasks.GetItem(p.Id);
            u.taskname = p.Name;
            u.taskdescription = p.Description;
            u.taskdeadline = p.Deadline;
            u.taskisdone = p.isDone;
            u.taskcard = db.Cards.GetList().Where(i => i.cardname == p.Card).First().id;
            u.taskchecker = db.Users.GetList().Where(i => i.userlogin == p.Checker).First().id;
            u.taskpriority = db.Priorities.GetList().Where(i=>i.priorityvalue==p.Priority).First().id;
            if (p.Status!=null)
                u.taskstatus = db.Statuses.GetList().Where(i => i.statusname == p.Status).First().id;
            db.Tasks.Update(u);
            Save();
        }

        public void DeleteTask(int id)
        {
            tasks p = db.Tasks.GetItem(id);
            if (p != null)
            {
                db.Tasks.Delete(p.id);
                Save();
            }
        }


        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }

    }
}
