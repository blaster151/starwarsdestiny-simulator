using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb.Exceptions
{

    [Serializable]
    public class DeckListNotFoundException : Exception
    {
        public DeckListNotFoundException() { }
        public DeckListNotFoundException(string message) : base(message) { }
        public DeckListNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected DeckListNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
