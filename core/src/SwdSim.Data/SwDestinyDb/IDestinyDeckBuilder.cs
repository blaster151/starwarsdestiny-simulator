using SwDestinyDb.Api.Dtos;
using SwdSim.Domain.Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb
{
    public interface IDestinyDeckBuilder
    {
        DestinyDeck Build(DeckList deckList, List<Card> destinyCards);
    }
}
