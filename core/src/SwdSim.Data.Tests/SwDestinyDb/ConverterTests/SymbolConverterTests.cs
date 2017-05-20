using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Converters;
using SwdSim.Domain;
using System;

namespace SwdSim.Data.Tests.SwDestinyDb.ConverterTests
{
    [TestFixture]
    public class SymbolConverterTests
    {
        private readonly SymbolConverter _converter = new SymbolConverter();

        [TestCase("-", Symbol.Blank)]
        [TestCase("Sp", Symbol.Special)]
        [TestCase("Sh", Symbol.Shield)]
        [TestCase("MD", Symbol.MeleeDamage)]
        [TestCase("RD", Symbol.RangedDamage)]
        [TestCase("Dc", Symbol.Discard)]
        [TestCase("Dr", Symbol.Disrupt)]
        [TestCase("F", Symbol.Focus)]
        public void SymbolConverter_Convert_ExpectedValue(string symbol, Symbol expected)
        {
            Assert.AreEqual(expected, _converter.Convert(symbol));
        }
        
        [Test]
        public void SymbolConverter_Convert_Unknown_ThrowsNotImplException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                _converter.Convert("afjpoaupj");
            });
        }
        
    }
}
