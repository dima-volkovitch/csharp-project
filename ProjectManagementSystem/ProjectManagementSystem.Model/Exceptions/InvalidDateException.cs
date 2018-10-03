using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException()
        {
        }

        public InvalidDateException(string message) : base(message)
        {
        }

        public InvalidDateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
