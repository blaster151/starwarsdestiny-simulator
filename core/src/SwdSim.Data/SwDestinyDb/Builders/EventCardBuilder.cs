using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwdSim.Domain.Constructs.Cards;
using Card = SwDestinyDb.Api.Dtos.Card;

namespace SwdSim.Data.SwDestinyDb.Builders
{
    public class EventCardBuilder
    {
        public EventCard Build(CardDefinition card)
        {
            if (card.CardType != Domain.CardType.Event) throw new Exception("Card is not an event.");
            var @event = new EventCard(card.Faction, card.Affiliation, card.Cost.Value);
            //TODO - add behaviors           
            return @event;
        }
    }
}
