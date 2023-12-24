using DTO;
using DomainModel;
using System.Collections.Generic;
using System.Linq;
using Interfaces.Repository;
using Interfaces.Services;
using Interfaces.DTO;

namespace BLL.Services
{
    public class ReportService : IReportService
    {
        private IDbRepos db;

        public ReportService(IDbRepos repos)
        {
            db = repos;
        }

        public List<TakeTask> GetAllTasksInProject(string projectname)
        {
            return db.Reports.GetAllTasksInProject(projectname);
        }
        public UserEficiency GetUserEficiency(string username)
        {
            return db.Reports.GetUserEficiency(username);
        }
        public List<TakeTask> WhatIsDoneBy(string username)
        {
            return db.Reports.WhatIsDoneBy(username);
        }
        public List<TakeTask> GetAllUsersTasks(string username)
        {
            return db.Reports.GetAllUsersTasks(username);
        }
    }
}
