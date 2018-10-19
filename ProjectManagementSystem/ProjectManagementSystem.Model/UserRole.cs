using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public enum UserRole : byte
    {
        Undefined = 0,
        Admin = 1,
        ResourcesManager = 2,
        ProjectManager = 3,
        Slave = 4
    }
}
