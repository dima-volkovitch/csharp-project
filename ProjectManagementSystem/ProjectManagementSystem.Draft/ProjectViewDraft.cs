using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Draft
{
    public class ProjectViewDraft
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public ProjectStatus Status { get; set; } = ProjectStatus.WAITING;
    }
}
