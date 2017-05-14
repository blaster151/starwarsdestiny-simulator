using SwdSim.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Constructs
{
    public class Die
    {
        public Face ActiveFace { get; private set; }
        public readonly List<Die.Face> Faces;

        public Die(List<Die.Face> faces)
        {
            if (faces?.Count != 6) throw new InvalidDieException("A star wars destiny die must have exactly 6 sides.");
            Faces = faces;
            ActiveFace = faces.First();
        }

        public class Face
        {
            public readonly Symbol? Symbol;
            public readonly int Value;
            public readonly Modifier? Modifer;

            public Face(Symbol? symbol, int value, Modifier? modifier)
            {
                validateFace(symbol, value, modifier);
                Symbol = symbol;
                Value = value;
                Modifer = modifier;
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
