using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TakePriority
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public List<TakeTask> Task { get; set; }
        public TakePriority(priorities p)
        {
            Id = p.id;
            Value = (int)p.priorityvalue;
        }

    }
}
