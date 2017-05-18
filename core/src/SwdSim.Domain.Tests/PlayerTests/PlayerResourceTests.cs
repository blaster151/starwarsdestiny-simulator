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
    public class PlayerResourceTests
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
        public void Player_TakeResource_Adds1()
        {
            var originalCount = _player.ResourceCount;
            _player.TakeResource();
            Assert.AreEqual(originalCount + 1, _player.ResourceCount);
        }

        [Test]
        public void Player_TakeResourceOverload_Takes3()
        {
            var originalCount = _player.ResourceCount;
            _player.TakeResource(3);
            Assert.AreEqual(originalCount + 3, _player.ResourceCount);
        }

        [Test]
        public void Player_SpendResource_Subtracts1()
        {
            _player.TakeResource(5);           
            _player.SpendResource();
            Assert.AreEqual(4, _player.ResourceCount);
        }

        [Test]
        public void Player_SpendResourceOverload_Spends3()
        {
            _player.TakeResource(5);
            _player.SpendResource(3);
            Assert.AreEqual(2, _player.ResourceCount);
        }

        [Test]
        public void Player_SpendResource_DoesntHave_ThrowsException()
        {
            Assert.Throws<NotEnoughResourcesException>(() => {
                _player.SpendResource();
            });
         
        }
        [Test]
        public void Player_SpendResource_DoesntHave3_ThrowsException()
        {
            _player.TakeResource(2);
            Assert.Throws<NotEnoughResourcesException>(() => {
                _player.SpendResource(3);
            });
        }



    }
}
