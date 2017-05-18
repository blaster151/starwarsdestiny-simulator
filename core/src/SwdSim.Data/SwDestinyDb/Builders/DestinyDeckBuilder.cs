using SwdSim.Domain.Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckList = SwDestinyDb.Api.Dtos.DeckList;
using Card = SwDestinyDb.Api.Dtos.Card;
using SwdSim.Domain.Constructs.Cards;

namespace SwdSim.Data.SwDestinyDb.Builders
{
    public class DestinyDeckBuilder
    {
        private readonly CharacterBuilder _characterBuilder = new CharacterBuilder();
        private readonly BattlefieldBuilder _battleFieldBuilder = new BattlefieldBuilder();
        private readonly PlayableCardBuilder _playableCardBuilder = new PlayableCardBuilder();

        private readonly Dictionary<string, Card> _cards;

        public DestinyDeckBuilder(List<Card> cards)
        {
            _cards = cards.ToDictionary(c => c.code);
        }

        DestinyDeck Build(DeckList deckList)
        {           
            throw new NotImplementedException();
        }
      
    }
}
