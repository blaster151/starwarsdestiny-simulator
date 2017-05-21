using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Builders;
using SwdSim.Domain;
using SwdSim.Domain.Tests;
using System;

namespace SwdSim.Data.Tests.SwDestinyDb.BuilderTests
{
    [TestFixture]
    public class CharacterBuilderTests
    {
        private readonly CharacterBuilder _builder = new CharacterBuilder();
        private CardDefinition _cardDefinition;

        [SetUp]
        public void SetUp()
        {
            _cardDefinition = new CardDefinition()
            {
                CardType = CardType.Character, 
                Faction = Faction.Command,
                Cost = 4,
                SubType = SubType.Vehicle,
                Affiliation = Affiliation.Villian,
                HasDie = true,  
                DieDefinition = TestUtils.GetValidDieDefinition(),
                Points = 10,
                ElitePoints = 13,
                IsUnique = true,
                Health = 12
            };
        }

        [Test]
        public void CharacterBuilder_Build_MapsCorrectly()
        {           
            var character = _builder.Build(_cardDefinition, 2);
            Assert.AreEqual(_cardDefinition.Affiliation, character.Affiliation);
            Assert.AreEqual(_cardDefinition.Faction, character.Faction);
            Assert.AreEqual(_cardDefinition.IsUnique, character.IsUnique);
            Assert.AreEqual(_cardDefinition.Health, character.Health);
            Assert.AreEqual(_cardDefinition.ElitePoints, character.TotalPoints);
            Assert.AreEqual(2, character.Dice.Count);
        }

        [Test]
        public void CharacterBuilder_BuildNonUnique_TotalPointsIsNonElite()
        {
            var character = _builder.Build(_cardDefinition, 1);
            Assert.AreEqual(_cardDefinition.Points, character.TotalPoints);
        }

        [Test]
        public void CharacterBuilder_NotACharacter_ThrowsException()
        {
            _cardDefinition.CardType = CardType.Upgrade;
            Assert.Throws<Exception>(() =>
            {
                var character = _builder.Build(_cardDefinition, 2);
            });
        }
    }
}
