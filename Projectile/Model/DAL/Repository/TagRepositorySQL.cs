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
    public class TagRepositorySQL : IRepository<tags>
    {
        private DataContext db;

        public TagRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<tags> GetList()
        {
            return db.tags.ToList();
        }

        public tags GetItem(int id)
        {
            return db.tags.Find(id);
        }

        public void Create(tags Tag)
        {
            db.tags.Add(Tag);
        }

        public void Update(tags Tag)
        {
            db.Entry(Tag).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            tags Tag = db.tags.Find(id);
            if (Tag != null)
                db.tags.Remove(Tag);
        }


    }
}
