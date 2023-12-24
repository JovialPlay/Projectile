using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TakeCard
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TakeBoard Board { get; set; }

        public List<TakeTask> Tasks { get; set; }   
        public TakeCard(cards c)
        {
            Id = c.id;
            Name = c.cardname;
            Board = new TakeBoard(c.boards);
            Tasks = new List<TakeTask>();
            List<tasks> buff=c.tasks.ToList();
            foreach (var task in buff)
            {
                Tasks.Add(new TakeTask(task));
            }
        }

        public TakeCard()
        {

        }
    }
}
