using NUnit.Framework;
using SFB.Web.ApplicationCore.Helpers;


namespace SFB.Web.UnitTests.Helpers
{
    public class UtilitiesTests
    {
        [Test]
        public void ReplaceShouldReplaceStringCaseInsensitive()
        {
            var input = "TestAString";
            var result = input.Replace("a", "1", true);
            Assert.AreEqual("Test1String", result);
        }

        [Test]
        public void ReplaceShouldNotReplaceStringCaseInsensitive()
        {
            var input = "TestAString";
            var result = input.Replace("a", "1", false);
            Assert.AreEqual("TestAString", result);
        }
    }
}
