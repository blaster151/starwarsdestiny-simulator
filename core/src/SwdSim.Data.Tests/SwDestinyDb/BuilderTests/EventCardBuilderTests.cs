using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Builders;
using SwdSim.Domain;
using SwdSim.Domain.Tests;
using System;

namespace SwdSim.Data.Tests.SwDestinyDb.BuilderTests
{
    [TestFixture]
    public class EventCardBuilderTests
    {
        private readonly EventCardBuilder _builder = new EventCardBuilder();
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

        [Test]
        public void EventCardBuilder_Build_MapsCorrectly()
        {           
            var @event =_builder.Build(_cardDefinition);
            Assert.AreEqual(_cardDefinition.Affiliation, @event.Affiliation);
            Assert.AreEqual(_cardDefinition.Faction, @event.Faction);
            Assert.AreEqual(_cardDefinition.Cost, @event.ResourceCost);
        }

        [Test]
        public void EventCardtBuilder_NotAnEvent_ThrowsException()
        {
            _cardDefinition.CardType = CardType.Character;
            Assert.Throws<Exception>(() =>
            {
                var @event = _builder.Build(_cardDefinition);
            });
        }
    }
}
