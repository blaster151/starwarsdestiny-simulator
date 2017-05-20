using SwDestinyDb.Api.Dtos;
using SwdSim.Domain.Constructs;
using System.Collections.Generic;
using System.Linq;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class DieConverter
    {
        private readonly DieFaceConverter _dieFaceConverter = new DieFaceConverter();

        internal List<Die.Face> Convert(List<string> sides)
        {
            if (sides == null) return null;
            return sides.Select(face => _dieFaceConverter.Convert(face)).ToList();
        }
    }
}
