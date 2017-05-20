using SwDestinyDb.Api.Dtos;
using SwdSim.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class CardTypeConverter
    {
        internal CardType Convert(string type_code)
        {
            switch (type_code)
            {
                case "character": return CardType.Character;
                case "event": return CardType.Event;
                case "upgrade": return CardType.Upgrade;
                case "support": return CardType.Support;
                case "battlefield": return CardType.Battlefield;
                default: throw new NotImplementedException();
            }
        }
    }
}
