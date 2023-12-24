using System;
using DomainModel;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TakeTask
    {
        public int Id { get; set; }

        public string Status { get; set; }
        public string Card { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int? Priority { get; set; }
        public string Checker { get; set; }

        public bool? isDone { get; set; }
        public string Workers { get; set; }
        public List<int> Todolists { get; set; }
        public List<string> Tags { get; set; }
        public TakeTask(tasks t)
        {
            Id = t.id;
            Deadline = (DateTime)t.taskdeadline;
            Description = t.taskdescription;
            isDone = t.taskisdone;
            if (t.statuses!=null)
                Status = t.statuses.statusname;
            if (t.users != null)
                Checker =t.users.userlogin;
            Name = t.taskname;
            if (t.cards != null)
                Card = t.cards.cardname;
            if (t.priorities != null)
                Priority = t.priorities.priorityvalue;
            if (t.users1 != null)
                Workers = t.users1.userlogin;
            Tags = t.tags.Select(i => i.tagname).ToList();
            Todolists = t.todolists.Select(i=>i.id).ToList();
        }
        public TakeTask()
        {

        }
    }
}
