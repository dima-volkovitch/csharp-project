using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.API.Repositories
{
    public interface IPaticipationHistoryRepository : IRepository<PaticipationHistory>
    {
        bool IsExistActive(long userId, long projectId);

        IEnumerable<PaticipationHistory> GetByUserAndProjectId(long userId, long projectId, bool? isActive);
    }
}
