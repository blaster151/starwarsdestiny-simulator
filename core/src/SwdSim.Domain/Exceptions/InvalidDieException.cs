using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Exceptions
{

    [Serializable]
    public class InvalidDieException : Exception
    {
        public InvalidDieException() { }
        public InvalidDieException(string message) : base(message) { }
        public InvalidDieException(string message, Exception inner) : base(message, inner) { }
        protected InvalidDieException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
