using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IProjectService
    {
        List<TakeProject> GetAllProjects();
        TakeProject GetSingleProject(int Id);
        void CreateProject(TakeProject p, int userid);
        void UpdateProject(TakeProject p, int userid);
        void DeleteProject(int id);
    }
}
