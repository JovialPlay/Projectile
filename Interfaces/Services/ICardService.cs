using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICardService
    {
        List<TakeCard> GetBoardsCards(int id);
        TakeCard GetSingleCard(int Id);
        void CreateCard(TakeCard p, int userid);
        void UpdateCard(TakeCard p, int userid);
        void DeleteCard(int id);
    }
}
