using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TakeProject
    {
        public int Id { get; set; }

        public string Owner { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Access { get; set; }


        public TakeProject(projects p) 
        {
            Id = p.id;
            Owner = p.users.userlogin;
            Name = p.projectname;
            Description = p.projectdescription;
            if (p.projectaccess == true)
                Access = "Публичный";
            else
                Access = "Приватный";
        }

        public TakeProject() 
        { 
        
        }
    }
}
