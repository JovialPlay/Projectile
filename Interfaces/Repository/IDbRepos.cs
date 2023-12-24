using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IDbRepos
    {
        IRepository<projects> Projects { get; }
        IRepository<boards> Boards { get; }
        IRepository<cards> Cards { get; }
        IRepository<tasks> Tasks { get; }

        IRepository<priorities> Priorities { get; }

        IRepository<todos> ToDos { get; }

        IRepository<todolists> ToDolists { get; }
        IRepository<users> Users { get; }
        IRepository<tags> Tags { get; }

        IRepository<statuses> Statuses { get; }

        IReportsRepository Reports { get; }
        int Save();
    }
}
