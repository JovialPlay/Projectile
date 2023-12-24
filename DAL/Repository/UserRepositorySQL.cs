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
    public class UserRepositorySQL : IRepository<users>
    {
        private DataContext db;

        public UserRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<users> GetList()
        {
            return db.users.ToList();
        }

        public users GetItem(int id)
        {
            return db.users.Find(id);
        }

        public void Create(users User)
        {
            db.users.Add(User);
        }

        public void Update(users User)
        {
            db.Entry(User).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            users User = db.users.Find(id);
            if (User != null)
                db.users.Remove(User);
        }


    }
}
