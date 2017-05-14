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
    public class DieTests
    {
        private Die.Face _validFace = new Die.Face(Symbol.MeleeDamage, 1, Modifier.Plus);

        [Test]
        public void Construct_NullFaces_ThrowsException()
        {
            Assert.Throws<InvalidDieException>(() =>
            {
                var die = new Die(null);
            });
        }

        [Test]
        public void Construct_6ValidFaces_Success()
        {
            Assert.DoesNotThrow(() =>
            {
                var faces = new List<Die.Face>() { _validFace, _validFace, _validFace, _validFace, _validFace, _validFace };
                var die = new Die(faces);
            });
        }

        [Test]
        public void Construct_Not6Faces_ThrowsException()
        {
            Assert.Throws<InvalidDieException>(() =>
            {
                var faces = new List<Die.Face>() { _validFace };
                var die = new Die(faces);
            });
        }


    }
}
