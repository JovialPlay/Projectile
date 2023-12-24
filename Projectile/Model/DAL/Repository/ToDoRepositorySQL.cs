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
    public class TodoRepositorySQL : IRepository<todos>
    {
        private DataContext db;

        public TodoRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<todos> GetList()
        {
            return db.todos.ToList();
        }

        public todos GetItem(int id)
        {
            return db.todos.Find(id);
        }

        public void Create(todos Todo)
        {
            db.todos.Add(Todo);
        }

        public void Update(todos Todo)
        {
            db.Entry(Todo).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            todos Todo = db.todos.Find(id);
            if (Todo != null)
                db.todos.Remove(Todo);
        }


    }
}
