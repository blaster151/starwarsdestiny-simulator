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
            throw new NotImplementedException();
            //if (card.type_code != SwDestinyDbTypeCode.character) throw new Exception("Card is not a character.");
            //var character = new Character();
            //Enumerable.Range(1, numberOfDice).ToList().ForEach(i =>
            // {
            //     character.AddDie();
            // });
            //return character;
        }
    }
}
