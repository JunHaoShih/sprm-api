using SprmApi.Common.Validations;
using System.ComponentModel.DataAnnotations;

namespace SprmUnitTest.Common.Validations
{
    internal class PasswordValidationAttributeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] s_validateSuccessCase =
        {
            new object[]
            {
                "validPassword"
            },
            new object[]
            {
                "!@#@$@#RWFDSFDFDSFSDFS"
            },
            new object[]
            {
                "AETRHGFDHFHGFHFHFGFDHG"
            },
            new object[]
            {
                "validLooooooooooooooooooooooooooooooooooooooooooooooooooooooooooog"
            },
        };

        [TestCaseSource(nameof(s_validateSuccessCase))]
        public void ValidateSuccess(string password)
        {
            ValidationContext context = new(password);
            PasswordValidationAttribute attribute = new();
            attribute.Validate(password, context);
            Assert.Pass(password);
        }

        private static readonly object[] s_validateFailedCase =
        {
            new object[]
            {
                "short"
            },
        };

        [TestCaseSource(nameof(s_validateFailedCase))]
        public void ValidateFailed(string badData)
        {
            ValidationContext context = new(badData);
            PasswordValidationAttribute attribute = new();
            ValidationException? ex = Assert.Throws<ValidationException>(() => attribute.Validate(badData, context));
            Assert.That(ex, Is.Not.Null);
            Assert.Pass(ex.Message);
        }
    }
}
