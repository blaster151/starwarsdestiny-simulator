using SwdSim.Domain.Constructs.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.SwDestinyDb.Builders
{
    public interface IBattlefieldBuilder
    {
        Battlefield Build(CardDefinition card);
    }
}
