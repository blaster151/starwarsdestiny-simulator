using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwdSim.Domain.Constructs.Cards;
using Card = SwDestinyDb.Api.Dtos.Card;
using SwDestinyDbTypeCode = SwDestinyDb.Api.TypeCode;
using SwdSim.Domain;

namespace SwdSim.Data.SwDestinyDb.Builders
{
    public class PlayableCardBuilder
    {
        private readonly SupportBuilder _supportBuilder = new SupportBuilder();
        private readonly UpgradeBuilder _upgradeBuilder = new UpgradeBuilder();
        private readonly EventCardBuilder _eventCardBuilder = new EventCardBuilder();

        public readonly CardType[] PlayableCardTypes = new[] { CardType.Event, CardType.Support, CardType.Upgrade };

        public bool CanBuildCard(CardDefinition card)
        {
            return PlayableCardTypes.Contains(card.CardType);
        }

        public PlayableCard Build(CardDefinition card)
        {
            return null;
        }
    }
}
