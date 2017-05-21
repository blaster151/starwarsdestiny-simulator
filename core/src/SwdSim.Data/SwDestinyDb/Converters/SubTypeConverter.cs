using SwDestinyDb.Api.Dtos;
using SwdSim.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    internal class SubTypeConverter
    {
        internal SubType? Convert(string subtype_code)
        {
            switch (subtype_code)
            {
                case "vehicle": return SubType.Vehicle;
                case "ability": return SubType.Ability;
                case "weapon": return SubType.Weapon;
                case "equipment": return SubType.Equipment;
                case "droid": return SubType.Droid;
                case null: return null;
                default: throw new NotImplementedException();
            }
        }
    }
}
