using NUnit.Framework;
using SFB.Web.ApplicationCore.Helpers;

namespace SFB.Web.UnitTests
{
    public class SchoolFormatHelpersTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FinancialTermFormatAcademiesShouldReturnAcademiesFormat()
        {
            var term = SchoolFormatHelpers.FinancialTermFormatAcademies(2020);
            Assert.AreEqual("2019 / 2020", term);
        }

        [Test]
        public void FinancialTermFormatAcademiesShouldReturnMaintainedFormat()
        {
            var term = SchoolFormatHelpers.FinancialTermFormatMaintained(2020);
            Assert.AreEqual("2019 - 2020", term);
        }
    }
}