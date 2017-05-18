using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Constructs.Cards
{
    public class PlayableCard : Card
    {
        public readonly int ResourceCost;
        public readonly List<Die> Dice;

        public PlayableCard(Faction faction, Affiliation affiliation, int resourceCost) : base(faction, affiliation)
        {
            ResourceCost = resourceCost;
            Dice = new List<Die>();
        }


    }
}
