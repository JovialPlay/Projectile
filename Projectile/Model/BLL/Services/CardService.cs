using DomainModel;
using DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CardService : ICardService
    {
        private IDbRepos db;
        public CardService(IDbRepos repos)
        {
            db = repos;
        }

        public List<TakeCard> GetBoardsCards(int id)
        {
            return db.Cards.GetList().Select(i => new TakeCard(i)).Where(i => i.Board.Id == id).ToList();
        }

        public TakeCard GetSingleCard(int Id)
        {
            return new TakeCard(db.Cards.GetItem(Id)); ;
        }

        public void CreateCard(TakeCard p, int userid)
        {
            cards newcard = new cards();
            newcard.cardboard=p.Board.Id;
            newcard.boards=db.Boards.GetItem(p.Board.Id);
            newcard.cardname = p.Name;
            db.Cards.Create(newcard);
            Save();
        }

        public void UpdateCard(TakeCard p, int userid)
        {
            cards cr = db.Cards.GetItem(p.Id);
            cr.cardboard = p.Board.Id;
            cr.boards = db.Boards.GetItem(p.Board.Id);
            cr.cardname = p.Name;
            db.Cards.Update(cr);
            Save();
        }
        public void DeleteCard(int id)
        {
            cards p = db.Cards.GetItem(id);
            if (p != null)
            {
                db.Cards.Delete(p.id);
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
