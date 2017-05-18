using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Constructs.Cards
{
    public class Battlefield : Card
    {
        public Battlefield() : base(Faction.Neutral, Affiliation.Neutral)
        {
        }
    }
}
