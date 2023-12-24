using DomainModel;
using DAL;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TaskRepositorySQL : IRepository<tasks>
    {
        private DataContext db;

        public TaskRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<tasks> GetList()
        {
            return db.tasks.ToList();
        }

        public tasks GetItem(int id)
        {
            return db.tasks.Find(id);
        }

        public void Create(tasks Task)
        {
            db.tasks.Add(Task);
        }

        public void Update(tasks Task)
        {
            db.Entry(Task).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            tasks Task = db.tasks.Find(id);
            if (Task != null)
                db.tasks.Remove(Task);
        }

    }
}
