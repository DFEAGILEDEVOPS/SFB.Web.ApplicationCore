using NUnit.Framework;
using SFB.Web.ApplicationCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Web.UnitTests
{
    public class GeoCodeCalcTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalcDistanceShouldReturnCorrectValue()
        {
            var dist = GeoCodeCalc.CalcDistance("36", "26", "42", "45");
            Assert.AreEqual(1768933.4399999999d, dist);
        }

    }
}
