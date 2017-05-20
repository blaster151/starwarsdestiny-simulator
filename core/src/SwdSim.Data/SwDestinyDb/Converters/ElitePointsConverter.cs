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
        internal override int? Convert(string points)
        {
            if (points == null) return null;
            return points.Contains("/")
                ? int.Parse(GetPointsArray(points)[1])
                : (int?)null;
        }

    }
}
