using NUnit.Framework;
using SwdSim.Domain.Constructs.Cards;
using SwdSim.Domain.Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwdSim.Domain.Exceptions;

namespace SwdSim.Domain.Tests.PlayerTests
{
    [TestFixture]
    public class PlayerDrawTests
    {
        private DestinyDeck _destinyDeck;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _destinyDeck = TestUtils.GetValidDestinyDeck();
            _player = new Player(_destinyDeck);
        }
       
        [Test]
        public void Player_DrawCard_EmptyDrawPile_ThrowsEmptyDrawPileException()
        {
            _player.Setup();
            _player.DrawPile.Clear();
            Assert.Throws<DrawPileEmptyException>(() => _player.DrawCard());
        }

        [Test]
        public void Player_DrawCard_DrawsTopCard()
        {
            var topCard = _player.DrawPile.Peek();
            _player.DrawCard();
            Assert.AreSame(topCard, _player.Hand.Last());
        }

       
    }
}
