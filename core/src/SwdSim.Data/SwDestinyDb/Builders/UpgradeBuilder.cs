using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwdSim.Domain.Constructs.Cards;
using Card = SwDestinyDb.Api.Dtos.Card;

namespace SwdSim.Data.SwDestinyDb.Builders
{
    public class UpgradeBuilder
    {
        public Upgrade Build(CardDefinition card)
        {
            if (card.CardType != Domain.CardType.Upgrade) throw new Exception("Card is not an Upgrade.");
            var upgrade = new Upgrade(card.Faction, card.Affiliation, card.Cost.Value, card.SubType, card.DieDefinition);
            //TODO - add behaviors           
            return upgrade;
        }
    }
}
