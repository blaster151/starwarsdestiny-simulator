using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwDestinyDb.Api.Dtos;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class ElitePointsConverter : PointsConverter
    {
        internal override int? Convert(Card card)
        {
            if (card.points == null) return null;
            return card.points.Contains("/")
                ? int.Parse(GetPointsArray(card.points)[1])
                : (int?)null;
        }

    }
}
