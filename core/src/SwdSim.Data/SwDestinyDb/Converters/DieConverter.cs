using SwDestinyDb.Api.Dtos;
using SwdSim.Domain.Constructs;
using System.Collections.Generic;
using System.Linq;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class DieConverter
    {
        private readonly DieFaceConverter _dieFaceConverter = new DieFaceConverter();

        internal List<Die.Face> ConvertSidesToDieDefinition(Card card)
        {
            if (card.sides == null) return null;
            return card.sides.Select(face => _dieFaceConverter.Convert(face)).ToList();
        }
    }
}
