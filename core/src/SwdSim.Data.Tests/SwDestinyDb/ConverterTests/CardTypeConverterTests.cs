using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Converters;
using SwdSim.Domain;
using System;

namespace SwdSim.Data.Tests.SwDestinyDb.ConverterTests
{
    [TestFixture]
    public class CardTypeConverterTests
    {
        private readonly CardTypeConverter _converter = new CardTypeConverter();

        [TestCase("character", CardType.Character)]
        [TestCase("event", CardType.Event)]
        [TestCase("upgrade", CardType.Upgrade)]
        [TestCase("support", CardType.Support)]
        [TestCase("battlefield", CardType.Battlefield)]
        public void CardTypeConverter_Convert_ExpectedValue(string type_code, CardType expected)
        {
            Assert.AreEqual(expected, _converter.Convert(type_code));
        }
      
        [Test]
        public void CardTypeConverter_Convert_Unknown_ThrowsNotImplException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                _converter.Convert("afjpoaupj");
            });
        }
        
    }
}
