using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TakeTodolist
    {
        public int Id { get; set; }

        public TakeTask Task { get; set; }

        List<TakeTodo> TakeToDoList { get; set;}

        public TakeTodolist(todolists td) 
        {
            Id = td.id;
            // Task = new TakeTask(td.tasks);
            /*
            foreach (var todo in td.todos) 
            {
                TakeToDoList.Add(new TakeTodo(todo));
            }
            */
        }
    }
}
