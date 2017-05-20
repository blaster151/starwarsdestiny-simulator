using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Converters;
using SwdSim.Domain;
using System;

namespace SwdSim.Data.Tests.SwDestinyDb.ConverterTests
{
    [TestFixture]
    public class DieFaceConverterTests
    {
        private readonly DieFaceConverter _converter = new DieFaceConverter();

        [TestCase("1RD", null, 1, Symbol.RangedDamage, 0)]
        [TestCase("3RD1", null, 3, Symbol.RangedDamage, 1)]
        [TestCase("2MD", null, 2, Symbol.MeleeDamage, 0)]
        [TestCase("20MD", null, 20, Symbol.MeleeDamage, 0)]
        [TestCase("+1F", Modifier.Plus, 1, Symbol.Focus, 0)]
        [TestCase("+1Dr1", Modifier.Plus, 1, Symbol.Disrupt, 1)]
        [TestCase("+10Dc12", Modifier.Plus, 10, Symbol.Discard, 12)]
        [TestCase("-", null, 0, Symbol.Blank, 0)]
        [TestCase("Sp", null, 0, Symbol.Special, 0)]
        public void DieFaceConverter_Convert_ExpectedValue(string face_string, Modifier? expectedModifier, int expectedValue, Symbol expectedSymbol, int expectedResourceCost)
        {
            var face = _converter.Convert(face_string);
            Assert.AreEqual(expectedModifier, face.Modifer);
            Assert.AreEqual(expectedValue, face.Value);
            Assert.AreEqual(expectedSymbol, face.Symbol);
            Assert.AreEqual(expectedResourceCost, face.ResourceCost);
        }
     
        [Test]
        public void DieFaceConverter_Convert_Unknown_ThrowsNotSupportedException()
        {
            Assert.Throws<NotSupportedException>(() =>
            {
                _converter.Convert("ajdfajp");
            });
        }
        
    }
}
