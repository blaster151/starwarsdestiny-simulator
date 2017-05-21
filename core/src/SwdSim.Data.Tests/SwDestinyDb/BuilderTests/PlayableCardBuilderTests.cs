using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Builders;
using SwdSim.Domain;
using SwdSim.Domain.Constructs.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.Tests.SwDestinyDb.BuilderTests
{
    [TestFixture]
    public class PlayableCardBuilderTests
    {
        private readonly PlayableCardBuilder _builder = new PlayableCardBuilder();
        private CardDefinition _cardDefinition;

        [SetUp]
        public void SetUp()
        {
            _cardDefinition = new CardDefinition()
            {
                CardType = CardType.Event,
                Faction = Faction.Command,
                Cost = 4,
                SubType = SubType.Vehicle,
                Affiliation = Affiliation.Villian,
                HasDie = true,
            };
        }

        [TestCase(CardType.Battlefield, false)]
        [TestCase(CardType.Character, false)]
        [TestCase(CardType.Event, true)]
        [TestCase(CardType.Support, true)]
        [TestCase(CardType.Upgrade, true)]
        public void PlayableCardBuilder_CanBuild_ReturnsCorrect(CardType type, bool expected)
        {
            _cardDefinition.CardType = type;
            Assert.AreEqual(expected, _builder.CanBuildCard(_cardDefinition));
        }

        [TestCase(CardType.Event, typeof(EventCard))]
        [TestCase(CardType.Support, typeof(Support))]
        [TestCase(CardType.Upgrade, typeof(Upgrade))]
        public void PlayableCardBuilder_CanBuild_ReturnsCorrectType(CardType cardType, Type expectedType)
        {
            //individual builders are tested thoroughly so test here just to make sure they come back with right type
            _cardDefinition.CardType = cardType;
            var card = _builder.Build(_cardDefinition);
            Assert.IsAssignableFrom(expectedType, card);
        }

        [TestCase(CardType.Battlefield)]
        [TestCase(CardType.Character)]
        public void PlayableCardBuilder_Build_NotPlayableCard_ThrowsException(CardType cardType)
        {
            _cardDefinition.CardType = cardType;
            Assert.Throws<Exception>(() => _builder.Build(_cardDefinition));
        }
    }
}
