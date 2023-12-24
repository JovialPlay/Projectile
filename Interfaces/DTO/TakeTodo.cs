using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TakeTodo
    {
        public int Id { get; set; }
        public TakeTodolist Todolist { get; set; }
        public bool? Isdone { get; set; }
        public string Name { get; set; }

        public TakeTodo(todos td) 
        {
            Id = td.id;
            // Todolist = new TakeTodolist(td.todolists);
            Isdone = td.todoisdone;
            Name = td.todoname;
        }
    }
}
