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
    public class StatusRepositorySQL : IRepository<statuses>
    {
        private DataContext db;

        public StatusRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<statuses> GetList()
        {
            return db.statuses.ToList();
        }

        public statuses GetItem(int id)
        {
            return db.statuses.Find(id);
        }

        public void Create(statuses Status)
        {
            db.statuses.Add(Status);
        }

        public void Update(statuses Status)
        {
            db.Entry(Status).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            statuses Status = db.statuses.Find(id);
            if (Status != null)
                db.statuses.Remove(Status);
        }
    }
}