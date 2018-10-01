using ProjectManagementSystem.Entity.Exceptions;
using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Entity
{
    public class Project : AEntity
    {
        private const string INVALID_DATE_EXCEPTION_MESSAGE = "Exception! Finish date is less then start date";

        private DateTime finishDate;


        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate
        {
            get { return finishDate; }
            set
            { if (finishDate <= StartDate)
                {
                    throw new InvalidDateException(INVALID_DATE_EXCEPTION_MESSAGE);
                }
                finishDate = value;
            }
        }

        public ProjectStatus Status { get; set; } = ProjectStatus.WAITING;

        public IList<Business> Businesses { get; set; }
    }
}
