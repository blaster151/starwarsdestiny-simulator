using SwDestinyDb.Api.Dtos;
using SwdSim.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class FactionConverter
    {
        internal Faction Convert(Card card)
        {
            switch (card.faction_code)
            {
                case "gray": return Faction.Neutral;
                case "red": return Faction.Command;
                case "blue": return Faction.Force;
                case "yellow": return Faction.Rogue;
                default: throw new NotImplementedException();
            }
        }
    }
}
