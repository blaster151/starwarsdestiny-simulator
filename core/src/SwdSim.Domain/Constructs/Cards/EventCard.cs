using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Constructs.Cards
{
    public class EventCard : PlayableCard
    {
        public EventCard(Faction faction, Affiliation affiliation, int resourceCost) : base(faction, affiliation, resourceCost)
        {
        }
    }
}
