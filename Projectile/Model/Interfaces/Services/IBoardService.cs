using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IBoardService
    {
        List<TakeBoard> GetProjectBoards(int id);
        TakeBoard GetSingleBoard(int Id);
        void CreateBoard(TakeBoard p, int userid);
        void UpdateBoard(TakeBoard p, int userid);
        void DeleteBoard(int id);
    }
}
