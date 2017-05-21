using SwdSim.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class SymbolConverter
    {
        internal Symbol Convert(string symbol)
        {
            switch (symbol)
            {
                case "-": return Symbol.Blank;
                case "Sp": return Symbol.Special;
                case "Sh": return Symbol.Shield;
                case "MD": return Symbol.MeleeDamage;
                case "RD": return Symbol.RangedDamage;
                case "Dc": return Symbol.Discard;
                case "Dr": return Symbol.Disrupt;
                case "F": return Symbol.Focus;
                case "R": return Symbol.Resource;
                case "X": return Symbol.Wildcard;
                default: throw new NotImplementedException();
            }
        }
    }
}
