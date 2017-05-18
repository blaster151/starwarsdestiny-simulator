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
    public class CharacterPointsTests
    {
        
        [Test]
        public void Construct_Character_HasNoPoints()
        {
            var character = TestUtils.GetValidCharacter(false, 10, null);
            Assert.AreEqual(0, character.TotalPoints);
        }

        [Test]
        public void Construct_NonEliteCharacter_PointsSameAsOneDie()
        {
            int points = 10;
            var character = TestUtils.GetValidCharacter(false, points, null);
            character.AddDie();
            Assert.AreEqual(points, character.TotalPoints);
        }

        [Test]
        public void Construct_EliteCharacter_PointsAreTwoDie()
        {
            int points = 10;
            int elitePoints = 15;
            var character = TestUtils.GetValidCharacter(false, points, elitePoints);
            character.AddDie();
            character.AddDie();
            Assert.AreEqual(elitePoints, character.TotalPoints);
        }



    }
}
