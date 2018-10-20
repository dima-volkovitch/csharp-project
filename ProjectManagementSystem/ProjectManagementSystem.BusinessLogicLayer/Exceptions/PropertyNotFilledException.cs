using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Exceptions
{
    public class PropertyNotFilledException : Exception
    {
        public string PropertyName { get; set; }

        public PropertyNotFilledException()
        {
        }

        public PropertyNotFilledException(string message, string propertyName) : base(message)
        {
            PropertyName = propertyName;
        }

        public PropertyNotFilledException(string message) : base(message)
        {
        }

        public PropertyNotFilledException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PropertyNotFilledException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
