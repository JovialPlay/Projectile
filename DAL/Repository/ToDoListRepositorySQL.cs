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
    public class ToDoListRepositorySQL : IRepository<todolists>
    {
        private DataContext db;

        public ToDoListRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<todolists> GetList()
        {
            return db.todolists.ToList();
        }

        public todolists GetItem(int id)
        {
            return db.todolists.Find(id);
        }

        public void Create(todolists ToDoList)
        {
            db.todolists.Add(ToDoList);
        }

        public void Update(todolists ToDoList)
        {
            db.Entry(ToDoList).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            todolists ToDoList = db.todolists.Find(id);
            if (ToDoList != null)
                db.todolists.Remove(ToDoList);
        }


    }
}
