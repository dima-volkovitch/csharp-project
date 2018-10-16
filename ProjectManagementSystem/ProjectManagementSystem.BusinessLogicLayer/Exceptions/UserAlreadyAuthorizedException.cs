using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Exceptions
{
    public class UserAlreadyAuthorizedException : Exception
    {
        public UserAlreadyAuthorizedException()
        {
        }

        public UserAlreadyAuthorizedException(string message) : base(message)
        {
        }

        public UserAlreadyAuthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserAlreadyAuthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
