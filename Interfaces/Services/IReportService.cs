using DTO;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IReportService
    {
        List<TakeTask> GetAllTasksInProject(string projectname);
        UserEficiency GetUserEficiency(string username);
        List<TakeTask> WhatIsDoneBy(string username);
    }
}
