using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectile.Model
{
    public class FakeProject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public FakeProject(string n, string d) 
        { 
            Name = n;
            Description = d;
        }
    }
}
