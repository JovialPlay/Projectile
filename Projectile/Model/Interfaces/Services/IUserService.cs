using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IUserService
    {
        List<TakeUser> GetAllUsers();
        TakeUser GetSingleUser(int Id);
        void CreateUser(TakeUser t);
        void UpdateUser(TakeUser t);
        void DeleteUser(int id);
    }
}
