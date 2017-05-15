using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Constructs.Cards
{
    public class Card
    {
        public Card()
        {
            Dice = new List<Die>();
        }

        public List<Die> Dice { get; set; }
    }
}
