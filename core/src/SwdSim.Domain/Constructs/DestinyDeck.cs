using SwdSim.Domain.Constructs.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Constructs
{
    public class DestinyDeck
    {
        public readonly List<Card> DrawDeck;
        public readonly List<Character> Team;
        public readonly Battlefield Battlefield;

        public DestinyDeck(IEnumerable<Character> team, IEnumerable<Card> drawDeck, Battlefield battlefield)
        {
            DrawDeck = drawDeck.ToList();
            Team = team.ToList();
            Battlefield = battlefield;
        }
            
    }

}
