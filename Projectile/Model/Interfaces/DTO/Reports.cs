using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class UserEficiency
    {
        public string User;
        public int TasksDone { get; set; }
        public int TasksNotDone { get; set; }
        public float EfficiencyInPersentage { get; set; }
    }
}
