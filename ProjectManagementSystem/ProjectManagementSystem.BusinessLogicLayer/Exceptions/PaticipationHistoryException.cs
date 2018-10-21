using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Exceptions
{
    public class PaticipationHistoryException : Exception
    {
        public PaticipationHistoryException()
        {
        }

        public PaticipationHistoryException(string message) : base(message)
        {
        }

        public PaticipationHistoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PaticipationHistoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
