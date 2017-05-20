using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Converters;
using SwdSim.Domain;
using System;
using System.Collections.Generic;

namespace SwdSim.Data.Tests.SwDestinyDb.ConverterTests
{
    [TestFixture]
    public class DieConverterTests
    {
        private readonly DieConverter _converter = new DieConverter();
      
        [Test]
        public void DieConverter_Convert_NoSides_ReturnsNull()
        {
            var sides = (List<string>)null;
            var dieDefinition = _converter.Convert(sides);
            Assert.IsNull(dieDefinition);
        }

        [Test]
        public void DieConverter_Convert_ExpectedValue()
        {
            //DieFaceConverter is already tested throuroughly so just ensure a standard 6 sided die works
            var sides = new List<string>()  { "1MD", "2RD", "3F1", "+1Dc", "Sp", "-" };       
            var dieDefinition = _converter.Convert(sides);

            var face = dieDefinition[0];
            Assert.AreEqual(null, face.Modifer);
            Assert.AreEqual(1, face.Value);
            Assert.AreEqual(Symbol.MeleeDamage, face.Symbol);
            Assert.AreEqual(0, face.ResourceCost);

            face = dieDefinition[1];
            Assert.AreEqual(null, face.Modifer);
            Assert.AreEqual(2, face.Value);
            Assert.AreEqual(Symbol.RangedDamage, face.Symbol);
            Assert.AreEqual(0, face.ResourceCost);

            face = dieDefinition[2];
            Assert.AreEqual(null, face.Modifer);
            Assert.AreEqual(3, face.Value);
            Assert.AreEqual(Symbol.Focus, face.Symbol);
            Assert.AreEqual(1, face.ResourceCost);

            face = dieDefinition[3];
            Assert.AreEqual(Modifier.Plus, face.Modifer);
            Assert.AreEqual(1, face.Value);
            Assert.AreEqual(Symbol.Discard, face.Symbol);
            Assert.AreEqual(0, face.ResourceCost);

            face = dieDefinition[4];
            Assert.AreEqual(null, face.Modifer);
            Assert.AreEqual(0, face.Value);
            Assert.AreEqual(Symbol.Special, face.Symbol);
            Assert.AreEqual(0, face.ResourceCost);

            face = dieDefinition[5];
            Assert.AreEqual(null, face.Modifer);
            Assert.AreEqual(0, face.Value);
            Assert.AreEqual(Symbol.Blank, face.Symbol);
            Assert.AreEqual(0, face.ResourceCost);


        }
     
              
    }
}
