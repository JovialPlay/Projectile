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
    public class UserService : IUserService
    {
        private IDbRepos db;
        public UserService(IDbRepos repos)
        {
            db = repos;
        }

        public List<TakeUser> GetAllUsers()
        {
            return db.Users.GetList().Select(i => new TakeUser(i)).ToList();
        }

        public TakeUser GetSingleUser(int Id)
        {
            return new TakeUser(db.Users.GetItem(Id));
        }

        public void CreateUser(TakeUser p)
        {
            db.Users.Create(new users()
            {
                userlogin = p.Login,
                userpassword = p.Password
            });
            Save();
        }
        public void UpdateUser(TakeUser p)
        {
            users u = db.Users.GetItem(p.Id);
            u.userlogin = p.Login;
            u.userpassword = p.Password;
            db.Users.Update(u);
            Save();
        }

        public void DeleteUser(int id)
        {
            users p = db.Users.GetItem(id);
            if (p != null)
            {
                db.Users.Delete(p.id);
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
