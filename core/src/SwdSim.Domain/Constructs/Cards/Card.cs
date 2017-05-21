using System.Collections.Generic;

namespace SwdSim.Domain.Constructs.Cards
{
    public class Card
    {

        public readonly Faction Faction;
        public readonly Affiliation Affiliation;
        public readonly string Name;

        public Card(string name, Faction faction, Affiliation affiliation)
        {
            Faction = faction;
            Affiliation = affiliation;
            Name = name;
        }
      
    }
}
