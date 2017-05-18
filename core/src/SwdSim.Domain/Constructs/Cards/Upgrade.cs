using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Constructs.Cards
{
    public class Upgrade : PlayableCard
    {
        public readonly SubType? SubType;

        public Upgrade(Faction faction, Affiliation affiliation, int resourceCost, SubType? subType, Die.Face[] dieDefinition) : base(faction, affiliation, resourceCost)
        {
            SubType = subType;
        }
    }
}
