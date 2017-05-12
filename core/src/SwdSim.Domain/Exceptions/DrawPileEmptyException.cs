using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Exceptions
{

    [Serializable]
    public class DrawPileEmptyException : Exception
    {
        public DrawPileEmptyException() { }
        public DrawPileEmptyException(string message) : base(message) { }
        public DrawPileEmptyException(string message, Exception inner) : base(message, inner) { }
        protected DrawPileEmptyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
