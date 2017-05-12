using SwdSim.Domain.Constructs.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Constructs
{
    public class SetAsideArea
    {
        public readonly List<Card> Cards;

        public SetAsideArea()
        {
            Cards = new List<Card>();
        }
    }
}
