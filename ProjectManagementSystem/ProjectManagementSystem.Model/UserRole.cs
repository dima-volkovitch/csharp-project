using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public enum UserRole : byte
    {
        UNDEFINED,
        ADMIN,
        RESOURCES_MANAGER,
        PROJECT_MANAGER,
        SLAVE
    }
}
