using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdSim.Data.Tests.SwDestinyDb.ConverterTests
{
    [TestFixture]
    public class PointsConverterTests
    {
        private readonly PointsConverter _pointsConverter = new PointsConverter();
        private readonly ElitePointsConverter _elitePointsConverter = new ElitePointsConverter();

        [Test]
        public void ElitePointsConverter_NonElite__NoElitePoints()
        {
            var elitePoints = _elitePointsConverter.Convert("12");
            Assert.IsNull(elitePoints);
        }
        [Test]
        public void PointsConverter_Convert_NonElite_HasBasePoints()
        {
            var points = _pointsConverter.Convert("12");
            Assert.AreEqual(12, points);
        }

        [Test]
        public void PointsConverter_Elite_HasBasePoints()
        {
            var points = _pointsConverter.Convert("12/15");
            Assert.AreEqual(12, points);
        }

        [Test]
        public void ElitePointsConverter_Elite__HasElitePoints()
        {
            var points = _elitePointsConverter.Convert("12/15");
            Assert.AreEqual(15, points);
        }
    }
}
