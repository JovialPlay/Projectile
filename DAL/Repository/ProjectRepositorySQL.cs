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
    public class ProjectRepositorySQL : IRepository<projects>
    {
        private DataContext db;

        public ProjectRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<projects> GetList()
        {
            return db.projects.ToList();
        }

        public projects GetItem(int id)
        {
            return db.projects.Find(id);
        }

        public void Create(projects Project)
        {
            db.projects.Add(Project);
        }

        public void Update(projects Project)
        {
            db.Entry(Project).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            projects Project = db.projects.Find(id);
            if (Project != null)
                db.projects.Remove(Project);
        }


    }
}