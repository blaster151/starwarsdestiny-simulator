using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Exceptions
{

    [Serializable]
    public class InvalidDieFaceException : Exception
    {
        public InvalidDieFaceException() { }
        public InvalidDieFaceException(string message) : base(message) { }
        public InvalidDieFaceException(string message, Exception inner) : base(message, inner) { }
        protected InvalidDieFaceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
