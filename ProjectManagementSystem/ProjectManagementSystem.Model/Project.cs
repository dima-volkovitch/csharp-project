using ProjectManagementSystem.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public class Project : AEntity
    {
        private const string InvalidDateExceptionMessage = "Exception! Finish date is less then start date";

        private DateTime finishDate;


        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate
        {
            get { return finishDate; }
            set
            {
                if (value <= StartDate)
                {
                    throw new InvalidDateException(InvalidDateExceptionMessage);
                }
                finishDate = value;
            }
        }

        public ProjectStatus Status { get; set; } = ProjectStatus.Waiting;

        public virtual IList<PaticipationHistory> PatisipationHistory { get; set; }
    }
}
