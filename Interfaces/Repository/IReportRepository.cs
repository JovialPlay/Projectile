using DTO;
using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Repository
{
    public interface IReportsRepository
    {
        List<TakeTask> GetAllTasksInProject(string projectname);
        UserEficiency GetUserEficiency(string username);
        List<TakeTask> WhatIsDoneBy(string username);
        List<TakeTask> GetAllUsersTasks(string username);
    }
}
