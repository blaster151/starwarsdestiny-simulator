using SwDestinyDb.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class PointsConverter
    {
        internal virtual int? Convert(string points)
        {
            if (points == null) return null;
            return points.Contains("/")
                ? int.Parse(GetPointsArray(points)[0])
                : int.Parse(points);
        }

        protected string[] GetPointsArray(string points)
        {
            return points.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        }
      
    }
}
