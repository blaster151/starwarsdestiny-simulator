using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwdSim.Domain.Constructs.Cards;
using Card = SwDestinyDb.Api.Dtos.Card;
using SwDestinyDbTypeCode = SwDestinyDb.Api.TypeCode;

namespace SwdSim.Data.SwDestinyDb.Builders
{
    public class CharacterBuilder
    {
        public Character Build(CardDefinition card, int numberOfDice)
        {
            if (card.CardType != Domain.CardType.Character) throw new Exception("Card is not a character.");
            var character = new Character(card.Faction, card.Affiliation, card.Health.Value, card.DieDefinition, card.IsUnique, card.Points.Value, card.ElitePoints);
            Enumerable.Range(1, numberOfDice).ToList().ForEach(i => { character.AddDie(); });
            return character;
        }
    }
}
