using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TakeBoard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? Project { get; set; }
        public List<int> Cards { get; set; }

        public List<int> Users { get; set; }

        public TakeBoard(boards b) 
        {
            Id = b.id;
            Name=b.boardname; 
            Description=b.boarddescription;
            Project = b.boardproject;
            Cards = b.cards.Select(i=>i.id).ToList();
            Users =b.users.Select(i=>i.id).ToList();
        }
        public TakeBoard()
        {

        }
    }
}
