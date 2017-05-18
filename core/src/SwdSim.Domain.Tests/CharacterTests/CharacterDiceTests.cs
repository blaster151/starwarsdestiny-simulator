using NUnit.Framework;
using SwdSim.Domain.Constructs.Cards;
using SwdSim.Domain.Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwdSim.Domain.Exceptions;

namespace SwdSim.Domain.Tests.DieTests
{
    [TestFixture]
    public class CharacterDiceTests
    {
        
        [Test]
        public void  Character_AddDie_AddsDiceWithoutException()
        {
            var character = TestUtils.GetValidCharacter(false, 10, null);
            Assert.DoesNotThrow(() =>
            {
                character.AddDie();
                Assert.AreEqual(1, character.Dice.Count);
            });
        }

        [Test]
        public void Character_AddDieSecondDieToNoElite_ThrowsException()
        {
            var character = TestUtils.GetValidCharacter(false, 10, null);
            Assert.Throws<MaxCharacterDiceExceededException>(() =>
            {
                character.AddDie();
                character.AddDie();
            });
        }

        [Test]
        public void Character_AddTwoDieToEliteCharacter_AddsTwoDiceWithoutException()
        {
            var character = TestUtils.GetValidCharacter(false, 10, 12);
            Assert.DoesNotThrow(() =>
            {
                character.AddDie();
                character.AddDie();
                Assert.AreEqual(2, character.Dice.Count);
            });
        }



    }
}
