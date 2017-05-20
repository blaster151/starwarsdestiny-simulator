using SwdSim.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class ModifierConverter
    {
        internal Modifier? Convert(string modifier)
        {
            if (modifier == "+") return Modifier.Plus;
            return null;
        }
    }
}
