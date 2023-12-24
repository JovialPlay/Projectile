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
    public class BoardRepositorySQL : IRepository<boards>
    {
        private DataContext db;

        public BoardRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<boards> GetList()
        {
            return db.boards.ToList();
        }

        public boards GetItem(int id)
        {
            return db.boards.Find(id);
        }

        public void Create(boards Board)
        {
            db.boards.Add(Board);
        }

        public void Update(boards Board)
        {
            db.Entry(Board).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            boards Board = db.boards.Find(id);
            if (Board != null)
                db.boards.Remove(Board);
        }
    }
}