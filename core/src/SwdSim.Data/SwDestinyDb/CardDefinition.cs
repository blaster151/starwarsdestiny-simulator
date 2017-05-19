using SwdSim.Domain;
using SwdSim.Domain.Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb
{
    public class CardDefinition
    {
        public string Name { get; set; }
        public string SubTitle { get; set; }
        public CardType CardType { get; set; }
        public Affiliation Affiliation { get; set; }
        public Faction Faction { get; set; }
        public SubType SubType { get;set;}
        public Die.Face[] DieDefinition { get; set; }
        public int? Cost { get; set; }
        public int? Health { get; set; }
        public int? Points { get; set; }
        public int? ElitePoints { get; set; }
        public bool IsUnique { get; set; }
        public bool HasDie { get; set; }       
    }
}
