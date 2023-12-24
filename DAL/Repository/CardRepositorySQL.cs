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
    public class CardRepositorySQL : IRepository<cards>
    {
        private DataContext db;

        public CardRepositorySQL(DataContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<cards> GetList()
        {
            return db.cards.ToList();
        }

        public cards GetItem(int id)
        {
            return db.cards.Find(id);
        }

        public void Create(cards Card)
        {
            db.cards.Add(Card);
        }

        public void Update(cards Card)
        {
            db.Entry(Card).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            cards Card = db.cards.Find(id);
            if (Card != null)
                db.cards.Remove(Card);
        }


    }
}
