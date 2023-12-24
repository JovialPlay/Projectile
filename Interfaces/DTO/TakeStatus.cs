using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class TakeStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<string> tasks { get; set; }

        public TakeStatus(statuses s)
        {
            Id = s.id;
            Name = s.statusname;
            tasks=s.tasks.Select(i=>i.taskname).ToList();
        }
    }
}
