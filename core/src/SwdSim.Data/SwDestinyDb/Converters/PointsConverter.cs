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
        internal virtual int? Convert(Card card)
        {
            if (card.points == null) return null;
            return card.points.Contains("/")
                ? int.Parse(GetPointsArray(card.points)[0])
                : int.Parse(card.points);
        }

        protected string[] GetPointsArray(string points)
        {
            return points.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        }
      
    }
}
