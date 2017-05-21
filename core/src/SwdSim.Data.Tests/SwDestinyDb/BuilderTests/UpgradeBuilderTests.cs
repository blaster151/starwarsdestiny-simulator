using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Builders;
using SwdSim.Domain;
using SwdSim.Domain.Tests;
using System;

namespace SwdSim.Data.Tests.SwDestinyDb.BuilderTests
{
    [TestFixture]
    public class UpgradeBuilderTests
    {
        private readonly UpgradeBuilder _builder = new UpgradeBuilder();
        private CardDefinition _cardDefinition;

        [SetUp]
        public void SetUp()
        {
            _cardDefinition = new CardDefinition()
            {
                CardType = CardType.Upgrade, 
                Faction = Faction.Command,
                Cost = 2,
                SubType = SubType.Equipment,
                Affiliation = Affiliation.Villian,
                HasDie = true,
                DieDefinition = TestUtils.GetValidDieDefinition()     
            };
        }

        [Test]
        public void UpgradeBuilder_Build_MapsCorrectly()
        {           
            var upgrade =_builder.Build(_cardDefinition);
            Assert.AreEqual(_cardDefinition.Affiliation, upgrade.Affiliation);
            Assert.AreEqual(_cardDefinition.Faction, upgrade.Faction);
            Assert.AreEqual(_cardDefinition.Cost, upgrade.ResourceCost);
            Assert.AreEqual(_cardDefinition.SubType, upgrade.SubType);
            Assert.AreEqual(_cardDefinition.DieDefinition, upgrade.DieDefinition);
        }

        [Test]
        public void UpgradeBuilder_NotAnUpgrade_ThrowsException()
        {
            _cardDefinition.CardType = CardType.Character;
            Assert.Throws<Exception>(() =>
            {
                var upgrade = _builder.Build(_cardDefinition);
            });
        }
    }
}
