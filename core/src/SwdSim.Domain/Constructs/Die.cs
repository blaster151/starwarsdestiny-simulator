using SwdSim.Domain.Constructs.Cards;
using SwdSim.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwdSim.Domain.Constructs
{
    public class Die
    {
        public Face ActiveFace { get; private set; }
        public readonly List<Die.Face> Faces;
        public Card Card { get; set; }

        public Die(List<Die.Face> faces)
        {
            if (faces?.Count != 6) throw new InvalidDieException("A star wars destiny die must have exactly 6 sides.");
            Faces = faces;
            ActiveFace = faces.First();
        }

        public void Roll()
        {
            Roll(new Random());
        }

        public void Roll(Random randomSeed)
        {
            ActiveFace = Faces[randomSeed.Next(0, 5)];
        }

        public class Face
        {
            public readonly Symbol? Symbol;
            public readonly int Value;
            public readonly Modifier? Modifer;
            public readonly int ResourceCost;

            public Face(Symbol? symbol, int value, Modifier? modifier, int resourceCost)
            {
                validateFace(symbol, value, modifier);
                Symbol = symbol;
                Value = value;
                Modifer = modifier;
                ResourceCost = resourceCost;
            }

            private void validateFace(Symbol? symbol, int value, Modifier? modifier)
            {
                if (symbol == Domain.Symbol.Special)
                {
                    if (value != 0) throw new InvalidDieFaceException("Special faces must have a value of 0.");
                    if (modifier.HasValue) throw new InvalidDieFaceException("Special faces cannot have modifiers.");
                }
                else if (symbol == Domain.Symbol.Blank)
                {
                    if (value != 0) throw new InvalidDieFaceException("Special faces must have a value of 0.");
                    if (modifier.HasValue) throw new InvalidDieFaceException("Special faces cannot have modifiers.");
                }
                else if (symbol.HasValue)
                {
                    if (value == 0) throw new InvalidDieFaceException($"{symbol} cannot have a value of 0.");                   
                }
            }
        }
    }
}
