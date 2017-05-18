using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Exceptions
{

    [Serializable]
    public class MaxCharacterDiceExceededException : Exception
    {
        public MaxCharacterDiceExceededException() { }
        public MaxCharacterDiceExceededException(string message) : base(message) { }
        public MaxCharacterDiceExceededException(string message, Exception inner) : base(message, inner) { }
        protected MaxCharacterDiceExceededException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
