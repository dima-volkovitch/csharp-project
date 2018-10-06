using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public class PatisipationHistory : AEntity
    {
        public bool IsActive { get; set; }

        public virtual User User { get; set; }

        public virtual Project Project { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public virtual IList<WorkDay> WorkDays { get; set; }
    }
}
