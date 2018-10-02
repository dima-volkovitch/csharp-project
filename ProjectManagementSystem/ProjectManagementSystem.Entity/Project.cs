using ProjectManagementSystem.Model.Exceptions;
using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Model
{
    public class Project : AEntity
    {
        private const string INVALID_DATE_EXCEPTION_MESSAGE = "Exception! Finish date is less then start date";

        private DateTime finishDate;


        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate
        {
            get { return finishDate; }
            set
            { if (value <= StartDate)
                {
                    throw new InvalidDateException(INVALID_DATE_EXCEPTION_MESSAGE);
                }
                finishDate = (DateTime)value;
            }
        }

        public ProjectStatus Status { get; set; } = ProjectStatus.WAITING;

        public virtual IList<Business> Businesses { get; set; }
    }
}
