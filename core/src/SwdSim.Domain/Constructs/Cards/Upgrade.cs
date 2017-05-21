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
        public readonly List<Die.Face> DieDefinition;

        public Upgrade(string name, Faction faction, Affiliation affiliation, int resourceCost, SubType? subType, List<Die.Face>  dieDefinition) : base(name, faction, affiliation, resourceCost)
        {
            SubType = subType;
            DieDefinition = dieDefinition;
        }
    }
}
