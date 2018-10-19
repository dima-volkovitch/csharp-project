using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public enum ProjectStatus : byte
    {
        Undefined = 0,
        Waiting = 1,
        During = 2,
        Finished = 3
    }
}
