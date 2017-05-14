using NUnit.Framework;
using SwdSim.Domain.Constructs.Cards;
using SwdSim.Domain.Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Domain.Tests.PlayerTests
{
    [TestFixture]
    public class PlayerConstructorTests
    {
        private DestinyDeck _destinyDeck;

        [SetUp]
        public void Setup()
        {
            var cards = Enumerable.Range(1, 30).Select(m => new Card());
            var characters = Enumerable.Range(1, 2).Select(m => new Character());
            var bf = new Battlefield();
            _destinyDeck = new DestinyDeck(characters, cards, bf);
        }

        [Test]
        public void Player_Construct_DiscardPileInitialized()
        {
            var player = new Player(_destinyDeck);
            Assert.IsNotNull(player.DiscardPile);
        }

        [Test]
        public void Player_Construct_SetAsideAreaInitialized()
        {
            var player = new Player(_destinyDeck);
            Assert.IsNotNull(player.SetAsideArea);
        }

        [Test]
        public void Player_Construct_DicePoolInitialized()
        {
            var player = new Player(_destinyDeck);
            Assert.IsNotNull(player.DicePool);
        }

        [Test]
        public void Player_Construct_HasZeroResourcesToStart()
        {
            var player = new Player(_destinyDeck);
            Assert.AreEqual(0, player.ResourceCount);
        }

        [Test]
        public void Player_Construct_DrawPileInitializedWithDrawDeck()
        {
            var player = new Player(_destinyDeck);
            Assert.IsNotNull(player.DrawPile);
            foreach (var card in _destinyDeck.DrawDeck)
            {
                Assert.Contains(card, player.DrawPile);
            }
        }

        [Test]
        public void Player_Construct_BattlefieldSet()
        {
            var player = new Player(_destinyDeck);
            Assert.AreSame(_destinyDeck.Battlefield, player.Battlefield);
        }

        [Test]
        public void Player_Construct_CharactersIncluded()
        {
            var player = new Player(_destinyDeck);
            for (int i = 0; i < player.Characters.Count; i++)
            {
                Assert.AreSame(_destinyDeck.Team[i], player.Characters[i]);
            }
        }
    }
}
