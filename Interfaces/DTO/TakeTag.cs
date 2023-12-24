using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TakeTag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TakeTask> Tasks { get; set; }
        public TakeTag(tags t)
        {
            Id=t.id; 
            Name=t.tagname;
            /*
            foreach(var task in t.tasks)
            {
                Tasks.Add(new TakeTask(task));
            }
            */
        }
    }
}
