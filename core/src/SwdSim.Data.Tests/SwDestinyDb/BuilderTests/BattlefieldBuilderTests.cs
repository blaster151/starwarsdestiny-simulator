using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Builders;
using SwdSim.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.Tests.SwDestinyDb.BuilderTests
{
    [TestFixture]
    public class BattlefieldBuilderTests
    {
        private readonly BattlefieldBuilder _builder = new BattlefieldBuilder();
        private CardDefinition _cardDefinition;

        [SetUp]
        public void SetUp()
        {
            _cardDefinition = new CardDefinition()
            {
                CardType = CardType.Battlefield,               
            };
        }

        [Test]
        public void BattleFieldBuilder_Maps_Correctly()
        {           
            var battleField =_builder.Build(_cardDefinition);
            Assert.AreEqual(Affiliation.Neutral, battleField.Affiliation);
            Assert.AreEqual(Faction.Neutral, battleField.Faction);
        }

        [Test]
        public void BattleFieldBuilder_NotABattleField_ThrowsException()
        {
            _cardDefinition.CardType = CardType.Character;
            Assert.Throws<Exception>(() =>
            {
                var battleField = _builder.Build(_cardDefinition);
            });
        }
    }
}
