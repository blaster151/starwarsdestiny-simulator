using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Constructs.Cards
{
    public class Support : PlayableCard
    {
        public readonly Die.Face[] DieDefinition;

        public Support(Faction faction, Affiliation affiliation, int resourceCost, Die.Face[] dieDefinition) : base(faction, affiliation, resourceCost)
        {
            DieDefinition = dieDefinition;
        }
    }
}
