using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Converters;
using SwdSim.Domain;
using System;

namespace SwdSim.Data.Tests.SwDestinyDb.ConverterTests
{
    [TestFixture]
    public class SubTypeConverterTests
    {
        private readonly SubTypeConverter _converter = new SubTypeConverter();


        [TestCase("vehicle", SubType.Vehicle)]
        [TestCase("ability", SubType.Ability)]
        [TestCase("weapon", SubType.Weapon)]
        [TestCase("equipment", SubType.Equipment)]
        [TestCase("droid", SubType.Droid)]
        public void SubTypeConverter_Convert_ExpectedValue(string subtype_code, SubType expected)
        {
            Assert.AreEqual(expected, _converter.Convert(subtype_code));
        }
     
        [Test]
        public void SubTypeConverter_Convert_Unknown_ThrowsNotImplException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                _converter.Convert("afjpoaupj");
            });
        }
        
    }
}
