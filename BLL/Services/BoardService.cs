using DomainModel;
using Interfaces.Services;
using DTO;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BoardService : IBoardService
    {
        private IDbRepos db;
        public BoardService(IDbRepos repos)
        {
            db = repos;
        }

        public List<TakeBoard> GetProjectBoards(int id)
        {
            return db.Boards.GetList().Select(i => new TakeBoard(i)).Where(i=>i.Project==id).ToList();
        }

        public TakeBoard GetSingleBoard(int Id)
        {
            return new TakeBoard(db.Boards.GetItem(Id));
        }

        public void CreateBoard(TakeBoard p, int userid)
        {
            boards newboard = new boards();
            newboard.boarddescription = p.Description;
            newboard.boardname = p.Name;
            newboard.boardproject = p.Project;
            newboard.users = new List<users>
            {
                db.Users.GetItem(userid)
            };
            foreach (var j in p.Users)
            {
                newboard.users.Add(db.Users.GetItem(j));
            }
            db.Boards.Create(newboard);
            Save();
        }

        public void UpdateBoard(TakeBoard p, int userid)
        {
            boards pr = db.Boards.GetItem(p.Id);
            pr.boardname = p.Name;
            pr.boarddescription = p.Description;
            pr.boardproject = p.Project;
            if (p.Users.Count == 0)
                pr.users.Add(db.Users.GetItem(userid));
            else
            {
                foreach (int i in p.Users)
                {
                    pr.users.Add(db.Users.GetItem(i));
                }
            }
            foreach (int i in p.Cards)
            {
                pr.cards.Add(db.Cards.GetItem(i));
            }
            db.Boards.Update(pr);
            Save();
        }

        public void DeleteBoard(int id)
        {
            boards p = db.Boards.GetItem(id);
            if (p != null)
            {
                db.Boards.Delete(p.id);
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
