using NUnit.Framework;
using Moq;
using SFB.Web.ApplicationCore.Services;

namespace SFB.Web.UnitTests.Services.Validation
{
    public class ValidationServiceTests
    {
        [Test]
        public void ValidateNameParameterTestValid()
        {
            var service = new ValidationService();
            var result = service.ValidateNameParameter("test");

            Assert.IsNull(result);
        }

        [Test]
        public void ValidateNameParameterTestNotValid()
        {
            var service = new ValidationService();
            var result = service.ValidateNameParameter("t");

            Assert.NotNull(result);
        }

        [Test]
        public void ValidateLocationParameterTestValid()
        {
            var service = new ValidationService();
            var result = service.ValidateLocationParameter("test");

            Assert.IsNull(result);
        }

        [Test]
        public void ValidateLocationParameterTestNotValid()
        {
            var service = new ValidationService();
            var result = service.ValidateLocationParameter("t");

            Assert.NotNull(result);
        }

        [Test]
        public void ValidateLaCodeParameterTestValid()
        {
            var service = new ValidationService();
            var result = service.ValidateLaCodeParameter("306");

            Assert.IsNull(result);
        }

        [Test]
        public void ValidateLaCodeParameterTestNotValid()
        {
            var service = new ValidationService();
            var result = service.ValidateLaCodeParameter("3");

            Assert.NotNull(result);
        }

        [Test]
        public void ValidateLaNameParameterTestValid()
        {
            var service = new ValidationService();
            var result = service.ValidateLaNameParameter("Croydon");

            Assert.IsNull(result);
        }

        [Test]
        public void ValidateLaNameParameterTestNotValid()
        {
            var service = new ValidationService();
            var result = service.ValidateLaNameParameter("C");

            Assert.NotNull(result);
        }

        [Test]
        public void ValidateLaCodeNameParameterTestValidCode()
        {
            var service = new ValidationService();
            var result = service.ValidateLaCodeNameParameter("306");

            Assert.IsNull(result);
        }

        [Test]
        public void ValidateCodeLaNameParameterTestNotValidCode()
        {
            var service = new ValidationService();
            var result = service.ValidateLaCodeNameParameter("3");

            Assert.NotNull(result);
        }

        [Test]
        public void ValidateLaCodeNameParameterTestValidName()
        {
            var service = new ValidationService();
            var result = service.ValidateLaCodeNameParameter("Croydon");

            Assert.IsNull(result);
        }

        [Test]
        public void ValidateCodeLaNameParameterTestNotValidName()
        {
            var service = new ValidationService();
            var result = service.ValidateLaCodeNameParameter("C");

            Assert.NotNull(result);
        }

        [Test]
        public void ValidateCompanyNoParameterTestValid()
        {
            var service = new ValidationService();
            var result = service.ValidateCompanyNoParameter("1234567");

            Assert.Null(result);
        }


        [Test]
        public void ValidateCompanyNoParameterTestNotValid()
        {
            var service = new ValidationService();
            var result = service.ValidateCompanyNoParameter("123456");

            Assert.NotNull(result);
        }

    }
}
