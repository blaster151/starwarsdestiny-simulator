using SwdSim.Domain.Constructs;
using SwdSim.Domain.Constructs.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Tests
{
    public static class TestUtils
    {
        public static DestinyDeck GetValidDestinyDeck()
        {
            var cards = Enumerable.Range(1, 30).Select(m => new PlayableCard(Faction.Command, Affiliation.Villian, 1));
            var characters = Enumerable.Range(1, 2).Select(m => GetValidCharacter(false, 10, null));
            var bf = new Battlefield();
            return new DestinyDeck(characters, cards, bf);
        }

        public static List<Die.Face> GetValidDieDefinition()
        {
            return Enumerable.Range(1, 6).Select(m => new Die.Face(Symbol.Blank, 0, null)).ToList();
        }

        public static Character GetValidCharacter(bool isUnique, int points, int? elitePoints)
        {
            var dieDefinition = GetValidDieDefinition();
            return new Character(Faction.Command, Affiliation.Villian, 10, dieDefinition, isUnique, points, elitePoints);
        }
    }
}
