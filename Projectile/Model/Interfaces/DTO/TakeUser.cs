using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TakeUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
            
        public List<int> Tasks {  get; set; }
        public List<int> Projects { get; set; }
 
        public TakeUser(users u) 
        { 
            Id= u.id;
            Login= u.userlogin;
            Password= u.userpassword;
            Tasks=u.tasks.Select(t => t.id).ToList();
        }
    }
}
