using SwdSim.Domain.Exceptions;
using System.Collections.Generic;

namespace SwdSim.Domain.Constructs.Cards
{
    public class Character : Card
    {
        public readonly int Health;
        public readonly List<Die.Face> DieDefinition;
        public readonly List<Die> Dice;
        public readonly bool IsUnique;
        public readonly int Points;
        public readonly int? ElitePoints;

        public Character(string name, Faction faction, Affiliation affiliation, int health, List<Die.Face> dieDefinition, bool isUnique, int points, int? elitePoints) : base(name, faction, affiliation)
        {
            Health = health;
            DieDefinition = dieDefinition;
            Dice = new List<Die>();
            IsUnique = isUnique;
            Points = points;
            ElitePoints = elitePoints;
        }

        public int TotalPoints
        {
            get
            {
                if (Dice.Count == 1) return Points;
                if (Dice.Count == 2) return ElitePoints.GetValueOrDefault();
                return 0;
            }
        }

        public virtual void AddDie()
        {
            if (this.Dice.Count == 2) throw new MaxCharacterDiceExceededException();
            if (!ElitePoints.HasValue && this.Dice.Count == 1) throw new MaxCharacterDiceExceededException();
            this.Dice.Add(new Constructs.Die(DieDefinition));
        }
    }
}
