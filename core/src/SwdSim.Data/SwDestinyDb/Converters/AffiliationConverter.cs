using SwDestinyDb.Api.Dtos;
using SwdSim.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class AffiliationConverter
    {
        internal Affiliation Convert(string affiliation_code)
        {
            switch (affiliation_code)
            {
                case "hero": return Affiliation.Hero;
                case "neutral": return Affiliation.Neutral;
                case "villain": return Affiliation.Villian;
                default: throw new NotImplementedException();
            }
        }
    }
}
