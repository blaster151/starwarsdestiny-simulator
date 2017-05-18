using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwdSim.Domain.Constructs.Cards;
using Card = SwDestinyDb.Api.Dtos.Card;

namespace SwdSim.Data.SwDestinyDb.Builders
{
    public class PlayableCardBuilder
    {
        private readonly SupportBuilder _supportBuilder = new SupportBuilder();
        private readonly UpgradeBuilder _upgradeBuilder = new UpgradeBuilder();
        private readonly EventCardBuilder _eventCardBuilder = new EventCardBuilder();

        public PlayableCard Build(Card card)
        {
            return null;
        }
    }
}
