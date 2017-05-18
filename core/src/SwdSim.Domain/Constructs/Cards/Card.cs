using System.Collections.Generic;

namespace SwdSim.Domain.Constructs.Cards
{
    public class Card
    {

        public readonly Faction Faction;
        public readonly Affiliation Affiliation;

        public Card(Faction faction, Affiliation affiliation)
        {
            Faction = faction;
            Affiliation = affiliation;
        }
      
    }
}
