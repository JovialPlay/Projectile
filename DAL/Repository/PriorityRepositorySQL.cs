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
    public class PriorityRepositorySQL : IRepository<priorities>
    {
        private DataContext db;

        public PriorityRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<priorities> GetList()
        {
            return db.priorities.ToList();
        }

        public priorities GetItem(int id)
        {
            return db.priorities.Find(id);
        }

        public void Create(priorities Priority)
        {
            db.priorities.Add(Priority);
        }

        public void Update(priorities Priority)
        {
            db.Entry(Priority).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            priorities Priority = db.priorities.Find(id);
            if (Priority != null)
                db.priorities.Remove(Priority);
        }


    }
}
