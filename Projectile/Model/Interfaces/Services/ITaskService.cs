using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ITaskService
    {
        List<TakeTask> GetAllCardsTasks(int id);
        TakeTask GetSingleTask(int Id);
        void CreateTask(TakeTask t);
        void UpdateTask(TakeTask t);
        void DeleteTask(int id);
    }
}
