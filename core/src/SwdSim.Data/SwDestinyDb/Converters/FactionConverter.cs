using SwdSim.Domain;
using System;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class FactionConverter
    {
        internal Faction Convert(string faction_code)
        {
            switch (faction_code)
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
