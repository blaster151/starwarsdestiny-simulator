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
    public class PlayerSetupTests
    {
        private DestinyDeck _destinyDeck;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _destinyDeck = TestUtils.GetValidDestinyDeck();
            _player = new Player(_destinyDeck);
        }

        //[Test]
        //public void Setup_ShufflesDrawDeck()
        //{
        //    var player = new Player(_destinyDeck);            
        //    //how to test that shuffle is called?
        //}

        [Test]
        public void Player_Setup_DrawsFiveCards()
        {
            _player.Setup();
            Assert.AreEqual(5, _player.Hand.Count);
        }

       
    }
}
