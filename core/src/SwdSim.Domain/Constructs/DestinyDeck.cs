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
        public readonly List<PlayableCard> DrawDeck;
        public readonly List<Character> Team;
        public readonly Battlefield Battlefield;

        public int TotalPoints => Team.Sum(c => c.TotalPoints);

        public DestinyDeck(IEnumerable<Character> team, IEnumerable<PlayableCard> drawDeck, Battlefield battlefield)
        {
            DrawDeck = drawDeck.ToList();
            Team = team.ToList();
            Battlefield = battlefield;
        }
            
    }

}
