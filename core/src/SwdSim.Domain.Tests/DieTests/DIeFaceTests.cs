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
    public class DieFaceTests
    {
        private Symbol[] ValueSymbols = new[] { Symbol.Discard, Symbol.Disrupt, Symbol.Focus, Symbol.MeleeDamage, Symbol.RangedDamage, Symbol.Resource, Symbol.Shield };
        private Symbol[] ZeroValueSymbols = new[] { Symbol.Special, Symbol.Blank };

        [Test]
        public void DieFace_Construct_ValueDice_Valid_DoesNotThrow()
        {
            foreach (var symbol in ValueSymbols)
            {
                foreach (var i in Enumerable.Range(1, 30))
                {
                    Assert.DoesNotThrow(() =>
                    {
                        var face = new Die.Face(symbol, i, null, 0);
                        face = new Die.Face(symbol, i, Modifier.Plus, 0);
                    });
                }                
            }
        }

        [Test]
        public void DieFace_Construct_ValueDice_Invalid_ThrowsException()
        {
            foreach (var symbol in ValueSymbols)
            {               
                Assert.Throws<InvalidDieFaceException>(() =>
                {
                    var face = new Die.Face(symbol, 0, null, 0);
                });                
            }
        }

        [Test]
        public void DieFace_Construct_ZeroValueDice_Valid_Succeeds()
        {
            foreach (var symbol in ZeroValueSymbols)
            {
                Assert.DoesNotThrow(() =>
                {
                    var face = new Die.Face(symbol, 0, null, 0);
                });
            }          
        }

        [Test]
        public void DieFace_Construct_ZeroValueDice_Invalid_ThrowsException()
        {
            foreach (var symbol in ZeroValueSymbols)
            {
                Assert.Throws<InvalidDieFaceException>(() =>
                {
                    var face = new Die.Face(symbol, 1, null,0 );
                });
                Assert.Throws<InvalidDieFaceException>(() =>
                {
                    var face = new Die.Face(symbol, 0, Modifier.Plus, 0);
                });
            }
        }


    }
}
