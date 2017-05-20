using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Converters;
using SwdSim.Domain;
using System;

namespace SwdSim.Data.Tests.SwDestinyDb.ConverterTests
{
    [TestFixture]
    public class AffiliationConverterTests
    {
        private readonly AffiliationConverter _converter = new AffiliationConverter();

        [TestCase("hero", Affiliation.Hero)]
        [TestCase("villain", Affiliation.Villian)]
        [TestCase("neutral", Affiliation.Neutral)]
        public void AffiliationConverter_Convert_ExpectedValue(string affiliation_code, Affiliation expected)
        {
            Assert.AreEqual(expected, _converter.Convert(affiliation_code));
        }
     
        [Test]
        public void AffiliationConverter_Convert_Unknown_ThrowsNotImplException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                _converter.Convert("afjpoaupj");
            });
        }
        
    }
}
