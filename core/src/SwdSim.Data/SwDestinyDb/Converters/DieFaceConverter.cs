using SwdSim.Domain.Constructs;
using System;
using System.Text.RegularExpressions;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class DieFaceConverter
    {
        private static Regex _faceRegex = new Regex(@"^(?<modifier>\+?)(?<value>\d{0,3})(?<symbol>-|Sp|Sh|MD|RD|Dc|Dr|F|R|X)(?<resourceCost>\d{0,3})$");
        private static SymbolConverter _symbolConverter = new SymbolConverter();
        private static ModifierConverter _modifierConverter = new ModifierConverter();

        internal Die.Face Convert(string face)
        {
            var match = _faceRegex.Match(face);
            if (!match.Success) throw new NotSupportedException($"{face} is an unsupported die face");

            var modifier = match.Groups["modifier"].Value;
            var value = match.Groups["value"].Value;
            var symbol = match.Groups["symbol"].Value;
            var resourceCost = match.Groups["resourceCost"].Value;

            return new Die.Face(
                _symbolConverter.Convert(symbol),
                GetValue(value),
                _modifierConverter.Convert(modifier),
                GetValue(resourceCost)
            );          
        }

        private int GetValue(string value, int @default = 0)
        {
            int output;
            if (int.TryParse(value, out output)) return output;
            return @default;
        } 

    
    }
}
