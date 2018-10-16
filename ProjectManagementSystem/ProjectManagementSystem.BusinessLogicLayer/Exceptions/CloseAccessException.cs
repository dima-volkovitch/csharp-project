using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Exceptions
{
    public class CloseAccessException : Exception
    {
        public CloseAccessException()
        {
        }

        public CloseAccessException(string message) : base(message)
        {
        }

        public CloseAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CloseAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
