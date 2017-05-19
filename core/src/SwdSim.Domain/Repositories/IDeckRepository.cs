using SwdSim.Domain.Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Repositories
{
    public interface IDeckRepository
    {
        DestinyDeck GetDestinyDeck(string deckId);
    }
}
