using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Converters;
using SwdSim.Domain;
using System;

namespace SwdSim.Data.Tests.SwDestinyDb.ConverterTests
{
    [TestFixture]
    public class FactionConverterTests
    {
        private readonly FactionConverter _converter = new FactionConverter();

        [TestCase("gray", Faction.Neutral)]
        [TestCase("red", Faction.Command)]
        [TestCase("blue", Faction.Force)]
        [TestCase("yellow", Faction.Rogue)]
        public void FactionConverter_Convert_ExpectedValue(string faction_code, Faction expected)
        {
            Assert.AreEqual(expected, _converter.Convert(faction_code));
        }
          
        [Test]
        public void FactionConverter_Convert_Unknown_ThrowsNotImplException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                _converter.Convert("afjpoaupj");
            });
        }
        
    }
}
