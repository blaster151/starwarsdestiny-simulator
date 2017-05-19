using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwdSim.Domain.Constructs.Cards;
using Card = SwDestinyDb.Api.Dtos.Card;

namespace SwdSim.Data.SwDestinyDb.Builders
{
    public class SupportBuilder
    {
        public Support Build(CardDefinition card)
        {
            if (card.CardType != Domain.CardType.Support) throw new Exception("Card is not a support.");
            var support = new Support(card.Faction, card.Affiliation, card.Cost.Value, card.DieDefinition.ToArray());
            //TODO - add behaviors           
            return support;
        }
    }
}
