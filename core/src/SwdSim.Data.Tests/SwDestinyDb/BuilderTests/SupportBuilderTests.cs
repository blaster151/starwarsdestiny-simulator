using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Builders;
using SwdSim.Domain;
using SwdSim.Domain.Tests;
using System;

namespace SwdSim.Data.Tests.SwDestinyDb.BuilderTests
{
    [TestFixture]
    public class SupportBuilderTests
    {
        private readonly SupportBuilder _builder = new SupportBuilder();
        private CardDefinition _cardDefinition;

        [SetUp]
        public void SetUp()
        {
            _cardDefinition = new CardDefinition()
            {
                CardType = CardType.Support, 
                Faction = Faction.Command,
                Cost = 4,
                SubType = SubType.Vehicle,
                Affiliation = Affiliation.Villian,
                HasDie = true,
                DieDefinition = TestUtils.GetValidDieDefinition()     
            };
        }

        [Test]
        public void SupportBuilder_Build_MapsCorrectly()
        {           
            var support =_builder.Build(_cardDefinition);
            Assert.AreEqual(_cardDefinition.Affiliation, support.Affiliation);
            Assert.AreEqual(_cardDefinition.Faction, support.Faction);
            Assert.AreEqual(_cardDefinition.Cost, support.ResourceCost);
            Assert.AreEqual(_cardDefinition.SubType, support.SubType);
            Assert.AreEqual(_cardDefinition.DieDefinition, support.DieDefinition);
        }

        [Test]
        public void SupportBuilder_NotASupport_ThrowsException()
        {
            _cardDefinition.CardType = CardType.Character;
            Assert.Throws<Exception>(() =>
            {
                var upgrade = _builder.Build(_cardDefinition);
            });
        }
    }
}
